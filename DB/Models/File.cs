using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public int FileId { get; set; }
        public string FileName { get; set; } = "";
        public string FilePath { get; set; } = "";
        public DateTime fechaSubida { get; set; } = DateTime.Now;
    }
}
