using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;

namespace WinFormsAppFoto
{
    public class Foto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string foto { get; set; }

        MySqlConnection con = new MySqlConnection("server=127.0.0.1;port=3306;database=aula;user id=root;password=Debase33@;charset=utf8");

        public List<Foto> listafoto()
        {
            List<Foto> li = new List<Foto>();
            try
            {
                string sql = "SELECT * FROM aluno";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Foto foto = new Foto();
                    foto.id = (int)dr["id"];
                    foto.nome = dr["nome"].ToString();
                    foto.foto = dr["foto"].ToString();
                    li.Add(foto);

                    // Log para verificar os dados retornados
                    Console.WriteLine($"ID: {foto.id}, Nome: {foto.nome}, Foto: {foto.foto}");
                }
                dr.Close();
                con.Close();

                if (li.Count == 0)
                {
                    Console.WriteLine("Nenhum dado encontrado no banco.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar dados: {ex.Message}");
            }
            return li;
        }


        public void Inserir(string nome, string foto)
        {
            try
            {
                string sql = "INSERT INTO aluno(nome, foto) VALUES('" + nome + "', '" + foto + "')";
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }

        public void Atualizar(int id, string nome, string foto)
        {
            try
            {
                string sql = "UPDATE aluno SET nome = @nome, foto = @foto WHERE id = @id";
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@foto", foto);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show($"Erro ao atualizar registro no banco de dados: {er.Message}");
            }
        }

        public void Excluir(int id)
        {
            try
            {
                string sql = "DELETE FROM aluno WHERE id='" + id + "'";
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }


    }
}
