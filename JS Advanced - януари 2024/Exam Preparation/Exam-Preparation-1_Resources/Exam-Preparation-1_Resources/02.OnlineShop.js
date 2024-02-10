class OnlineShop {

    warehouseSpace;
    products;
    sales;

    constructor(warehouseSpace) {

        this.warehouseSpace = warehouseSpace;
        this.products = [];
        this.sales = [];
    }

    loadingStore(product, quantity, spaceRequired) {

        if (this.warehouseSpace < spaceRequired) {

            throw new Error("Not enough space in the warehouse.");
        }

        let productObj = {
            product,
            quantity
        };

        this.products.push(productObj);

        this.warehouseSpace -= spaceRequired;

        return `The ${product} has been successfully delivered in the warehouse.`;
    }

    quantityCheck(product, minimalQuantity) {

        let productObj = this.products.find(p => p.product === product);

        if (!productObj) {

            throw new Error(`There is no ${product} in the warehouse.`);
        }

        if (minimalQuantity <= 0) {

            throw new Error(`The quantity cannot be zero or negative.`);
        }

        if (productObj.quantity >= minimalQuantity) {

            return `You have enough from product ${product}.`;
        }

        else {

            let oldQuantity = productObj.quantity;
            productObj.quantity = minimalQuantity;


            return `You added ${minimalQuantity - oldQuantity} more from the ${product} products.`;
        }
    }

    sellProduct(product) {

        let productObj = this.products.find(p => p.product === product);

        if (!productObj) {

            throw new Error(`There is no ${product} in the warehouse.`);
        }

        productObj.quantity -= 1;
        this.sales.push({product: product, quantity: 1});

        return `The ${product} has been successfully sold.`;

    }

    revision(){

        if (this.sales.length === 0) {
            
            throw new Error("There are no sales today!");
        }

        let output = `You sold ${this.sales.length} products today!\n`;
        output += "Products in the warehouse:\n";

       this.products.forEach(x => {

        output += `${x.product}-${x.quantity} more left\n`;
       })

        return output.trimEnd();

    }
}


