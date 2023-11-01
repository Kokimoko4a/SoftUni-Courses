function radar(speed, place) {



    if (place == "motorway" && speed <= 130) {

        console.log(`Driving ${speed} km/h in a 130 zone`);
    }

    else if (place == "interstate" && speed <= 90) {
        console.log(`Driving ${speed} km/h in a 90 zone`);
    }

    else if (place == "city" && speed <= 50) {
        console.log(`Driving ${speed} km/h in a 50 zone`);
    }

    else if (place == "residential" && speed <= 20) {
        console.log(`Driving ${speed} km/h in a 20 zone`);
    }

    else {

        let limit = 0;
        let status = "";

        if (place == "motorway") {
            limit = 130;
        }

        else if (place == "interstate") {
            limit = 90;
        }

        else if (place == "city") {
            limit = 50;
        }

        else if (place == "residential") {
            limit = 20;
        }

        if (speed - limit <= 20) {
            status = "speeding";
        }

        else if (speed - limit <= 40) {
            status = "excessive speeding";
        }

        else{
            status = "reckless driving";
        }

        console.log(`The speed is ${speed - limit} km/h faster than the allowed speed of ${limit} - ${status}`);
    }
}

