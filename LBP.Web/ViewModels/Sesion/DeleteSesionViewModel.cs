using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Sesion
{
    public class DeleteSesionViewModel
    {
        public int? SesionId { get; set; }

        public void CargarDatos(int? SesionId)
        {
            this.SesionId = SesionId;

            if (SesionId.HasValue)
            {
                LBPEntities context = new LBPEntities();
                Sesiones objSesion = context.Sesiones.FirstOrDefault(X => X.SesionId == SesionId);
            }
        }
    }
}