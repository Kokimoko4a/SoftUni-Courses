import { html,render } from "../lib.js";

const exampleTempl = () => html`

<section>
    <p>ff</p>
</section>`;


export function showEx(ctx){

    render(exampleTempl());
}