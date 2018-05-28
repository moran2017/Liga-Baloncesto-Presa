using LBP.Web.Models;
using System.Linq;

namespace LBP.Web.ViewModels.Partido
{
    public class DeletePartidosViewModel
    {
        public int? PartidoId { get; set; }

        public DeletePartidosViewModel()
        {

        }

        public void CargarDatos(int? PartidoId)
        {
            this.PartidoId = PartidoId;

            if (PartidoId.HasValue)
            {
                LBPEntities context = new LBPEntities();
                Partidos objPartido = context.Partidos.FirstOrDefault(X => X.PartidoId == PartidoId);

            }
        }
    }
}