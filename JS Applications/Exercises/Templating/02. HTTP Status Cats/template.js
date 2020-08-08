(() => {
    renderCatTemplate();

    function renderCatTemplate() {
        document.querySelectorAll('li').forEach(el => {
            el.getElementsByClassName('showBtn')[0].addEventListener('click', function (e) {
                e.preventDefault();
                el.getElementsByClassName('status')[0].style.display = 'block';
            });
        });
    }
});