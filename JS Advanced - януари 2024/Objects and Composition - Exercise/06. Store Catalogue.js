function solve(array) {

    let products = [];

    for (let index = 0; index < array.length; index++) {
        const element = array[index];

        let [name, price] = element.split(" : ");

        products.push({ name: name, price: (Number)(price) });



    }

    products.sort((a, b) => a.name.localeCompare(b.name));
    let previosLetter = "";
   

    for (let index = 0; index < products.length; index++) {
        const key = products[index].name;
        let price = products[index].price;
        
        let currentLetters = Array.from(key);

        if (previosLetter != currentLetters[0]) {

            console.log(currentLetters[0])
        }

        console.log(`  ${key}: ${price}`)

        previosLetter = currentLetters[0];
    }

}

solve([
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'T-Shirt : 10']
);