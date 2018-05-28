using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels
{
    public class DeleteEquiposViewModel
    {
        public int? EquipoId { get; set; }

        public void CargarDatos(int? EquipoId)
        {
            this.EquipoId = EquipoId;

            if (EquipoId.HasValue)
            {
                LBPEntities context = new LBPEntities();
                Equipos objEquipo = context.Equipos.FirstOrDefault(X => X.EquipoId == EquipoId);

            }
        }
    }
}