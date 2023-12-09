function addItem() {
    let menu = document.getElementById("menu");
    let inputWord = document.getElementById("newItemText");
    let inputValue = document.getElementById("newItemValue");

    let option = document.createElement('option');

    option.value = inputValue.value;
    option.textContent = inputWord.value;

    menu.appendChild(option);

    inputWord.value = "";
    inputValue.value = "";
}