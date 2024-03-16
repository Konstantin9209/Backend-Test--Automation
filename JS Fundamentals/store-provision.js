function processStockAndDelivery(currentStock, delivery) {
    const stockObject = {};


    for (let i = 0; i < currentStock.length; i += 2) {
        const product = currentStock[i];
        const quantity = Number(currentStock[i + 1]);

        stockObject[product] = quantity;
    }

    for (let i = 0; i < delivery.length; i += 2) {
        const product = delivery[i];
        const quantity = Number(delivery[i + 1]);

        if (stockObject.hasOwnProperty(product)) {

            stockObject[product] += quantity;
        } else {
  
            stockObject[product] = quantity;
        }
    }

    for (let product in stockObject) {
        console.log(`${product} -> ${stockObject[product]}`);
    }
}


const currentStock = ['Chips', '5', 'Coca Cola', '9', 'Bananas', '14'];
const delivery = ['Chips', '10', 'Coca Cola', '5', 'Bananas', '3', 'Orange Juice', '8'];

processStockAndDelivery(currentStock, delivery);
