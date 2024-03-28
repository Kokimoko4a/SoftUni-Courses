import { clearDataUser, getUserData } from "../utils.js";

const host = 'http://localhost:3030';

async function request(method, url, data){

    const options = {


        method,
        headers: {}
    };

    if (data) {
        
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    let userData = getUserData();

    if (userData) {
        
        options.headers['X-Authorization'] = userData.accessToken;
    }


    try {

        let response = await fetch(host +  url, options);

        if (!response.ok) {
            
            

            if (response.status == 403) {
                clearDataUser()
            }

            

            let err = await response.json();
            throw new Error(err.message);
        }

        if (response.status == 204) {
            
            return response;
        }

        else{
            return response.json();
        }
        
    } catch (err) {
        
        alert(err.message)
        throw err;
    }
   
}


export const get = (url) => request('GET', url);

export const post = (url,data) => request('post', url,data);

export const put = (url,data) => request('put', url,data);

export const del = (url) => request('delete', url);