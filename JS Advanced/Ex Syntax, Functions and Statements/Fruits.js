function output(fruit, grams, price) {
    let result = "";
    let kilograms = grams / 1000;
    let moneyNeeded = kilograms * price;
    result += "I need $" + moneyNeeded.toFixed(2) + " to buy " + kilograms.toFixed(2) + " kilograms " + fruit + ".";
    console.log(result);
}