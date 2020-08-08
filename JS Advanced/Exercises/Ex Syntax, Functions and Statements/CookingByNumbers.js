function cooking(array) {
    let number = parseFloat(array[0]);
    for (i = 1; i < array.length; i++) {
        switch (array[i]) {
            case "chop":
                number /= 2;
                break;
            case "dice":
                number = Math.sqrt(number);
                break;
            case "spice":
                number += 1;
                break;
            case "bake":
                number *= 3;
                break;
            case "fillet":
                number -= 0.2 * number;
                break;
        }
        console.log(number);
    }
}