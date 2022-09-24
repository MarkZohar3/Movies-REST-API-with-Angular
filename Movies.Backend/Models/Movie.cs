using System.ComponentModel.DataAnnotations;

namespace Movies.Backend.Models
{
    public class Movie
    {
    //primary key of table
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }  

        public int MinutesDuration { get; set; }   




    }
}
