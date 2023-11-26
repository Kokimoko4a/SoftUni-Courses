function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      class Restaurant {
         constructor(name, array) {
            this.name = name;
            this.workers = array;
         }
      }

      class Worker {
         constructor(name, salary) {
            this.name = name;
            this.salary = salary;
         }
      }

      let input = document.getElementsByTagName("textarea")[0];
      let output = document.getElementById("bestRestaurant");

      let array = input.value.trim().split('\n');

      let list = [];

      for (let index = 0; index < array.length; index++) {
         const element = array[index];

         let [name, people] = element.split(" - ");

         let peopleAndSalaries = [];

         people = people.split(", ");

         for (let index = 0; index < people.length; index += 2) {

            let name = people[index].split(" ")[0];
            let salary = parseFloat(people[index].split(" ")[1]);

            peopleAndSalaries.push(new Worker(name, parseFloat(salary)));
         }

         let curr = new Restaurant(name, peopleAndSalaries);

         list.push(curr);
      }

      let maxAverageSalary = 0;
      let bestSalary = 0;
      let bestRestaurant = "";

      for (let index = 0; index < list.length; index++) {
         const element = list[index];

         let currSalary = 0;

         element.workers.forEach(worker => {
            currSalary += worker.salary;
         });

         if (currSalary / element.workers.length > maxAverageSalary) {
            maxAverageSalary = currSalary / element.workers.length;
            bestRestaurant = element.name;
         }
      }

      let bestRestaurantEntity = list.find(x => x.name === bestRestaurant);

      for (let index = 0; index < bestRestaurantEntity.workers.length; index++) {
         const element = bestRestaurantEntity.workers[index];

         if (element.salary > bestSalary) {
            bestSalary = element.salary;
         }
      }

      console.log(`Name: ${bestRestaurant} Average Salary: ${maxAverageSalary} Best Salary: ${bestSalary}`);

      let pRes = document.createElement("p");

      output.appendChild(pRes);

      pRes.textContent = `Name: ${bestRestaurant} Average Salary: ${maxAverageSalary} Best Salary: ${bestSalary}`;

      
   }
}