function storeAndPrintContacts(contactArray) {
    const contacts = {};

    contactArray.forEach(contactString => {
        const [name, number] = contactString.split(' ');
        contacts[name] = number;
    });

    for (let name in contacts) {
        console.log(`${name} -> ${contacts[name]}`);
    }
}

const contactList = [
    'John 123456789',
    'Jane 987654321',
    'John 555555555',
    'Alice 111222333'
];

storeAndPrintContacts(contactList);
