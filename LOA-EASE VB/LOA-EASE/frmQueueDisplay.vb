Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frmQueueDisplay

    Private Sub frmQueueDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateQueueDisplay()
        RefreshTimer.Start()
    End Sub

    Private Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick
        UpdateQueueDisplay()
    End Sub

    Public Sub UpdateQueueDisplay()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf UpdateQueueDisplay))
        Else
            flpNowServing.Controls.Clear()
            flpWaiting.Controls.Clear()

            PopulateNowServingPanel()
            PopulateWaitingPanel()
        End If
    End Sub

    Private Sub PopulateNowServingPanel()
        Dim query As String = "SELECT q.queue_number, c.counter_name " &
                              "FROM queues q " &
                              "JOIN counters c ON q.counter_id = c.counter_id " &
                              "WHERE q.status = 'serving' AND DATE(q.schedule_datetime) = CURDATE() " &
                              "ORDER BY c.counter_id ASC"

        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.HasRows Then
                            ShowEmptyMessage(flpNowServing, "No one is currently being served.")
                        Else
                            While reader.Read()
                                Dim queueNumber As String = reader("queue_number").ToString()
                                Dim counterName As String = reader("counter_name").ToString()

                                Dim counterControl As New ucCounter()
                                counterControl.QueueNumber = queueNumber
                                counterControl.CounterName = counterName
                                flpNowServing.Controls.Add(counterControl)
                            End While
                        End If
                    End Using
                End Using
            Catch ex As Exception
                RefreshTimer.Stop()
                MessageBox.Show("Failed to load 'Now Serving' data. Please check the database connection." & vbCrLf & "Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub PopulateWaitingPanel()
        Dim query As String = "SELECT queue_number FROM queues WHERE status = 'waiting' AND DATE(schedule_datetime) = CURDATE() ORDER BY is_priority DESC, created_at ASC"

        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Dim waitingList As New List(Of String)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            waitingList.Add(reader("queue_number").ToString())
                        End While
                    End Using

                    If waitingList.Count > 0 Then
                        For Each queueNumber As String In waitingList
                            Dim lblQueueItem As New Label()
                            lblQueueItem.Text = queueNumber
                            lblQueueItem.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
                            lblQueueItem.ForeColor = Color.White
                            lblQueueItem.BackColor = Color.FromArgb(255, 13, 110, 253)
                            lblQueueItem.TextAlign = ContentAlignment.MiddleCenter
                            lblQueueItem.Size = New Size(flpWaiting.ClientSize.Width - 40, 60)
                            lblQueueItem.Margin = New Padding(8)
                            flpWaiting.Controls.Add(lblQueueItem)
                        Next
                    Else
                        ShowEmptyMessage(flpWaiting, "No students are currently waiting.")
                    End If
                End Using
            Catch ex As Exception
                Console.WriteLine("Failed to load waiting list: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub ShowEmptyMessage(ByVal panel As FlowLayoutPanel, ByVal message As String)
        Dim lblEmpty As New Label()
        lblEmpty.Text = message
        lblEmpty.Font = New Font("Segoe UI", 14.0F, FontStyle.Regular)
        lblEmpty.ForeColor = Color.Gray
        lblEmpty.TextAlign = ContentAlignment.MiddleCenter
        lblEmpty.Size = New Size(panel.ClientSize.Width - 40, 100)
        panel.Controls.Add(lblEmpty)
    End Sub

End Class