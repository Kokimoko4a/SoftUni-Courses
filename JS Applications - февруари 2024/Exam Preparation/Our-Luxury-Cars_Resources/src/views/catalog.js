import { getAllCars } from "../data/cars.js";
import { html, render } from "../../node_modules/lit-html/lit-html.js";


let catalogTemp = (cars) => html`

<h3 class="heading">Market</h3>
<section id="dashboard">

  ${cars.length ?  cars.map(carsTemplate) : html` <h3 class="empty">No Items Yet</h3>`}
</section>
`;

const carsTemplate = (car) => html`

<div class="item">
    <img src=${car.imageUrl} alt="example1" />
    <h3 class="model">${car.item}</h3>
    <div class="item-info">
      <p class="price">Price: €${car.price}</p>
      <p class="availability">
        ${car.availability}
      </p>
      <p class="type">Type: ${car.type}</p>
    </div>
    <a class="details-btn" href="/catalog/${car._id}">Uncover More</a>
  </div>
`
  

export async function showCatalog(ctx) {

  let cars = await getAllCars();

  let main = document.querySelector('main');


  render(catalogTemp(cars), main);
}

/*<!-- Dashboard page -->

  <!-- Display a div with information about every post (if any)-->
  
  <div class="item">
    <img src="./images/controller.png" alt="example1" />
    <h3 class="model">Neural Impulse Controller</h3>
    <div class="item-info">
      <p class="price">Price: €799</p>
      <p class="availability">Underground black markets</p>
      <p class="type">Type: Experimental</p>
    </div>
    <a class="details-btn" href="#">Uncover More</a>
  </div>
  <div class="item">
    <img src="./images/drone.png" alt="example1" />
    <h3 class="model">Sky Seeker Drone</h3>
    <div class="item-info">
      <p class="price">Price: €1200</p>
      <p class="availability">Mass-Market Retail, Online Marketplace</p>
      <p class="type">Type: Advanced Surveillance</p>
    </div>
    <a class="details-btn" href="#">Uncover More</a>
  </div>
</section>
<!-- Display an h2 if there are no posts -->

 */