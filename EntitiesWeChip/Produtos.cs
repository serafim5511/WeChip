using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesWeChip
{
    public class Produtos
    {
        public int Id { get; set; }
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int Tipo { get; set; }    
    }
}
