describe("mathEnforcer", () => {
    describe("addFive", () => {
        it("should return undefined when passed a non-number", () => {
            expect(mathEnforcer.addFive("not a number")).to.be.undefined;
        });

        it("should add 5 to a positive number", () => {
            expect(mathEnforcer.addFive(7)).to.equal(12);
        });

        it("should add 5 to a negative number", () => {
            expect(mathEnforcer.addFive(-3)).to.equal(2);
        });

        it("should add 5 to a floating-point number within 0.01", () => {
            expect(mathEnforcer.addFive(2.999)).to.be.closeTo(7.999, 0.01);
        });
    });

    describe("subtractTen", () => {
        it("should return undefined when passed a non-number", () => {
            expect(mathEnforcer.subtractTen("not a number")).to.be.undefined;
        });

        it("should subtract 10 from a positive number", () => {
            expect(mathEnforcer.subtractTen(15)).to.equal(5);
        });

        it("should subtract 10 from a negative number", () => {
            expect(mathEnforcer.subtractTen(-8)).to.equal(-18);
        });

        it("should subtract 10 from a floating-point number within 0.01", () => {
            expect(mathEnforcer.subtractTen(10.999)).to.be.closeTo(0.999, 0.01);
        });
    });

    describe("sum", () => {
        it("should return undefined if any parameter is not a number", () => {
            expect(mathEnforcer.sum("not a number", 5)).to.be.undefined;
            expect(mathEnforcer.sum(10, "not a number")).to.be.undefined;
        });

        it("should return the correct sum for two positive numbers", () => {
            expect(mathEnforcer.sum(2, 3)).to.equal(5);
        });

        it("should return the correct sum for two negative numbers", () => {
            expect(mathEnforcer.sum(-5, -7)).to.equal(-12);
        });

        it("should return the correct sum for a positive and a negative number", () => {
            expect(mathEnforcer.sum(8, -3)).to.equal(5);
        });

        it("should return the correct sum for two floating-point numbers within 0.01", () => {
            expect(mathEnforcer.sum(1.234, 2.345)).to.be.closeTo(3.579, 0.01);
        });
    });
});