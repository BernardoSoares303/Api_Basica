using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Basica.Models
{
    public enum StatusTarefa
    {
        Pendente,
        EmAndamento,
        Concluida
    }
    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;

        public DateTime? DataEntrega { get; set; }

        // FK Projeto
        public int ProjetoId { get; set; }

        [ForeignKey("ProjetoId")]
        public Projeto Projeto { get; set; }

        // FK Usuario responsável
        public int UsuarioResponsavelId { get; set; }

        [ForeignKey("UsuarioResponsavelId")]
        public usuario UsuarioResponsavel { get; set; }
    }
}
