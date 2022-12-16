
using System.Text.RegularExpressions;


var zodis = new[]
{
    "televizorius",
    "lektuvas",
    "kakava",
    "geografija",
    "kompiuteris",
    "automobilis",
    "vardas",
    "pavarde",
    "planas",
    "zmogus",
    "teismas",
    "ratas",
    "draugas",
    "vilkas",
    "sportininkas",
    "pinigai",
    "svecias",
    "ukininkas",
    "arklys",
    "svarstykles",
};


var pasirinktasZodis = zodis[new Random().Next(0, zodis.Length - 1)];
var rastmenys = new Regex("[a-z]");
var gyvybes = 5;
var raides = new List<string>();




Console.WriteLine("  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n=========");
Console.WriteLine("Sveiki atvykę !");
Console.WriteLine();
Console.WriteLine("Šiandien žaisime žaidimą  - HANGMAN !");
Console.WriteLine();
Console.WriteLine("Taisyklės :\r\n 1 - Turite 5 spėjimus .\r\n 2 - Naudojamos tik mažosios raidės .\r\n 3 - Naudojami lietuviški žodžiai , bet be lietuviškų raštmenų balsių (ą, ę, į, ų) ir raidžių su diakritiniais ženklais (č, š, ž, ė, ū).");
Console.WriteLine();
Console.WriteLine("Pradėti spausti - (Y) \r\nNežaisti spausti - (N)");

bool zaisti = true;
while (zaisti)
{
    Console.WriteLine("Ar noretumėte pradėti?");
    string pasirinkimas = Console.ReadLine();

    
    if (pasirinkimas == "Y")
    {
        zaisti = false;
    }
    else if (pasirinkimas != "N" && pasirinkimas != "Y")
    {
        Console.WriteLine();
        Console.WriteLine("Blogai įvesta ! Reikia įvesti(Y/N)");
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Apgailestaujame , kad nenorite žaisti! :( ");
        return;
    }

   

}






while (gyvybes != 0)
{
     var likusiosRaides = 0;
    foreach (var x in pasirinktasZodis)
    {
        var raide = x.ToString();

       
        if (raides.Contains(raide))
        {
            Console.Write(raide);
        }
        else
        {
            Console.Write("-");

            likusiosRaides++;
        }
    }
    Console.WriteLine(string.Empty);
    if (likusiosRaides == 0)
    {
        break;
    }
    Console.WriteLine();
    Console.Write("(Įveskite raidę): ");
    Console.WriteLine();
    var key = Console.ReadKey().Key.ToString().ToLower();
    Console.WriteLine(string.Empty);
    Console.WriteLine();

    if (!rastmenys.IsMatch(key))
    {
        Console.WriteLine();
        Console.WriteLine($"(Raidė {key} neteisinga. Bandykite dar kartą.)");
        Console.WriteLine();
        continue;
    } 
    if (raides.Contains(key))
    {

        Console.WriteLine();
        Console.WriteLine("(Raidė jau buvo panaudota!)");
        Console.WriteLine();
        continue;
    }


    raides.Add(key);

    if (!pasirinktasZodis.Contains(key))
    {
        gyvybes--;
        if (gyvybes > 0)
        {
            Console.WriteLine();
            Console.WriteLine($"(Raidės {key} nėra šiame žodyje. Liko {gyvybes} {(gyvybes == 1 ? "bandymai" : "bandymai.)")}");
            Console.WriteLine();

        }
    }
}


if (gyvybes > 0)
{
    Console.WriteLine();
    Console.WriteLine($"(Laimėjote ! Su  {gyvybes} {(gyvybes == 1 ? "gyvybe" : "likusiom")} gyvybėmis!)");
    
}
else
{
    Console.WriteLine();
    Console.WriteLine($"(Pralaimėjote :( ! Teisingas žodis - {pasirinktasZodis}.)");
}
