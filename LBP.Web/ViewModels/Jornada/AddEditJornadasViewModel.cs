using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Jornada
{
    public class AddEditJornadasViewModel
    {
        public int? JornadaId { get; set; }
        public String Descripcion { get; set; }

        public void CargarDatos(int? JornadaId)
        {
            LBPEntities context = new LBPEntities();
            this.JornadaId = JornadaId;
            this.Descripcion = Descripcion;

            if (JornadaId.HasValue)
            {
                Jornadas objJornada = context.Jornadas.FirstOrDefault(X => X.JornadaId == JornadaId);

                this.Descripcion = objJornada.Descripcion;
            }
        }
    }
}