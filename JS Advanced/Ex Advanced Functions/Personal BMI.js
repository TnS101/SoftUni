function solution(name, age, weight, height) {
    let bmi = 0;
    let status = '';

    let output = new class {};

    output.name = name;
    output.personalInfo = {
        age: age,
        weight: weight,
        height: height,
    }

    bmi = Math.floor(weight / Math.pow(height / 100, 2));

    age <= 20 ? bmi : bmi += 1;

    if (bmi < 18.5) status = 'underweight';
    else if (bmi < 25) status = 'normal';
    else if (bmi < 30) status = 'overweight';
    else {
        status = 'obese';
        output.recommendation = 'admission required'
    };


    output.BMI = bmi;

    output.status = status;

    return output;
}

console.log(solution('Honey Boo Boo', 9, 57, 137));
console.log(solution('Peter', 29, 75, 182));
console.log(solution('Ivan', 20, 55, 200));
console.log(solution('Dragan', 20, 80, 185));