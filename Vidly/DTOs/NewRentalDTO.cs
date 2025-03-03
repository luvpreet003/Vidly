using System.Collections.Generic;

namespace Vidly.DTOs
{
    public class NewRentalDTO
    {
        public string CustomerName { get; set; }
        public List<int> MovieIds { get; set; }
    }
}