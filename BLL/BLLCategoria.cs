using DAL;
using MODELO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class BLLCategoria
    {
        private DALConexao conexao;

        public BLLCategoria(DALConexao cx)
        { this.conexao = cx; }

        public void Incluir(ModeloCategoria modelo)
        {
            if (modelo.Cat_nome.Trim().Length == 0)
            { throw new Exception("O Nome da Categoria é obrigatorio."); }

            DALCategoria DALObj = new DALCategoria(conexao);
            DALObj.Incluir(modelo);
        }

        public void Alterar(ModeloCategoria modelo)
        {
            if (modelo.Cat_cod <= 0)
            { throw new Exception("Informe o codigo da categoria."); }

            if (modelo.Cat_nome.Trim().Length == 0)
            { throw new Exception("O Nome da Categoria é obrigatorio."); }

            DALCategoria DALObj = new DALCategoria(conexao);
            DALObj.Alterar(modelo);

        }

        public void Excluir(int codigo)
        {
            DALCategoria DALObj = new DALCategoria(conexao);
            DALObj.Excluir(codigo);
        }

        public DataTable Localizar(String valor)
        {
            DALCategoria DALObj = new DALCategoria(conexao);
            return DALObj.Localizar(valor);
        }

        public ModeloCategoria CarregarModeloCategoria(int codigo)
        {
            DALCategoria DALObj = new DALCategoria(conexao);
            return DALObj.CarregarModeloCategoria(codigo);
        }
    }
}
