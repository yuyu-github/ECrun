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
       Dictionary<string, ComboBoxItems> Types = new Dictionary<string, ComboBoxItems>
        {
            {
                "BuildEnv", new ComboBoxItems(new string[,] {
                    { "React", "React" },
                })
            },
            {
                "Run", new ComboBoxItems(new string[,] {
                    { "React", "React" },
                })
            },
        };

        Dictionary<string, Dictionary<string, ComboBoxItems>> Templates = new Dictionary<string, Dictionary<string, ComboBoxItems>>
        {
            {
                "BuildEnv", new Dictionary<string, ComboBoxItems> {
                    
                }
            },
            {
                "Run", new Dictionary<string, ComboBoxItems> {

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

            public ComboBoxItems(string[,] items)
            {
                for (int i = 0; i < items.Length / 2; i++)
                {
                    var item = new ComboBoxItem();
                    item.Name = items[i, 0];
                    item.Id = items[i, 1];
                    this.List.Add(item);
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
            comboBox2.DataSource = Types[comboBox1.SelectedValue.ToString()].List;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DataSource = Templates[comboBox1.SelectedValue.ToString()]
                .TryGetValue(comboBox2.SelectedValue.ToString(), out var result) ? result.List : (new ComboBoxItems(new string[,] { { "デフォルト", "Default" } })).List;
            comboBox3.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
