class List {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(num) {
        this.list.push(num);
        this.list.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        this.validate(index);
        this.list.splice(index, 1);
        this.size--;
    }

    get(index) {
        this.validate(index);
        return this.list[index];
    }

    validate(index) {
        if (index < 0 || index >= this.list.length) {
            throw new Error('KYS');
        }
    }
}

let list = new List();
list.add(2);
list.add(3);
list.remove(2);
console.log(list.get(0));