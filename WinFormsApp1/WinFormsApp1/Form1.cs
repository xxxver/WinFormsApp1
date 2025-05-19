using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1;Database=111";

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProductsToFlowPanel();
        }

        private void LoadProductsToFlowPanel()
        {
            flowLayoutPanel1.Controls.Clear();

            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;

            flowLayoutPanel1.Size = new Size(748, 380);
            flowLayoutPanel1.MaximumSize = flowLayoutPanel1.Size;
            flowLayoutPanel1.MinimumSize = flowLayoutPanel1.Size;
            flowLayoutPanel1.Dock = DockStyle.None;

            List<int> productIds = GetAllProductIds();

            foreach (int productId in productIds)
            {
                var item = new List(connectionString);
                item.FillProductInfo(productId);

                item.Size = new Size(700, 280);
                item.MaximumSize = item.Size;
                item.MinimumSize = item.Size;
                item.AutoSize = false;

                flowLayoutPanel1.Controls.Add(item);
            }
        }

        private List<int> GetAllProductIds()
        {
            var ids = new List<int>();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id FROM Продукты ORDER BY id;";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ids.Add(reader.GetInt32(0));
                    }
                }
            }
            return ids;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateProduct form = new CreateProduct();
            form.FormClosed += (s, args) => LoadProductsToFlowPanel();
            form.ShowDialog();
        }
    }
}
