import { isSymmetric } from './checkForSymmetry.js';
import { expect } from 'chai';

describe('isSymmetric', () => {
    it('should return true for an empty array', () => {
        const inputArray = [];
        const result = isSymmetric(inputArray);
        expect(result).to.be.true;
    });

    it('should return false for a non-array value', () => {
        const nonArrayValue = 42;
        const result = isSymmetric(nonArrayValue);
        expect(result).to.be.false;
    });

    it('should return false for a non-symmetric array', () => {
        const nonSymmetricArray = [1, 2, 3, 4];
        const result = isSymmetric(nonSymmetricArray);
        expect(result).to.be.false;
    });

    it('should return false for a mixed array', () => {
        const mixedArray = [1, '2', 3, '4', 5];
        const result = isSymmetric(mixedArray);
        expect(result).to.be.false;
    });
    it('should return false symmetric lookalike values', () => {
        const symmetricArray = ['1', '2', '3', 2, 1];
        const result = isSymmetric(symmetricArray);
        expect(result).to.be.false;
    });
});
