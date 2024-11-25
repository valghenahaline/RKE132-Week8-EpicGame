
string folderPath = @"D:\Visual Studio\data\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));


//string[] heroes = { "Rammus", "Teemo", "Ekko", "Heimerdinger" };
//string[] villains = { "Moredekaiser", "Yuumi", "Warwick", "Silco", "Jynx"};


string[] weapons = { "Golden spatula", "Ninja tabis", "BORK", "Kraken slayer", "Zhonya's hourglass", "banana"};

string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapons);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine ($"Today {hero} ({heroHP} HP) saves the day with {heroWeapon}!");
   


string villain = GetRandomValueFromArray(villains); 
string villainWeapon = GetRandomValueFromArray(weapons);
int villainHP = GetCharacterHP (villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) tries to take over Piltover with {villainWeapon}!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if(heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"{villain} has taken over!");
}
else
{
    Console.WriteLine("Draw!");
}


static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}


static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10 )
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}


static int Hit (string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target");
    }
    else if(strike == characterHP -1) 
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!"); 
    }

    return strike;
}




