function solve(fruit,weightGrams,pricePerKilogram){


    let weightKilos = weightGrams/1000;

    let neededMoney = weightKilos*pricePerKilogram;

    console.log(`I need $${neededMoney.toFixed(2)} to buy ${weightKilos.toFixed(2)} kilograms ${fruit}.`);
}

