using System;
using Library;
namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var consoleControl = true;
            
            while(consoleControl){
                Sql.showHealth();
                Console.WriteLine(@"
                                    
                                    Input 0 to Add a Day option 
                                    Input 1 to Pick a day to Update 
                                    Input 2 to Pick a day to Delete
                                    Press Enter to Quit");


                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine(@"Date format YYYY-MM-DD
                                            Input : Date,BMI,Weight,Calories");
                        var info = Console.ReadLine();
                        info = info.split(",");
                        Sql.addDay(info[0],Convert.ToDecimal(info[1]),Convert.ToDecimal(info[2]),Convert.ToInt32(info[3]));
                        break;
                    case "1":
                    Console.WriteLine(@"Date format YYYY-MM-DD
                                            Input : Date,Weight,BMI,Calories");
                        var info = Console.ReadLine();
                        info = info.split(",");
                        Sql.updateDay(info[0],Convert.ToDecimal(info[1]),Convert.ToDecimal(info[2]),Convert.ToInt32(info[3]));
                        break;
                    case "2":
                        Console.WriteLine(@"Date format YYYY-MM-DD
                                            Input : Date");
                        var info = Console.ReadLine();
                        Sql.removeDay(info);
                        break;
                    case "":
                        break;

                }

                



            }
        }
    }
}
