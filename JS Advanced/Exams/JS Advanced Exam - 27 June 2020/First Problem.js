function solve() {
    var form = document.getElementById('container');

    var name = form.children[0];
    var age = form.children[1];
    var kind = form.children[2];
    var currentOwner = form.children[3];

    document.querySelectorAll('button')[0].addEventListener('click', function add(e) {
        e.preventDefault();
        if (name.value != '' && age.value != '' && Number(age) != undefined && kind.value != '' && currentOwner.value != '') {
            var li = document.createElement('li');
            var p = document.createElement('p');

            p.innerHTML = `<strong>${name.value}</strong> is a <strong>${age.value}</strong> year old <strong>${kind.value}</strong>`

            var span = document.createElement('span');
            span.textContent = `Owner: ${currentOwner.value}`;

            var button = document.createElement('button');
            button.textContent = 'Contact with owner';

            button.addEventListener('click', function adopt(e) {
                e.preventDefault();
                li.removeChild(li.querySelector('button'));
                var div = document.createElement('div');
                var input = document.createElement('input');
                input.placeholder = 'Enter your names';
                var adoptionButton = document.createElement('button');
                adoptionButton.textContent = 'Yes! I take it!';

                adoptionButton.addEventListener('click', function take(e) {
                    e.preventDefault();
                    if (input.value != '') {
                        li.removeChild(li.querySelector('div'));
                        li.children[1].textContent = `New Owner: ${input.value}`;
                        var killButton = document.createElement('button');
                        killButton.textContent = 'Checked';

                        killButton.addEventListener('click', function kill() {
                            li.parentNode.value = '';
                        });

                        li.appendChild(killButton);

                        document.getElementById('adopted').children[1].appendChild(li);
                    }
                });

                div.appendChild(input);
                div.appendChild(adoptionButton);
                li.appendChild(div);
            });

            li.appendChild(p);
            li.appendChild(span);
            li.appendChild(button);
            document.getElementById('adoption').children[1].appendChild(li);

            name.value = '';
            age.value = '';
            kind.value = '';
            currentOwner.value = '';
        }
    });
}