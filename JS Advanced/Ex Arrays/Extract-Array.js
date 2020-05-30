function solution(array) {
    let output = [array[0]];
    let biggest = array[0];

    for (let index = 0; index < array.length; index++) {
        let element = array[index];

        if (index > 0) {
            if (element >= biggest) {
                output.push(element);
                biggest = element;
            }
        }
    }

    for (let index = 0; index < output.length; index++) {
        console.log(output[index]);
    }
}