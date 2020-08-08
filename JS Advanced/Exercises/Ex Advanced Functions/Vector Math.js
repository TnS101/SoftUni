function result() {

    let result = {
        add: function(x, y) {
            return [x[0] + x[1], y[0] + y[1]];
        },

        multiply: function(x, times) {
            return [x[0] * times, x[1] * times]
        },

        length: function(array) {
            return Math.sqrt(Math.pow(array[0], 2) + Math.pow(array[1], 2));
        },

        dot: function(x, y) {
            return x[0] * x[1] + y[0] * y[1];
        },

        cross: function(x, y) {
            return x[0] * y[1] - x[1] * y[0];
        },
    }

    return result;
}