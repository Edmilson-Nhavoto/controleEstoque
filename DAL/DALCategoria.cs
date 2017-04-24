using System;
using MODELO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALCategoria
    {
        private DALConexao conexao;

        public DALCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCategoria modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjectoConexao;
            cmd.CommandText = "INSERT INTO categoria(cat_nome) " +
                              "VALUES (@nome) SELECT @@IDENTITY";
            cmd.Parameters.AddWithValue("@nome", modelo.Cat_nome);
            conexao.Conectar();
            modelo.Cat_cod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Alterar(ModeloCategoria modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjectoConexao;
            cmd.CommandText = "UPDATE categoria SET cat_nome = @nome "+
                              "WHERE cat_cod = @codigo";
            cmd.Parameters.AddWithValue("@nome", modelo.Cat_nome);
            cmd.Parameters.AddWithValue("@codigo", modelo.Cat_cod);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjectoConexao;
            cmd.CommandText = "DELETE FROM categoria WHERE cat_cod = @codigo";
            cmd.Parameters.AddWithValue("@cat_cod", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM categoria WHERE cat_nome LIKE "+
                                                   "'%"+valor+"%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModeloCategoria CarregarModeloCategoria(int codigo)
        {
            ModeloCategoria modelo = new ModeloCategoria();
            SqlCommand cmd  = new SqlCommand();
            cmd.Connection  = conexao.ObjectoConexao;
            cmd.CommandText = "SELECT * FROM categoria "+
                              "WHERE cat_cod = @nome";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                modelo.Cat_cod = Convert.ToInt32(registo["cat_cod"]);
                modelo.Cat_nome = Convert.ToString(registo["cat_nome"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
