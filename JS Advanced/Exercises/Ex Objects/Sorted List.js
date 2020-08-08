function solution() {
    class sortedList {

        constructor() {
            this.array = [];
            size = this.array.length;
        }

        add(element) {
            this.array.push(element);
            this.size++;
            this.order();
        }

        remove(index) {
            this.validate(index);
            this.array.splice(index, 1);
            this.size--;
            this.order();
        }

        get(index) {
            this.validate(index);
            return this.array[index];
        }

        order() {
            this.array.sort((a, b) => a - b);
        }

        validate(index) {
            if (index < 0 || index > this.array.length) {
                return;
            }
        }
    }

    return Object.getPrototypeOf(new sortedList());
}

let result = solution();

console.log(result.hasOwnProperty('add'));
console.log(result.hasOwnProperty('size'));