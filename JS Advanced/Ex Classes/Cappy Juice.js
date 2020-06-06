function solution(array) {
    let result = {};
    let queuedItem = {};

    for (let index = 0; index < array.length; index++) {
        const [type, ml] = array[index].split(' => ');

        if (queuedItem.type == type) queuedItem.ml += Number(ml);

        if (queuedItem.ml >= 1000) {
            result[queuedItem.type] = [];
            result[type].push(queuedItem.ml);
            queuedItem = {};
            continue;
        }

        if (ml >= 1000) {
            if (result.hasOwnProperty(type) === false) {
                result[type] = [];
            }
        } else queuedItem = { type: type, ml: Number(ml) };

        if (result.hasOwnProperty(type) === true) {
            result[type].push(ml);
        }
    }

    Object.entries(result).forEach(([type, ml]) => {
        let amount = Number(ml[0]);

        if (ml.length > 1) amount += Number(ml[1]);

        if (amount >= 1000) {
            console.log(`${type} => ${Math.floor(amount / 1000)}`);
        }
    });
}

solution(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'
]);

solution(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549'
]);