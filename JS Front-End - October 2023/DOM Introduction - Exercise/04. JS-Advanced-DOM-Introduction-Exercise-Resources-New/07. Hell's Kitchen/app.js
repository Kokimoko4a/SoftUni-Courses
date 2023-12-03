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

      let listOfRestaurants = [];

      let input = document.getElementsByTagName("textarea")[0];
      let outputForRes = document.getElementsByTagName("p")[0];
      let outputForWorkers = document.getElementsByTagName("p")[1];

      let stringFromInputRes = JSON.parse(input.value);

      let arrayFromInputRes = stringFromInputRes;

      let higherAverageSalary = 0;
      let bestRestaurantName = "";

      for (let index = 0; index < arrayFromInputRes.length; index++) {
         let currData = arrayFromInputRes[index].split(" - ");
         let nameOfRes = currData[0];
         let workers = currData[1].split(", ");
         let currListWithWorkers = [];

         workers.forEach(element => {
            let currDataForWorker = element.split(" ");
            let currWorker = new Worker(currDataForWorker[0], parseFloat(currDataForWorker[1]));
            currListWithWorkers.push(currWorker);
         });

         let existingRes = listOfRestaurants.find(res => res.name === nameOfRes);

         if (existingRes) {
            // Update existing restaurant
            existingRes.workers = existingRes.workers.concat(currListWithWorkers);
         } else {
            // Create new restaurant
            let currRes = new Restaurant(nameOfRes, currListWithWorkers);
            listOfRestaurants.push(currRes);
         }
      }

      listOfRestaurants.forEach(element => {
         let currSumOfSalaries = element.workers.reduce((sum, worker) => sum + worker.salary, 0);
         let currAverageSalary = currSumOfSalaries / element.workers.length;

         if (currAverageSalary >= higherAverageSalary) {
            higherAverageSalary = currAverageSalary;
            bestRestaurantName = element.name;
         }
      });

      let bestRestaurantObj = listOfRestaurants.find(x => x.name === bestRestaurantName);
      let bestSalaryInBestRestaurant = Math.max(...bestRestaurantObj.workers.map(worker => worker.salary));

      let sortedWorkers = bestRestaurantObj.workers
         .sort((a, b) => b.salary - a.salary)
         .map(worker => `Name: ${worker.name} With Salary: ${worker.salary}`);

      let outputText = `Name: ${bestRestaurantName} Average Salary: ${higherAverageSalary.toFixed(2)} Best Salary: ${bestSalaryInBestRestaurant.toFixed(2)}`;
      outputForRes.textContent = outputText;

      outputForWorkers.textContent = sortedWorkers.join(' ');
   }
}