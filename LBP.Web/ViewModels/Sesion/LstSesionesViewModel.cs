using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LBP.Web.Models;

namespace LBP.Web.ViewModels.Sesion
{
    public class LstSesionesViewModel
    {
        public List<Sesiones> LstSesiones { get; set; }
        public String Filtro { get; set; }

        public LstSesionesViewModel()
        {
            LBPEntities context = new LBPEntities();
            LstSesiones = context.Sesiones.ToList();
        }

        public void CargaDatos(String filtro)
        {
            LBPEntities context = new LBPEntities();
            LstSesiones = context.Sesiones.Where(X => X.Usuarios.Nombre.Contains(filtro)).ToList();
        }
    }
}