function solution(array) {
    let result = {};

    for (let index = 0; index < array.length; index++) {
        const [make, model, count] = array[index].split(' | ');

        if (result.hasOwnProperty(make) === false) {
            result[make] = {};
        }

        if (result[make].hasOwnProperty(model) === false) {
            result[make][model] = [];
        }

        result[make][model].push(count);
    }

    Object.entries(result).forEach(([make, model]) => {
        console.log(make);
        Object.entries(model).forEach(count => {
            let output = `###${count.join(' -> ')}`;
            if (String(count[1]).split(',').length > 1) {
                output = `###${count[0]} -> ${Number(count[1][0]) + Number(count[1][1])}`;
            }
            console.log(output);
        })
    });;
}

solution(['Mercedes-Benz | 50PS | 123',
    'Mini | Clubman | 20000',
    'Mini | Convertible | 1000',
    'Mercedes - Benz | 60 PS | 3000',
    'Hyunday | Elantra GT | 20000',
    'Mini | Countryman | 100',
    'Mercedes - Benz | W210 | 100',
    'Mini | Clubman | 1000',
    'Mercedes - Benz | W163 | 200'
]);