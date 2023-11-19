function createProducts(localProducts, deliveryProducts){

    let list = {};

    for (let i = 0; i < localProducts.length; i+=2) {
        const product = localProducts[i];
        const quantity = parseInt(localProducts[i+1]);

        list[product] = quantity;

    }


    for (let i = 0; i < deliveryProducts.length; i+=2) {
        const product = deliveryProducts[i];
        const quantity = parseInt(deliveryProducts[i+1]);

        if (!list.hasOwnProperty(product)) {
           list[product] = quantity;
        }

        else{
            list[product] += quantity;
        }

       

    }

    for (const key in list) {
        console.log(`${key} -> ${list[key]}`)
    }
}

createProducts([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
    );