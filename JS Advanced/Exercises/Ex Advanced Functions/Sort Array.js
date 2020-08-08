function solution(array, order) {
    return order == 'asc' ? array.sort((a, b) => a - b) : array.sort((a, b) => b - a);
}

console.log(solution([3, 1, 2, 10], 'asc'));
solution([14, 7, 17, 6, 8], 'asc');