using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api_Basica.Models
{
    public class usuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Senha { get; set; }

        public string Role { get; set; }

        // Relacionamentos

        [JsonIgnore] // inicializados para não causar erro de null
        public List<Projeto> ProjetosCriados { get; set; } = new List<Projeto>();

        [JsonIgnore]
        public List<Tarefa> TarefasResponsavel { get; set; } = new List<Tarefa>();
    }
}
