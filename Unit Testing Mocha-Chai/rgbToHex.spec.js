import { rgbToHexColor } from './rgbToHexColor.js';
import { expect } from 'chai';

describe('rgbToHexColor', () => {
    it('should return correct hex color for valid RGB values', () => {
        const result = rgbToHexColor(255, 0, 128);
        expect(result).to.equal('#FF0080');
    });

    it('should return undefined for invalid red value (less than 0)', () => {
        const result = rgbToHexColor(-1, 128, 255);
        expect(result).to.be.undefined;
    });

    it('should return undefined for invalid green value (greater than 255)', () => {
        const result = rgbToHexColor(128, 300, 255);
        expect(result).to.be.undefined;
    });

    it('should return undefined for invalid blue value (not an integer)', () => {
        const result = rgbToHexColor(128, 255, 'abc');
        expect(result).to.be.undefined;
    });

    it('should return undefined for invalid input type (non-integer)', () => {
        const result = rgbToHexColor('abc', 255, 128);
        expect(result).to.be.undefined;
    });
});
