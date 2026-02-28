using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Basica.Models
{
    public class Projeto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // FK
        public int UsuarioCriadorId { get; set; }

        [ForeignKey("UsuarioCriadorId")]
        public usuario UsuarioCriador { get; set; }

        // Relacionamento
        public List<Tarefa> Tarefas { get; set; }
    }
}
