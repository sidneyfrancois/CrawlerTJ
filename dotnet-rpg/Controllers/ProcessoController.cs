using System.Collections.Generic;
using System.Linq;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProcessoController : ControllerBase
    {            
        private readonly IProcessoService _processoService;

        public Processo newProcess { get; private set; }

        public ProcessoController(IProcessoService processoService)
        {               
            _processoService = processoService;
        }

        [HttpGet("GetProcesso")]
        public IActionResult GetProcesso()
        {                
            newProcess = _processoService.GetProcesso();
            ArmazenarProcesso(newProcess);
            return Ok(newProcess);
        }

        public static void ArmazenarProcesso(Processo newProcessDB)
        {                
            using(var context = new ProcessoContext())
            {                    
                context.Add(newProcessDB);
                context.SaveChanges();
            }
        }
    }
}