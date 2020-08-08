function solve() {
    let tabs = document.querySelectorAll('tr');

    Array.from(tabs).forEach(element => {
        element.addEventListener('click', function exe() {
            if (element.style.backgroundColor == "rgb(65, 63, 94)") {
                element.style.backgroundColor = '';
            } else {
                Array.from(tabs).forEach(sub => {
                    sub.style.backgroundColor = '';
                });

                element.style.backgroundColor = "rgb(65, 63, 94)";
            }
        });
    });
}