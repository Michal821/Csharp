using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool exit = false;
            double frameRate = 1000 / 5.0; //speed 
            DateTime lastDate = DateTime.Now;
            Meal meal = new Meal();    // point
            Snake snake = new Snake();    
           
            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                
                   // Console.WriteLine("test input ");
                   switch(input.Key)
                    {
                        case ConsoleKey.Escape:
                            exit = true; //stop while
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;

                    }
                }
                // Console.WriteLine("test 01");
                if ((DateTime.Now - lastDate).TotalMilliseconds >= frameRate)
                {

                    snake.Move();
                    if (meal.CurrentTarget.X == snake.HeadPosition.X
                        && meal.CurrentTarget.Y == snake.HeadPosition.Y)
                    {
                        snake.EatMeal();
                        meal = new Meal();
                        frameRate /= 1.1;
                    }

                    lastDate = DateTime.Now;

                    if (snake.GameOver)
                    {
                        Console.Clear();
                        Console.WriteLine($"GAME OVER");


                        exit = true;
                        Console.ReadLine();
                    }    
                }
            }
        }
    }
}
