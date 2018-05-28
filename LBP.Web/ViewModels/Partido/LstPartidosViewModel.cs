using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Partido
{
    public class LstPartidosViewModel
    {
        public List<Partidos> LstPartidos { get; set; }
        public String Filtro { get; set; }
        public List<Jornadas> LstJornada{get; set;}
        public int JornadaId { get; set; }
        public String fecha { get; set; }
        public List<Partidos> LstFechas { get; set; }

        public LstPartidosViewModel()
        {
            LBPEntities context = new LBPEntities();
            LstPartidos = context.Partidos.ToList();
            LstJornada = context.Jornadas.ToList();
            LstFechas = context.Partidos.ToList();
        }

        public void CargaDatos(String filtro)
        {
            LBPEntities context = new LBPEntities();
            LstPartidos = context.Partidos.Where(X => X.Jornadas.Descripcion.Contains(filtro)).ToList();
        }
    }
}