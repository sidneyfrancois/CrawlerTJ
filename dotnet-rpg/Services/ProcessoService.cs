using System.Collections.Generic;
using System.Linq;
using System.Net;
using dotnet_rpg.Models;
using System.Text;

namespace dotnet_rpg.Services.CharacterService
{
    public class ProcessoService : IProcessoService
    {
        private static Processo processo = new Processo{ numeroProcesso = "0030002020203030302"};
        private object Encoding;

        public void AddMovimentacoes(Movimentacoes newMovimentacoes)
        {
            throw new System.NotImplementedException();
        }

        public Processo AddProcesso(Processo newProcesso)
        {
            return newProcesso;
        }

        public Movimentacoes GetMovimentacoes()
        {
            throw new System.NotImplementedException();
        }

        public Processo GetProcesso()
        {
            return processo;

        }
    }
}