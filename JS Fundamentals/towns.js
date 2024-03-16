function createObjectsFromTable(tableRows) {
    const objectsList = [];

    for (let row of tableRows) {
        const [town, latitude, longitude] = row.split(' | ').map(value => value.trim());
        const latitudeNum = Number(latitude).toFixed(2);
        const longitudeNum = Number(longitude).toFixed(2);

        const currentObject = {
            town: town,
            latitude: latitudeNum,
            longitude: longitudeNum
        };

        objectsList.push(currentObject);
    }

    objectsList.forEach(object => {
        console.log(object);
    });
}

const tableRows = [
    'Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625'
];

createObjectsFromTable(tableRows);
