function getFibonator(){

    let previouNumber = 0;
    let nextNumber = 1;

    return function fib(){

       
      
        let res = previouNumber + nextNumber;
        previouNumber = nextNumber;
        nextNumber =  res;
        return  previouNumber;

    }

}
let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
