import { getUser } from "../utils/userUtils.js";


const BASE_URL = '';

async function requester(method, url, data){

    let url = BASE_URL + url;

    const userData = getUser()l;

    let option = {

        method,
        headers: {}
    };

    if (userData) {
        
        option.headers['x-authorization'] = userData.accessToken;
    }

    if (data) {
        
        option.headers['content-type'] = 'application/json';
        option.body = JSON.stringify(data);
    }

    try {
        
        let response = await fetch(url,option)

        if (!response.ok) {
            
            if (response.status = 403) {
                
                removeUser();
            }

           let error = await response.json();
           throw new Error(error.message);
          
        }

        if (response.status === 204) {
                
            return response;

        }

    return  response.json();

    } catch (error) {
        

        alert(error);
        throw error;
    }


}

function get(){

    re
}