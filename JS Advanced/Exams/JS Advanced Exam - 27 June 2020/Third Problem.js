class VeterinaryClinic {
    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = {};
        this.totalProfit = 0;
        this.currentWorkload = 0;
        this.result = {};
    }

    newCustomer(ownerName, petName, kind, procedures) {
        if (this.capacity < this.clients.length) {
            throw new Error('Sorry, we are not able to accept more patients!');
        }

        if (this.clients[ownerName] != undefined && this.clients[ownerName].pets.find(c => c.petName === petName) !== undefined && this.clients[ownerName].pets.find(c => c.petName === petName).procedures.length > 0) {
            throw new Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${procedures.join(', ')}.`);
        }

        if (this.clients.hasOwnProperty(ownerName) !== false) {
            this.clients[ownerName].pets.push({ petName: petName, kind: kind, procedures: procedures });
            this.result[ownerName].pets.push({ petName: petName, kind: kind, procedures: procedures });
        } else {
            this.clients[ownerName] = { ownerName: ownerName, pets: [{ petName: petName, kind: kind, procedures: procedures }] };
            this.result[ownerName] = { ownerName: ownerName, pets: [{ petName: petName, kind: kind, procedures: procedures }] };
        }

        return `Welcome ${petName}!`;
    }

    onLeaving(ownerName, petName) {
        if (this.clients.hasOwnProperty(ownerName) === false) {
            throw new Error('Sorry, there is no such client!');
        }

        var client = this.clients[ownerName];

        if (client.pets.find(p => p.petName === petName) === undefined || client.pets.find(p => p.petName === petName).procedures.length == 0) {
            throw new Error(`Sorry, there are no procedures for ${petName}`);
        }

        var pet = client.pets.find(p => p.petName === petName);

        pet.procedures = [];

        this.totalProfit += 500;
        this.currentWorkload -= 1 / this.capacity;

        return `Goodbye ${petName}. Stay safe!`
    }

    toString() {
        var pets = 0;

        for (const ownerName of Object.keys(this.clients)) {
            var client = this.clients[ownerName];
            var count = 0;
            client.pets.forEach(p => {
                count += p.procedures.length;
            });

            if (count > 0) {
                pets++;
            }
        }

        var output = [`${this.clinicName} is ${Math.ceil(pets * this.capacity)}% busy today!`, `Total profit: ${this.totalProfit.toFixed(2)}$`];

        for (const ownerName in this.clients) {
            if (this.clients.hasOwnProperty(ownerName)) {
                const client = this.clients[ownerName];
                //this.result[ownerName].sort((a, b) => (a.ownerName, b.ownerName));
                //client.pets.sort((a, b) => (a.petName, b.petName));

                output.push(`${ownerName} with:`);
                client.pets.forEach(p => {
                    output.push(`---${p.petName} - a ${p.kind.toLowerCase()} that needs: ${p.procedures.join(', ')}`);
                });
            }
        }

        return output.join('\n');
    }
}