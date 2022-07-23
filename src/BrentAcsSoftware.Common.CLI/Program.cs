using BrentAcsSoftware.Common.Leisure.Utilities;

Console.WriteLine("Hello, World!");

var dice = Dice.Crypto;
for (int i = 0; i < 20; i++)
{
   Console.WriteLine($"{dice.NextD10()}");
}
