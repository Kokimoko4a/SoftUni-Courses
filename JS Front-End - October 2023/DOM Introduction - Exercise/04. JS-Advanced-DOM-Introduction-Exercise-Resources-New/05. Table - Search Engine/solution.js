function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      
      let searchString = document.getElementById("searchField");
      let table = Array.from(document.getElementsByTagName("tr"));


      for (let index = 2; index < table.length; index++) {
         let element = table[index];

         element.classList.remove("select");         
      }

      for (let index = 2; index < table.length; index++) {
         let element = table[index];

        if ( element.textContent.includes(searchString.value)) {

         element.classList.add("select");
        }

         
         
      }
      
      searchString.value = " ";
      

   }
}