function solve(array){


    function compare(a,b){

        let lengthDiff = a.length - b.length;

        if (lengthDiff !== 0) {
            
            return lengthDiff;
        }

        return a.localeCompare(b);
    }

    array.sort(compare);

    array.forEach(element => {
        
        console.log(element);
    });
}

solve(['alpha', 
'beta', 
'gamma']
);