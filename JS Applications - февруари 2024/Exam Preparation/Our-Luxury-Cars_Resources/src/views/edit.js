import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { createSubmitHandler } from "../utils.js";
import { updateCar, getCarById } from "../data/cars.js";
import { page } from "../lib.js";


const editTemplate = (car, onEdit) => html`

<section id="edit">
    <div class="form">
      <img class="border" src=${car.imageUrl} alt="">
      <h2>Edit Character</h2>
      <form class="edit-form" @submit=${onEdit}>
        <input
        type="text"
        name="category"
        id="category"
        placeholder="Character Type"
        .value=${car.category}
      />
      <input
        type="text"
        name="image-url"
        id="image-url"
        placeholder="Image URL"
        .value=${car.imageUrl}
      />
      <textarea
      id="description"
      name="description"
      placeholder="Description"
      rows="2"
      cols="10"
      .value=${car.description}
    ></textarea>
    <textarea
      id="additional-info"
      name="additional-info"
      placeholder="Additional Info"
      rows="2"
      cols="10"
      .value=${car.moreInfo}
    ></textarea>
        <button type="submit">Edit</button>
      </form>
      <img class="border" src="./images/border.png" alt="">
    </div>
  </section>

`;

export async function showEdit(ctx) {

    const id = ctx.params.id;

    const car = await getCarById(id);
    let main = document.querySelector('main');


    render(editTemplate(car,createSubmitHandler(onEdit)), main);

    async function onEdit(character, form) {


    
        if (!character['category'] || !character['image-url']  || !character['description']  || !character['additional-info']) {
    
            return alert("All fields are required!");
        }
    
        await updateCar(id,character['category'], character['image-url'], character['description'], character['additional-info']);
    
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

