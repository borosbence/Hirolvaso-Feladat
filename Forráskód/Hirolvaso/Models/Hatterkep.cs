namespace Hirolvaso.Models
{
    public class Kep
    {
        public string UrlBase { get; set; }
        public string Copyright { get; set; }
    }

    public class Hatterkep
    {
        public List<Kep> Images { get; set; }
    }
}
