using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels
{
    public class LstRolesViewModel
    {
        public List<Roles> LstRoles { get; set; }
        public String Filtro { get; set; }

        public LstRolesViewModel()
        {
            LBPEntities context = new LBPEntities();
            LstRoles = context.Roles.ToList();
        }

        public void CargaDatos(String filtro)
        {
            LBPEntities context = new LBPEntities();
            LstRoles = context.Roles.Where(X => X.Descripcion.Contains(filtro)).ToList();
        }
    }
}