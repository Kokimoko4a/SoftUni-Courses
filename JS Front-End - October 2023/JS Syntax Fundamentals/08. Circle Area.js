function solve(number) {
    if (typeof number === 'number') 
    {
         let result = Math.pow(number,2) * Math.PI;
         console.log(result.toFixed(2));
    
    }

    else{

        
        console.log(`We can not calculate the circle area, because we receive a ${typeof(number)}.`);
    }
}

