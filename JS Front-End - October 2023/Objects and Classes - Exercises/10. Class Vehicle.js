class Vehicle{

    constructor(type,model,parts,fuel) {
        
       this.type = type;
       this.model = model;
       this.parts = {
        engine: parts.engine,
        power: parts.power,
        quality: parts.power * parts.engine
       };
       this.fuel = fuel
    }

     drive(fuelLoss){

        this.fuel-=fuelLoss;

    }
    /* •	type – a string
•	model – a string
•	parts – an object that contains:
o	engine – number (quality of the engine)
o	power – number
o	quality – engine * power
•	fuel – a number
•	drive – a method that receives fuel loss and decreases the fuel of the vehicle by that number
*/
}