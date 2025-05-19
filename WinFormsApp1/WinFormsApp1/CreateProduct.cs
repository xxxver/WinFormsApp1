using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace WinFormsApp1
{
    public partial class CreateProduct : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1;Database=111";

        public CreateProduct()
        {
            InitializeComponent();
            LoadComboBoxes();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void LoadComboBoxes()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT id, название_типа FROM Типы_Продукции", conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "название_типа";
                    comboBox1.ValueMember = "id";
                }

                using (var cmd = new NpgsqlCommand("SELECT id, название_типа FROM Тип_Материала", conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "название_типа";
                    comboBox2.ValueMember = "id";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите добавить новый продукт?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите тип продукции и материал.");
                return;
            }

            int productId;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string insertProductQuery = @"
INSERT INTO Продукты (артикул, название_продукта, минимальная_стоимость, id_тип_продукции, id_тип_материала)
VALUES (@a, @n, @m, @tp, @tm)
RETURNING id;";
                using (var cmd = new NpgsqlCommand(insertProductQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@a", textBox1.Text);
                    cmd.Parameters.AddWithValue("@n", textBox2.Text);
                    cmd.Parameters.AddWithValue("@m", decimal.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@tp", Convert.ToInt32(comboBox1.SelectedValue));
                    cmd.Parameters.AddWithValue("@tm", Convert.ToInt32(comboBox2.SelectedValue));
                    productId = (int)cmd.ExecuteScalar();
                }

                double exampleTime = 1.0; 
                double timeForInsert = exampleTime * 1.5;

                string insertTimeQuery = @"
INSERT INTO Цех_Продукция (продукт_id, цех_id, время_изготовления_часы)
VALUES (@pid, 1, @t);";
                using (var cmd = new NpgsqlCommand(insertTimeQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.Parameters.AddWithValue("@t", timeForInsert);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Продукт добавлен.");
        }
    }
}
