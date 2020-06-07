function create(words) {
    let parent = document.getElementById('content');
    words.forEach(element => {
        let child = document.createElement('div');
        let paragraph = document.createElement('p');
        paragraph.textContent = element;
        paragraph.style.display = 'none';

        child.appendChild(paragraph);

        child.addEventListener('click', function exe() {
            paragraph.style.display = 'block';
        });

        parent.appendChild(child);
    });
}