const { expect } = require("chai");

function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return 'even';
    }
    return 'odd';
}

describe('isOddOrEven', function() {
    const errorMessage = 'Function did not return the correct result!';
    it('should return undefined with a number parameter', function() {
        expect(isOddOrEven(10)).to.equal(undefined, errorMessage);
    });

    it('should return undefined with a object parameter', function() {
        expect(isOddOrEven({ name: "nesh" })).to.equal(undefined, errorMessage);
    });

    it('should return correct result with an even length', function() {
        expect(isOddOrEven('abcd')).to.equal('even', errorMessage);
    });

    it('should return correct result with an odd length', function() {
        expect(isOddOrEven('abc')).to.equal('odd', errorMessage);
    });

    it('should return correct values with multiple consecutive checks', function() {
        expect(isOddOrEven('abcd')).to.equal('even', errorMessage);
        expect(isOddOrEven('abc')).to.equal('odd', errorMessage);
        expect(isOddOrEven('cdef')).to.equal('even', errorMessage);
        expect(isOddOrEven('xyz')).to.equal('odd', errorMessage);
    });
});