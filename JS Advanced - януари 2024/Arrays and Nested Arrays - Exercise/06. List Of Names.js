function solve(array){

    array.sort((a,b) => a.localeCompare(b));

    let number = 1;
    let output = "";

    array.forEach(element => {
        
     output += `${number}.${element}\n`;

    number++;
        
    });

    return output;
}

 console.log( solve(["John", "Bob", "Christina", "Ema"]));