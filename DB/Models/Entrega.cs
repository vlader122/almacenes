using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Entrega
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public string Observaciones { get; set; }
        [ForeignKey("PersonalId")]
        public int PersonalId { get; set; }
        public virtual Personal? Personal { get; set; }
        public virtual ICollection<DetalleEntrega> DetalleEntrega { get; set; }
    }
}
