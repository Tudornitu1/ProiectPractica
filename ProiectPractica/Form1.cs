using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProiectPractica
{
    public partial class Form1 : Form
    {
        private List<Task> tasks = new List<Task>();
        private int nextId = 1;
        private string workerName;
        public Form1(string workerName)
        {
            InitializeComponent();
            this.workerName = workerName;
            label1.Text = "Worker: " + workerName;
            ConfigureListView();
        }
        private void ConfigureListView()
        {
            listViewTasks.View = View.Details;
            listViewTasks.FullRowSelect = true;
            listViewTasks.Columns.Add("ID", 50);
            listViewTasks.Columns.Add("Description", 200);
        }

        private void RefreshListView()
        {
            listViewTasks.Items.Clear();
            foreach (var task in tasks)
            {
                ListViewItem item = new ListViewItem(task.Id.ToString());
                item.SubItems.Add(task.Description); // Add task description as a subitem
                listViewTasks.Items.Add(item);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTaskDescription.Text))
            {
                Task newTask = new Task { Id = nextId++, Description = txtTaskDescription.Text };
                tasks.Add(newTask);
                txtTaskDescription.Clear();
                RefreshListView();
                MessageBox.Show("Task added successfully.");
            }

        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count > 0)
            {
                var selectedItem = listViewTasks.SelectedItems[0];
                var selectedTask = tasks.Find(task => task.Id == int.Parse(selectedItem.SubItems[0].Text));
                if (selectedTask != null && !string.IsNullOrWhiteSpace(txtTaskDescription.Text))
                {
                    selectedTask.Description = txtTaskDescription.Text;
                    txtTaskDescription.Clear();
                    RefreshListView();
                    MessageBox.Show("Task edited successfully.");
                }

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count > 0)
            {
                var selectedItem = listViewTasks.SelectedItems[0];
                var selectedTask = tasks.Find(task => task.Id == int.Parse(selectedItem.SubItems[0].Text));
                if (selectedTask != null)
                {
                    tasks.Remove(selectedTask);
                    RefreshListView();
                    MessageBox.Show("Task removed successfully.");
                }
            }

        }

        




        private void listViewTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count > 0)
            {
                var selectedItem = listViewTasks.SelectedItems[0];
                txtTaskDescription.Text = selectedItem.SubItems[1].Text;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExportTasksToTxt();
        }
        private void ExportTasksToTxt()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File|*.txt";
            saveFileDialog.Title = "Save Tasks as Text File";

            // Show the SaveFileDialog and wait for the user to select a file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Open the file selected by the user for writing
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Write the tasks' information to the file
                        writer.WriteLine("Name :"+ workerName);
                        writer.WriteLine("=====");
                        writer.WriteLine("Tasks");
                        writer.WriteLine("=====");
                        writer.WriteLine();

                        foreach (var task in tasks)
                        {
                            writer.WriteLine($" {task.Id}, Description: {task.Description}");
                        }
                    }

                    MessageBox.Show("Tasks exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while exporting tasks: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
