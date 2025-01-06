using System;

namespace Vidly.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime DateReleased { get; set; }
        public int PiecesInStock { get; set; }
    }
}