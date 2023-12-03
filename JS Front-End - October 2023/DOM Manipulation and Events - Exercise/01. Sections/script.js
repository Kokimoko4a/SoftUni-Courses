function create(words) {

   let parentDiv = document.getElementById("content");

   for (let index = 0; index < words.length; index++) {
      const element = words[index];


      let currDiv = document.createElement('div');

      parentDiv.appendChild(currDiv);

      let currParagraph = document.createElement("p");

      currParagraph.style.display = "none";

      currParagraph.textContent = element;

      currDiv.appendChild(currParagraph);



      currDiv.addEventListener('click', () => {

        
         currParagraph.style.display = "block";
        
      })


   }



}