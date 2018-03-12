using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataExtractor
{
    public partial class UserInterface : Form
    {
        DatabaseHandler database = null;
        public UserInterface()
        {
            InitializeComponent();
        }

        private async void uxFileSelectButton_Click(object sender, EventArgs e)
        {
            if (uxOpenFile.ShowDialog() == DialogResult.OK)
            {
                List<string> csv;
                try
                {
                    csv = ExcelReader.Read(uxOpenFile.FileName);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (database != null)
                {
                    database.Close();
                    uxHeaderSelect.Items.Clear();
                    uxDataSelect.Items.Clear();
                }

                database = new DatabaseHandler(uxOpenFile.FileName);
                await Task.Run(() => database.CsvToSql(csv));

                UpdateHeaderComboBox(database);
            }
        }

        private void UpdateHeaderComboBox(DatabaseHandler database)
        {
            string[] headers = database.RetrieveHeaders();
            foreach (string header in headers)
            {
                uxHeaderSelect.Items.Add(header);
            }

            uxHeaderSelect.SelectedIndex = 0;
        }

        private void UpdateDataComboBox(string header, DatabaseHandler database)
        {
            List<string> data = database.RetrieveDataFromHeader(header);
            foreach (string s in data)
            {
                uxDataSelect.Items.Add(s);
            }
            uxDataSelect.SelectedIndex = 0;
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {
        }

        private void uxHeaderSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            uxDataSelect.Items.Clear();
            UpdateDataComboBox(uxHeaderSelect.SelectedItem.ToString(), database);
        }
    }
}
