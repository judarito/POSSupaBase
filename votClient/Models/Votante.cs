namespace votClient.Models
{
    public class Votante
    {
        public int Id { get; set; }

        public int IdLider { get; set; }
        public string NombreLider { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int IdPuesto { get; set; }
        public string NombrePuesto { get; set; }
    }
}
