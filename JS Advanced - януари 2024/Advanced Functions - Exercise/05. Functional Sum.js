function add(num) {
    let sum = num;
  
    function innerAdd(nextNum) {
      sum += nextNum;
      return innerAdd;
    }
  
    innerAdd.toString = function() {
      return sum;
    };
  
    return innerAdd;
  }

