using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels
{
    public class AddEditRolesViewModel
    {
        public int? RolId { get; set; }
        public String Acronimo { get; set; }
        public String Descripcion { get; set; }

        public List<Roles> LstRoles { get; set; }


        public void CargarDatos(int? RolId)
        {
            LBPEntities context = new LBPEntities();
            this.RolId = RolId;
            this.LstRoles = context.Roles.ToList();

            if (RolId.HasValue)
            {
                Roles objRol = context.Roles.FirstOrDefault(X => X.RolId == RolId);

                this.RolId = objRol.RolId;
                this.Acronimo = objRol.Acronimo;
                this.Descripcion = objRol.Descripcion;
            }
        }

    }
}