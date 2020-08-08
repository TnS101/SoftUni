function solution() {
    const root = document.getElementById('root');
    root.children[0].textContent = '';
    document.getElementById('btnLoadTowns').addEventListener('click', function (e) {
        e.preventDefault();
        document.getElementById('towns').value.split(', ').forEach(el => {
            const li = document.createElement('li');
            li.textContent = el;
            root.children[0].appendChild(li);
        });
    });
}

solution();