using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class beztebya
    {
        private string s;
        private int x;
        private int y;
        private bool l;
        private int kol;
        private int uron;


        public void Info (string s, int x,int y, bool l,int kol, int uron)
        {
            this.s = s;
            this.x = x;
            this.y = y;
            this.l = l;
            this.kol = kol;
            this.uron=uron;
        }

        public void Print()
        {
            string friend;
            if (l==true)
            {
                friend = "Силы света";
            } else
            {
                friend = "Силы тьмы";
            }

            Console.WriteLine($"Имя: {s}. Координаты x:{x} y:{y}. {friend}. Количество его жизней: {kol}. Его урон: {uron}");
        }

        public void MoveX(int dx)
        {
            x = dx;
        }
        public void MoveY(int dy)
        {
            y = dy;
        }

       public int getx()
        {
            return x;

        }
        public int gety()
        {
            return y;
        }

        public void Del(int anigilate)
        {

            kol = 0;
            Console.WriteLine("Поганый ящер уничтожен.");
        }

        public int getdu()
        {
            return uron;
        }

        public void Uron (int anigilate)
        {
            kol = kol - anigilate;
            if (kol < 1) 
            {
                kol = 0;
                Console.WriteLine("\n (o-_-o) Он уже мёртв... Тебе весело издеваться над трупом?\n");
            }
        }

        public void Doc (int du)
        {
            kol += du;
            if (kol > 100)
            {
                Console.WriteLine("Нельзя быть здоровее 100 хп, считай что остальное ушло на благотварительность.");
                kol = 100;
            }
            Console.WriteLine("Бахнув кротовухи вы апнули своё здоровье до " + kol);
        }

        public void Vost()
        {
            Console.WriteLine("Бахнув байкальской водички вы отрегенились на 100. И ТЕПЕРЬ ГОТОВЫ СРАЖАТЬСЯ С ЯЩЕРАМИ ПРОКЛЯТЫМИ!");
            kol = 100;
        }

        public void Lager()
        {
            l = !l;
        }

        public int getxp()
        {
            return kol;
        }

        public bool getl()
        {
            return l;
        }







    }


}
