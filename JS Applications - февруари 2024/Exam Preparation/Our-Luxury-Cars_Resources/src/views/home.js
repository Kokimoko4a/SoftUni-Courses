import { html, render } from "../../node_modules/lit-html/lit-html.js";


let homeTemlate = () => html`

<section id="hero">
<h1>
  Accelerate Your Passion Unleash the Thrill of Sport Cars Together!
</h1>
</section>
`;

export function showHome(ctx){

  let main = document.querySelector('main');

    render(homeTemlate(), main);
}