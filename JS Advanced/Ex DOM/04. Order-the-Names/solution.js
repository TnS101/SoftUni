function solve() {
    document.getElementsByTagName('button')[0].onclick = function exe() {
        let name = document.getElementsByTagName('input')[0];

        let firstLetterCode = (name.value).toUpperCase().charCodeAt(0);

        let a = document.getElementsByTagName('li')[firstLetterCode - 65];

        let nameToInsert = (name.value[0]).toUpperCase() + (name.value).slice(1).toLowerCase();

        (a.textContent === '') ? a.textContent = nameToInsert: a.textContent = a.textContent + ', ' + nameToInsert;

        name.value = '';
    }
}