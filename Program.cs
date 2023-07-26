using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using Console = Colorful.Console;
using Newtonsoft.Json;
namespace ColorBlockArray {
    public class Data {
        public int[] x { get; set; }
        public int[] y { get; set; }
        public int[][] colour { get; set; }
    }
    internal class Program {
        private static int linespc = 25; //设置要输出多少行换列，这里15就是输出15个颜色快然后换列
        private static int space = 3; //每列间距

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
            int To = 0;
            for (int i = 0; i < length; i++) {
                if (To % 2 == 0) {
                    Thread.Sleep(10);
                }

                if (outputs >= linespc) {
                    //控制换列输出
                    col++;
                    outputs = 0;
                    Thread.Sleep(10); //设置一些无用延时。可去除
                }

                Console.SetCursorPosition(col * space, outputs); //控制换列输出

                if (a[i] == 0) {
                    Console.Write("█ ", Color.FromArgb(22, 27, 34));
                    outputs++;
                }
                else if (a[i] >= lvl5) {
                    //颜色块输出
                    Console.Write("█ ", Color.FromArgb(57, 211, 83));
                    outputs++;
                }

                else if (a[i] >= lvl4) {
                    Console.Write("█ ", Color.FromArgb(38, 166, 65));
                    outputs++;
                }

                else if (a[i] >= lvl3) {
                    Console.Write("█ ", Color.FromArgb(38, 166, 65));
                    outputs++;
                }

                else if (a[i] >= lvl2) {
                    Console.Write("█ ", Color.FromArgb(0, 109, 50));
                    outputs++;
                }

                else if (a[i] > 0) {
                    Console.Write("█ ", Color.FromArgb(14, 68, 41));
                    outputs++;
                } //颜色块输出

                To++;
            }
        }

        static void cbacwithoutcolo(int[] a, int maxvalue) {
            //不带换列输出，代码只是去掉了我注释换列输出位置的代码以及相关变量，
            int length = a.Length;
            int lvl2 = Convert.ToInt32(maxvalue * 0.25);
            int lvl3 = Convert.ToInt32(maxvalue * 0.50);
            int lvl4 = Convert.ToInt32(maxvalue * 0.75);
            int lvl5 = maxvalue;
            string block = "█ ";
            //Console.Write($"{lvl2} {lvl3} {lvl4} {lvl5}\n");
            for (int i = 0; i < length; i++) {
                if (a[i] == 0) {
                    Console.Write(block, Color.FromArgb(22, 27, 34));
                }

                else if (a[i] > lvl4 && a[i] <= lvl5) {
                    Console.Write(block, Color.FromArgb(57, 211, 83));
                }

                else if (a[i] > lvl3 && a[i] <= lvl4) {
                    Console.Write(block, Color.FromArgb(38, 166, 65));
                }

                else if (a[i] > lvl2 && a[i] <= lvl3) {
                    Console.Write(block, Color.FromArgb(0, 109, 50));
                }

                else if (a[i] > 0 && a[i] <= lvl2) {
                    Console.Write(block, Color.FromArgb(14, 68, 41));
                }
                else {
                    Console.Write("11111");
                }
            }
        }

        static void xycb(int x, int y, int lvl) {
            string block = "█ ";
            //Console.Write($"{lvl2} {lvl3} {lvl4} {lvl5}\n");
            Console.SetCursorPosition(x,y);
            if (lvl == 0) {
                Console.Write(block, Color.FromArgb(22, 27, 34));
            }

            else if (lvl == 4) {
                Console.Write(block, Color.FromArgb(57, 211, 83));
            }

            else if (lvl == 3) {
                Console.Write(block, Color.FromArgb(38, 166, 65));
            }

            else if (lvl == 2) {
                Console.Write(block, Color.FromArgb(0, 109, 50));
            }

            else if (lvl == 1) {
                Console.Write(block, Color.FromArgb(14, 68, 41));
            }
            else {
                Console.Write("Unknown Level");
            }
        }
        static void rgbcb(int r, int g, int b,int x,int y) {
            string block = "█ ";
            Console.SetCursorPosition(x,y);
            Console.Write(block,Color.FromArgb(r,g,b));
        }

        public static void Main(string[] args) {
            int[] a = new int[1000];
            Random r = new Random();
            for (int i = 0; i < a.Length; i++) {
                a[i] = 0;
            }
            Array.Sort(a);
            Array.Reverse(a);
            //int[,] aaa = new int[10000,10000];
            //cbac是每5列换列输出
            //cbacwithoutcolo()是不换列换行输出
            int max = a.Max();
            cbacwithoutcolo(a, max);
                
            Console.ReadKey();
        }
    }
}