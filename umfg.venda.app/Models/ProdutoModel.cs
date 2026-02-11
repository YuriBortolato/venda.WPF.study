using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace umfg.venda.app.Models
{
    public class ProdutoModel
    {
        private Guid _id = Guid.NewGuid();
        private ImageSource _imagem;
        private string _referencia;
        private string _descricao;
        private decimal _valor;

        public Guid Id { get => _id; set => _id = value; }
        public ImageSource Imagem { get => _imagem; set => _imagem = value; }
        public string Referencia { get => _referencia; set => _referencia = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }
        public decimal Valor { get => _valor; set => _valor = value; }
    }
}
