using System.ComponentModel.DataAnnotations;

namespace ProjetoLivraria.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor preencher o campo Nome")]
        [StringLength(200, ErrorMessage = "Quantidade máxima de caracteres: 200")]
        public string Nome { get; set; }

        [Display(Name ="Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name= "Status Autor")]
        public bool Ativo { get; set; }

    }
}
