using System.Text.Json;
using MovieWebApi.Abstraction;
using MovieWebApi.Domain.Entities;

namespace MovieWebApi.Infrastructure.Services;

public class MovieService : IMovieRepository
{
    private static string JSON_DATA_MOVIES = """
        [
        {
            "id": 1,
            "title": "Les Évadés",
            "releaseDate": "1994-09-23",
            "description": "Condamné à tort pour meurtre, un banquier se lie d'amitié avec un détenu et garde espoir pendant des décennies à la prison de Shawshank.",
            "score": 9.3,
            "duration": 8520,
            "imageUrl": "https://example.com/posters/1.jpg",
            "directors": [{ "lastName": "Darabont", "firstName": "Frank" }],
            "writers": [{ "lastName": "Darabont", "firstName": "Frank" }],
            "actors": [
            { "lastName": "Robbins", "firstName": "Tim" },
            { "lastName": "Freeman", "firstName": "Morgan" },
            { "lastName": "Gunton", "firstName": "Bob" }
            ],
            "categories": ["Drame"]
        },
        {
            "id": 2,
            "title": "Le Parrain",
            "releaseDate": "1972-03-24",
            "description": "Le patriarche d'une dynastie mafieuse new-yorkaise transmet son empire à son fils, d'abord réticent.",
            "score": 9.2,
            "duration": 10500,
            "imageUrl": "https://example.com/posters/2.jpg",
            "directors": [{ "lastName": "Coppola", "firstName": "Francis Ford" }],
            "writers": [
            { "lastName": "Puzo", "firstName": "Mario" },
            { "lastName": "Coppola", "firstName": "Francis Ford" }
            ],
            "actors": [
            { "lastName": "Brando", "firstName": "Marlon" },
            { "lastName": "Pacino", "firstName": "Al" },
            { "lastName": "Caan", "firstName": "James" },
            { "lastName": "Duvall", "firstName": "Robert" }
            ],
            "categories": ["Crime", "Drame"]
        },
        {
            "id": 3,
            "title": "The Dark Knight : Le Chevalier noir",
            "releaseDate": "2008-07-18",
            "description": "Batman affronte le Joker, un criminel anarchiste qui plonge Gotham dans le chaos.",
            "score": 9.0,
            "duration": 9120,
            "imageUrl": "https://example.com/posters/3.jpg",
            "directors": [{ "lastName": "Nolan", "firstName": "Christopher" }],
            "writers": [
            { "lastName": "Nolan", "firstName": "Jonathan" },
            { "lastName": "Nolan", "firstName": "Christopher" }
            ],
            "actors": [
            { "lastName": "Bale", "firstName": "Christian" },
            { "lastName": "Ledger", "firstName": "Heath" },
            { "lastName": "Eckhart", "firstName": "Aaron" }
            ],
            "categories": ["Action", "Crime", "Drame"]
        },
        {
            "id": 4,
            "title": "Pulp Fiction",
            "releaseDate": "1994-10-14",
            "description": "Plusieurs histoires entrelacées de gangsters, de boxeurs et de braqueurs dans le Los Angeles criminel.",
            "score": 8.9,
            "duration": 9240,
            "imageUrl": "https://example.com/posters/4.jpg",
            "directors": [{ "lastName": "Tarantino", "firstName": "Quentin" }],
            "writers": [
            { "lastName": "Tarantino", "firstName": "Quentin" },
            { "lastName": "Avary", "firstName": "Roger" }
            ],
            "actors": [
            { "lastName": "Travolta", "firstName": "John" },
            { "lastName": "Jackson", "firstName": "Samuel L." },
            { "lastName": "Thurman", "firstName": "Uma" },
            { "lastName": "Willis", "firstName": "Bruce" }
            ],
            "categories": ["Crime", "Drame"]
        },
        {
            "id": 5,
            "title": "Inception",
            "releaseDate": "2010-07-16",
            "description": "Un voleur spécialisé dans l'infiltration des rêves doit, cette fois, implanter une idée dans l'esprit d'un héritier.",
            "score": 8.8,
            "duration": 8880,
            "imageUrl": "https://example.com/posters/5.jpg",
            "directors": [{ "lastName": "Nolan", "firstName": "Christopher" }],
            "writers": [{ "lastName": "Nolan", "firstName": "Christopher" }],
            "actors": [
            { "lastName": "DiCaprio", "firstName": "Leonardo" },
            { "lastName": "Gordon-Levitt", "firstName": "Joseph" },
            { "lastName": "Page", "firstName": "Elliot" },
            { "lastName": "Hardy", "firstName": "Tom" }
            ],
            "categories": ["Science-fiction", "Action", "Thriller"]
        },
        {
            "id": 6,
            "title": "Fight Club",
            "releaseDate": "1999-10-15",
            "description": "Un employé insomniaque fonde un club de combat clandestin avec un mystérieux vendeur de savon.",
            "score": 8.8,
            "duration": 8340,
            "imageUrl": "https://example.com/posters/6.jpg",
            "directors": [{ "lastName": "Fincher", "firstName": "David" }],
            "writers": [{ "lastName": "Uhls", "firstName": "Jim" }],
            "actors": [
            { "lastName": "Pitt", "firstName": "Brad" },
            { "lastName": "Norton", "firstName": "Edward" },
            { "lastName": "Bonham Carter", "firstName": "Helena" }
            ],
            "categories": ["Drame", "Thriller"]
        },
        {
            "id": 7,
            "title": "Forrest Gump",
            "releaseDate": "1994-07-06",
            "description": "Un homme simple d'esprit traverse trois décennies d'histoire américaine, sans jamais cesser d'aimer son amie d'enfance.",
            "score": 8.8,
            "duration": 8520,
            "imageUrl": "https://example.com/posters/7.jpg",
            "directors": [{ "lastName": "Zemeckis", "firstName": "Robert" }],
            "writers": [{ "lastName": "Roth", "firstName": "Eric" }],
            "actors": [
            { "lastName": "Hanks", "firstName": "Tom" },
            { "lastName": "Wright", "firstName": "Robin" },
            { "lastName": "Sinise", "firstName": "Gary" }
            ],
            "categories": ["Drame", "Romance", "Comédie"]
        },
        {
            "id": 8,
            "title": "Matrix",
            "releaseDate": "1999-03-31",
            "description": "Un hacker découvre que son monde n'est qu'une simulation et rejoint la rébellion contre les machines.",
            "score": 8.7,
            "duration": 8160,
            "imageUrl": "https://example.com/posters/8.jpg",
            "directors": [
            { "lastName": "Wachowski", "firstName": "Lana" },
            { "lastName": "Wachowski", "firstName": "Lilly" }
            ],
            "writers": [
            { "lastName": "Wachowski", "firstName": "Lana" },
            { "lastName": "Wachowski", "firstName": "Lilly" }
            ],
            "actors": [
            { "lastName": "Reeves", "firstName": "Keanu" },
            { "lastName": "Fishburne", "firstName": "Laurence" },
            { "lastName": "Moss", "firstName": "Carrie-Anne" },
            { "lastName": "Weaving", "firstName": "Hugo" }
            ],
            "categories": ["Science-fiction", "Action"]
        },
        {
            "id": 9,
            "title": "Interstellar",
            "releaseDate": "2014-11-07",
            "description": "Alors que la Terre se meurt, une équipe d'astronautes traverse un trou de ver pour chercher une nouvelle planète habitable.",
            "score": 8.7,
            "duration": 10140,
            "imageUrl": "https://example.com/posters/9.jpg",
            "directors": [{ "lastName": "Nolan", "firstName": "Christopher" }],
            "writers": [
            { "lastName": "Nolan", "firstName": "Jonathan" },
            { "lastName": "Nolan", "firstName": "Christopher" }
            ],
            "actors": [
            { "lastName": "McConaughey", "firstName": "Matthew" },
            { "lastName": "Hathaway", "firstName": "Anne" },
            { "lastName": "Chastain", "firstName": "Jessica" },
            { "lastName": "Caine", "firstName": "Michael" }
            ],
            "categories": ["Science-fiction", "Aventure", "Drame"]
        },
        {
            "id": 10,
            "title": "Parasite",
            "releaseDate": "2019-05-30",
            "description": "Une famille pauvre s'infiltre peu à peu dans le quotidien d'une riche famille, avec des conséquences imprévues.",
            "score": 8.5,
            "duration": 7920,
            "imageUrl": "https://example.com/posters/10.jpg",
            "directors": [{ "lastName": "Bong", "firstName": "Joon-ho" }],
            "writers": [
            { "lastName": "Bong", "firstName": "Joon-ho" },
            { "lastName": "Han", "firstName": "Jin-won" }
            ],
            "actors": [
            { "lastName": "Song", "firstName": "Kang-ho" },
            { "lastName": "Lee", "firstName": "Sun-kyun" },
            { "lastName": "Cho", "firstName": "Yeo-jeong" },
            { "lastName": "Choi", "firstName": "Woo-sik" }
            ],
            "categories": ["Thriller", "Drame", "Comédie noire"]
        }
        ]
        """;

    public async Task<IEnumerable<Movie>> GetMovies()
    {
        List<Movie> movies = new List<Movie>();
        List<Movie>? m = JsonSerializer.Deserialize<List<Movie>>(
            JSON_DATA_MOVIES,
            JsonSerializerOptions.Web
        );
        if (m is not null)
            movies.AddRange(m);

        return movies;
    }
}
