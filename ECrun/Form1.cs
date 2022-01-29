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
        string[] TypesForEnv = {
            "React",
        };
        string[] TypesForRun =
        {
            "Reac",
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Items = new string[0];
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Items = TypesForEnv;
                    break;
                case 1:
                    Items = TypesForRun;
                    break;
            }

            comboBox2.Items.Clear();
            foreach (var Item in Items)
            {
                comboBox2.Items.Add(Item);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
