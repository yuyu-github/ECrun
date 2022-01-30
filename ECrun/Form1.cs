using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wecres.ECrun
{
    public partial class Form1 : Form
    {
       Dictionary<string, string[]> Types = new Dictionary<string, string[]>
        {
            {
                "BuildEnv", new string[]{
                    "React",
                }
            },
            {
                "Run", new string[] {
                    "Reac",
                }
            },
        };

        class ComboBoxItems
        {
            public class ComboBoxItem
            {
                public string Name { get; set; }
                public string Id { get; set; }
            }

            public List<ComboBoxItem> List { get; set; } = new List<ComboBoxItem>();

            public ComboBoxItems(string[,] Items)
            {
                for (int i = 0; i < Items.Length / 2; i++)
                {
                    var Item = new ComboBoxItem();
                    Item.Name = Items[i, 0];
                    Item.Id = Items[i, 1];
                    this.List.Add(Item);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new ComboBoxItems(new string[,] {
                { "環境構築", "BuildEnv" },
                { "実行", "Run" },
            }).List;
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Items = Types[comboBox1.SelectedValue.ToString()];

            comboBox2.Items.Clear();
            foreach (var Item in Items)
            {
                comboBox2.Items.Add(Item);
            }
            if (comboBox2.Items.Count != 0) comboBox2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
