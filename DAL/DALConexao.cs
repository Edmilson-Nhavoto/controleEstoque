﻿using System;
using System.Data.SqlClient;

namespace DAL
{
    public class DALConexao
    {
        private String _stringConexao;
        private SqlConnection _conexao;

        public DALConexao(String dadosConexao)
        {
            this._conexao = new SqlConnection();
            this._stringConexao = dadosConexao;
        }

        public String StringConexao
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }
        }

        public SqlConnection ObjectoConexao
        {
            get { return _conexao; }
            set { this._conexao = value; }
        }

        public void Conectar()
        { this._conexao.Open(); }

        public void Desconectar()
        { this._conexao.Close(); }
    }
}
