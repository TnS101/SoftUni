function solve() {
    const departButton = document.getElementById('depart');
    const arriveButton = document.getElementById('arrive');

    function depart() {
        departButton.setAttribute('disabled', 'true');
        arriveButton.setAttribute('disabled', 'false');
        append('depart');
    }

    function arrive() {
        arriveButton.setAttribute('disabled', 'true');
        departButton.setAttribute('disabled', 'false');
        append('arrive');
    }

    function append(action) {
        const info = document.getElementById('info').children[0];
        if (action == 'depart') {
            info.textContent = 'Next stop';

        } else {
            info.textContent = 'Arriving at';
        }

        fetch(`https://judgetests.firebaseio.com/schedule/1287.json`)
            .then(respone => respone.json())
            .then(data => info.textContent += data.stopName);
    }

    return {
        depart,
        arrive
    };
}

let result = solve();