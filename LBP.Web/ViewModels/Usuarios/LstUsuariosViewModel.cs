using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels
{
    public class LstUsuariosViewModel
    {
        public List<Usuarios> LstUsuarios { get; set; }
        public String Filtro { get; set; }
        public int? UsuarioId { get; set; }

        public LstUsuariosViewModel()
        {
            LBPEntities context = new LBPEntities();
            LstUsuarios = context.Usuarios.ToList();
        }

        public void CargaDatos(String filtro)
        {
            LBPEntities context = new LBPEntities();
            LstUsuarios = context.Usuarios.Where(X => X.Nombre.Contains(filtro)).ToList();
        }
    }
}