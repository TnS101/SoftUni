function caloires(array) {
    let result = "{";
    for (i = 0; i < array.length; i++) {
        if (i % 2 == 0) {
            result += " " + array[i] + ":";
        } else if (i % 2 != 0) {
            if (i == array.length - 1) {
                result += " " + array[i] + " }";
            } else {
                result += " " + array[i] + ",";
            }
        }
    }
    console.log(result);
}