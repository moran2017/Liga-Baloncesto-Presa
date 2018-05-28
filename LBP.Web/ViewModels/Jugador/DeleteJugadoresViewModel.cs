using LBP.Web.Models;
using System.Linq;

namespace LBP.Web.ViewModels.Jugador
{
    public class DeleteJugadoresViewModel
    {
        public int? JugadorId { get; set; }

        public void CargarDatos(int? JugadorId)
        {
            this.JugadorId = JugadorId;

            if (JugadorId.HasValue)
            {
                LBPEntities context = new LBPEntities();
                Jugadores objJugador = context.Jugadores.FirstOrDefault(X => X.JugadorId == JugadorId);

            }
        }
    }
}