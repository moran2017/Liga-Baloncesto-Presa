using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels
{
    public class AddEditEquiposViewModel
    {
        public int? EquipoId { get; set; }
        public String Nombre { get; set; }

        public List<Equipos> lstEquipos { get; set; }


        public void CargarDatos(int? EquipoId)
        {
            LBPEntities context = new LBPEntities();
            this.EquipoId = EquipoId;
            this.lstEquipos = context.Equipos.ToList();

            if (EquipoId.HasValue)
            {
                Equipos objEquipo = context.Equipos.FirstOrDefault(X => X.EquipoId == EquipoId);

                this.EquipoId = objEquipo.EquipoId;
                this.Nombre = objEquipo.Nombre;
            }
        }

    }
}