using System.Collections.Generic;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public interface IProcessoService
    {
        Processo GetProcesso();
        Processo AddProcesso(Processo newProcesso);

        Movimentacoes GetMovimentacoes();
        void AddMovimentacoes(Movimentacoes newMovimentacoes);

    }
}
