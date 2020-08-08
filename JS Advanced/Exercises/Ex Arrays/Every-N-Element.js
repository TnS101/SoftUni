function solution(array) {
    let step = Number(array.pop());

    for (let index = 0; index < array.length; index += step) {

        console.log(array[index]);
    }
}

solution(['1', '2', '3', '4', '5', '6']);