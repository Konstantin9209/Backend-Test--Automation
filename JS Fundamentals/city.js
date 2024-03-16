function printObjectProperties(obj) {
    for (let key in obj) {
        console.log(`${key} -> ${obj[key]}`);
    }
}

const cityInfo = {
    name: "CityName",
    area: 100,
    population: 500000,
    country: "CountryName",
    postcode: "12345"
};

printObjectProperties(cityInfo);
