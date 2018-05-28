using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Jugador
{
    public class LstJugadoresViewModel
    {
        public List<Jugadores> LstJugadores { get; set; }
        public String Filtro { get; set; }

        public LstJugadoresViewModel()
        {
            LBPEntities context = new LBPEntities();
            LstJugadores = context.Jugadores.ToList();
        }

        public void CargaDatos(String filtro)
        {
            LBPEntities context = new LBPEntities();
            LstJugadores = context.Jugadores.Where(X => X.Nombre.Contains(filtro)).ToList();
        }
    }
}