function solution() {

    let storage = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    return function manage(...args) {

        let command = args[0];

        if (command === "restock") {

            let entity = args[1];
            let quantity = Number(args[2]);

            storage[entity] += quantity;

            return "Success";

        }

        else if (command === "prepare") {

            let recipe = args[1];
            let count = Number(args[2]);

            if (recipe === "lemonade") {

                let carbs = 10 * count;
                let flavour = 2 * count;

                let isPossible = carbs <= storage.carbohydrate && flavour <= storage.flavour;

                if (isPossible) {

                    storage.carbohydrate -=carbs;
                    storage.flavour -= flavour;
                    return "Success";
                }

                else {


                    if (carbs > storage.carbohydrate) {

                        return `Error: not enough carbohydrate in stock`;

                    }

                    else if (flavour > storage.flavour) {

                        return `Error: not enough flavour in stock`;

                    }

                }

            }




            else if (recipe === "burger") {

                let carbs = 5 * count;
                let flavour = 3 * count;
                let neededFats = 7 * count;


                let isPossible = carbs <= storage.carbohydrate && flavour <= storage.flavour && neededFats <= storage.fat;

                if (isPossible) {

                    storage.carbohydrate -= carbs;
                    storage.flavour -= flavour;
                    storage.fat -= neededFats;
                    return "Success";
                }

                else {


                    if (carbs > storage.carbohydrate) {

                        return `Error: not enough carbohydrate in stock`;

                    }

                    else if (neededFats > storage.fat) {

                        return `Error: not enough fat in stock`;

                    }

                    else if (flavour > storage.flavour) {

                        return `Error: not enough flavour in stock`;

                    }

                }

            }

            else if (recipe === "eggs") {


                let flavour = count;
                let neededFats = count;
                let protein = 5 * count;


                let isPossible = protein <= storage.protein && flavour <= storage.flavour && neededFats <= storage.fat;

                if (isPossible) {

                    storage.protein -= protein;
                    storage.flavour -= flavour;
                    storage.fat-= neededFats;
                    return "Success";
                }

                else {


                    if (protein > storage.carbohydrate) {

                        return `Error: not enough protein in stock`;

                    }

                    else if (neededFats > storage.fat) {

                        return `Error: not enough fat in stock`;

                    }

                    else if (flavour > storage.flavour) {

                        return `Error: not enough flavour in stock`;

                    }

                }

            }

            else if (recipe === "turkey") {


                let flavour = 10 * count;
                let neededFats = 10 * count;
                let protein = 10 * count;
                let neededCarbohydrates = 10 * count;


                let isPossible = protein <= storage.protein && flavour <= storage.flavour && neededFats <= storage.fat && neededCarbohydrates <= storage.carbohydrate;

                if (isPossible) {

                    storage.protein -= protein;
                    storage.flavour -= flavour;
                    storage.fat -= neededFats;
                    storage.carbohydrate -= neededCarbohydrates;


                    return "Success";
                }

                else {


                    if (protein > storage.carbohydrate) {

                        return `Error: not enough protein in stock`;

                    }

                    else if (neededCarbohydrates > storage.carbohydrate) {

                        return `Error: not enough carbohydrate in stock`;
                    }

                    else if (neededFats > storage.fat) {

                        return `Error: not enough fat in stock`;

                    }

                    else if (flavour > storage.flavour) {

                        return `Error: not enough flavour in stock`;

                    }

                }

            }

            else if (recipe === "apple") {

                let carbs = count;
                let flavour = count * 2;

                let isPossible = carbs <= storage.carbohydrate && flavour <= storage.flavour;

                if (isPossible) {

                    storage.carbohydrate -= carbs;
                    storage.flavour -= flavour;

                    return "Success";
                }

                else {

                    if (carbs > storage.carbohydrate) {

                        return `Error: not enough carbohydrate in stock`;
                    }

                    else if (flavour > storage.flavour) {

                        return `Error: not enough flavour in stock`;

                    }
                }
            }


        }

        else if (command === "report") {

            return `protein=${storage.protein} carbohydrate=${storage.carbohydrate} fat=${storage.fat} flavour=${storage.flavour}`;
        }
    }
}

let manage = solution();
console.log(manage("restock", "flavour", "50"));
console.log(manage("prepare","lemonade","4"));



/*restock flavour 50 
prepare lemonade 4 
restock carbohydrate 10
restock flavour 10
prepare apple 1
restock fat 10
prepare burger 1
report
 */

