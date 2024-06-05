using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPractica
{
    public partial class NameForm : Form
    {
        public string WorkerName { get; private set; }

        public NameForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtWorkerName.Text))
            {
                // Set the WorkerName property and DialogResult to OK
                WorkerName = txtWorkerName.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please enter the worker's name.");
            }
        }

        private void NameForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}