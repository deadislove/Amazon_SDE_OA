// See https://aka.ms/new-console-template for more information
using Amazon_SDE_OA.Number_Game;
using Amazon_SDE_OA.Robot_Bounded_in_Box;
using Amazon_SDE_OA.Shopping_Options;

Console.WriteLine("Amazon SDE OA problems.");
Console.WriteLine("------------------------------\n");

new Robot_Bounded_in_Box().Solution();
Console.WriteLine();
new Number_Game().Solution();
Console.WriteLine();
new Shopping_Options().Solution();