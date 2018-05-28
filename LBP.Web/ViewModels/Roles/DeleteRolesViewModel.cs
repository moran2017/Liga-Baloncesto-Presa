using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels
{
    public class DeleteRolesViewModel
    {
        public int? RolId { get; set; }


        public void CargarDatos(int? RolId)
        {
            this.RolId = RolId;

            if (RolId.HasValue)
            {
                LBPEntities context = new LBPEntities();
                Roles objRol = context.Roles.FirstOrDefault(X => X.RolId == RolId);
            }
        }
    }
}