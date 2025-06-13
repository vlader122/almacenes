using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DB.Models
{
    public class DetalleEntrega
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //relaciones
        public int EntregaId { get; set; }
        public int ItemId { get; set; }
        public int Cantidad { get; set; }
        [JsonIgnore]
        public virtual Item? Item { get; set; }
        [JsonIgnore]
        public virtual Entrega? Entrega { get; set; }
    }
}
