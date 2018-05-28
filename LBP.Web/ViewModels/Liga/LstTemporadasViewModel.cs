using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Liga
{
    public class LstTemporadasViewModel
    {
        public List<Temporada> LstTemporadas { get; set; }
        public String Filtro { get; set; }

        public LstTemporadasViewModel()
        {
            LBPEntities context = new LBPEntities();
            LstTemporadas = context.Temporada.ToList();
        }

        public void CargaDatos(String filtro)
        {
            LBPEntities context = new LBPEntities();
            LstTemporadas = context.Temporada.Where(X => X.Descripcion.Contains(filtro)).ToList();
        }
    }
}