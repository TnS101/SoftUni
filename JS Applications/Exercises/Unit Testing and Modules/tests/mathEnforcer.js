const { expect } = require("chai");

let mathEnforcer = {
    addFive: function(num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function(num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function(num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

describe('mathEnforcer', function() {
    const errorMessage = 'Function did not return the correct result!';
    describe('addFive', function() {
        it('should return undefined if num is string', function() {
            expect(mathEnforcer.addFive('string')).to.eq(undefined, errorMessage);
        });

        it('should return undefined if num is object', function() {
            expect(mathEnforcer.addFive({ obj: 'obj' })).to.eq(undefined, errorMessage);
        });

        it('should return undefined if num is array', function() {
            expect(mathEnforcer.addFive([1, 2, '3'])).to.eq(undefined, errorMessage);
        });

        it('should return sum', function() {
            expect(mathEnforcer.addFive(5)).to.eq(10, errorMessage);
        });
    });

    describe('substractTen', function() {
        it('should return undefined if num is string', function() {
            expect(mathEnforcer.subtractTen('string')).to.eq(undefined, errorMessage);
        });

        it('should return undefined if num is object', function() {
            expect(mathEnforcer.subtractTen({ obj: 'obj' })).to.eq(undefined, errorMessage);
        });

        it('should return undefined if num is array', function() {
            expect(mathEnforcer.subtractTen([1, 2, '3'])).to.eq(undefined, errorMessage);
        });

        it('should return sum', function() {
            expect(mathEnforcer.subtractTen(20)).to.eq(10, errorMessage);
        });
    });

    describe('sum', function() {
        it('should return undefined if num1 is string', function() {
            expect(mathEnforcer.sum('string', 1)).to.eq(undefined, errorMessage);
        });

        it('should return undefined if num1 is object', function() {
            expect(mathEnforcer.sum({ obj: 'obj' }, 1)).to.eq(undefined, errorMessage);
        });

        it('should return undefined if num1 is array', function() {
            expect(mathEnforcer.sum([1, 2, '3'], 1)).to.eq(undefined, errorMessage);
        });

        it('should return undefined if num2 is string', function() {
            expect(mathEnforcer.sum(1, 'string')).to.eq(undefined, errorMessage);
        });

        it('should return undefined if num2 is object', function() {
            expect(mathEnforcer.sum(1, { obj: 'obj' })).to.eq(undefined, errorMessage);
        });

        it('should return undefined if num2 is array', function() {
            expect(mathEnforcer.sum(1, [1, 2, '3'])).to.eq(undefined, errorMessage);
        });

        it('should return sum', function() {
            expect(mathEnforcer.sum(0, 10)).to.eq(10, errorMessage);
        });
    });
});