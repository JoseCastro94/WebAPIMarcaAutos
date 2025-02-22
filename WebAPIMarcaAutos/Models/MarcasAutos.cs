using System.ComponentModel.DataAnnotations;

namespace WebAPIMarcaAutos.Models
{
    public class MarcasAutos
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }
    }
}
