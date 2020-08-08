class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return parseInt(this.value.toString(16).toUpperCase(), 16);
    }

    toString() {
        return `0x${this.value.toString(16).toUpperCase()}`;
    }

    plus(number) {
        let num = 0;
        typeof(number) == 'number' ? num = Number(number): num = Number(number.value);

        return new Hex(num + parseInt(this.value.toString(16).toUpperCase(), 16));
    }

    minus(number) {
        let num = 0;
        typeof(number) == 'number' ? num = Number(number): num = Number(number.value);

        return new Hex(parseInt(this.value.toString(16).toUpperCase(), 16) - num);
    }

    parse(number) {
        return parseInt(number, 16);
    }
}