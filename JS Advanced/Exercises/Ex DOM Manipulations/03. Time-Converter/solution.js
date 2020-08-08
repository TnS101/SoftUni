function attachEventsListeners() {
    let array = document.getElementsByTagName('main')[0].children;

    find('daysBtn').addEventListener('click', function exe() {
        find('days').value = Number(find(hours).value) / 24;

    });

    find('hoursBtn').addEventListener('click', function exe() {
        find('hours').value = Number(find(days).value) * 24;
    })
}

function find(id) {
    return document.getElementById(id);
}