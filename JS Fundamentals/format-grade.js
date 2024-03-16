function printGradeDescription(grade) {
    let description;
    
    if (grade < 3.00) {
        description = "Fail";
    } else if (grade < 3.50) {
        description = "Poor";
    } else if (grade < 4.50) {
        description = "Good";
    } else if (grade < 5.50) {
        description = "Very good";
    } else {
        description = "Excellent";
    }
    console.log(`${description} (${grade === 2 ? Math.floor(grade) : grade.toFixed(2)})`);
}
printGradeDescription(2.00);
printGradeDescription(3.33);
printGradeDescription(4.50);