using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using Console = Colorful.Console;

namespace ColorBlockArray {
    internal class Program {
        private static int linespc = 15; //设置要输出多少行换列，这里15就是输出15个颜色快然后换列
        private static int space = 2; //每列间距

        static void cbac(int[] a, int maxvalue) {
            //定义变量
            int col = 0; //控制换列输出
            int outputs = 0; //控制换列输出
            int length = a.Length; //数组长度
            int lvl1 = Convert.ToInt32(maxvalue * 0.2); //等级最小值设定
            int lvl2 = Convert.ToInt32(maxvalue * 0.4);
            int lvl3 = Convert.ToInt32(maxvalue * 0.6);
            int lvl4 = Convert.ToInt32(maxvalue * 0.8);
            int lvl5 = maxvalue;
            for (int i = 0; i < length; i++) {
                if (outputs >= linespc) {
                    //控制换列输出
                    col++;
                    outputs = 0;
                    Thread.Sleep(10); //设置一些无用延时。可去除
                }

                Console.SetCursorPosition(col * space, outputs); //控制换列输出

                if (a[i] >= lvl5) {
                    //颜色块输出
                    Console.Write("█ ", Color.FromArgb(0, 100, 0));
                    outputs++;
                }

                else if (a[i] >= lvl4) {
                    Console.Write("█ ", Color.FromArgb(0, 128, 0));
                    outputs++;
                }

                else if (a[i] >= lvl3) {
                    Console.Write("█ ", Color.FromArgb(50, 205, 50));
                    outputs++;
                }

                else if (a[i] >= lvl2) {
                    Console.Write("█ ", Color.FromArgb(152, 251, 152));
                    outputs++;
                }

                else if (a[i] > 0) {
                    Console.Write("█ ", Color.FromArgb(127, 255, 187));
                    outputs++;
                }

                else if (a[i] == 0) {
                    Console.Write("█ ", Color.FromArgb(255, 255, 255));
                    outputs++;
                } //颜色块输出
            }
        }

        static void cbacwithoutcolo(int[] a, int maxvalue) {
            //不带换列输出，代码只是去掉了我注释换列输出位置的代码以及相关变量，
            int length = a.Length;
            int lvl1 = Convert.ToInt32(maxvalue * 0.2);
            int lvl2 = Convert.ToInt32(maxvalue * 0.4);
            int lvl3 = Convert.ToInt32(maxvalue * 0.6);
            int lvl4 = Convert.ToInt32(maxvalue * 0.8);
            int lvl5 = maxvalue;
            string block = "█ ";

            for (int i = 0; i < length; i++) {
                if (a[i] >= lvl5) {
                    Console.Write(block, Color.FromArgb(0, 100, 0));
                }

                else if (a[i] >= lvl4) {
                    Console.Write(block, Color.FromArgb(0, 128, 0));
                }

                else if (a[i] >= lvl3) {
                    Console.Write(block, Color.FromArgb(50, 205, 50));
                }

                else if (a[i] >= lvl2) {
                    Console.Write(block, Color.FromArgb(152, 251, 152));
                }

                else if (a[i] > 0) {
                    Console.Write(block, Color.FromArgb(127, 255, 187));
                }

                else if (a[i] == 0) {
                    Console.Write(block, Color.FromArgb(255, 255, 255));
                }
            }
        }

        public static void Main(string[] args) {
            int[] a = new int[500];

            Random r = new Random();
            for (int i = 0; i < a.Length; i++) {
                a[i] = r.Next(-1, 114514);
            }

            int maxv = a.Max();
            Array.Sort(a);
            Array.Reverse(a);
            cbac(a, maxv);
            Console.SetCursorPosition(0, linespc + 3); //让不换列的输出与换列输出间隔3行，去掉不影响运行
            cbacwithoutcolo(a, maxv);
            Console.ReadKey();
        }
    }
}