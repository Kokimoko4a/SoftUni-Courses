function solve() {

  let input = document.getElementsByTagName('textarea')[0];
  let button = document.getElementsByTagName('button')[0];
  let tableBody = document.querySelector('tbody');
  let buttonForBuying = document.getElementsByTagName('button')[1];
  let itemsAdded = [];
  let output = document.getElementsByTagName('textarea')[1];

  button.addEventListener('click', addNewItem);
  buttonForBuying.addEventListener('click', buyItems);



  function addNewItem() {

    let items = JSON.parse(input.value);

    for (let i = 0; i < items.length; i++) {
      const element = items[i];

      let row = document.createElement('tr');
      tableBody.appendChild(row);


      let tableDataForImage = document.createElement('td');
      row.appendChild(tableDataForImage);

      let imageTag = document.createElement('img');

      imageTag.setAttribute('src', element.img);

      tableDataForImage.appendChild(imageTag);


      let tableDataForName = document.createElement('td');

      row.appendChild(tableDataForName);

      let currParagraph = document.createElement('p');

      tableDataForName.appendChild(currParagraph);

      currParagraph.textContent = element.name;


      let tableDataForPrice = document.createElement('td');

      row.appendChild(tableDataForPrice);

      let currParagraphForPrice = document.createElement('p');

      tableDataForPrice.appendChild(currParagraphForPrice);

      currParagraphForPrice.textContent = element.price;


      let tableDataForDecorationFactor = document.createElement('td');

      row.appendChild(tableDataForDecorationFactor);

      let currParagraphForDecorationFactor = document.createElement('p');

      tableDataForDecorationFactor.appendChild(currParagraphForDecorationFactor);

      currParagraphForDecorationFactor.textContent = element.decFactor;


      let tableDataForCheckBox = document.createElement('td');
      row.appendChild(tableDataForCheckBox);

      let inputTag = document.createElement('input');

      inputTag.setAttribute('type', 'checkbox');
      

      inputTag.checked = false;

      tableDataForCheckBox.appendChild(inputTag);


      itemsAdded.push(element);
   
  
      inputTag.addEventListener('change', createCheckboxHandler);

      function createCheckboxHandler(){

        element.isChecked = this.checked;
      }
  

    }
  }


  function buyItems() {

    

    let wantedItems = itemsAdded.filter(x => x.isChecked === true);



    if (wantedItems.length === 0) {
      
    }

    else{
    //alert(itemsAdded.length);
    let boughtFurnitureItems = [];
    let totalPrice = 0;
    let totalDecFac = 0;

    for (let index = 0; index < wantedItems.length; index++) {
      const element = wantedItems[index];

      boughtFurnitureItems.push(element.name);

      console.log(typeof(element.price));

      totalPrice += parseFloat(element.price);

      totalDecFac += element.decFactor;

    }

    output.value += `Bought furniture: ${boughtFurnitureItems.join(", ")}\n`;

    let averageDecFac = totalDecFac / wantedItems.length;

    output.value +=   `Total price: ${totalPrice.toFixed(2)}\n` + `Average decoration factor: ${averageDecFac.toFixed(1)}`;



  }


  }
}