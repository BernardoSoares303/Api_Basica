using System.ComponentModel.DataAnnotations;

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

        public string Role { get; set; } = "Dev";

        // Relacionamentos
        public List<Projeto> ProjetosCriados { get; set; }
        public List<Tarefa> TarefasResponsavel { get; set; }
    }
}
