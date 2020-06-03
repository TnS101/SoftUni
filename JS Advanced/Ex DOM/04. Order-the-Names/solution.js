function solve() {
    let name = document.getElementsByTagName('input').value;
    let array = document.getElementsByTagName('ol');
    let tArray = Array.of(array);

    for (let i = 0; i < array.length; i++) {
        if (array.item(i).value[0] == name[0] && array.item(i).value != null) {
            array.item(i).value = [array.item(i).value, name].join(', ');
        } else {
            tArray.push(name);
        }
    }

    name = '';

    tArray.sort();
}