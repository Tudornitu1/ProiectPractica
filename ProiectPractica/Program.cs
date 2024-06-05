using System;
using System.Windows.Forms;

namespace ProiectPractica
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Open WorkerNameForm first
            NameForm NameForm = new NameForm();
            if (NameForm.ShowDialog() == DialogResult.OK)
            {
                // Retrieve the worker's name
                string workerName = NameForm.WorkerName;

                // Create an instance of Form1, passing the worker's name
                Form1 mainForm = new Form1(workerName);
                Application.Run(mainForm);
            }
            else
            {
                // Handle cancel or close action
                // You may choose to exit the application or handle it differently
                MessageBox.Show("Worker name not provided. Exiting application.");
            }
        }
    }
}
