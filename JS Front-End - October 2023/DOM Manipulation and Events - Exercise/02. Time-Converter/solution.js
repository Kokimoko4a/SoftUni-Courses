function attachEventsListeners() {

    let days = document.getElementById("days");
    let hours = document.getElementById("hours");
    let minutes = document.getElementById("minutes");
    let seconds = document.getElementById("seconds");

    let daysButton = document.getElementById("daysBtn");
    let hoursButton = document.getElementById("hoursBtn");
    let minutesButton = document.getElementById("minutesBtn");
    let secondsButton = document.getElementById("secondsBtn");

    daysButton.addEventListener('click', convertDays);
    hoursButton.addEventListener('click', convertHours);
    minutesButton.addEventListener('click', convertMinutes);
    secondsButton.addEventListener('click', convertSeconds);

    function convertDays() {

        hours.value = days.value * 24;
        minutes.value = hours.value * 60;
        seconds.value = minutes.value * 60;

    }

    function convertHours() {

        days.value = hours.value / 24;
        minutes.value = hours.value * 60;
        seconds.value = minutes.value * 60;

    }

    function convertMinutes() {

        hours.value = minutes.value/60;
        seconds.value = minutes.value*60;
        days.value = hours.value /24;

    }

    function convertSeconds() {

        minutes.value = seconds.value / 60;
        hours.value = minutes.value / 60;
        days.value = hours.value / 24;

    }

}

