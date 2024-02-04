function calculator() {
    let num1Element, num2Element, resultElement;
  
    function init(selector1, selector2, resultSelector) {
      num1Element = document.querySelector(selector1);
      num2Element = document.querySelector(selector2);
      resultElement = document.querySelector(resultSelector);
    }
  
    function add() {
      const num1 = parseFloat(num1Element.value);
      const num2 = parseFloat(num2Element.value);
      const sum = num1 + num2;
      resultElement.textContent = sum;
    }
  
    function subtract() {
      const num1 = parseFloat(num1Element.value);
      const num2 = parseFloat(num2Element.value);
      const difference = num1 - num2;
      resultElement.textContent = difference;
    }
  
    return {
      init: init,
      add: add,
      subtract: subtract
    };
  }



