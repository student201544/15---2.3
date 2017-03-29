using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken
{
    public class Game2 : Game
    {
        public Game2(
             int i1, int i2, int i3,
            int i4, int i5, int i6,
            int i7, int i8, int i9
            ) : base(i1, i2, i3,
            i4, i5, i6,
            i7, i8, i9)
        {
        }

        public Game2(
             int i1, int i2, int i3, int i4,
            int i5, int i6, int i7, int i8,
            int i9, int i10, int i11, int i12,
            int i13, int i14, int i15, int i16
            ) : base(i1, i2, i3,
            i4, i5, i6,
            i7, i8, i9, i10, i11, i12, i13, i14, i15, i16)
        { }

        public void RandomArea()
        {
            int[] a = new int[this.Length * this.Length];
            int k = 0;
            for (int i = 0; i < this.Length; i++)
            {
                for (int j = 0; j < this.Length; j++)
                {
                    a[k] = this.Area[i, j];
                    k++;
                }
            }

            var r = new Random();
            for (int i = a.Length - 1; i > 0; i--)
            {
                int j = r.Next(i);
                var t = a[i];
                a[i] = a[j];
                a[j] = t;
            }

            int[,] newArea = new int[this.Length, this.Length];
            k = 0;
            for (int i = 0; i < this.Length; i++)
            {
                for (int j = 0; j < this.Length; j++)
                {
                    newArea[i, j] = a[k];

                    if (a[k] == 0)
                    {
                        this.zX = i;
                        this.zY = j;
                    }

                    k++;
                }
            }

            this.Area = newArea;
        }

        public bool IsEndGame() // Определение выигрыша
        {
            int i, j, k = 1;

            for (i = 0; i < this.Length; i++)
            {
                for (j = 0; j < this.Length; j++)
                {
                    if (this.Area[this.Length - 1, this.Length - 1] == 0)
                    {
                        if (i == this.Length - 1 && j == this.Length - 1)
                        {
                            return true;
                        }
                        else
                        {
                            if (this.Area[i, j] != k)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }

                    k++;
                }
            }

            return true;
        }
    }
}
