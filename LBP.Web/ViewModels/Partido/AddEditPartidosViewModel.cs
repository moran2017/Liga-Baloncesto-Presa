using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Timers;
using System.Web;

namespace LBP.Web.ViewModels.Partido
{
    public class AddEditPartidosViewModel
    {
        public int? PartidoId { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Horario { get; set; }
        public int TemporadaId { get; set; }
        public int JornadaId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public int EquipoLocalId { get; set; }
        public int PuntosLocal { get; set; }
        public int EquipoVisitante { get; set; }
        public int PuntosVisitante { get; set; }
        public int EquipoId { get; set; }
        public List<Partidos> LstPartidos { get; set; }
        public List<Jornadas> LstJornadas { get; set; }
        public List<Equipos> LstEquipoLocal { get; set; }
        public List<Equipos> LstEquipoVisitante { get; set; }
        public List<Temporada> LstTemporada { get; set; }

        public void CargarDatos(int? PartidoId)
        {
            LBPEntities context = new LBPEntities();
            this.PartidoId = PartidoId;
            this.LstTemporada = context.Temporada.ToList();
            this.LstEquipoLocal = context.Equipos.ToList();
            this.LstJornadas = context.Jornadas.ToList();
            this.LstEquipoVisitante = context.Equipos.ToList();
            
            if (PartidoId.HasValue)
            {
                Partidos objPartido = context.Partidos.FirstOrDefault(X => X.PartidoId == PartidoId);

                this.Horario = (TimeSpan)objPartido.Horario;
                this.TemporadaId = (int)objPartido.TemporadaId;
                this.JornadaId = (int)objPartido.JornadaId;
                this.Fecha = (DateTime)objPartido.Fecha;
                this.EquipoLocalId = (int)objPartido.EquipoLocalId;
                this.PuntosLocal = (int)objPartido.PuntosLocal;
                this.EquipoVisitante = (int)objPartido.EquipoVisitanteId;
                this.PuntosVisitante = (int)objPartido.PuntosVisitante;
            }
        }
    }
}