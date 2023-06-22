using System.Reflection.Metadata.Ecma335;

namespace BookApi.Models
{
    public class Book
    {
        public int Id { get; set; } = 0;

        public string Title { get; set; } = "Education";

        public string Author { get; set; } = "Manith";

        public int Year { get; set; } = DateTime.Now.Year;

      
    }


}
