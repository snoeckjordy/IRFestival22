namespace IRFestival.Api.Domain
{
    public class Festival
    {
        public int Id { get; set; }

        public Schedule LineUp { get; set; }

        public ICollection<Artist> Artists { get; set; }

        public ICollection<Stage> Stages { get; set; }

        public Festival()
        {
            Artists = new List<Artist>();
            Stages = new List<Stage>();
        }
    }
}
