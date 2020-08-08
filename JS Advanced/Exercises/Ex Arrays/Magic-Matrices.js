function solution(array) {
    let rowSum = 0;
    let colSum = 0;

    for (let i = 0; i < array.length; i++) {
        let element = array[i];
        for (let j = 0; j < array.length; j++) {
            let rows = element[j];
            let cols = array[i, j][0];

            rowSum += rows;
            colSum += cols;
        }
    }

    if (rowSum == colSum) {
        return true;
    }

    return false;
}

solution([
    [1, 2, 3],
    [1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1]
]);