function movieDatabase(input) {
    const movies = [];

    for (let line of input) {
        if (line.includes("addMovie")) {
            const movieName = line.substring(9);
            movies.push({ name: movieName });
        } else if (line.includes("directedBy")) {
            const [movieName, director] = line.split(" directedBy ");
            const movie = movies.find(m => m.name === movieName);
            if (movie) {
                movie.director = director;
            }
        } else if (line.includes("onDate")) {
            const [movieName, date] = line.split(" onDate ");
            const movie = movies.find(m => m.name === movieName);
            if (movie) {
                movie.date = date;
            }
        }
    }

    const validMovies = movies.filter(movie => movie.name && movie.director && movie.date);
    validMovies.forEach(movie => {
        console.log(`{"name":"${movie.name}","director":"${movie.director}","date":"${movie.date}"}`);
    });
}


const input = [
    'addMovie Inception',
    'addMovie The Dark Knight',
    'Inception directedBy Christopher Nolan',
    'Inception onDate 2010-07-16',
    'The Dark Knight directedBy Christopher Nolan',
    'The Dark Knight onDate 2008-07-18',
    'Interstellar onDate 2014-11-05'
];

movieDatabase(input);
