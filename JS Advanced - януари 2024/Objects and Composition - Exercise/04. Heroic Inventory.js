function solve(array){

    let result = [];

    for (let index = 0; index < array.length; index++) {
        const element = array[index];
        
       

        let [name, level, items] = element.split(" / ");

        let currItems = [];

        if (items) {
           
             currItems = items.split(", ");
        }     

        let currentHero = {

            name,
            level: (Number)(level),
            items : currItems
        };

        result.push(currentHero);
    }

    console.log(JSON.stringify(result));
}

solve(['Isacc / 25',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
)