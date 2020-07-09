function solution() {
    const button = document.getElementById('submit');
    const location = document.getElementById('location');
    const validLocations = ['London', 'New York', 'Barcelona'];
    const forecast = document.getElementById('forecast');
    button.addEventListener('click', function exe() {
        if (validLocations.includes(location) == false) {
            forecast.textcontent = 'Error';
            return;
        }

        var currentLocation = async function getCurrentLocation() {
            return await fetch('https://judgetests.firebaseio.com/locations.json')
                .then(response => response.json())
                .then(data => data.find(e => e.name == location));
        }

        var el = async function getForecast() {
            return await fetch(`https://judgetests.firebaseio.com/forecast/today/${currentLocation.code}.json`)
                .then(response => response.json());

        }

        var upcoming = async function getUpcoming() {
            return await fetch(`https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`)
                .then(response => response.json());
        }

        forecast.css.display = 'block';
        const forecastPanel = document.createElement('div');
        forecastPanel.className = 'forecasts';

        var symbol = function () {
            switch (el.condition) {
                case 'Sunny':
                    return '&#x2600;';
                case 'Partly sunny':
                    return '&#x26C5;';
                case 'Overcast':
                    return '&#x2601;';
                case 'Rain':
                    return '&#x2614;';
            }
        }

        const weatherSymbol = document.createElement('span');
        weatherSymbol.className = 'condition symbol';
        weatherSymbol.textContent = symbol;

        forecastPanel.appendChild(weatherSymbol);

        const condition = document.createElement('span');
        condition.className = 'condition';

        const forecastLocation = document.createElement('span');
        forecastLocation.className = 'forecast-data';
        forecastLocation.textContent = el().name;

        const forecastDegrees = document.createElement('span');
        forecastDegrees.className = 'forecast-data';
        forecastDegrees.textContent = `${el.forecast.low}&#176;/${el.forecast.high}&#176;`;

        const forecastCondition = document.createElement('span');
        forecastCondition.className = 'forecast-data';
        forecastCondition.textContent = el.condition;

        condition.appendChild(forecastLocation);
        condition.appendChild(forecastDegrees);
        condition.appendChild(forecastCondition);

        upcoming.forEach(el => {
            const upcomingCondition = document.createElement('span');
            upcomingCondition.className = 'condition';

            const upcomingForecastLocation = document.createElement('span');
            upcomingForecastLocation.className = 'forecast-data';
            upcomingForecastLocation.textContent = el.name;

            const upcomingForecastDegrees = document.createElement('span');
            upcomingForecastDegrees.className = 'forecast-data';
            upcomingForecastDegrees.textContent = `${el.forecast.low}&#176;/${el.forecast.high}&#176;`;

            const upcomingForecastCondition = document.createElement('span');
            upcomingForecastCondition.className = 'forecast-data';
            upcomingForecastCondition.textContent = el.condition;

            upcomingCondition.appendChild(upcomingForecastLocation);
            upcomingCondition.appendChild(upcomingForecastDegrees);
            upcomingCondition.appendChild(upcomingForecastCondition);
        });
    });
}