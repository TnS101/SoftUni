function rotate(array) {
    for (let index = array.length - 1; index >= 0; index--) {
        console.log(array[index]);
    }
}

function braindead(array) {
    let step = array.pop();

    for (let index = 0; index < step; index++) {
        array.unshift(array.pop());
    }

    console.log(array.join(' '));
}

braindead(['1', '2', '3', '4', '2']);