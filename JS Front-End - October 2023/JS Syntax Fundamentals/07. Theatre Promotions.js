function solve(day, age) {

    

    if (day == "Holiday") {
        if (age >= 0 && age <= 18) {

            console.log("5$");
        }

        else if (age > 18 && age <= 64) {
            sum = 12;
            console.log("12$");
        }

        else if (age > 64 && age <= 122) {
            sum = 10;
            console.log("10$");
        }

        else {
            console.log("Error!")
        }
    }

    else if (day == "Weekend") {
        if (age >= 0 && age <= 18) {
            sum = 15;
            console.log("15$");
        }

        else if (age > 18 && age <= 64) {
            sum = 20;
            console.log("20$");
        }

        else if (age > 64 && age<= 122) {
            sum = 15;
            console.log("15$");
        }

        else {
            console.log("Error!")
        }
    }

    else if (day == "Weekday") {

        if (age >= 0 && age <= 18) {
            sum = 12;
            console.log("12$");
        }

        else if (age > 18 && age <= 64) {
            sum = 18;
            console.log("18$");
        }

        else if (age > 64  && age<= 122) {
            sum = 12;
            console.log("12$");
        }

        else {
            console.log("Error!")
        }

    }

    else {
        console.log("Error!");
    }

   
}



