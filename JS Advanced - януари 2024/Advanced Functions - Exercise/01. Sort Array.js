function solve(array, typeSort) {

    const sorter = {

        asc: (a, b) => a - b,
        desc: (a, b) => b - a
    }

    return array.sort(sorter[typeSort]);


}

solve([1, 32, 3], 'asc');