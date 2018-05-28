using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels
{
    public class DeleteUsuariosViewModel
    {
        public int? UsuariosId { get; set; }

        public void CargarDatos(int? UsuarioId)
        {
            this.UsuariosId = UsuarioId;

            if (UsuarioId.HasValue)
            {
                LBPEntities context = new LBPEntities();
                Usuarios objUsuario = context.Usuarios.FirstOrDefault(X => X.UsuarioId == UsuarioId);
            }
        }

    }
}