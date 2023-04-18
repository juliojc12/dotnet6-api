using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs
{
    public class ReadMovieDto
    {
        
        public string Title { get; set; }

        public string Genre { get; set; }
        
        public int Duration { get; set; }

        public DateTime ConsultHour { get; set; }
    }
}
