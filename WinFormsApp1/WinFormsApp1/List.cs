using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace WinFormsApp1
{
    public partial class List : UserControl
    {
        private string connectionString;
        public int ProductId { get; private set; }

        public List(string connString)
        {
            InitializeComponent();
            connectionString = connString;

            this.Click += List_Click;
            foreach (Control ctrl in this.Controls)
                ctrl.Click += List_Click;
        }

        private void List_Load(object sender, EventArgs e)
        {
        }

        private void List_Click(object sender, EventArgs e)
        {
            Update updateForm = new Update(connectionString, ProductId);
            updateForm.ShowDialog();
        }

        public void FillProductInfo(int productId)
        {
            ProductId = productId;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
SELECT
    tp.название_типа AS тип_продукции,
    p.название_продукта,
    cp.время_изготовления_часы,
    p.артикул,
    p.минимальная_стоимость::text AS минимальная_стоимость,
    tm.название_типа AS основной_материал
FROM
    Продукты p
JOIN
    Типы_Продукции tp ON p.id_тип_продукции = tp.id
JOIN
    Тип_Материала tm ON p.id_тип_материала = tm.id
LEFT JOIN
    Цех_Продукция cp ON cp.продукт_id = p.id
WHERE
    p.id = @id
LIMIT 1;";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label1.Text = reader["тип_продукции"].ToString();
                            label2.Text = reader["название_продукта"].ToString();
                            label4.Text = reader["артикул"].ToString();
                            label5.Text = reader["минимальная_стоимость"].ToString();
                            label6.Text = reader["основной_материал"].ToString();

                            if (reader["время_изготовления_часы"] != DBNull.Value)
                            {
                                double totalHours = Convert.ToDouble(reader["время_изготовления_часы"]);
                                int hours = (int)totalHours;
                                int minutes = (int)Math.Round((totalHours - hours) * 60);

                                string hoursText = hours == 1 ? "1 час" : $"{hours} часа";
                                string minutesText = minutes == 1 ? "1 минута" : $"{minutes} минут";

                                if (hours == 0)
                                    label3.Text = $"{minutesText}";
                                else if (minutes == 0)
                                    label3.Text = $"{hoursText}";
                                else
                                    label3.Text = $"{hoursText} {minutesText}";

                                label3.Font = new Font(label3.Font, FontStyle.Bold);
                            }
                            else
                            {
                                label3.Text = "нет данных";
                                label3.Font = new Font(label3.Font, FontStyle.Regular);
                            }
                        }
                        else
                        {
                            label1.Text = "Нет данных";
                            label2.Text = "";
                            label3.Text = "";
                            label4.Text = "";
                            label5.Text = "";
                            label6.Text = "";
                        }
                    }
                }
            }

            Color customColor = ColorTranslator.FromHtml("#355CBD");
            label1.ForeColor = customColor;
            label2.ForeColor = customColor;
            label3.ForeColor = customColor;
            label4.ForeColor = customColor;
            label5.ForeColor = customColor;
            label6.ForeColor = customColor;
        }
    }
}
