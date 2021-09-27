using System;
using Microsoft.Data.Sqlite;
namespace Library
{
    public static class Sql
    {    




        public static void addDay(string day,decimal weight,decimal bmi,int calories)
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
        public static void updateDay(string day,decimal bmi,decimal weight,int calories)
        {  
            using var connection = new SqliteConnection("Data Source=./Data/health.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                UPDATE healthInfo
                SET  weight = $weight, bmi = $bmi, calories = $calories
                WHERE date = $day;
               
            ";
            //YYYY-MM-DD
            command.Parameters.AddWithValue("$day",day);
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
            using var reader = command.ExecuteReader();
        }
        public static void showHealth()
        {
            using var connection = new SqliteConnection("Data Source=./Data/health.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT *
                FROM healthInfo
                ORDER BY date;
            ";
            using var reader = command.ExecuteReader();
            Console.WriteLine(@"LOG:DATE - Weight - BMI - CALORIES");
                Console.WriteLine("___________________________");
            while(reader.Read())
            {
                {
                var date = reader.GetString(0);
                var weight = reader.GetDecimal(1);
                var bmi = reader.GetDecimal(2);
                var calories = reader.GetInt32(3);

                
                Console.WriteLine($"Row: {date} - {weight} - {bmi} - {calories}");
                }
            }
        }
        public static void showHealthByCalories()
        {
            using var connection = new SqliteConnection("Data Source=./Data/health.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT *
                FROM healthInfo
                ORDER BY calories;
            ";
            using var reader = command.ExecuteReader();
            Console.WriteLine(@"LOG:DATE - Weight - BMI - CALORIES");
                Console.WriteLine("___________________________");
            while(reader.Read())
            {
                {
                var date = reader.GetString(0);
                var weight = reader.GetDecimal(1);
                var bmi = reader.GetDecimal(2);
                var calories = reader.GetInt32(3);

                
                Console.WriteLine($"Row: {date} - {weight} - {bmi} - {calories}");
                }
            }
        }
    }   
}
