function solve(array){

    let result = {};

    for (let index = 0; index < array.length; index++) {
        const element = array[index];
        
        let [town,product,price] = element.split(" | ");

        price = (Number)(price);

        if (!result.hasOwnProperty(product)) {
            
            result[product] = {town: town,price: Number(price) };
        }

        else
        {

            if (result[product].price > price) {
                
                result[product].price = price;
                result[product].town = town;
               
            }
        }
    }

    for (const key in result) {
        console.log(`${key} -> ${result[key].price} (${result[key].town})`);
    }
}

solve(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'Mexico City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Washington City | Mercedes | 1000']
)