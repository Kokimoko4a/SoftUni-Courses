function solve(count, typeGroup, day) {

    if (day == "Friday") {

        if (typeGroup == "Students") {


            let sum = count * 8.45;

            if (count >= 30) {
                sum = (count * 8.45) - (0.15 * (count * 8.45));
            }

            console.log(`Total price: ${(sum).toFixed(2)}`);
        }

        else if (typeGroup == "Regular") {

            let sum = count * 15;

            if(count >= 10 && count<=20)
            {
                sum = sum - (0.05*sum);
            }

            console.log(`Total price: ${(sum).toFixed(2)}`);
        }

        else if (typeGroup == "Business") {

            if (count >= 100) {
                count -= 10;
            }

            console.log(`Total price: ${(count * 10.9).toFixed(2)}`);
        }
    }

    else if (day == "Saturday") {

        if (typeGroup == "Students") {

            let sum = count * 9.8;

            if (count >= 30) {
                sum = (count * 9.8) - (0.15 * (count * 9.8));
            }



            console.log(`Total price: ${(sum).toFixed(2)}`);
        }

        else if (typeGroup == "Regular") {
            let sum = count * 20;

            if(count >= 10 && count <= 20)
            {
                sum = sum - (0.05*sum);
            }

            console.log(`Total price: ${(sum).toFixed(2)}`);
        }

        else if (typeGroup == "Business") {
            if (count >= 100) {
                count -= 10;
            }

            console.log(`Total price: ${(count * 15.6).toFixed(2)}`);
        }
    }

    else if (day == "Sunday") {
        if (typeGroup == "Students") {


            let sum = count * 10.46;

            if (count >= 30) {
                sum = (count * 10.46) - (0.15 * (count * 10.46));
            }



            console.log(`Total price: ${(sum).toFixed(2)}`);
        }

        else if (typeGroup == "Regular") {

            let sum = count * 22.5;

            if(count >=10 && count<=20)
            {
                sum = sum - (0.05*sum);
            }

            console.log(`Total price: ${(sum).toFixed(2)}`);
        }

        else if (typeGroup == "Business") {
            if (count >= 100) {
                count -= 10;
            }

            console.log(`Total price: ${(count * 16).toFixed(2)}`);
        }

    }
}
