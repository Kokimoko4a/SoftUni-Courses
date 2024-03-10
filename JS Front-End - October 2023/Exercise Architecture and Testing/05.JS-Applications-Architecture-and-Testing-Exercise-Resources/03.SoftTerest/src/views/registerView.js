let registerView = document.querySelector("div[data-view-name='register']");
let form = registerView.querySelector('form').addEventListener('submit', onSubmit);

export function showRegisterView(ctx){


    ctx.render(registerView);
}

function onSubmit(e){

    e.preventDefault();

    const formData = new FormData(e.target);

    const {email,password,confirmPassword} = Object.entries(formData);

    if (email.length < 3 || password.length <3 || confirmPassword.length < 3 || password !== confirmPassword) {
        
        return alert('Register error');
    }
}