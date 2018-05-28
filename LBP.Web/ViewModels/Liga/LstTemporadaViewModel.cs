using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Liga
{
    public class LstTemporadaViewModel
    {
        public List<Temporada> LstTemporada { get; set; }
        public String Filtro { get; set; }

        public LstTemporadaViewModel()
        {
            LBPEntities context = new LBPEntities();
            LstTemporada = context.Temporada.ToList();
        }

        public void CargaDatos(String filtro)
        {
            LBPEntities context = new LBPEntities();
            LstTemporada = context.Temporada.Where(X => X.Descripcion.Contains(filtro)).ToList();
        }
    }
}