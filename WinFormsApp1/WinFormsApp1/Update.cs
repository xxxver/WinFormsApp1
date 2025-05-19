using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace WinFormsApp1
{
    public partial class Update : Form
    {
        private string connectionString;
        private int productId;

        public Update(string connString, int id)
        {
            InitializeComponent();
            connectionString = connString;
            productId = id;

            LoadComboBoxes();
            LoadData();
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

        private void LoadData()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
SELECT
    артикул,
    название_продукта,
    минимальная_стоимость,
    id_тип_продукции,
    id_тип_материала,
    (SELECT время_изготовления_часы FROM Цех_Продукция WHERE продукт_id = @id LIMIT 1) AS время_изготовления
FROM Продукты
WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = reader["артикул"].ToString();
                            textBox2.Text = reader["название_продукта"].ToString();
                            textBox3.Text = reader["минимальная_стоимость"].ToString();
                            comboBox1.SelectedValue = Convert.ToInt32(reader["id_тип_продукции"]);
                            comboBox2.SelectedValue = Convert.ToInt32(reader["id_тип_материала"]);

                            double baseHours = 1.0;

                            if (reader["время_изготовления"] != DBNull.Value)
                            {
                                baseHours = Convert.ToDouble(reader["время_изготовления"]);
                            }

                            double adjusted = baseHours * 1.5;
                            int h = (int)adjusted;
                            int m = (int)Math.Round((adjusted - h) * 60);

                            string hoursText = h == 1 ? "1 час" : $"{h} часа";
                            string minutesText = m == 1 ? "1 минута" : $"{m} минут";

                            label4.Text = $"{hoursText} {minutesText}";
                            label4.Font = new Font(label4.Font, FontStyle.Bold);
                        }
                    }
                }
            }
        }

        private void SaveChanges()
        {
            var result = MessageBox.Show("Вы точно хотите сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
UPDATE Продукты
SET артикул = @a,
    название_продукта = @n,
    минимальная_стоимость = @m,
    id_тип_продукции = @tp,
    id_тип_материала = @tm
WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@a", textBox1.Text);
                    cmd.Parameters.AddWithValue("@n", textBox2.Text);
                    cmd.Parameters.AddWithValue("@m", decimal.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@tp", Convert.ToInt32(comboBox1.SelectedValue));
                    cmd.Parameters.AddWithValue("@tm", Convert.ToInt32(comboBox2.SelectedValue));
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Изменения сохранены.");
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }
    }
}
