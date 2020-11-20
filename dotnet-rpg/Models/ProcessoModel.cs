using System.Collections.Generic;

namespace dotnet_rpg.Models
{
    public class Processo 
  {
      public string numeroProcesso { get; set; }
      public string classe { get; set; }
      public string area { get; set; }
      public string assunto { get; set; }
      public string origem { get; set; }
      public string distribuicao { get; set; }
      public string relator { get; set; }
  }

  public class Movimentacoes
  {
      public string numeroProcesso { get; set; }
      public string movimentacao { get; set; }
  }
}