function solution() {
    let map = new Map();

    for (let index = 0; index < solution.arguments.length; index++) {
        const element = solution.arguments[index];
        let type = typeof(element);

        console.log(`${type}: ${element}`);

        if (map.has(type)) {
            let value = map.get(type);
            map.delete(type);
            map.set(type, value + 1);
        } else {
            map.set(type, 1);
        }
    }

    let result = new Map([...map.entries()].sort((a, b) => b[1] - a[1]));

    for (const [key, value] of result) {
        console.log([key, value].join(' = '));
    }
}

solution('cat', 42, function() { console.log('Hello world!'); });