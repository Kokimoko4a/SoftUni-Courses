function solve(car){

    let result = {};

    result.model = car.model;

    if (car.power <= 90) {
        
        result.engine = {power: 90, volume: 1800};
    }

    else if (car.power <= 120) {
        
        result.engine = {power: 120, volume: 2400};
    }

    else if(car.power <= 200){

        result.engine = {power:200, volume: 3500};
    }

    /*Small engine: { power: 90, volume: 1800 }
    Normal engine: { power: 120, volume: 2400 }
    Monster engine: { power: 200, volume: 3500 }

    carriage: { type: 'hatchback',
              color: 'blue' },

 */

    let sizeOfTires = 0;
    result.carriage = {type: car.carriage, color: car.color};

    if (car.wheelsize % 2 === 0) {
        
        sizeOfTires = car.wheelsize - 1;
    }

    else{

        sizeOfTires = car.wheelsize;
    }

    result.wheels = [sizeOfTires,sizeOfTires,sizeOfTires,sizeOfTires];

    return result;

}

console.log(solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
));

