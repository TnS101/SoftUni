function solve() {
    let expressionField = document.getElementById('expressionOutput');
    let result = document.getElementById('resultOutput');
    let keys = document.getElementsByClassName('keys')[0].children;

    let operator = '';

    Array.from(keys).forEach(b => {
        document.addEventListener('click', function exe() {
            if (b.value != '+' && b.value != '-' &&
                b.value != '/' && b.value != '*' && b.value != '=') {
                expressionField.textContent += b.value;
            } else if (b.value == '=') {
                if (expressionField.textContent.charAt(expressionField.textContent.indexOf(operator) + 1) != null) {
                    let [left, right] = expressionField.textContent.split(operator);

                    if (operator == '+') result.textContent = Number(left) + Number(right);
                    if (operator == '-') result.textContent = Number(left) - Number(right);
                    if (operator == '/') result.textContent = Number(left) / Number(right);
                    if (operator == '*') result.textContent = Number(left) * Number(right);
                }
            } else {
                operator = b.value;
                expressionField.textContent += operator;
            }
        })
    });
}