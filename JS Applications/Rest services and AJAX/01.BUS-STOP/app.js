function getInfo() {
    const validIds = ['1287', '1308', '1327', '2334'];
    const inputId = document.getElementById('stopId');
    const stopName = document.getElementById('stopName');
    const url = `http://localhost:3000/businfo/${stopId}`;
    
    document.getElementById('submit').addEventListener('click',function exe(e)
    {
        e.preventDefault();
        if (validIds.includes(inputId) === false)
        {
            stopName.textContent = 'Error';
            return;
        }

        fetch(url)
        .then(result => result.json())
        .then(data => append(data));
    });

    function append(data)
    {
        stopName.textContent = data.name;
        data.buses.forEach(el =>
            {
                const li = document.createElement('li');
                li.textContent = `Bus ${el.busId} arrives in ${el.time} minutes`;

                document.getElementById('busses').appendChild(li);
            });
    }
}