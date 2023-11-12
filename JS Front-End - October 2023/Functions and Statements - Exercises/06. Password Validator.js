function validatePassword(password) {

    let regex = /^[a-zA-Z0-9]+$/;
    let checkPasswordLength = (password) => password.length >= 6 && password.length <= 10 ? true : false;
    let consistsOfNumbersAndLettersOnly = (password) => regex.test(password);
    


    if (!checkPasswordLength(password)) {

        console.log("Password must be between 6 and 10 characters")
    }

    if(!consistsOfNumbersAndLettersOnly(password)){

        console.log("Password must consist only of letters and digits");
    }

    if(!containsTwoDigitsAtLeast(password)){
            
        console.log("Password must have at least 2 digits");
    }

    else{
        console.log("Password is valid");
    }

    function containsTwoDigitsAtLeast(password){

        let regexNumber = /[0-9]/;
        let count = 0;

        for (let index = 0; index < password.length; index++) {

            const element = password[index];

            if(regexNumber.test(element)){

                count++;
            }

            if(count ===2)
            {
                return true;
            }
            
        }

        if(count <=1){
            return false;
        }

        regexNumber.lastIndex = 0;
    }
}

