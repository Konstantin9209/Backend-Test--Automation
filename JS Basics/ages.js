function solve(age) {
    let message = '';

    if (age >= 0 && age <= 2) {
        message = 'baby';
    } else if (age >= 3 && age <= 13){
        message = 'child';
    } else if (age >= 14 && age <= 19){
        message = 'teenager';
    } else if (age >= 20 && age <=65){
        message = 'adult';
    } else if (age >=65){
        message = 'elder';
    }else{
        message = 'out of bounds';
    }
    console.log(message);
}   
solve(66);
solve(15);
