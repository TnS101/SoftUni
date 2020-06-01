function solution(array) {
    for (let i = 0; i < array.length; i++) {

        array.sort(function(a, b) {
            let first = a.toUpperCase();
            let second = b.toUpperCase();

            if (first < second) {
                return -1;
            }
            if (first > second) {
                return 1;
            }

            return 0;
        });

        array.sort(function(a, b) {
            let first = a.toUpperCase();
            let second = b.toUpperCase();

            if (first.length < second.length) {
                return -1;
            }
            if (first.length > second.length) {
                return 1;
            }

            return 0;
        });

        console.log(array[i]);
    }
}

solution(['test',
    'Deny',
    'omen',
    'Default'
]);