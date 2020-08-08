function sameNumbers(array) {
    let sum = 0;
    let sumCheck = 1;

    for (i = 0; i < array.toString().length; i++) {
        sum += parseInt(array.toString()[i]);
    }

    for (j = 1; j < array.toString().length; j++) {
        if (array.toString()[0] == array.toString()[j]) {
            sumCheck++;
        }
    }

    if (sumCheck == array.toString().length) {
        console.log("true");
    } else {
        console.log("false");
    }
    console.log(sum);
}