using System;
using System.Threading;
using System.IO;
using System.Text;
using static System.Console;


namespace ConsoleApp
{
    internal class Program
    {
        public static int W = 60;
        public static int H = 32;
        public static string Field = "";
        public static int cursor = 0;
        public static string login = "";
        public static string password = "";
        public static int screen = 0;
        public static int quest = 0;
        public static StreamReader sR1 = new StreamReader("Answers.txt");
        public static StreamReader sR2 = new StreamReader("Questions.txt", Encoding.Unicode);
        public static string[] ans = sR1.ReadLine().Split(' ');
        public static string[] q = sR2.ReadToEnd().Split('\n');
        public static void Window()
        {
            OutputEncoding = Encoding.Unicode;
            CursorVisible = false;
            WindowWidth = W;
            BufferWidth = W;
            WindowHeight = H;
            BufferHeight = H;
        }
        public static void Screen()
        {
            SetCursorPosition(0, 0);
            Write(Field);
            SetCursorPosition(0, 31);
            Write(cursor + 1);
            SetCursorPosition(3, 31);
            Write(login);
            SetCursorPosition(login.Length + 5, 31);
            Write(password);
            if (screen == 0)
            {
                SetCursorPosition(27, 5);
                Write("LOGIN");
                SetCursorPosition(18, 7);
                Write("╔═════════════════════╗");
                SetCursorPosition(18, 8);
                Write("║                     ║");
                SetCursorPosition(18, 9);
                Write("╚═════════════════════╝");
                SetCursorPosition(18, 11);
                Write("╔═════════════════════╗");
                SetCursorPosition(18, 12);
                Write("║                     ║");
                SetCursorPosition(18, 13);
                Write("╚═════════════════════╝");
                SetCursorPosition(18, 15);
                Write("╔═════════════════════╗");
                SetCursorPosition(18, 16);
                Write("║         OK          ║");
                SetCursorPosition(18, 17);
                Write("╚═════════════════════╝");
                SetCursorPosition(20, 8);
                Write(login);
                SetCursorPosition(20, 12);
                Write(password);
                SetCursorPosition(16, 8 + cursor * 4);
                Write(">");
            }
            else if (screen == 1)
            {
                SetCursorPosition(5, 5);
                if (q[quest * 5].Length < 50)
                {
                    Write(q[quest * 5]);
                }
                else
                {
                    for (int i = 0; i < 50; i++)
                    {
                        Write(q[quest * 5][i]);
                    }
                    SetCursorPosition(5, 7);
                    for (int i = 50; i < q[quest * 5].Length; i++)
                    {
                        Write(q[quest * 5][i]);
                    }
                }
                SetCursorPosition(7, 13);
                Write(q[quest * 5 + 1]);
                SetCursorPosition(7, 15);
                Write(q[quest * 5 + 2]);
                SetCursorPosition(7, 17);
                Write(q[quest * 5 + 3]);
                SetCursorPosition(7, 19);
                Write(q[quest * 5 + 4]);
                SetCursorPosition(5, 13 + cursor * 2);
                Write(">");
            }
        }
        static void Main(string[] args)
        {
            string[] ansUser = new string[6];
            Field += "╔══════════════════════════════════════════════════════════╗";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "║                                                          ║";
            Field += "╚══════════════════════════════════════════════════════════╝";
            Window();
            do
            {
                if (quest == 6)
                {
                    break;
                }
                Screen();
                Thread.Sleep(60);
                if (KeyAvailable)
                {
                    ConsoleKey key = ReadKey(false).Key;
                    switch (key)
                    {
                        case ConsoleKey.Enter:
                            if (screen == 0)
                            {
                                if (cursor == 0)
                                {
                                    SetCursorPosition(20, 8);
                                    CursorVisible = true;
                                    login = ReadLine();
                                    CursorVisible = false;
                                }
                                else if (cursor == 1)
                                {
                                    SetCursorPosition(20, 12);
                                    CursorVisible = true;
                                    password = ReadLine();
                                    CursorVisible = false;
                                }
                                else if (cursor == 2)
                                {
                                    screen = 1;
                                    cursor = 0;
                                }
                            }
                            else if (screen == 1)
                            {
                                ansUser[quest++] = (cursor + 1).ToString();
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (screen == 0)
                            {
                                cursor++;
                                if (cursor >= 3)
                                {
                                    cursor = 0;
                                }
                            }
                            else if (screen == 1)
                            {
                                cursor++;
                                if (cursor >= 4)
                                {
                                    cursor = 0;
                                }
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (screen == 0)
                            {
                                cursor--;
                                if (cursor <= -1)
                                {
                                    cursor = 2;
                                }
                            }
                            else if (screen == 1)
                            {
                                cursor--;
                                if (cursor <= -1)
                                {
                                    cursor = 3;
                                }
                            }
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
            } while (true);
            SetCursorPosition(0, 0);
            Write(Field);
            SetCursorPosition(0, 31);
            Write(cursor + 1);
            SetCursorPosition(3, 31);
            Write(login);
            SetCursorPosition(login.Length + 5, 31);
            Write(password);
            int score = 0;
            for (int i = 0; i < ansUser.Length; i++)
            {
                if (ansUser[i] == ans[i])
                {
                    score++;
                }
            }
            SetCursorPosition(25, 14);
            Write($"Score: {score}");
            SetCursorPosition(0, 31);
            sR1.Close();
            sR2.Close();
            StreamWriter sW = new StreamWriter("DataBase.txt", true);
            if (login != "")
            {
                sW.Write($"<{DateTime.Now}> {login} ({password}): {score}\n");
            }
            sW.Close();
            Thread.Sleep(3000);
        }
    }
}
