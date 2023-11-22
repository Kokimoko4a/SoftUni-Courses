function count(text){

   text = text.toLowerCase();

   let arrEl = text.split(" ");

   let map = new Map();


   arrEl.forEach(element => {
    if (map.has(element)) {
        
        let oldValue = map.get(element);
        let newValue = oldValue + 1;
        map.set(element,newValue);
    }

    else{
        map.set(element,1);
    }


   });


   let reultArray = [];

   map.forEach((value,key)=> {

    if (value%2 !==0) {
        reultArray.push(key);
    }

   })
   console.log(reultArray.join(" "));
}

count('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');