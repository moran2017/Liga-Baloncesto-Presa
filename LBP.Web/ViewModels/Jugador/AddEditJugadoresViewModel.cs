using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Jugador
{
    public class AddEditJugadoresViewModel
    {
        public int? JugadorId { get; set; }
        public String Nombre { get; set; }
        public String Paterno { get; set; }
        public String Materno { get; set; }
        public int Numero { get; set; }
        public int EquipoId { get; set; }
        public List<Equipos> LstEquipos { get; set; }

        public void CargarDatos(int? JugadorId)
        {
            LBPEntities context = new LBPEntities();
            this.JugadorId = JugadorId;
            this.LstEquipos = context.Equipos.ToList();

            if (JugadorId.HasValue)
            {
                Jugadores objJugador = context.Jugadores.FirstOrDefault(X => X.JugadorId == JugadorId);

                this.Nombre = objJugador.Nombre;
                this.Paterno = objJugador.Paterno;
                this.Materno = objJugador.Materno;
                this.Numero = objJugador.Numero;
                this.EquipoId = objJugador.EquipoId;
            }
        }
    }
}