namespace PrimoProgettoEF_FA.Models
{
    public class Esame
    {
        public int EsameId { get; set; }
        public string Nome { get; set; }
        public int? CFU { get; set; }
        public int? Votazione { get; set; }
        public bool Passato { get; set; } = false;

        public int StudentId { get; set; }
        public Studente Studente { get; set; }
    }
}