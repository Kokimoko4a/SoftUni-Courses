import { clearDataUser, setUserData } from "../utils.js";
import { get,post } from "./request.js";

const endpoints = {

    login: '/users/login',
    register: '/users/register',
    logout: '/users/logout'

}

export async function login(email, password){

    let result = await post(endpoints.login,{email, password});

    setUserData(result);
}

export async function register(email, password){

    let result = await post(endpoints.register,{email, password});

    setUserData(result);
}


export async function logout(){

   let promise = get(endpoints.logout);

   clearDataUser();

   await promise;
   
  

}