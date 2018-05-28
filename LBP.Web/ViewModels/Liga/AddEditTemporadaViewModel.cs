using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Liga
{
    public class AddEditTemporadaViewModel
    {
        public int? TemporadaId { get; set; }
        public String Descripcion { get; set; }

        public List<Temporada> lstTemporada { get; set; }


        public void CargarDatos(int? TemporadaId)
        {
            LBPEntities context = new LBPEntities();
            this.TemporadaId = TemporadaId;
            this.lstTemporada = context.Temporada.ToList();

            if (TemporadaId.HasValue)
            {
                Temporada objTemporada = context.Temporada.FirstOrDefault(X => X.TemporadaId == TemporadaId);

                this.TemporadaId = objTemporada.TemporadaId;
                this.Descripcion = objTemporada.Descripcion;
            }
        }
    }
}