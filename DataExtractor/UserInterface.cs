using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataExtractor
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        private void uxFileSelectButton_Click(object sender, EventArgs e)
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

                DatabaseHandler database = new DatabaseHandler(uxOpenFile.FileName);
                database.CsvToSql(csv);
            }
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {
        }
    }
}
