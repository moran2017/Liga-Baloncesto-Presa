using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels
{
    public class LoginViewModel
    {
        public int UsuarioId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Usuario no puede estar vacío.")]
        public String Usuario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Password no puede estar vacío.")]
        public String password { get; set; }

        public LoginViewModel()
        {

        }
    }
}