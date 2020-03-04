using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ClimaTempo.Controllers
{
    [Route("api/previsao-tempo")]
    [ApiController]
    public class PrevisaoTempoController : ControllerBase
    {
        [HttpGet]
        public List<PrevisaoTempo> BuscarTodasPrevisoes()
        {
            var p1 = new PrevisaoTempo { Data = DateTime.Now, Temperatura = 20 };
            var p2 = new PrevisaoTempo { Data = DateTime.Now, Temperatura = 23 };
            var p3 = new PrevisaoTempo { Data = DateTime.Now, Temperatura = 26 };
            var p4 = new PrevisaoTempo { Data = DateTime.Now, Temperatura = 40 };

            return new List<PrevisaoTempo> { p1, p2, p3, p4 };
        }
    }
    public class PrevisaoTempo
    {
        public DateTime Data { get; set; }
        public int Temperatura { get; set; }
    }
}