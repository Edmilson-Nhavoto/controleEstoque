using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ModeloCategoria
    {
        private int cat_cod;
        private String cat_nome;

        public int Cat_cod
        {
            get { return this.cat_cod; }
            set { cat_cod = value; }
        }

        public string Cat_nome
        {
            get {  return cat_nome; }
            set {  cat_nome = value; }
        }
    }
}
