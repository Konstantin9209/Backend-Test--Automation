function some(firstNameInput, lastNameInput, ageInput){
    let person = {
        firstName: firstNameInput,
        lastName: lastNameInput,
        age: ageInput
    }
    return person;
}
let person1 = some("John", "Doe", 25);
console.log(person1);