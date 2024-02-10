class Company{

    departments;

    constructor(){

        this.departments = {};
    }

    addEmployee(name, salary, position, department){

        if (!(name) || !(salary) || !(position) || !(department)) {
            
            throw new Error("Invalid input!");
        }

        if (salary < 0) {
            throw new Error("Invalid input!");
        }

        let employee = {

            name,
            salary,
            position
            
        };

        if (!this.departments[department]) {
            
            this.departments[department] = {

                avg:0,
                sumSalary:0,
                employees:[]
            }
        }

        this.departments[department].employees.push(employee);
        this._updateDepartmentInfo(department,salary);
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    _updateDepartmentInfo(department,salary){

        let currDep = this.departments[department];
        currDep.sumSalary += salary;
        currDep.avg = currDep.sumSalary / currDep.employees.length;
    }

    bestDepartment(){

        let theBest =  Object.entries(this.departments).sort((a,b) => b[1].avg - a[1].avg)[0];

        let buff = `Best Department is: ${theBest[0]}\n`;
        buff += `Average salary: ${theBest[1].avg.toFixed(2)}\n`;

        theBest[1].employees.sort((emp1, emp2) => {

            return emp2.salary - emp1.salary || emp1.name.localeCompare(emp2.name);
        }).array.forEach(emp => {
            
            buff += `${emp.name} ${emp.salary} ${emp.position}\n`;

        });
        
        return buff.trimEnd();
    }
}