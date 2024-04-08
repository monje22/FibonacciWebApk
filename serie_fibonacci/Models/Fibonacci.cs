/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;*/

using System.ComponentModel.DataAnnotations;

namespace serie_fibonacci.Models
{
    public class Fibonacci
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public int FirstNum { get; set; }
        public int SecondNum { get; set; }
        public int SumTotal { get; set; }
        public string? Serie { get; set; }


    }
}
