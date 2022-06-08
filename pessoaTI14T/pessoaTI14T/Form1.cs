using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pessoaTI14T
{
    public partial class Form1 : Form
    {

        DAOpessoa pessoa;

        public Form1()
        {

            InitializeComponent();
            pessoa = new DAOpessoa();// Abrindo conexao com o BD

        }// fim do método construtor 

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            maskedTextBox1.Text = "" + pessoa.ConsultarCPF(Convert.ToInt32(textBox1.Text));
            textBox2.Text       = pessoa.ConsultarNome(Convert.ToInt32(textBox1.Text));
            maskedTextBox2.Text = pessoa.ConsultarTelefone(Convert.ToInt32(textBox1.Text));
            textBox4.Text       = pessoa.ConsultarEndereco(Convert.ToInt32(textBox1.Text));

        }// Fim do botão consultar

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                //int codigo = Convert.ToInt32(textBox1.Text);// coletando o dado do campo do codigo
                string tratamentoCPF = maskedTextBox1.Text.Replace(",", "");
                tratamentoCPF = tratamentoCPF.Replace("-", "");

                long cpf = Convert.ToInt64(tratamentoCPF);// coletando do campo cpf
                string nome = textBox2.Text;// coletando do campo nome
                string telefone = maskedTextBox2.Text;// coletando do campo telefone
                string endereco = textBox4.Text;// coletando do campo endereco 

                pessoa.Inserir(cpf, nome, telefone, endereco);

            }catch(Exception erro)
            {

                MessageBox.Show("" + erro);

            }

        }// Fim do botão Cadastrar

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Atualizar_Click(object sender, EventArgs e)
        {

        }// Fim do botão atualizar

        private void Excluir_Click(object sender, EventArgs e)
        {

        }// Fim do botão excluir

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }// textBox de código 

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }// maskedTextBox de CPF

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }// textBox de nome

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }// maskedtextbox de telefone

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }// textbox de endereco
    }// Fim class

}// Fim projeto
