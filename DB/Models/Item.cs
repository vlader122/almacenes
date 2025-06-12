using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Precio { get; set; }
        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        //crear el atributo de categoria asegura crear la relacion
        public virtual Categoria? Categoria { get; set; }
    }
}
