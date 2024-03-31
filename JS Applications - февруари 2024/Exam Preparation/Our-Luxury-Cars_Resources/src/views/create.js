import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { createSubmitHandler } from "../utils.js";
import { createCar } from "../data/cars.js";
import { page } from "../lib.js";


const createTemplate = (onCreate) => html`

<!-- Create Page (Only for logged-in users) -->
<section id="create">
  <div class="form form-item">
    <h2>Share Your item</h2>
    <form class="create-form"  @submit=${onCreate}>
      <input type="text" name="item" id="item" placeholder="Item" />
      <input
        type="text"
        name="imageUrl"
        id="item-image"
        placeholder="Your item Image URL"
      />
      <input
        type="text"
        name="price"
        id="price"
        placeholder="Price in Euro"
      />
      <input
        type="text"
        name="availability"
        id="availability"
        placeholder="Availability Information"
      />
      <input
        type="text"
        name="type"
        id="type"
        placeholder="Item Type"
      />
      <textarea
        id="description"
        name="description"
        placeholder="More About The Item"
        rows="10"
        cols="50"
      ></textarea>
      <button type="submit">Add</button>
    </form>
  </div>
</section>
`;

export function showCreate(ctx) {

  let main = document.querySelector('main');


  render(createTemplate(createSubmitHandler(onCreate)), main);
}

async function onCreate(data, form) {

  console.log(typeof (data['imageUrl']));

  console.log()

  if (!data['description'] || !data['type'] || !data['availability'] || !data['price'] || !data['imageUrl'] || !data['item']) {

    return alert("All fields are required!");
  }

  await createCar( data['item'], data['imageUrl'], data['price'], data['availability'], data['type'],data['description'] );
  /*item,
  imageUrl, 
  price, 
  availability,
  type,
  description
 */

  page.redirect('/catalog');

}