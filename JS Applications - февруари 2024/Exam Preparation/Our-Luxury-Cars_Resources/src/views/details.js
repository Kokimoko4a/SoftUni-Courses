import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { createSubmitHandler, getUserData } from "../utils.js";
import { createCar, deleteEvent, getCarById } from "../data/cars.js";
import { page } from "../lib.js";

 const detailsTemplate = (data, isOwner, onDelete) => html`
 
 <section id="details">
    <div id="details-wrapper">
      <img id="details-img" src=${data.imageUrl} alt="example1" />
      <div>
      <p id="details-category">${data.category}</p>
      <div id="info-wrapper">
        <div id="details-description">
          <p id="description">
            ${data.description}
            </p>
             <p id ="more-info">
              ${data.moreInfo}
                  </p>
        </div>
      </div>
     
        ${isOwner ? html` <div id="action-buttons">
        <a href="/edit/${data._id}" id="edit-btn">Edit</a>
        <a href="javascript:void(0)" id="delete-btn"  @click=${onDelete}>Delete</a>`: null}
   

    </div>
      </div>
  </div>
</section>
 ` ;

 export async function showDetails(ctx){

    const id = ctx.params.id;
    let main = document.querySelector('main');

    const car = await getCarById(id);


    console.log(car._ownerId);
    const user = getUserData();
    const hasUser = !!user;
    const isOwner = hasUser && user._id == car._ownerId;

  console.log(car.description);

    render(detailsTemplate(car,isOwner, onDelete), main);

    async function onDelete(){

        let choice = confirm("Are you sure?");

        if (choice ) {
            
            await deleteEvent(id);

            page.redirect('/catalog');
        }
       
    }
 }

 /*<section id="details">
 <div id="details-wrapper">
   <img id="details-img" src=${data.imageUrl}alt="example1" />
   <p id="details-title">${data.model}</p>
   <div id="info-wrapper">
     <div id="details-description">
       <p class="price">Price: €${data.price}</p>
       <p class="weight">Weight: ${data.weight} kg</p>
       <p class="top-speed">Top Speed: ${data.speed} kph</p>
       <p id="car-description">
         ${data.about}</p>
     </div>

     ${isOwner ? html`  <div id="action-buttons">
     <a href="/edit/${data._id}" id="edit-btn">Edit</a>
     <a href="javascript:void(0)" id="delete-btn" @click=${onDelete}>Delete</a>
   </div>` : null}
   </div>
 </div>
</section> */