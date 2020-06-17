function solution(car) {
    let volume;

    if (car.power - 90 <= 15) {
        car.power = 90;
        volume = 1800;
    } else if (car.power - 90 <= 30) {
        car.power = 120;
        volume = 2400;
    }

    if (car.power - 120 >= 40) {
        car.power = 200;
        volume = 3500;
    }

    let wheel;

    wheel = car.wheelsize % 2 != 0 ? car.wheelsize : car.wheelsize - 1;

    return {
        model: car.model,
        engine: {
            power: car.power,
            volume: volume
        },
        carriage: {
            type: car.carriage,
            color: car.color
        },
        wheels: [wheel, wheel, wheel, wheel]
    }
}

console.log(solution({
    model: 'Brichka',
    power: 65,
    color: 'white',
    carriage: 'hatchback',
    wheelsize: 16
}));