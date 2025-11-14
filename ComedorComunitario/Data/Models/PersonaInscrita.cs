using SQLite;

namespace ComedorComunitario.Data.Models
{
    public class PersonaInscrita
    {
        public DateTime MarcaTemporal { get; set; } 

        [PrimaryKey] 
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public int FaltasConsecutivas { get; set; } = 0;
        public bool EstaSuspendido { get; set; } = false;
        public DateTime UltimaAsistencia { get; set; }
    }
}
