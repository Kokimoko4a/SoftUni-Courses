import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { createSubmitHandler } from "../utils.js";
import { createCar } from "../data/cars.js";
import { page } from "../lib.js";


const createTemplate = (onCreate) => html`

<section id="create">
<div class="form" @submit=${onCreate}>
  <img class="border" src="./images/border.png" alt="">
  <h2>Add Character</h2>
  <form class="create-form">
    <input
      type="text"
      name="category"
      id="category"
      placeholder="Character Type"
    />
    <input
      type="text"
      name="image-url"
      id="image-url"
      placeholder="Image URL"
    />
    <textarea
    id="description"
    name="description"
    placeholder="Description"
    rows="2"
    cols="10"
  ></textarea>
  <textarea
    id="additional-info"
    name="additional-info"
    placeholder="Additional Info"
    rows="2"
    cols="10"
  ></textarea>
    <button type="submit">Add Character</button>
  </form>
  <img class="border" src="./images/border.png" alt="">
</div>
</section>
`;

export function showCreate(ctx) {

    let main = document.querySelector('main');


    render(createTemplate(createSubmitHandler(onCreate)), main);
}

async function onCreate(data, form) {

console.log(typeof(data['image-url']));

 console.log()

    if (!data['category'] || !data['image-url'] || !data['description'] || !data['additional-info']) {

        return alert("All fields are required!");
    }

    await createCar(data['category'], data['image-url'], data['description'], data['additional-info']);

   page.redirect('/catalog');

}