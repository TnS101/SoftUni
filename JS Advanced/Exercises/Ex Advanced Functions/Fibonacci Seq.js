function getFibonator() {
    let previous = 0;
    let current = 1;

    function fibonator() {
        let newNumber = previous + current;
        previous = current;
        current = newNumber

        return previous;
    }

    return fibonator;
};

let fib = getFibonator();
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());