using System;
using Microsoft.Data.Sqlite;
namespace Library
{
    public static class Sql
    {    




        public static void addDay(string day,decimal bmi,decimal weight,int calories)
        {  
            using var connection = new SqliteConnection("Data Source=./Data/health.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                INSERT INTO healthInfo(date,weight,bmi,calories)
                VALUES ($date, $weight,$bmi,$calories)
            ";
            //YYYY-MM-DD
            command.Parameters.AddWithValue("$date",day);
            command.Parameters.AddWithValue("$weight",weight);
            command.Parameters.AddWithValue("$bmi",bmi);
            command.Parameters.AddWithValue("$calories",calories);
            using var reader =  command.ExecuteReader();
        }




        public static void removeDay(string day)
        {  
            using var connection = new SqliteConnection("Data Source=./Data/health.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                DELETE
                FROM healthInfo
                WHERE date = $date;
            ";
            command.Parameters.AddWithValue("$date",day);
        }
    }
}
