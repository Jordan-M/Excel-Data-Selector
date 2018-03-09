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

            string queryFormat = "INSERT INTO cache ({0}) VALUES ({1});";

            for (int i = 1; i < csv.Rows; i++)
            {
                string rowContent = csv.GetRow(i);
                Console.WriteLine(rowContent);
                sqlCommand.CommandText = String.Format(queryFormat, csv.GetRow(0), csv.GetRow(i));
                sqlCommand.ExecuteNonQuery();
            }

            sqlCommand = new SQLiteCommand("end", dbConnection);
            sqlCommand.ExecuteNonQuery();
        }

        public string[] RetrieveHeaders()
        {
            SQLiteCommand sqlCommand = new SQLiteCommand("select * from cache", dbConnection);
            SQLiteDataReader reader = sqlCommand.ExecuteReader();

            string[] headers = new string[reader.FieldCount];

            for (var i = 0; i < reader.FieldCount; i++)
            {
                headers[i] = reader.GetName(i);
            }

            return headers;
        }
    }
}