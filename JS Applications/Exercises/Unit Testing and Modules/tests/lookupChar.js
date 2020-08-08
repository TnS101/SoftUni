const { expect } = require("chai");
const incorrectIndex = 'Incorrect index';

function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return incorrectIndex;
    }
    return string.charAt(index);
}

describe('lookupChar', function() {
    const errorMessage = 'Function did not return the correct result!';

    it('should return undefined with first param number type', function() {
        expect(lookupChar(1, 1)).to.equal(undefined, errorMessage);
    });

    it('should return undefined with first param object type', function() {
        expect(lookupChar({ neshto: 'neshto' }, 1)).to.equal(undefined, errorMessage);
    });

    it('should return undefined with second param string type', function() {
        expect(lookupChar(1, 'neshto')).to.equal(undefined, errorMessage);
    });

    it('should return undefined with second param object type', function() {
        expect(lookupChar(1, { nestho: 'neshto' })).to.equal(undefined, errorMessage);
    });

    it(`should return ${incorrectIndex} with length less than index`, function() {
        expect(lookupChar('1', 2)).to.equal(incorrectIndex, errorMessage);
    });

    it(`should return ${incorrectIndex} with length equal than index`, function() {
        expect(lookupChar('22', 2)).to.equal(incorrectIndex, errorMessage);
    });

    it(`should return ${incorrectIndex} with length less than 0`, function() {
        expect(lookupChar('22', -1)).to.equal(incorrectIndex, errorMessage);
    });

    it('should return char at index', function() {
        expect(lookupChar('22', 0)).to.equal('2', errorMessage);
    });

    it('should return char at index', function() {
        expect(lookupChar('22', 1)).to.equal('2', errorMessage);
    });
});