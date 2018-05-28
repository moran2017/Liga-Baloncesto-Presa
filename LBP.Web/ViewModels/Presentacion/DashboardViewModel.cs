using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels
{
    public class DashboardViewModel
    {
        public int nUsuarios { get; set; }
        public int nRoles { get; set; }
        public int nEquipos { get; set; }
        public int nSesiones { get; set; }
        public int nJornadas { get; set; }
        public int nTemporadas { get; set; }
        public int nPartidos { get; set; }
        public int nEstadisticas { get; set; }
        public DashboardViewModel()
        {
            LBPEntities context = new LBPEntities();

            nUsuarios = context.Usuarios.Count();
            nRoles = context.Roles.Count();
            nEquipos = context.Equipos.Count();
            nSesiones = context.Sesiones.Count();
            nJornadas = context.Jornadas.Count();
            nTemporadas = context.Temporada.Count();
            nPartidos = context.Partidos.Count();
            nEstadisticas = context.Estadisticas.Count();
        }
    }
}