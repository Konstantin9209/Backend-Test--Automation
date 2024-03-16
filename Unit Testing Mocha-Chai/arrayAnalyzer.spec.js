import { analyzeArray } from "./arrayAnalyzer.js"; 
import { expect } from "chai";

describe("analyzeArray", () => {
    it("should return min, max, and length for an array of numbers", () => {
        const result = analyzeArray([4, 2, 7, 1, 9]);

        expect(result).to.deep.equal({
            min: 1,
            max: 9,
            length: 5
        });
    });

    it("should return undefined for an empty array", () => {
        const result = analyzeArray([]);

        expect(result).to.be.undefined;
    });

    it("should return undefined for a non-array input", () => {
        const result = analyzeArray("not an array");

        expect(result).to.be.undefined;
    });

    it("should return min, max, and length for a single element array", () => {
        const result = analyzeArray([42]);

        expect(result).to.deep.equal({
            min: 42,
            max: 42,
            length: 1
        });
    });

    it("should return undefined for an array with non-number elements", () => {
        const result = analyzeArray([1, 2, "not a number"]);

        expect(result).to.be.undefined;
    });

    it("should handle floating-point numbers", () => {
        const result = analyzeArray([3.14, 2.71, 1.618]);

        expect(result).to.deep.equal({
            min: 1.618,
            max: 3.14,
            length: 3
        });
    });
});
