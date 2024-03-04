function solution() {
    
    let main = document.getElementById('main');

fetch('http://localhost:3030/jsonstore/advanced/articles/list').then(data => data.json()).then(data => {

    for (const key in data) {
        

        main.innerHTML = '<div class=accordion">
        <div class="head"><span>Scalable Vector Graphics</span><button class="button" id="ee9823ab-c3e8-4a14-b998-8c22ec246bd3">More</button></div><div class="extra"><p>Scalable Vector Graphics .....</p></div></div>';
    }

});
}