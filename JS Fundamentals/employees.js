function createEmployeeList(names) {
    const employeeList = {};

    for (let name of names) {
        const personalNum = name.length;
        employeeList[name] = personalNum;
    }

    for (let employeeName in employeeList) {
        const personalNum = employeeList[employeeName];
        console.log(`Name: ${employeeName} -- Personal Number: ${personalNum}`);
    }
}
const employees = ["John Doe", "Alice Smith", "Bob Johnson"];
createEmployeeList(employees);
