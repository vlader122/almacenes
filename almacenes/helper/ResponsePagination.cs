namespace Almacenes.helper
{
    public class ResponsePagination <T>
    {
        public int TotalRegistros { get; set; }
        public int NumeroPagina { get; set; }
        public int TamanioPagina { get; set; }
        public List<T> Datos { get; set; }
    }
}
