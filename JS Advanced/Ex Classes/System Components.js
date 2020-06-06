function solution(array) {
    let result = {};

    for (let index = 0; index < array.length; index++) {
        let [system, component, sub] = array[index].split(' | ');

        if (result.hasOwnProperty(system) === false) {
            result[system] = {};
        }

        if (result[system].hasOwnProperty(component) === false) {
            component = `|||${component}`;
            result[system][component] = [];
        }

        result[system][component].push(`||||||${sub}`);
    }

    console.log(result);
}

solution(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security'
]);