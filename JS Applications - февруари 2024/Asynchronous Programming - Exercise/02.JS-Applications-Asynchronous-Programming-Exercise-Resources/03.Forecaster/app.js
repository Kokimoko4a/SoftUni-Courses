function attachEvents() {

    const urlLocations = 'http://localhost:3030/jsonstore/forecaster/locations';

    let buttonSubmit = document.getElementById('submit');
    let input = document.getElementById('location');
    let currentConditions = document.getElementById('current');
    let upcomingConditions = document.getElementById('upcoming');
    let forecastDiv = document.getElementById('forecast');


    buttonSubmit.addEventListener('click', (e) => {

        e.preventDefault();

        fetch(urlLocations).then(data => data.json()).catch(err => forecastDiv.textContent = err.message).then(data => {


            let locationObj = data.find(x => x.name === input.value);

            fetch(`http://localhost:3030/jsonstore/forecaster/today/${locationObj.code}`).then(data => data.json()).catch(err => forecastDiv.textContent = err.message).then(data => {


                forecastDiv.style.display = 'block';

                let div = document.createElement('div');
                div.classList.add('forecasts');

                let spanWeatherSymbol = document.createElement('span');
                spanWeatherSymbol.classList.add('condition');
                spanWeatherSymbol.classList.add('symbol');

                if (data.forecast.condition === 'Sunny') {

                    spanWeatherSymbol.innerHTML = '&#x2600';
                }

                else if (data.forecast.condition === 'Partly sunny') {

                    spanWeatherSymbol.innerHTML = '&#x26C5';

                }

                else if (data.forecast.condition === 'Overcast') {

                    spanWeatherSymbol.innerHTML = '&#x2601';

                }

                else if (data.forecast.condition === 'Rain') {

                    spanWeatherSymbol.innerHTML = '&#x2614';

                }

                else if (data.forecast.condition === 'Degrees') {

                    spanWeatherSymbol.innerHTML = '&#176';

                }

                let spanCondition = document.createElement('span');
                spanCondition.classList.add('condition');




                let spanForecastDataForName = document.createElement('span');
                spanForecastDataForName.classList.add('forecast-data');
                spanForecastDataForName.textContent = data.name;


                let spanForecastDataForDegres = document.createElement('span');
                spanForecastDataForDegres.classList.add('forecast-data');
                spanForecastDataForDegres.textContent = data.forecast.low + '°' + '/' + data.forecast.high + "°";


                let spanForecastDataForCondition = document.createElement('span');
                spanForecastDataForCondition.classList.add('forecast-data');
                spanForecastDataForCondition.textContent = data.forecast.condition;

                currentConditions.appendChild(div);

                div.appendChild(spanWeatherSymbol);
                div.appendChild(spanCondition);
                spanCondition.appendChild(spanForecastDataForName);
                spanCondition.appendChild(spanForecastDataForDegres);
                spanCondition.appendChild(spanForecastDataForCondition);


            }).catch(err => forecastDiv.textContent = err.message)


            fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${locationObj.code}`).then(data => data.json()).catch(err => forecastDiv.textContent = err.message).then(data => {


                let divForecastInfo = document.createElement('div');
                divForecastInfo.classList.add('forecast-info');
                upcomingConditions.appendChild(divForecastInfo);

                for (let index = 0; index < data.forecast.length; index++) {
                    const element = data.forecast[index];


                    let spanUpcoming = document.createElement('span');
                    spanUpcoming.classList.add('upcoming');

                    let spanSymbol = document.createElement('span');
                    spanSymbol.innerHTML = getSymbol(element.condition);
                    spanSymbol.classList.add('symbol');

                    let spanDegrees = document.createElement('span');
                    spanDegrees.classList.add('forecast-data');
                    spanDegrees.textContent = element.low + '°' + '/' + element.high + '°';


                    let spanCondition = document.createElement('span');
                    spanCondition.classList.add('forecast-data');
                    spanCondition.textContent = data.name;

                    divForecastInfo.appendChild(spanUpcoming);
                    spanUpcoming.appendChild(spanSymbol);
                    spanUpcoming.appendChild(spanDegrees);
                    spanUpcoming.appendChild(spanCondition);



                }




            }).catch(err => forecastDiv.textContent = err.message)




        }).catch(err => forecastDiv.textContent = err.message);

        function getSymbol(code) {

            switch (code) {
                case 'Sunny':
                    return '&#x2600';
                    break;

                case 'Partly sunny':
                    return '&#x26C5';
                    break;

                case 'Overcast':
                    return '&#x2601';
                    break;

                case 'Rain':
                    return '&#x2614';
                    break;

                case 'Degrees':
                    return '&#176';
                    break;
            }
        }

    });




}

attachEvents();