using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LBP.Web.ViewModels
{
    public class AddEditUsuariosViewModel
    {
        public int? UsuarioId { get; set; }
        public String Nombre { get; set; }
        public String Paterno { get; set; }
        public String Materno { get; set; }
        public String Usuario { get; set; }
        public String Password { get; set; }
        public int EstatusId { get; set; }
        public int RolId { get; set; }
        public List<Roles> LstRoles { get; set; }
        public List<Usuarios> LstUsuario { get; set; }
        public List<Estatus> LstEstatus { get; set; }


        public void CargarDatos(int? UsuarioId)
        {
            LBPEntities context = new LBPEntities();
            this.UsuarioId = UsuarioId;
            this.LstRoles = context.Roles.ToList();
            this.LstEstatus = context.Estatus.ToList();

            if (UsuarioId.HasValue)
            {
                Usuarios objUsuario = context.Usuarios.FirstOrDefault(X => X.UsuarioId == UsuarioId);

                this.UsuarioId = objUsuario.UsuarioId;
                this.Nombre = objUsuario.Nombre;
                this.Paterno = objUsuario.Paterno;
                this.Materno = objUsuario.Materno;
                this.Usuario = objUsuario.Usuario;
                this.Password = objUsuario.Password;
                this.EstatusId = objUsuario.EstatusId;
                this.RolId = objUsuario.RolId;
            }
        }

    }
}