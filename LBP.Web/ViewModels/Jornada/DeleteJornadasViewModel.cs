using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Jornada
{
    public class DeleteJornadasViewModel
    {
        public int? JornadaId { get; set; }

        public DeleteJornadasViewModel()
        {

        }

        public void CargarDatos(int? JornadaId)
        {
            this.JornadaId = JornadaId;

            if (JornadaId.HasValue)
            {
                LBPEntities context = new LBPEntities();
                Jornadas objJornada = context.Jornadas.FirstOrDefault(X => X.JornadaId == JornadaId);
            }
        }
    }
}