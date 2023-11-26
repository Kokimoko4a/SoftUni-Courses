function search() {
   let towns = Array.from(document.getElementsByTagName("li"));
   let searchString = document.getElementById("searchText").value.toLowerCase();
   let result = document.getElementById("result");
   let matches = 0;

   for (let index = 0; index < towns.length; index++) {
      const element = towns[index];
      element.style.textDecoration = "none";
   }

   for (let index = 0; index < towns.length; index++) {
      let element = towns[index];
      
      if (element.textContent.toLowerCase().includes(searchString)) {
         
         console.log(12);
         element.style.textDecoration = "underline";
         element.style.fontWeight = "bold";
         matches++;
      }
   }

   result.textContent = `${matches} matches found`;

}
