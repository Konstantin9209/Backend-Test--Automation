function manageParkingLot(parkingData) {
    const parkingLot = [];

    for (const entry of parkingData) {
        const [direction, carNumber] = entry.split(', ');

        if (direction === 'IN' && !parkingLot.includes(carNumber)) {
            parkingLot.push(carNumber);
        } else if (direction === 'OUT' && parkingLot.includes(carNumber)) {
            const index = parkingLot.indexOf(carNumber);
            parkingLot.splice(index, 1);
        }
    }

    if (parkingLot.length === 0) {
        console.log('Parking Lot is Empty');
    } else {
        // Sort car numbers in ascending order
        parkingLot.sort((a, b) => a.localeCompare(b));
        console.log(parkingLot.join('\n'));
    }
}

// Example usage:
const input1 = [
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU'
];

manageParkingLot(input1);

const input2 = [
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'OUT, CA1234TA'
];

manageParkingLot(input2);
