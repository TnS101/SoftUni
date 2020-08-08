function solution(array) {
    let output = [];

    for (let index = 0; index < array.length; index++) {

        if (array[index] == 'add') {
            output.push(index + 1);
        } else {
            output.pop();
        }
    }

    if (output.length > 0) {
        for (let index = 0; index < output.length; index++) {
            console.log(output[index]);
        }
    } else {
        console.log('Empty');
    }
}