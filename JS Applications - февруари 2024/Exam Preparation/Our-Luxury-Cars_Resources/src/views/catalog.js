import { getAllCars } from "../data/cars.js";
import { html, render } from "../../node_modules/lit-html/lit-html.js";


let catalogTemp = (cars) => html`

<h2>Characters</h2>
  <section id="characters">

  ${cars.length ?  cars.map(carsTemplate) : html` <h2>No added Heroes yet.</h2>`}
</section>
`;

const carsTemplate = (car) => html`

<div class="character">
<img src=${car.imageUrl} alt="example1" />
<div class="hero-info">
  <h3 class="category">${car.category}</h3>
  <p class="description">${car.description}</p>
  <a class="details-btn" href="/catalog/${car._id}">More Info</a>
</div>
`
  

export async function showCatalog(ctx) {

  let cars = await getAllCars();

  let main = document.querySelector('main');


  render(catalogTemp(cars), main);
}