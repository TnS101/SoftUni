import * as data from './monkeys';

$(() => {
    for (let i = 1; i < 3; i++) {
        const monkey = document.getElementsByClassName('monkey')[0].cloneNode(true);
        const element = data.monkeys[i];

        monkey.children[0].textContent = element.name;
        monkey.children[1].src = element.image;
        monkey.children[2].addEventListener('click', function (e) {
            e.preventDefault();
            monkey.children[3].style.display = 'block';
        });
        monkey.children[3].textContent = element.info;
    }
})