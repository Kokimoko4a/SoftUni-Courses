const endPoints = {

    register: 'user/register'
}

async function register(data){

    return await post(endPoints,data)
}