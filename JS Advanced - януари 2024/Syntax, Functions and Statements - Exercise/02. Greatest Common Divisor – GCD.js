function findGCD(a, b) {
    // Make sure both numbers are non-negative
    a = Math.abs(a);
    b = Math.abs(b);

    // Euclidean algorithm
    while (b !== 0) {
        let temp = b;
        b = a % b;
        a = temp;
    }

     console.log(a);
}

findGCD(5,15);