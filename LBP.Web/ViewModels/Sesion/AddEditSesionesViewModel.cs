using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Sesion
{
    public class AddEditSesionesViewModel
    {
        public int? SesionId { get; set; }
        public DateTime IniciSesion { get; set; }
        public DateTime CierreSesion { get; set; }
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public List<Usuarios> lstUsuarios { get; set; }
        public List<Roles> lstRoles { get; set; }

        public void CargaDatos(int? sesionId)
        {
            LBPEntities context = new LBPEntities();
            this.SesionId = sesionId;
            this.lstRoles = context.Roles.ToList();
            this.lstUsuarios = context.Usuarios.ToList();

            if (sesionId.HasValue)
            {
                Sesiones objSesion = context.Sesiones.FirstOrDefault(X => X.SesionId == sesionId);

                this.SesionId = objSesion.UsuarioId;
                this.IniciSesion = objSesion.InicioSesion;
                this.CierreSesion = objSesion.CierreSesion;
                this.UsuarioId = objSesion.UsuarioId;
                this.RolId = objSesion.RolId;
            }
        }
    }
}