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
        public string msg;
        public int contador;
        public int i;// declarando o contador do for e do while

        public MySqlConnection conexao;

        // declarar os vetores...
        public int     []    vetorCodigo;
        public long    []    vetorCPF;
        public string  []    vetorNome;
        public string  []    vetorTelefone;
        public string  []    vetorEndereco;
        
        


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
                comando = "Insert into pessoaTI14T(codigo, CPF, nome, telefone, endereco) value" + dados;

                // Executar o comando na base de dados
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                MessageBox.Show(resultado + " Linha afetada! ");

            }catch(Exception erro)
            {

                MessageBox.Show("Algo deu errado!\n\n" + erro);

            }

        }// Fim método inserir

        public void PreencherVetor()
        {

            string query = "select * from pessoaTI14T";// comando para coletar dados do BD

            // Instanciando os vetores...
            vetorCodigo    = new int[100];
            vetorCPF       = new long[100];
            vetorNome      = new string[100];
            vetorTelefone  = new string[100];
            vetorEndereco  = new string[100];

            // Preencher os vetores criados anteriormente, ou seja, dar valores iniciais para os vetores.

            for(int i = 0; i < 100; i++)
            {

                vetorCodigo[i]    = 0;
                vetorCPF[i]       = 0;
                vetorNome[i]      = "";
                vetorTelefone[i]  = "";
                vetorEndereco[i]  = "";

            }// Fim do for

            // realizar os comandos de consulta ao BD
            MySqlCommand coletar = new MySqlCommand(query, conexao);

            //ler os dados de acordo com o que esta no BD
            MySqlDataReader leitura = coletar.ExecuteReader();// variavel leitura, faz uma consulta ao BD

            i = 0;
            contador = 0;

            //preencher os vetores com dados do BD
            while (leitura.Read()) // enquanto for verdadeiro, executa o que está no while
            {

                vetorCodigo[i]    = Convert.ToInt32(leitura["codigo"]);
                vetorCPF[i]       = Convert.ToInt64(leitura["CPF"]);
                vetorNome[i]      = leitura["nome"] + "";
                vetorTelefone[i]  = leitura["telefone"] + "";
                vetorEndereco[i]  = leitura["endereco"] + "";
                i++;// contador sai de zero e vai se incrementando 
                contador++;

            }// Fim while

            leitura.Close();// Fechar 

        }// Fim método preencherVetor

        // criar um consultar tudo por messageBox

        public string ConsultarTudo()
        {

            PreencherVetor();//preencher os vetores com dados do BD

            msg = "";

            for(i = 0; i < contador; i++)
            {

                msg = "Código: "    + vetorCodigo[i] +
                      "CPF: "       + vetorCPF[i] +
                      "Nome: "      + vetorNome[i] +
                      "Telefone: "  + vetorTelefone[i] +
                      "Endereço: "  + vetorEndereco[i] +
                      "\n\n";

            }// Fim do for

            return msg; // retorna todos os dados armazenados na variavel msg

        }// Fim consultar tudo 

        public long ConsultarCPF(int cod)
        {

            PreencherVetor();

            for (i = 0; i < contador; i++)
            {

                if (vetorCodigo[i] == cod)
                {

                    return vetorCPF[i];

                }// Fim if

            }// Fim do for

            return -1;

        }// Fim do consultarCPF

        public string ConsultarNome(int cod)
        {

            PreencherVetor();
            for(i = 0; i < contador; i++)
            {

                if (vetorCodigo[i] == cod)
                {

                    return vetorNome[i];

                }// Fim do if

            }// Fim for 

            return "Nome não encontrado!";

        }// Fim consultar nome

        public string ConsultarTelefone(int cod)
        {

            PreencherVetor();
            for (i = 0; i < contador; i++)
            {

                if (vetorCodigo[i] == cod)
                {

                    return vetorTelefone[i];

                }// Fim do if

            }// Fim for 

            return "Telefone não encontrado!";

        }// Fim consultar telefone

        public string ConsultarEndereco(int cod)
        {

            PreencherVetor();
            for (i = 0; i < contador; i++)
            {

                if (vetorCodigo[i] == cod)
                {

                    return vetorEndereco[i];

                }// Fim do if

            }// Fim for 

            return "Endereço não encontrado!";

        }// Fim consultar endereco

        public void Atualizar(int cod, string campo, string novoDado)
        {

            try
            {

                string query = "update pessoaTI14T set " + campo + "= '" + novoDado + "'where codigo = '" + cod + "'";

                MySqlCommand sql = new MySqlCommand(query, conexao);

                MessageBox.Show(resultado + "Linha afetada");

            }
            catch (Exception erro)
            {

                MessageBox.Show("" + erro);

            }

        }// Fim método atualizar


        public void Deletar(int cod)
        {

            try
            {

                string query = "delete from pessoaTI14T where codigo = '" + cod + "'";
                MySqlCommand sql = new MySqlCommand(query, conexao);

                string resultado = "" + sql.ExecuteNonQuery();
                MessageBox.Show(resultado + "Linha Afetada!");

            }catch(Exception erro)
            {

                MessageBox.Show("" + erro);

            }

        }
    }// Fim class

}// Fim projeto 
