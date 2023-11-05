function solve(array) {

    let lenth = array.length;
    let sorted = array.sort((a,b) => a - b);
    let result = [];


    for (let i = 0; i < lenth; i++) {

        

        if(i % 2 == 0)
        {
                result.push(sorted.shift());
        }
        
        else{
            result.push(sorted.pop());
        }
    }

    

    return result;
}

console.log( solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));