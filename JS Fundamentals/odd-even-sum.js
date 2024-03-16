function sumOfEvenAndOddDigits(number) {
    const digits = String(Math.abs(number));

    let oddSum = 0;
    let evenSum = 0;

    for (let digit of digits) {
        const currentDigit = parseInt(digit, 10);

        if (currentDigit % 2 === 0) {
            evenSum += currentDigit;
        } else {
            oddSum += currentDigit;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

sumOfEvenAndOddDigits(1000435); 
sumOfEvenAndOddDigits(3495892137259234); 
