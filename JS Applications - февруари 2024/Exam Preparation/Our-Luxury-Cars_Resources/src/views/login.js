import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { createSubmitHandler, updateNav } from "../utils.js";
import { login } from "../data/user.js";
import { page } from "../lib.js";


const loginTemlate = (onLogin) => html`
   

<section id="login">
<div class="form" @submit=${onLogin}>
  <img class="border" src="./images/border.png" alt="">
  <h2>Login</h2>
  <form class="login-form">
    <input type="text" name="email" id="email" placeholder="email" />
    <input
      type="password"
      name="password"
      id="password"
      placeholder="password"
    />
    <button type="submit">login</button>
    <p class="message">
      Not registered? <a href="/register">Create an account</a>
    </p>
  </form>
  <img class="border" src="./images/border.png" alt="">
</div>
</section>
`;

export function showLogin(ctx){



  let main = document.querySelector('main');


  render(loginTemlate(createSubmitHandler(onLogin)), main);
}

async function onLogin({email,password}, form){

    if (!email || !password) {
        
        return;
    }

    await login(email,password);

    updateNav();

    page.redirect('/');
}