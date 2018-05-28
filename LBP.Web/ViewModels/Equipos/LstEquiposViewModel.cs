using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels
{
    public class LstEquiposViewModel
    {
        public List<Equipos> LstEquipos { get; set; }
        public String Filtro { get; set; }

        public LstEquiposViewModel()
        {
            LBPEntities context = new LBPEntities();
            LstEquipos = context.Equipos.ToList();
        }

        public void CargaDatos(String filtro)
        {
            LBPEntities context = new LBPEntities();
            LstEquipos = context.Equipos.Where(X => X.Nombre.Contains(filtro)).ToList();
        }
    }
}