using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTime.Model
{
    public class Movie
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public TimeSpan Time { get; set; }
        public string Platform { get; set; }
        public string Image { get; set; }
    }

    public enum Genres
    {
        Action,
        Romanse,
        Horror,
    }

    public enum Platforms
    {
        Netflix,
        HBO,
        DisneyPlus
    }
}