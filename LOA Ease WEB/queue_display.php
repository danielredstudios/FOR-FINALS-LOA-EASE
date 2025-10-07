<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Live Queue Display - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;700;800&display=swap" rel="stylesheet">
    <style>
        body { font-family: 'Poppins', sans-serif; background-color: #003366; color: white; overflow: hidden; }
        .main-container { display: grid; grid-template-columns: 2fr 1fr; height: 100vh; gap: 1.5rem; padding: 1.5rem; }
        .serving-section, .waiting-section { background-color: #002a52; border-radius: 1.5rem; padding: 2rem; display: flex; flex-direction: column; }
        .serving-grid { display: grid; grid-template-columns: repeat(2, 1fr); grid-template-rows: repeat(2, 1fr); gap: 1.5rem; flex-grow: 1; }
        .counter-card { background-color: #FFFFFF; color: #003366; border-radius: 1rem; text-align: center; padding: 1rem; border: 5px solid #0055a4; transition: all 0.3s ease; display: flex; flex-direction: column; justify-content: center; }
        .counter-card.greyout { background-color: #e9ecef; filter: grayscale(80%); opacity: 0.6; }
        .counter-card.highlight { transform: scale(1.05); box-shadow: 0 0 40px rgba(255, 199, 44, 0.7); border-color: #FFC72C; }
        .counter-card .counter-name { font-size: clamp(1.5rem, 2.5vw, 2.5rem); font-weight: 700; }
        .counter-card .serving-number { font-size: clamp(4rem, 9vw, 9rem); font-weight: 800; line-height: 1.1; }
        .waiting-list { list-style: none; padding: 0; flex-grow: 1; overflow-y: auto; }
        .waiting-list-item { background-color: #004080; padding: 1rem; border-radius: 0.5rem; margin-bottom: 1rem; font-size: clamp(1.2rem, 2vw, 2.2rem); font-weight: 700; text-align: center; }
        h1 { font-size: clamp(2rem, 3.5vw, 3.5rem); font-weight: 800; }
        .branding-header { border-bottom: 2px solid #004080; padding-bottom: 1rem; margin-bottom: 1.5rem; }
        .branding-header .brand-title { font-size: clamp(1.8rem, 2.8vw, 2.8rem); font-weight: 800; color: #FFC72C; margin: 0; }
        .branding-header .brand-subtitle { font-size: clamp(1rem, 1.5vw, 1.5rem); opacity: 0.8; margin: 0; }
    </style>
</head>
<body>
    <div class="main-container">
        <div class="serving-section">
            <h1 class="text-center mb-4">NOW SERVING</h1>
            <div id="serving-grid" class="serving-grid"></div>
        </div>
        <div class="waiting-section">
            <div class="branding-header text-center">
                <p class="brand-title">LOA-EASE</p>
                <p class="brand-subtitle">Lyceum of Alabang Queuing System</p>
            </div>
            <h1 class="text-center mb-4" style="font-size: clamp(1.5rem, 2.5vw, 2.5rem);">IN QUEUE</h1>
            <ul id="waiting-list" class="waiting-list"></ul>
        </div>
    </div>
    <audio id="notification-sound" src="https://www.soundjay.com/buttons/sounds/button-16.mp3" preload="auto"></audio>
    <script>
        const servingGrid = document.getElementById('serving-grid');
        const waitingList = document.getElementById('waiting-list');
        const notificationSound = document.getElementById('notification-sound');
        let currentServingState = {};

        function updateDisplay() {
            fetch('api/get_live_status.php')
                .then(response => response.json())
                .then(data => {
                    if (!data.counters) return;

                    servingGrid.innerHTML = '';
                    let soundPlayed = false;

                    data.counters.forEach(counter => {
                        const servingNumber = counter.serving_number || '---';
                        const card = document.createElement('div');
                        card.className = 'counter-card';
                        
                        if (counter.is_open == '0' || counter.status === 'break') {
                            card.classList.add('greyout');
                        }

                        let statusText = servingNumber;
                        if (counter.is_open == '0') {
                            statusText = 'OFFLINE';
                        } else if (counter.status === 'break') {
                            statusText = 'BREAK';
                        }
                        
                        card.innerHTML = `
                            <div class="serving-number">${statusText}</div>
                            <div class="counter-name">${counter.counter_name}</div>
                        `;
                        servingGrid.appendChild(card);

                        if (currentServingState[counter.counter_id] && currentServingState[counter.counter_id] !== servingNumber && servingNumber !== '---' && !soundPlayed) {
                            notificationSound.play().catch(e => console.error("Audio play failed:", e));
                            soundPlayed = true;
                            card.classList.add('highlight');
                            setTimeout(() => card.classList.remove('highlight'), 2000);
                        }
                        currentServingState[counter.counter_id] = servingNumber;
                    });

                    waitingList.innerHTML = '';
                    if (data.waiting_list && data.waiting_list.length > 0) {
                        data.waiting_list.forEach(item => {
                            const li = document.createElement('li');
                            li.className = 'waiting-list-item';
                            li.textContent = item;
                            waitingList.appendChild(li);
                        });
                    } else {
                        const li = document.createElement('li');
                        li.className = 'waiting-list-item opacity-50';
                        li.textContent = 'No Students Waiting';
                        waitingList.appendChild(li);
                    }
                })
                .catch(error => console.error('Error fetching live status:', error));
        }

        document.addEventListener('DOMContentLoaded', () => {
            updateDisplay();
            setInterval(updateDisplay, 3000);
        });
    </script>
</body>
</html>