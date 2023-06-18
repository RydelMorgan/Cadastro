using MySql.Data.MySqlClient;
using System.Data;


namespace BDSimples
{
    public partial class Cadastros : Form
    {
        string connstring = "Server=localhost;uid=root;pwd=root;database=auesolucoes";
        private int userID;

        public Cadastros()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GridFillSearch();

        }

        private void checkIfTextBoxIsEmpty()
        {
            if (nameBox.Text == "" || cityBox.Text == "")
            {
                throw new Exception("Nome ou cidade se encontra vazio");
            }
        }

        private String getCheckedRadioValue()
        {
            if (M.Checked == true) return M.Name;
            if (F.Checked == true) return F.Name;
            throw new Exception("Sexo não selecionado");
        }

        void GridFillSearch()
        {
            try
            {

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = connstring;
                con.Open();

                string sql = "SELECT codcontato, nome AS Name, sexo AS Sexo, cidade AS Cidade, date_format(data_cadastro, '%d-%m-%Y') AS 'Data do Cadastro' FROM cadastros";

                MySqlDataAdapter sqlDa = new MySqlDataAdapter(sql, con);
                DataTable dtblUser = new DataTable();

                sqlDa.Fill(dtblUser);
                dgvSearch.DataSource = dtblUser;
                dgvSearch.Columns[0].Visible = false;
                dgvSearch.Rows[dgvSearch.Rows.Count - 1].Height = -1;

                analiseText.Text = "";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void headerContar()
        {
            try
            {
                String allRegistersSQL = "SELECT " +
                    "count(codcontato) as total, " +
                    "SUM(CASE WHEN sexo = 'M' THEN 1 ELSE 0 END) AS total_homens, " +
                    "SUM(CASE WHEN sexo = 'F' THEN 1 ELSE 0 END) AS total_mulheres " +
                    "FROM cadastros";

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = connstring;
                con.Open();
                MySqlCommand cmd = new MySqlCommand(allRegistersSQL, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    analiseText.Text = "Análise dos contatos: \r\n" +
                                       " .Número de contatos no banco de dados: "
                                       + reader.GetString(0) + ", " + reader.GetString(1) +
                                       " homens e " + reader.GetString(2) + " mulheres";
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private List<String> cityList()
        {
            String existingCitiesSQL = "SELECT DISTINCT cidade FROM cadastros";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();
            MySqlCommand cmd = new MySqlCommand(existingCitiesSQL, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<string> citiesList = new List<string>();

            while (reader.Read())
            {
                string result = reader.GetString(0);
                citiesList.Add(result);
            }
            reader.Close();
            return citiesList;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = connstring;
                con.Open();

                string sql = "INSERT INTO cadastros (nome, cidade, sexo, data_cadastro) values (@nome , @cidade, @sexo, CURRENT_DATE())";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                checkIfTextBoxIsEmpty();

                cmd.Parameters.AddWithValue("@nome", nameBox.Text);
                cmd.Parameters.AddWithValue("@cidade", cityBox.Text);
                cmd.Parameters.AddWithValue("@sexo", getCheckedRadioValue());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cadastrado com sucesso");
                GridFillSearch();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ocorreu um erro ao conectar no banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnContar_Click(object sender, EventArgs e)
        {
            try
            {
                String registerPerMonthSQL = "SET lc_time_names = 'pt_BR';" +
                    "SELECT " +
                    "MONTHNAME(data_cadastro) AS mes, " +
                    "SUM(CASE WHEN sexo = 'M' THEN 1 ELSE 0 END) AS total_homens, " +
                    "SUM(CASE WHEN sexo = 'F' THEN 1 ELSE 0 END) AS total_mulheres " +
                    "FROM cadastros where cidade=@city " +
                    "GROUP BY MONTHNAME(data_cadastro)";

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = connstring;
                con.Open();
                headerContar();

                List<string> citiesList = cityList();
                int index = 0;

                while (index < citiesList.Count)
                {
                    MySqlCommand cmd = new MySqlCommand(registerPerMonthSQL, con);
                    cmd.Parameters.AddWithValue("@city", citiesList[index]);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    int cadastroTotalPorCidade = 0;

                    analiseText.Text += "\r\n\r\n.Contatos em " + citiesList[index].ToUpper() + ":";
                    while (reader.Read())
                    {
                        String homem = reader.GetInt32(1) > 1 || reader.GetInt32(1) == 0 ? " homens e " : " homem e ";
                        String mulher = reader.GetInt32(2) > 1 || reader.GetInt32(2) == 0 ? " mulheres" : " mulher";

                        analiseText.Text += "\r\n" +
                            (char.ToUpper(reader.GetString(0)[0]) + reader.GetString(0).Substring(1)) +
                            ": " + (reader.GetInt32(1) + reader.GetInt32(2)) + ", " +
                            reader.GetInt32(1) + homem + reader.GetInt32(2) + mulher;
                        cadastroTotalPorCidade += reader.GetInt32(1) + reader.GetInt32(2);
                    }
                    analiseText.Text += "\r\nTotal: " + cadastroTotalPorCidade;
                    reader.Close();
                    index++;

                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvSearch.CurrentRow.Index == 0) throw new Exception("Nenhum cadastro selecionado");
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = connstring;
                con.Open();

                string sql = "DELETE FROM cadastros WHERE codcontato=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", userID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastrado excluido");


                GridFillSearch();
                analiseText.Text = "";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ocorreu um erro ao conectar no banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = connstring;
                con.Open();

                string sql = "UPDATE cadastros SET nome = @nome, sexo = @sexo, cidade = @cidade WHERE codcontato=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                checkIfTextBoxIsEmpty();

                cmd.Parameters.AddWithValue("@nome", nameBox.Text);
                cmd.Parameters.AddWithValue("@cidade", cityBox.Text);
                cmd.Parameters.AddWithValue("@sexo", getCheckedRadioValue());
                cmd.Parameters.AddWithValue("@id", userID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastrado atualizado");

                GridFillSearch();
                analiseText.Text = "";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ocorreu um erro ao conectar no banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSearch_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSearch.CurrentRow.Index != -1)
            {
                nameBox.Text = dgvSearch.CurrentRow.Cells[1].Value.ToString();
                cityBox.Text = dgvSearch.CurrentRow.Cells[3].Value.ToString();
                if (dgvSearch.CurrentRow.Cells[2].Value.ToString() == "M") M.Checked = true;
                else F.Checked = true;
                userID = Convert.ToInt32(dgvSearch.CurrentRow.Cells[0].Value.ToString());
            }
        }
    }
}