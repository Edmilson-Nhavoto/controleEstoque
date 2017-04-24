using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DadosDaConexao
    {
        public static String conexao
        {
            get { return @"Data Source=ADMINISTRADOR\DEBUG;Initial Catalog=controleEstoque;Integrated Security=True"; }
        }
    }
}
