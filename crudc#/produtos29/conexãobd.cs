using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace produtos29
{
    class conexãobd
    {
        private MySqlConnection conexao;
        
        public void Conectar()
        {
            conexao = new MySqlConnection("persist security info = false;server=localhost;database=produtos2c1;uid=root;pwd=;");
            conexao.Open();
        }
        // insert - delete - update
        public void AlterarTabelas(string sql)
        {
            Conectar();
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        //select 
        public DataTable ConsultarTabelas(string sql)
        {
            Conectar();
            MySqlDataAdapter consulta = new MySqlDataAdapter(sql, conexao);
            DataTable resultado = new DataTable();
            consulta.Fill(resultado);
            conexao.Close();
            return resultado;
        }

    }
}
