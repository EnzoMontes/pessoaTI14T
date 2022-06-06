using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace pessoaTI14T
{

    class DAOpessoa
    {

        public string dados;
        public string comando;
        public string resultado;

        public MySqlConnection conexao;

        public DAOpessoa()
        {

            conexao = new MySqlConnection("server=localhost;DataBase=turma14;Uid=root;password=");

            try
            {

                conexao.Open();//tentando conectar ao BD
                MessageBox.Show("Conectado com sucesso!");

            }catch(Exception erro)
            {

                MessageBox.Show("Algo deu errado!\n\n" + erro);// Enviano messagem de erro aos usuarios 
                conexao.Close(); // Fechando a conexao com o banco de dados 

            }

        }// Fim método daopessoa

        public void Inserir(long cpf, string nome, string telefone, string endereco)
        {

            try
            {

                // Preparar os dados para inserir no BD
                dados = "('','" + cpf + "','" + nome + "','" + telefone + "','" + endereco + "')";
                comando = "Insert into pessoaTI14T(codigo, cpf, nome, telefon, endereco) value" + dados;

                // Executar o comando na base de dados
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                MessageBox.Show(resultado + " Linha afetada! ");

            }catch(Exception erro)
            {

                MessageBox.Show("Algo deu errado!\n\n" + erro);

            }

        }// Fim método inserir

    }// Fim class

}// Fim projeto 
