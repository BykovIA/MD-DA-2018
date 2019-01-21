using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salaryPrediction
{
    public partial class Form1 : Form
    {
        SalaryPredictor predictor;
        public Form1()
        {
            InitializeComponent();
            predictor = new SalaryPredictor("..//..//Data");
            predictor.GetModel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int exp = Int32.Parse(textBox3.Text);
            int fte = Int32.Parse(textBox2.Text);
            string region = comboBox2.Text;
            string subcategory = comboBox3.Text;
            string qual = comboBox1.Text;
            
            textBox1.Text = predictor.Predict(exp, region, subcategory, qual, fte);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
