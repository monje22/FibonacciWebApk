/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;*/

namespace serie_fibonacci.Models
{
    public class Fibonacci
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int FirstNum { get; set; }
        public int SecondNum { get; set; }
        public int SumTotal { get; set; }


    }
}
