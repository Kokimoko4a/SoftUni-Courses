function solve() {
    console.log("//TODO")

    let addButton = document.getElementById('add');
    let openSection = document.getElementsByClassName('orange')[0];
    

    addButton.addEventListener('click', (event) => {

        event.preventDefault();
        
        let task = document.getElementById('task');
        let date = document.getElementById('date');
        let description = document.getElementById('description');

        if (task.value !== "" && date.value !== "" && description.value !== "") {
            
            let article = document.createElement('article');
            let h3 = document.createElement('h3');
            let pForDesc = document.createElement("p");
            let pDate = document.createElement('p');
            let div = document.createElement('div');
            div.classList.add("flex");
            let buttonStart = document.createElement('button');
            let buttonDelete = document.createElement('button');
            buttonStart.classList.add('green');
            buttonStart.textContent = "Start";
            buttonDelete.classList.add('red');
            buttonDelete.textContent = "Delete";

            h3.textContent = task.value;
            pForDesc.textContent = description.value;
            pDate.textContent = date.value;

            div.appendChild(buttonStart);
            div.appendChild(buttonDelete); // Append the buttons to the div
            article.appendChild(h3);
            article.appendChild(pForDesc); // Append the description paragraph
            article.appendChild(pDate); // Append the date paragraph
            article.appendChild(div);
            openSection.appendChild(article);
           
        
 
          
        }
 
    })
}