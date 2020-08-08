class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;

        if (string.length > length) {
            let diff = string.length - length;
            this.string = string.slice(0, string.length - diff);

            for (let index = 0; index < diff; index++) {
                string += '.';
            }
        } else {
            this.string = string;
        }
        this.length = length;
    };

    increase(length) {
        if (this.length - length <= this.innerLength) {
            this.length += length;
            this.innerLength += length;
            this.string = this.innerString.slice(0, this.length);

            for (let index = length; index < this.length; index++) {
                this.string += '.';
            }
        }
    }

    decrease(length) {
        if (this.length >= length) {
            this.length -= length;
            this.innerLength -= length;
            this.string = this.innerString.slice(0, this.length);

            for (let index = 0; index < length; index++) {
                this.string += '.';
            }
        } else {
            this.length = 0;
            this.innerLength = 0;
            this.string = '...';
        }
    }

    toString() {
        return this.string;
    }
}