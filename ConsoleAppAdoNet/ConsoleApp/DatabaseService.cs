using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp
{
    public class DatabaseService
    {
        private string _connectionString;

        public DatabaseService()
        {
            _connectionString = @"Data Source=(local); Initial catalog=Calendaryk; Integrated Security=True";
        }

        private string RandomString(int length = 16)
        {
            Random random = new Random();
            var rString = "";
            for (var i = 0; i < length; i++)
            {
                rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
            }
            return rString;
        }

        private DateTime RandomDate()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1918, 1, 22);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        private List<int> GetAllId(string tableName)
        {

            string sqlExpression = $"SELECT * FROM {tableName}";
            string parentTable = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                parentTable = reader.GetName(1).Substring(2);
                parentTable += "s";
                reader.Close();
            }

            sqlExpression = $"SELECT * FROM {parentTable}";
            List<int> idList = new List<int>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) 
                        idList.Add(Convert.ToInt32(reader.GetValue(0)));

                }
                reader.Close();
            }
            return idList;
        }
        private int RandomInt(string tableName)
        {
            var values = GetAllId(tableName);
            Random random = new Random();
            int index = random.Next(values.Count);
            return values[index];
        }

        public void ShowAllDataFrom(string tableName)
        {
            string sqlExpression = $"SELECT * FROM {tableName}";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                int index = 0;
                if (reader.HasRows)
                {
                    while (reader.VisibleFieldCount != index)
                    {
                        Console.Write("{0}\t", reader.GetName(index));
                        index++;
                    }

                    Console.WriteLine();
                    while (reader.Read())
                    {
                        for (int i = 0; i < index; i++)
                        {
                            Console.Write("{0} \t", reader.GetValue(i));
                        }
                        Console.WriteLine();
                    }
                }
                reader.Close();
            }
        }

        public void RandomInsertionInto(string tableName, int rowsCount)
        {
            string sqlExpression = $"SELECT * FROM {tableName}";
            string SQLCommand = $"INSERT INTO {tableName} ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var commandSelect = new SqlCommand(sqlExpression, connection);
                var reader = commandSelect.ExecuteReader();
                var columnsName = new List<string>();
                var columnsDataType = new List<string>();
                for (int i = 1; i < reader.VisibleFieldCount; i++)
                {
                    columnsName.Add(reader.GetName(i));
                    columnsDataType.Add(reader.GetDataTypeName(i));
                }
                reader.Close();

                SQLCommand += "(";
                for (int i = 0; i < columnsName.Count - 1; i++)
                {
                    SQLCommand += columnsName[i] + ", ";
                }

                SQLCommand += $"{columnsName[columnsName.Count - 1]}) VALUES ";
                for (int i = 0; i < rowsCount; i++)
                {
                    if (i != 0)
                        SQLCommand += ",";

                    SQLCommand += "(";
                    for (int j = 0; j < columnsName.Count; j++)
                    {
                        switch (columnsDataType[j])
                        {
                            case "varchar":
                                SQLCommand += $"'{RandomString(10)}', ";
                                break;
                            case "int":
                                SQLCommand += $"{RandomInt(tableName)}, ";
                                break;
                            case "smalldatetime":
                                SQLCommand += $"'{RandomDate():yyyy-MM-dd HH:mm:ss}', ";
                                break;
                        }
                    }

                    SQLCommand = SQLCommand.Remove(SQLCommand.Length - 2) + ")";
                }
                SqlCommand command = new SqlCommand(SQLCommand, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
