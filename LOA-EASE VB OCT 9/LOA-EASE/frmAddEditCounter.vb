Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmAddEditCounter
    Private ReadOnly _isEditMode As Boolean
    Private ReadOnly _counterId As Integer
    Private ReadOnly _initialCounterName As String
    Private ReadOnly _initialCashierName As String
    Private _initialCashierId As Integer = 0

    Private Class CashierItem
        Public Property CashierId As Integer
        Public Property FullName As String
        Public Overrides Function ToString() As String
            Return FullName
        End Function
    End Class

    Public Sub New()
        InitializeComponent()
        _isEditMode = False
        Me.Text = "Add New Counter"
        lblTitle.Text = "Add New Counter"
    End Sub

    Public Sub New(counterId As Integer, counterName As String, assignedCashierName As String)
        InitializeComponent()
        _isEditMode = True
        _counterId = counterId
        _initialCounterName = counterName
        _initialCashierName = assignedCashierName
        Me.Text = "Edit Counter"
        lblTitle.Text = "Edit Counter"
    End Sub

    Private Sub frmAddEditCounter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCashiers()
        If _isEditMode Then
            txtCounterName.Text = _initialCounterName
            If Not String.IsNullOrEmpty(_initialCashierName) AndAlso _initialCashierName <> "N/A" Then
                For Each item As CashierItem In cboCashier.Items
                    If item.FullName = _initialCashierName Then
                        cboCashier.SelectedItem = item
                        _initialCashierId = item.CashierId ' Store the initial cashier ID
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub LoadCashiers()
        cboCashier.Items.Clear()
        cboCashier.Items.Add(New CashierItem With {.CashierId = 0, .FullName = "(No Cashier Assigned)"})
        cboCashier.SelectedIndex = 0

        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                ' Corrected query to get cashiers from the 'cashiers' table
                Dim query As String = "
                    SELECT cashier_id, full_name
                    FROM cashiers
                    WHERE role = 'cashier'"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cboCashier.Items.Add(New CashierItem With {
                                .CashierId = Convert.ToInt32(reader("cashier_id")),
                                .FullName = reader("full_name").ToString()
                            })
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error loading cashiers: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtCounterName.Text) Then
            MessageBox.Show("Counter name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedCashier As CashierItem = CType(cboCashier.SelectedItem, CashierItem)
        Dim selectedCashierId As Integer = selectedCashier.CashierId

        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()
            Try
                If _isEditMode Then
                    ' --- UPDATE LOGIC ---
                    ' 1. Update counter name
                    Dim updateCounterQuery As String = "UPDATE counters SET counter_name = @counterName WHERE counter_id = @counterId"
                    Using cmd As New MySqlCommand(updateCounterQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@counterName", txtCounterName.Text.Trim())
                        cmd.Parameters.AddWithValue("@counterId", _counterId)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' 2. Unassign the original cashier if they are being changed
                    If _initialCashierId > 0 AndAlso _initialCashierId <> selectedCashierId Then
                        Dim unassignQuery As String = "UPDATE cashiers SET counter_id = NULL WHERE cashier_id = @cashierId"
                        Using cmd As New MySqlCommand(unassignQuery, conn, transaction)
                            cmd.Parameters.AddWithValue("@cashierId", _initialCashierId)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If

                    ' 3. Assign the new cashier
                    If selectedCashierId > 0 Then
                        Dim assignQuery As String = "UPDATE cashiers SET counter_id = @counterId WHERE cashier_id = @cashierId"
                        Using cmd As New MySqlCommand(assignQuery, conn, transaction)
                            cmd.Parameters.AddWithValue("@counterId", _counterId)
                            cmd.Parameters.AddWithValue("@cashierId", selectedCashierId)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                Else
                    ' --- ADD LOGIC ---
                    ' 1. Insert new counter and get its ID
                    Dim insertCounterQuery As String = "INSERT INTO counters (counter_name) VALUES (@counterName); SELECT LAST_INSERT_ID();"
                    Dim newCounterId As Integer
                    Using cmd As New MySqlCommand(insertCounterQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@counterName", txtCounterName.Text.Trim())
                        newCounterId = Convert.ToInt32(cmd.ExecuteScalar())
                    End Using

                    ' 2. Assign cashier if selected
                    If selectedCashierId > 0 Then
                        Dim assignQuery As String = "UPDATE cashiers SET counter_id = @counterId WHERE cashier_id = @cashierId"
                        Using cmd As New MySqlCommand(assignQuery, conn, transaction)
                            cmd.Parameters.AddWithValue("@counterId", newCounterId)
                            cmd.Parameters.AddWithValue("@cashierId", selectedCashierId)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                End If

                transaction.Commit()
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show($"Error saving counter: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class