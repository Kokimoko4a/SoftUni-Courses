function createMovies(movies) {

    let list = [];

    movies.forEach(element => {

        if (element.includes("addMovie")) {
            let movie = element.split("addMovie ")[1];

            list.push({ name: movie });
        }

        else if (element.includes('directedBy')) {

            [movieName, director] = element.split(" directedBy ");

            let movie = list.find(x => x.name == movieName);
            
            if (movie) {
                movie["director"] = director;
            }
        }

        else if (element.includes('onDate')) {

            [ movieName,date] = element.split(" onDate ");

            let movie = list.find(x => x.name == movieName);
            
            if (movie) {
                movie["date"] = date;
            }
        }


    });


   for (const obj of list) {
    
    if (obj.date && obj.director && obj.name) {
        
        console.log(JSON.stringify(obj));
    }
   }
}

createMovies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]
);