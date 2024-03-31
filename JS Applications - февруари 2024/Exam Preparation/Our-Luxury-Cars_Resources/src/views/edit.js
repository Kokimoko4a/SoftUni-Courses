import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { createSubmitHandler } from "../utils.js";
import { updateCar, getCarById } from "../data/cars.js";
import { page } from "../lib.js";


const editTemplate = (car, onEdit) => html`

<!-- Edit Page (Only for logged-in users) -->
<section id="edit">
  <div class="form form-item">
    <h2>Edit Your Item</h2>
    <form class="edit-form" @submit=${onEdit}>
      <input type="text" name="item" id="item" placeholder="Item" .value=${car.item} />
      <input
        type="text"
        name="imageUrl"
        id="item-image"
        placeholder="Your item Image URL"
        .value=${car.imageUrl}
      />
      <input
        type="text"
        name="price"
        id="price"
        placeholder="Price in Euro"
        .value=${car.price}
      />
      <input
        type="text"
        name="availability"
        id="availability"
        placeholder="Availability Information"
        .value=${car.availability}
      />
      <input
        type="text"
        name="type"
        id="type"
        placeholder="Item Type"
        .value=${car.type}
      />
      <textarea
        id="description"
        name="description"
        placeholder="More About The Item"
        .value=${car.description}
        rows="10"
        cols="50"
      ></textarea>
      <button type="submit">Edit</button>
    </form>
  </div>
</section>
`;

export async function showEdit(ctx) {

    const id = ctx.params.id;

    const car = await getCarById(id);
    let main = document.querySelector('main');


    render(editTemplate(car,createSubmitHandler(onEdit)), main);

    async function onEdit(data, form) {


    
        if (!data['description'] || !data['type'] || !data['availability'] || !data['price'] || !data['imageUrl'] || !data['item']) {
    
            return alert("All fields are required!");
        }
    
        await updateCar(id,data['item'], data['imageUrl'], data['price'], data['availability'], data['type'],data['description']);
    
       page.redirect('/catalog/' + id);
    
    }
}

/*<section id="edit">
<div class="form form-auto">
  <h2>Edit Your Car</h2>
  <form class="edit-form" @submit=${onEdit}>
    <input type="text" name="model" id="model" placeholder="Model"     .value=${car.model} />
    <input
      type="text"
      name="imageUrl"
      id="car-image"
      placeholder="Your Car Image URL"
      .value=${car.imageUrl}
    />
    <input
      type="text"
      name="price"
      id="price"
      placeholder="Price in Euro"
      .value=${car.price}
    />
    <input
      type="number"
      name="weight"
      id="weight"
      placeholder="Weight in Kg"
      .value=${car.weight}
    />
    <input
      type="text"
      name="speed"
      id="speed"
      placeholder="Top Speed in Kmh"
      .value=${car.speed}
    />
    <textarea
      id="about"
      name="about"
      placeholder="More About The Car"
      rows="10"
      cols="50"
      .value=${car.about}
    ></textarea>
    <button type="submit">Edit</button>
  </form>
</div>
</section> */

