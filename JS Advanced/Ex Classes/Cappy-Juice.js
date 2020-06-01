function solution(array) {
    let map = new Map();

    for (let index = 0; index < array.length; index++) {
        let element = array[index].split(' => ');

        if (!map.has(element[0])) {
            if (element[1] > 1000) {

            }
            map.set(element[0], element[1]);
        } else {
            let value = Number(map.get(element[0]));
            value += Number(element[1]);
            map.delete(element[0]);
            map.set(element[0], value);
        }
    }

    console.log(map);

    for (let [key, value] of map) {
        value = Math.floor(value / 1000);
        if (value > 0) {
            map.set(key, value);
        } else {
            map.delete(key);
        }
    }
    console.log(map);
}
solution(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'
]);