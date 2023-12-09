

function solve(inputArray) {

    let astrnounts = [];
   


    for (let index = 1; index <= parseInt(inputArray[0]); index++) {

        let currData = inputArray[index].split(' ');

        let currAstronaut = {
            name: currData[0],
            oxygenLevel: parseInt(currData[1]),
            energyReserves: parseInt(currData[2])
        }

        astrnounts.push(currAstronaut);
    }

    
    let indexator = astrnounts.length + 1

    for (let index = 0; index < inputArray.length - astrnounts.length - 1; index++) {
        
        let data = inputArray[indexator].split(" - ");

        if (data[0] === "Explore") {
            
            let currAstronaut = astrnounts.find(x => x.name === data[1]);
            let energyNeeded = parseInt(data[2]);

            if (energyNeeded <= currAstronaut.energyReserves) {

                currAstronaut.energyReserves -= energyNeeded;

                console.log(`${currAstronaut.name} has successfully explored a new area and now has ${currAstronaut.energyReserves} energy!`);
                
            }

            else{

                console.log(`${currAstronaut.name} does not have enough energy to explore!`);
            }

        }

        else if (data[0] === "Refuel") {
            
            /*"Refuel – {astronaut name} – {amount}" */

            let currAstronaut = astrnounts.find(x => x.name === data[1]);
            let amount  = parseInt(data[2]);

           if (currAstronaut.energyReserves + amount > 200) {

            let energyOfAstronautBefore = currAstronaut.energyReserves;
            
            currAstronaut.energyReserves += 200 - currAstronaut.energyReserves;

            console.log(`${currAstronaut.name} refueled their energy by ${200 - energyOfAstronautBefore}!`);
           }

           else{

            currAstronaut.energyReserves += amount;

            console.log(`${currAstronaut.name} refueled their energy by ${amount}!`);
           }

        }

        else if (data[0] === "Breathe") {
            

            
            let currAstronaut = astrnounts.find(x => x.name === data[1]);
            let amount  = parseInt(data[2]);

           if (currAstronaut.oxygenLevel + amount > 100) {

            let oxygenLevelOfAstronautBefore = currAstronaut.oxygenLevel;
            
            currAstronaut.oxygenLevel += 100 - currAstronaut.oxygenLevel;

            console.log(`${currAstronaut.name} took a breath and recovered ${100 - oxygenLevelOfAstronautBefore} oxygen!`);
           }

           else{

            currAstronaut.oxygenLevel += amount;

            console.log(`${currAstronaut.name} took a breath and recovered ${amount} oxygen!`);
           }

        }

       else{

        astrnounts.forEach(a => {

            console.log(`Astronaut: ${a.name}, Oxygen: ${a.oxygenLevel}, Energy: ${a.energyReserves}`);
        })
       }

        indexator++;
        
    }

   

}

solve([    '4',
'Alice 60 100',
'Bob 40 80',
'Charlie 70 150',
'Dave 80 180',
'Explore - Bob - 60',
'Refuel - Alice - 30',
'Breathe - Charlie - 50',
'Refuel - Dave - 40',
'Explore - Bob - 40',
'Breathe - Charlie - 30',
'Explore - Alice - 40',
'End']

);