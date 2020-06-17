function solution(worker) {
    if (worker.dizziness == true) {
        let sum = worker.weight * worker.experience / 10;
        worker.levelOfHydrated += sum;
        worker.dizziness = false;
    }

    return worker;
}

console.log(solution({
    weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false
}));