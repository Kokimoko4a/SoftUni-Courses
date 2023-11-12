function loadingPrint(number){
    if(number === 100){
        console.log("100% Complete!");
        console.log(`[%%%%%%%%%%]`);
    }

    else{
        let percents = (number/10)
        let dots = (10 - (percents))
        

        let result = `[${'%'.repeat(percents)}${'.'.repeat(dots)}]`

        console.log(`${number}% ${result}`);
        console.log("Still loading...")
    }
}

loadingPrint(30);
