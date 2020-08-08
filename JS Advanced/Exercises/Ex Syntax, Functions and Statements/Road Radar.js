function roadRadar(array) {
    let speed = array[0];
    let zone = array[1];
    let limit = 0;
    if (zone == "city") {
        limit += 50;
    } else if (zone == "motorway") {
        limit += 130;
    } else if (zone == "interstate") {
        limit += 90;
    } else if (zone == "residential") {
        limit += 20;
    }

    if (speed - limit <= 0) {

    } else if (speed - limit <= 20) {
        console.log("speeding");
    } else if (speed - limit <= 40 && speed - limit > 20) {
        console.log("excessive speeding");
    } else if (speed - limit > 40) {
        console.log("reckless driving");
    }
}