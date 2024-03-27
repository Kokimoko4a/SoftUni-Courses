export function setUserData(data){

    localStorage.setItem('user', JSON.stringify(data));
}

export function getUserData(){

    return JSON.parse(localStorage.getItem('user'));
}

export function clearDataUser(){

    localStorage.removeItem('user');
}

export function createSubmitHandler(callback){

    return function(event){

        event.preventDefault();

        let formData = new FormData(event.target);

        let data = [...formData.entries()].map(([k,v]) => [k,v.trim()]);

        callback( Object.fromEntries(data));
    }
}

