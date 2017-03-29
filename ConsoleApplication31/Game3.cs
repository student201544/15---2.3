using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken
{
    public class Game3 : Game2
    {
        public Game3(
             int i1, int i2, int i3,
            int i4, int i5, int i6,
            int i7, int i8, int i9
            ) : base(i1, i2, i3,
            i4, i5, i6,
            i7, i8, i9)
        {
        }

        public Game3(
             int i1, int i2, int i3, int i4,
            int i5, int i6, int i7, int i8,
            int i9, int i10, int i11, int i12,
            int i13, int i14, int i15, int i16
            ) : base(i1, i2, i3,
            i4, i5, i6,
            i7, i8, i9, i10, i11, i12, i13, i14, i15, i16)
        { }

        private Print print = new Print(); // Для вывода информации на экран консоли
        public override void Shift(int value)
        {
            var coord = this.GetLocation(value);

            if (coord[0] == -1 || coord[1] == -1)
            {
                int path = (int)Math.Sqrt(Math.Abs(Math.Pow(coord[0] - this.zX, 2) + Math.Pow(coord[1] - this.zY, 2)));

                if (path == 1)
                {
                    this.Area[this.zX, this.zY] = value; // пустой клетке присваиваем значение перемещаемой фишки
                    this.Area[coord[0], coord[1]] = 0; // перемещаемую фишку делаем пустой, присваивая ноль

                    this.zX = coord[0]; // перезаписываем координаты 0
                    this.zY = coord[1];

                    print.Message("Фишка перемещена");
                    print.SaveAction("Фишка со значением " + value + ", перемещена на  (" + this.zX + ", " + this.zY + ")");
                }
                else
                {
                    // если все четрые соседние клетки не пустые
                    print.Message("Невозможно совершить перемещение. Рядом нет пустой клетки.");
                    print.SaveAction("Невозможно совершить перемещение. Рядом нет пустой клетки.");
                }
            }
        }

        public void PrintLogActions()
        {
            foreach (var item in print.GetActions())
            {
                Console.WriteLine("Шаг {0}: {1}", item.Key, item.Value);
            }
        }
    }
}
