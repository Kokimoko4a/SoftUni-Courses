function solve() {
  let input = document.getElementById("text").value.toLowerCase();

  let namingConvention = document.getElementById("naming-convention").value;

  let words = input.split(" ");

  let output = document.getElementById("result");

  let result = "";

  if (namingConvention === "Camel Case") {

    result += words[0];

    for (let index = 1; index < words.length; index++) {
      const element = words[index];

      result += element.charAt(0).toUpperCase();

      for (let index = 1; index < element.length; index++) {

        result += element[index];

      }
    }

  }

  else if (namingConvention === "Pascal Case") {

    for (let index = 0; index < words.length; index++) {
      const element = words[index];

      result += element.charAt(0).toUpperCase();

      for (let index = 1; index < element.length; index++) {

        result += element[index];

      }
    }
  }

  else{
    result = "Error!";
  }

  output.textContent = result;


 

}