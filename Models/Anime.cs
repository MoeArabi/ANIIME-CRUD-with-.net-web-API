namespace AnimeInternship.API.Models
{
    public class Anime
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //mc is the main character
        public string MCName { get; set; } = string.Empty;
        //Seasons beacuse public
        public int Seasons { get; set; }

        public Anime(int id, string name, string mcName, int seasons)
        {
            Id = id;
            Name = name;
            MCName = mcName;
            Seasons = seasons;
        }
        public void Update(string name, string mcName, int seasons)
            => (Name, MCName, Seasons) = (name, mcName, seasons);
    }
}
