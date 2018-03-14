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
using DataAccess;
using System.IO;

namespace DataExtractor
{
    public partial class UserInterface : Form
    {
        LINQDatabaseHandler csvHandler = null;

        public UserInterface()
        {
            InitializeComponent();
        }

        private void uxFileSelectButton_Click(object sender, EventArgs e)
        {
            if (uxOpenFile.ShowDialog() == DialogResult.OK)
            {
                MutableDataTable csv;

                try
                {
                    csv = ExcelReader.Read(uxOpenFile.FileName);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                uxHeaderSelect.Items.Clear();
                uxDataSelect.Items.Clear();

                csvHandler = new LINQDatabaseHandler(csv);

                UpdateHeaderComboBox();
            }
        }

        private void UpdateHeaderComboBox()
        {
            string[] headers = csvHandler.RetrieveHeaders();
            foreach (string header in headers)
            {
                uxHeaderSelect.Items.Add(header);
            }

            uxHeaderSelect.SelectedIndex = 0;
        }

        private void UpdateDataComboBox(string header)
        {
            List<string> data = csvHandler.RetrieveDataFromHeader(header);
            foreach (string item in data.OrderBy(s => s))
            {
                uxDataSelect.Items.Add(item);
            }
            uxDataSelect.SelectedIndex = 0;

            using (StreamWriter sr = new StreamWriter("C:\\Users\\Jordan\\Desktop\\LOG.txt"))
            {
                foreach (string item in uxDataSelect.Items)
                {
                    sr.WriteLine(item);
                }
            }

        }

        private void UserInterface_Load(object sender, EventArgs e)
        {
        }

        private void uxHeaderSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            uxDataSelect.Items.Clear();
            UpdateDataComboBox(uxHeaderSelect.SelectedItem.ToString());
        }
    }
}
