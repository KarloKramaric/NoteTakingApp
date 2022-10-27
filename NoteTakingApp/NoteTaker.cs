using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakingApp
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public NoteTaker()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            previousNotes.DataSource = notes;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void titleBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                titleBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
                noteBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
                editing = true;
            } 
            catch (Exception)
            {
                MessageBox.Show("Please select valid note to load.", "Error - note not selected");
            }
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();
                titleBox.Text = "";
                noteBox.Text = "";
                editing = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Please select valid note to delete.", "Error - Note not selected");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (titleBox.Text == "")
            {
                MessageBox.Show("Can't save empy note.", "Error - Note is empty");
            }
            else
            {
                if (editing)
                {
                    notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                    notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = noteBox.Text;
                }
                else
                {
                    notes.Rows.Add(titleBox.Text, noteBox.Text);
                }
                titleBox.Text = "";
                noteBox.Text = "";
                editing = false;
            }
        }

        private void closeNoteButton_Click(object sender, EventArgs e)
        {
            if (titleBox.Text == "")
            {
                MessageBox.Show("All notes are closed.", "Error - Note is closed");
            }
            else
            {
                titleBox.Text = "";
                noteBox.Text = "";
                editing = false;
            }
            
        }

        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
    }
}
