using Game;
using Game2;
using System.Threading.Channels;

Random random = new Random();
WanDarkHolme pashalka = new WanDarkHolme();

string hello = @"
               _                            _          _   _                 _       _       _               _     _        
              | |                          | |        | | | |               | |     | |     | |             | |   | |       
 __      _____| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___    ___| |_   _| |__   | |__  _   _  __| | __| |_   _  
 \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \  / __| | | | | '_ \  | '_ \| | | |/ _` |/ _` | | | | 
  \ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/ | (__| | |_| | |_) | | |_) | |_| | (_| | (_| | |_| | 
   \_/\_/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___|  \___|_|\__,_|_.__/  |_.__/ \__,_|\__,_|\__,_|\__, | 
                                                                                                                      __/ | 
                                                                                                                     |___/  
";
Console.WriteLine(hello);

List<string> names = new List<string> {
"Валеркин","Апрашкин","Сан4езкин","Димазкин","Маслёнкин","Севчизкин","ВотИзЛавкин","Мамадзиёзкин"
};

Console.WriteLine("Введи кол-во игроков");
int bots = int.Parse(Console.ReadLine());

beztebya[] player = new beztebya[bots];

for (int i = 0; i < player.Length; i++)
{
    player[i] = new beztebya();
}


for (int i = 0; i < player.Length; i++)
{
    bool friend = false;
    int ForRandomName = random.Next(0,8);
    int ForRandomFriend = random.Next(0,2);
    if (ForRandomFriend == 0)
    {
        friend = false;
    }
    else { friend = true; }
    int lives = 100;


    player[i].Info(names[ForRandomName],random.Next(1,100), random.Next(1,100), friend, lives,random.Next(10,20));
}
Console.Clear();
for (int i = 0; i < player.Length; i++)
{
    Console.Write(i + 1 + " ");
    player[i].Print();
}

Console.Write("Выбери своего героя: ");
int hero = int.Parse(Console.ReadLine())-1;




while (true)
{
    Console.WriteLine("\n0 - Информация о всех героях.\n1 - Поменять героя.\n2 - Движение.\n3 - УНИЧТОЖЕНИЕ.\n4 - Битва.\n5 - Лечение.\n6 - Полное восстановление здоровья.\n7 - Смена лагеря.\n8 - Информация о соём герое.");
    Console.Write("Ввод: ");
    int what = int.Parse(Console.ReadLine());
    Console.WriteLine();


    int xp = player[hero].getxp();
    if (xp < 1)
    {
        Console.Clear();
        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(i + 1 + " ");
            player[i].Print();
        }
        Console.WriteLine("Ваш герой отправился на фонтан, давай меняй героя");
        Console.Write("Выбери нового героя: ");
        hero = int.Parse(Console.ReadLine()) - 1;
    }

    if (what == 8)
    {
        Console.Clear();
        player[hero].Print();
        Console.WriteLine();
    }

    if (what == 0)
    {
        Console.Clear();
        for (int i = 0; i < player.Length; i++)
        {
            player[i].Print();
        }
    }

    if (what == 1)
    {
        Console.Clear();
        Console.WriteLine("Выбери своего героя: ");
        hero = int.Parse(Console.ReadLine())-1;
    }

    if (what == 2)
    {
        Console.Clear();
        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(i + 1 + " ");
            player[i].Print();
        }
        Console.WriteLine("Перемещение героя.");
        Console.Write("Введи координаты x: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Введи координаты y: ");
        int y = int.Parse(Console.ReadLine());
        player[hero].MoveX(x);
        player[hero].MoveY(y);
    }

    if (what == 3)
    {

        Console.Clear();
        Console.WriteLine("Режим турбо пушки");

        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(i+1 + " ");
            player[i].Print();
        }

        Console.WriteLine("Введи номер игрока, которого АНИГИЛИРУЕМ: ");
        int anigilate = int.Parse(Console.ReadLine())-1;

        if (player[hero].getl() == player[anigilate].getl())
        {
            Console.WriteLine("ЭЭЭ, СВОИ СВОИ БРАТ. Ты волыну то убери.\n");
        }

        else if (player[hero].getx() == player[anigilate].getx() && player[hero].gety()==player[anigilate].gety()) 
        {
            player[anigilate].Del(anigilate);
            
        
        } else
        { 
            Console.WriteLine("Дружок - перожок, тобой выбранна неправильная координата. Клуб кожевенного мастерства парой координат дальше."); 
        }
        

    }
    if (what == 4)
    {
        Console.Clear();
        for (int i = 0; i < player.Length; i++)
        {
            Console.Write(i + 1 + " ");
            player[i].Print();
        }
        Console.WriteLine("Введи номер игрока с которым хотим пообщаться: ");
        int anigilate = int.Parse(Console.ReadLine()) - 1;

        if (player[hero].getl() == player[anigilate].getl())
        {
            Console.WriteLine("ЭЭЭ, СВОИ СВОИ БРАТ. Ты волыну то убери.\n");
        }

        else if (player[hero].getx() == player[anigilate].getx() && player[hero].gety() == player[anigilate].gety())
        {
            int du = player[hero].getdu();
            player[anigilate].Uron(du);

            du = player[anigilate].getdu();
            player[hero].Uron(du);

            player[hero].Print();
            player[anigilate].Print();

        }
        else if (player[hero].getx() != player[anigilate].getx() && player[hero].gety() == player[anigilate].gety()) 
        { 
            Console.WriteLine("Дружок - перожок, тобой выбранна неправильная координата. Клуб кожевенного мастерства парой координат дальше."); 
        }

    }

    if (what == 5)
    {
        Console.Write("Лечение.");
        int du = random.Next(5,20);
        player[hero].Doc(du);
    }

    if (what == 6)
    {
        Console.WriteLine("Полное восстановление здоровья.");
        player[hero].Vost();
    }

    if (what == 7)
    {
        Console.WriteLine("Смена лагеря.");
        player[hero].Lager();
    }

    if (what == 8800)
    {
        pashalka.RikardoMilos();
    }





}




//Продам гараж. Обращаться ко мне. Дане привет