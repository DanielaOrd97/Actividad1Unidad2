namespace Act1_U2.Models.ViewModel
{
    public class ClasesViewModel
    {
        public int Id { get; set; }
        public string NombreClase { get; set; } = null!;
        public IEnumerable<EspecieModel> Especies { get; set; } = null!;
    }

    public class EspecieModel
    {
        public int IdEspecie { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
