using System.ComponentModel.DataAnnotations;

namespace EsercizioEFCarFluentAPI.Models
{
    internal class Vehicle
    {
        [Key]
        public string Targa { get; set; }
        public int NumeroPosti { get; set; }
        public string Marca { get; set; }
        public DateTime DataImmatricolazione { get; set; }

        public string PersonCodiceFiscale { get; set; }
        public Person Person { get; set; }

        public override string ToString()
        {
            return $"{Targa} - {NumeroPosti} - {Marca} - data immatricolazione: {DataImmatricolazione.ToShortDateString()}";

        }

    }
}