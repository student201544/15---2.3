﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken
{
    public class Game
    {
        private int[,] area = null; // Игровое поле
        private int? lenX = null; // Длина X
        private int? lenY = null; // Длина Y


        public Game() { }

        public Game(
            int i1, int i2, int i3,
            int i4, int i5, int i6,
            int i7, int i8, int i9) // Поле 3*3
        {
            area = new int[3, 3]; // Инициализируем поле (задаем размеры)

            area[0, 0] = i9;
            area[0, 1] = i1;
            area[0, 2] = i2;

            area[1, 0] = i3;
            area[1, 1] = i4;
            area[1, 2] = i5;

            area[2, 0] = i6;
            area[2, 1] = i7;
            area[2, 2] = i8;

            lenX = 3; // Длина X
            lenY = 3; // Длина Y
        }

        public Game(
            int i1, int i2, int i3, int i4,
            int i5, int i6, int i7, int i8,
            int i9, int i10, int i11, int i12,
            int i13, int i14, int i15, int i16) // Поле 4*4
        {
            area = new int[4, 4];

            area[0, 0] = i16;
            area[0, 1] = i1;
            area[0, 2] = i2;
            area[0, 3] = i3;

            area[1, 0] = i4;
            area[1, 1] = i5;
            area[1, 2] = i6;
            area[1, 3] = i7;

            area[2, 0] = i8;
            area[2, 1] = i9;
            area[2, 2] = i10;
            area[2, 3] = i11;

            area[3, 0] = i12;
            area[3, 1] = i13;
            area[3, 2] = i14;
            area[3, 3] = i15;

            lenX = 4;
            lenY = 4;
        }


        public int this[int x, int y] // Индексатор, который позволяет определить значение по координатам
        {
            get
            {
                if (x >= lenX || y >= lenY || x < 0 || y < 0)
                {
                    return -1;
                }

                return area[x, y];
            }
        }

        public int[] GetLocation(int value) // Получить координаты элемента по значению.
        {
            int[] a = new int[2];
            a[0] = -1;
            a[1] = -1;

            for (int i = 0; i < lenX; i++)
            {
                for (int j = 0; j < lenY; j++)
                {
                    if (area[i, j] == value)
                    {
                        a[0] = i;
                        a[1] = j;
                    }
                }
            }

            return a;
        }

        private Dictionary<string, int[]> prepareCheckCoords(int x, int y)
        {
            Dictionary<string, int[]> retData = new Dictionary<string, int[]>();

            retData.Add("UP", new int[2] { x, y - 1 });
            retData.Add("RIGHT", new int[2] { x + 1, y });
            retData.Add("DOWN", new int[2] { x, y + 1 });
            retData.Add("LEFT", new int[2] { x - 1, y });

            return retData;
        }

        private Print print = new Print(); // Для вывода информации на экран консоли
        public virtual void Shift(int value) // Перемешение фишки на свободное место
        {
            var coord = GetLocation(value);
            if (coord[0] == -1 || coord[1] == -1) //проверяем, что точка в пределах поля
            {
                print.Message("Невозможно совершить перемещение. Такой фишки на поле не существует.");
            }
            else
            {
                bool isMove = false; // Флаг, для проверки удалось пердвинуть фишку или нет

                foreach (var point in prepareCheckCoords(coord[0], coord[1]))
                {
                    int[] val = new int[2] { point.Value[0], point.Value[1] };
                    if (this[val[0], val[1]] == 0 && !isMove)
                    {
                        area[val[0], val[1]] = value; //пустой верхней фишке присваиваем значение перемещаемой фишки
                        area[coord[0], coord[1]] = 0; //перемещаемую фишку делаем пустой, присваивая ноль

                        //Log.PrintAction(point.Key, val[0], val[1]);
                        Console.WriteLine(point.Key + ". Координаты ({0}, {1}).", val[0], val[1]);

                        isMove = true;
                    }
                }

                if (!isMove)
                {
                    // если все четрые соседние клетки не пустые
                    print.Message("Невозможно совершить перемещение. Рядом нет пустой клетки.");
                }

                return;
            }
        }

        public int Length
        {
            get { return (int)lenX; }
        }

        public int zX
        {
            get { return (int)lenX; }
            set { lenX = value; }
        }

        public int zY
        {
            get { return (int)lenY; }
            set { lenY = value; }
        }

        public int[,] Area
        {
            get { return area; }
            set { area = value; }
        }
    }
}
