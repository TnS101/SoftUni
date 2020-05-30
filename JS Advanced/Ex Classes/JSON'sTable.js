function solution(input) {
    let data = [];

    for (let index = 0; index < input.length; index++) {
        let element = input[index];
        data.push(JSON.parse(element));
    }

    let result = '<table></table>';

    for (let index = 0; index < data.length; index++) {
        let element = data[index];
        let collection = element.name;

        for (let i = 0; i < collection.length; i++) {
            let property;

            if (i % 2 != 0) {
                property = collection[i];
            }

            result += `<tr>${property}</tr>`;
        }
    }

    console.log(result);
}

solution(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}'
]);