using AspCore_Crud.Models.Interfaces;
using ASpCore_Infra;
using System.Data;
using System.Data.SqlClient;
namespace AspCore_Crud.Models
{
    public class FuncionarioDAL : IFuncionarioDAL
    {

        public void AddFuncionario(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(DataBase.ConnectionString))
            {
                string comandoSQL = @"Insert into Funcionarios (Nome,Cidade,Departamento,Sexo) 
                                                        Values(@Nome, @Cidade, @Departamento, @Sexo)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Cidade", funcionario.Cidade);
                cmd.Parameters.AddWithValue("@Departamento", funcionario.Departamento);
                cmd.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteFuncionario(int? id)
        {
            using (SqlConnection con = new SqlConnection(DataBase.ConnectionString))
            {
                string comandoSQL = "Delete from Funcionarios where FuncionarioId = @FuncionarioId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FuncionarioId", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public IEnumerable<Funcionario> GetAllFuncionarios()
        {
            var IstFuncionario = new List<Funcionario>();

            using (SqlConnection con = new SqlConnection(DataBase.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT FuncionarioId, Nome,Cidade, Departamento,Sexo from Funcionarios", con);
                cmd.CommandType = System.Data.CommandType.Text; 

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.FuncionarioId = Convert.ToInt32(reader["FuncionarioId"]);
                    funcionario.Nome = reader["Nome"].ToString();
                    funcionario.Cidade = reader["Cidade"].ToString();
                    funcionario.Departamento = reader["Departamento"].ToString();
                    funcionario.Sexo = reader["Sexo"].ToString();

                    IstFuncionario.Add(funcionario);
                }
                con.Close();
            }
            return IstFuncionario;
        }

        public Funcionario GetFuncionario(int id)
        {
            Funcionario funcionario = new Funcionario();
            using(SqlConnection con = new SqlConnection( DataBase.ConnectionString))
            {
                string sqlQuery = "SELECT * FROM Funcionarios WHERE FuncionarioId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    funcionario.FuncionarioId = Convert.ToInt32(reader["FuncionarioId"]);
                    funcionario.Nome = reader["Nome"].ToString();
                    funcionario.Cidade = reader["Cidade"].ToString();
                    funcionario.Departamento = reader["Departamento"].ToString();
                    funcionario.Sexo = reader["Sexo"].ToString();
                }
                return funcionario;
            }
        }

        public void UpdateFuncionario(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(DataBase.ConnectionString))
            {
                string comandoSQL = @"Update Funcionarios set Nome = @Nome, Cidade = @Cidade, Departamento = 
                                                              @Departamento, Sexo = @Sexo where FuncionarioId = @FuncionarioId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FuncionarioId", funcionario.FuncionarioId);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Cidade", funcionario.Cidade);
                cmd.Parameters.AddWithValue("@Departamento", funcionario.Departamento);
                cmd.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
