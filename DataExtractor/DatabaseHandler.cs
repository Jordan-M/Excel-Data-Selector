using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor
{
    class DatabaseHandler
    {
        SQLiteConnection dbConnection;

        public DatabaseHandler(string datebaseLocation)
        {
            dbConnection = new SQLiteConnection(String.Format("Data Source={0}.cache;Version=3;", datebaseLocation));
            dbConnection.Open();
        }

        public void CsvToSql(string CsvPath)
        {
            CSVFile csv = new CSVFile(CsvPath);
            CreateTable(csv);
            InsertData(csv);
        }

        public void CsvToSql(List<string> CsvData)
        {
            CSVFile csv = new CSVFile(CsvData);
            CreateTable(csv);
            InsertData(csv);
        }

        private void CreateTable(CSVFile csv)
        {
            string[] headers = csv.GetRowAsArray(0);

            StringBuilder formattedHeaders = new StringBuilder();
            foreach (string s in headers)
            {
                formattedHeaders.Append(s);
                formattedHeaders.Append(" text varchar(100),");
            }
            formattedHeaders.Length--; // Remove last comma

            SQLiteCommand sqlCommand = dbConnection.CreateCommand();
            sqlCommand.CommandText = String.Format("CREATE TABLE cache ({0});", formattedHeaders.ToString());
            sqlCommand.ExecuteNonQuery();
        }

        private void InsertData(CSVFile csv)
        {
            SQLiteCommand sqlCommand;
            sqlCommand = new SQLiteCommand("begin", dbConnection);
            sqlCommand.ExecuteNonQuery();

            StringBuilder queryFormat = new StringBuilder();

            for (int i = 1; i < csv.Rows; i++)
            {
                string[] content = csv.GetRowAsArray(i);
                sqlCommand.CommandText = "";
            }

            sqlCommand = new SQLiteCommand("end", dbConnection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}