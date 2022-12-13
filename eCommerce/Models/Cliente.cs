using MySqlConnector;
using System;

namespace eCommerce.Models
{
    public class Cliente
    {
        // Atributos da classe cliente
        private string nome;
        private string cpf;
        private string email;
        private string senha;
        private int cep;
        private string logradouro;
        private int numero;
        private string complemento;
        private string bairro;
        private string cidade;

        // Criando a conexão com banco
        const string conString = "Server=ESN509VMYSQL;Database=db_djmtech;User id=aluno;Password=Senai1234";

        // Getters e Setters da classe cliente 
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public int Cep { get => cep; set => cep = value; }
        public string Logradouro { get => logradouro; set => logradouro = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Complemento { get => complemento; set => complemento = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cidade { get => cidade; set => cidade = value; }

        // Método utilizado para verificar se já possui o email cadastrado no banco
        public bool VerificarUsuarioExistente()
        {
            MySqlConnection con = new MySqlConnection(conString);
            bool x = false;
            try
            {
                con.Open();

                MySqlCommand query = new MySqlCommand("select * from cliente where email = @email", con);
                query.Parameters.AddWithValue("@email", email);
                MySqlDataReader leitor = query.ExecuteReader();

                if (leitor.HasRows)
                {
                    x = true;
                }
                else
                {
                    x = false;
                }

                con.Close();
                return x;

            }
            catch (Exception)
            {
                return x;
            }
        }

        // Método para cadastrar um novo cliente no banco 
        public string Inserir()
        {
            bool x = false;

            x = VerificarUsuarioExistente();
            MySqlConnection con = new MySqlConnection(conString);

            try
            {
                con.Open();
                if (!x)
                {
                    MySqlCommand query = new MySqlCommand("INSERT INTO cliente(nome,bairro,cep,numero,cidade,complemento," +
                        "email,senha,cpf,logradouro) VALUES(@nome,@bairro,@cep,@numero,@cidade,@complemento," +
                        "@email,@senha,@cpf,@logradouro)", con);
                    query.Parameters.AddWithValue("@nome", nome);
                    query.Parameters.AddWithValue("@cpf", cpf);
                    query.Parameters.AddWithValue("@email", email);
                    query.Parameters.AddWithValue("@senha", senha);
                    query.Parameters.AddWithValue("@cep", cep);
                    query.Parameters.AddWithValue("@logradouro", logradouro);
                    query.Parameters.AddWithValue("@numero", numero);
                    query.Parameters.AddWithValue("@complemento", complemento);
                    query.Parameters.AddWithValue("@bairro", bairro);
                    query.Parameters.AddWithValue("@cidade", cidade);
                    query.ExecuteNonQuery();
                    con.Close();
                    return "Inserido com sucesso!";
                }
                else
                {
                    con.Close();
                    return "Já possui cadastro";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
