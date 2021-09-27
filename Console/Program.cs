using System;
using Library;
namespace myConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var consoleControl = true;
            
            while(consoleControl){
                Console.WriteLine("\n\n");
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
                        var input = Console.ReadLine();
                        var info = input.Split(",");
                        Sql.addDay(info[0],Convert.ToDecimal(info[1]),Convert.ToDecimal(info[2]),Convert.ToInt32(info[3]));
                        break;
                    case "1":
                    Console.WriteLine(@"Date format YYYY-MM-DD
                                            Input : Date,Weight,BMI,Calories");
                        var input1 = Console.ReadLine();
                        var info1 = input1.Split(",");
                        Sql.updateDay(info1[0],Convert.ToDecimal(info1[1]),Convert.ToDecimal(info1[2]),Convert.ToInt32(info1[3]));
                        break;
                    case "2":
                        Console.WriteLine(@"Date format YYYY-MM-DD
                                            Input : Date");
                        var info2 = Console.ReadLine();
                        Sql.removeDay(info2);
                        break;
                    case "":
                        consoleControl = false;
                        break;

                }

                



            }
        }
    }
}
