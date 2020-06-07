function solve() {
    let expressionField = document.getElementById('expressionOutput');

    let keys = document.getElementsByClassName('keys');

    Array.of(keys).forEach(b => {
        b.onclick() = function exe() {
            expressionField.textContent += 'b.value';
        }
    });
}