using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Presentacion
{
    public class RegistarViewModel
    {
        public int? UsuarioId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre no puede estar vacío.")]
        public String Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Apellido Paterno no puede estar vacío.")]
        public String Paterno { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Apellido Materno no puede estar vacío.")]
        public String Materno { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Usuario no puede estar vacío.")]
        public String Usuario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Password no puede estar vacío.")]
        public String Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Seleccione el Estatus no puede estar vacío")]
        public int EstatusId { get; set; }
        public int RolId { get; set; }
        public List<Roles> LstRoles { get; set; }
        public List<Usuarios> LstUsuario { get; set; }
        public List<Estatus> LstEstatus { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El usuario ya existe ingrese otro diferente")]
        public String UsuExiste { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "No debe de haber ningun campo sin llenar.")]
        public String RegistrarVacio { get; set; }

        public RegistarViewModel()
        {

        }
    }
}