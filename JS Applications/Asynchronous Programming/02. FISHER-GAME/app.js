import * as data from './data.js';

function attachEvents() {
    document.getElementsByClassName('load')[0].addEventListener('click', function () {
        const result = data.getData();
        const origin = document.getElementsByClassName('catch')[0];
        for (let i = 0; i < result.length; i++) {
            const element = result[i];
            const details = document.cloneNode(origin);
            details.setAttribute(`data-id, ${element.id}`);
            const info = details.children[0];
            info.children[1] = element.angler;
            info.children[3] = element.weight;
            info.children[5] = element.species;
            info.children[7] = element.location;
            info.children[9] = element.bait;
            info.children[11] = element.captureTime;

            info.children[13].addEventListener('click', function () {
                data.createEntry(element.id);
            });
            info.children[14].addEventListener('click', function () {
                data.deleteEntry(element.id);
                details.innerHTML = '';
            });

            document.getElementById('catches').appendChild(details);
        }
        origin.textContent = '';
    });

    document.getElementsByClassName('add')[0].addEventListener('click', function () {
        const formChildren = document.getElementById('addForm').children;
        data.createEntry({
            angler: formChildren[0],
            weight: formChildren[1],
            species: formChildren[2],
            location: formChildren[3],
            bait: formChildren[4],
            captureTime: formChildren[5]
        });
    });
}

attachEvents();