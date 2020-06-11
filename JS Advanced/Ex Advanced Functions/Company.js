class Company {
    constructor() {
        this.company = [];
    }

    addEmployee(username, salary, position, department) {
        if (username == '' || username == null || username == undefined || salary < 0) throw new Error('Invalid input!');

        let employee = { name: username, position: position, salary: salary, department: department };

        this.company.push(employee);

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let result = '';

        this.company.map(x => x.department).sort((a, b) => b.salary - a.salary);

        this.company.sort((a, b) => b.salary - a.salary);
        this.company.sort((a, b) => b.name - a.name);
        this.company.sort((a, b) => a.name.length - b.name.length);

        let naiDobrataFirma = this.company[0].department;
        let bestDepart = this.company.filter(x => x.department == naiDobrataFirma);
        let average = 0;

        result += `Best department is: ${naiDobrataFirma}`;

        for (let index = 0; index < bestDepart.length; index++) {
            average += bestDepart[index].salary;
        }

        result += `\n${average / bestDepart.length}`;

        for (let index = 0; index < bestDepart.length; index++) {
            const employee = bestDepart[index];
            result += `\n${employee.name} ${employee.salary} ${employee.position}`;
        }

        return result;
    }
}

let  c  =  new  Company();
c.addEmployee("Stanimir",  2000,  "engineer",  "Construction");
c.addEmployee("Pesho",  1500,  "electrical engineer",  "Construction");
c.addEmployee("Slavi",  500,  "dyer",  "Construction");
c.addEmployee("Stan",  2000,  "architect",  "Construction");
c.addEmployee("Stanimir",  1200,  "digital marketing manager",  "Marketing");
c.addEmployee("Pesho",  1000,  "graphical designer",  "Marketing");
c.addEmployee("Gosho",  1350,  "HR",  "Human resources");
console.log(c.bestDepartment());