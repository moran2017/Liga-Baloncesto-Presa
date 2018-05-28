﻿using LBP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBP.Web.ViewModels.Liga
{
    public class DeleteTemporadaViewModel
    {
        public int? TemporadaId { get; set; }

        public DeleteTemporadaViewModel()
        {

        }

        public void CargarDatos(int? TemporadaId)
        {
            this.TemporadaId = TemporadaId;

            if (TemporadaId.HasValue)
            {
                LBPEntities context = new LBPEntities();
                Temporada objTemporada = context.Temporada.FirstOrDefault(X => X.TemporadaId == TemporadaId);
            }
        }
    }
}