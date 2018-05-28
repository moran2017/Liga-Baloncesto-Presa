using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Jornada
{
    public class LstJornadasViewModel
    {
        public List<Jornadas> LstJornadas { get; set; }
        public String Filtro { get; set; }

        public LstJornadasViewModel()
        {
            LBPEntities context = new LBPEntities();
            LstJornadas = context.Jornadas.ToList();
        }

        public void CargaDatos(String filtro)
        {
            LBPEntities context = new LBPEntities();
            LstJornadas = context.Jornadas.Where(X => X.Descripcion.Contains(filtro)).ToList();
        }
    }              
}                  