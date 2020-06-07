function notify(message) {
    let button = document.getElementsByTagName('button')[0];
    let notificaiton = document.getElementById('notification');

    notificaiton.textContent = message;


    button.onclick = function exe() {
        notificaiton.style.display = 'block';

        let interval = setInterval(function hide() {
            notificaiton.style.display = 'none';
        }, 2000);
    };

    clearInterval(interval);
}