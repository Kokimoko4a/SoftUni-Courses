import { html, render } from "../../node_modules/lit-html/lit-html.js";


let homeTemlate = () => html`


<section id="hero">
<img src="./images/home.png" alt="home" />
<p>We know who you are, we will contact you</p>
</section>
`;

export function showHome(ctx){

  let main = document.querySelector('main');

    render(homeTemlate(), main);
}