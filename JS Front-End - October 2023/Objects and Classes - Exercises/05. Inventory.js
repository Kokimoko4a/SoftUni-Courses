function heroes(data){

    let list = [];

    for (let index = 0; index < data.length; index++) {
        
        let [name,level,items] = data[index].split(" / ");

        let currHero = {
            name: name,
            level: level,
            items: items
        };

        list.push(currHero);
    }

     list.sort((a,b) =>a.level-b.level ) ;

    list.forEach(element => {
        console.log(`Hero: ${element.name}`);
        console.log(`level => ${element.level}`);
        console.log(`items => ${element.items}`);
       
    });
}

heroes([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]
    );