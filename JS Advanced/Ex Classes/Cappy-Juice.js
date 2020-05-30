function solution(array) {

    for (let index = 0; index < array.length; index++) {
        let element = array[index].split(' => ');
        let fruit = element[0];
        let quantity = element[1];

        quantity += element[fruit][1];

        if (quantity > 1000) {
            let bottles = Number(quantity / 1000);

            console.log(`${fruit} => ${bottles}`);
        }
    }
}

solution(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549'
]);