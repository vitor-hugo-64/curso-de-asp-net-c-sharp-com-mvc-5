using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Introducao.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Nome é obrigatório")] // Faz com que essa propriedade seja obrigatória, caso não seja o sistema irá apontar o erro // Isso é util em formulários
        public string nome { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Insira de 2 a 50 caracteres")] // Define o maximo e o minimo de caracteres nessa propriedade
        public string observacoes { get; set; }
        [Range( 18, 70, ErrorMessage = "Idade deve estar entre 18 e 70")] // Define um intervalo de numeros
        public int idade { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um email válido")] // define uma expressão que devera conter no campo para validar email \\ Regex
        public string email { get; set; }
        [RegularExpression(@"[a-zA-Z]{5,15}", ErrorMessage = "Insira somente letras")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [Remote("LoginUnico", "Usuario", ErrorMessage = "Este Login Já Existe")] //chama uma determinada rota e trata ela // nesse caso será chamado  rota que verifica se já existe determinado login
        public string login { get; set; }
        [Required(ErrorMessage = "Senha é obrigatória")]
        public string senha { get; set; }
        [System.Web.Mvc.Compare("senha", ErrorMessage = "Senha diferente obrigatório")]
        public string confirmarSenha { get; set; }


    }
}