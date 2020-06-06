function solution(array) {
    array.sort();
    let firstLetter = array[0][0];
    let result = `${firstLetter}`;

    for (let index = 0; index < array.length; index++) {
        let element = array[index];

        if (firstLetter != element[0]) {
            firstLetter = element[0];
            result += `\n${firstLetter}`;
        }
        result += `\n  ${element.split(' : ').join(': ')}`;
    }
    console.log(result);
}

solution(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
]);