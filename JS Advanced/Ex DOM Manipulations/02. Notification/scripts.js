function notify(message) {
    let notificaiton = document.getElementById('notification');

    notificaiton.textContent = message;
    notificaiton.style.display = 'block';

    setTimeout(function hide() {
        notificaiton.style.display = 'none';
    }, 2000);
}