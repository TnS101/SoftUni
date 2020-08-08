function solution(input) {
    let map = new Map();

    map.set('protein', 0);
    map.set('carbohydrate', 0);
    map.set('fat', 0);
    map.set('flavour', 0);

    let [restockType, restockAmount] = [];
    let [prepareType, prepareAmount] = [];

    let dish = { protein: 0, carbohydrate: 0, fat: 0, flavour: 0 };

    switch (prepareType) {
        case 'apple':
            dish.carbohydrate = 1;
            dish.flavour = 2;
            break;
        case 'lemonade':
            dish.carbohydrate = 10;
            dish.flavour = 20;
            break;
        case 'burger':
            dish.carbohydrate = 5;
            dish.fat = 7;
            dish.flavour = 3;
            break;
        case 'eggs':
            dish.protein = 5;
            dish.fat = 1;
            dish.flavour = 3;
            break;
        case 'turkey':
            dish.protein = 10;
            dish.carbohydrate = 10;
            dish.fat = 10;
            dish.flavour = 10
            break;
    }

    let command = input.split(' ');

    if (command[0] == 'restock') {
        restockType = command[1];
        restockAmount = command[2];

        let value = map.get(restockType) + Number(restockAmount);
        map.delete(restockType);
        map.set(restockType, value);

        return 'Success';
    } else if (command[0] == 'prepare') {
        for (const [key, value] of Object.entries(dish)) {
            let mapValue = map.get(key);
            console.log(map);

            if (mapValue <= value * prepareAmount) {
                map.delete(key);
                map.set(key, mapValue - value);

                return 'Success';
            }

            return `Error: not enough ${key} in stock`;
        }
    } else {
        return `protein=${map.get('protein')} carbohydrate= ${map.get('carbohydrate')} fat=${map.get('fat')} flavour = ${map.get('flavour')}`;
    }
}

console.log(solution("restock carbohydrate 10"));
console.log(solution("restock flavour 10"));
console.log(solution("prepare apple 1"));
console.log(solution("restock fat 10"));
console.log(solution("prepare burger 1"));
console.log(solution("report"));