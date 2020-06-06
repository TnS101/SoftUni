function solution(array) {
    let result = '<table>';
    for (let index = 0; index < array.length; index++) {
        let element = JSON.parse(array[index]);
        result += `\n\t<tr>\n\t\t<td>${element.name}</td>\n\t\t<td>${element.position}</td>\n\t\t<td>${element.salary}</td>\n\t</tr>`;
    }

    result += '\n</table>';

    console.log(result);
}

solution(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}'
]);