using System;
using System.IO;
using System.Security.Cryptography;


namespace ConsoleApp3
{
    internal class Program
    {

        static string file = "C:/Users/lucyf/Documents/Testing/ConsoleApp3/Users.txt";
        static void Main(string[] args)
        {
            //Definicion de variables
            String user, pswd;            

            //Llamar al Menu de Login, luego por cada tecla presionada en la posicion (60,13) aplicar un '*'
            do
            {
                LoginM();
                ConsoleKeyInfo key;
                pswd = "";
                Console.SetCursorPosition(60, 12);
                user = Console.ReadLine().Trim();
                Console.SetCursorPosition(60, 13);
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        pswd += key.KeyChar;
                        Console.Write("*");
                    }
                } while (key.Key != ConsoleKey.Enter);
            } while (!LoginU(user, pswd));
            
            while (true)
            {
                MainM();
                Console.SetCursorPosition(70, 18);
                int option;

                do
                {
                    String op = Console.ReadLine();
                    int.TryParse(op, out option);
                } while (option < 0 || option > 5);

                switch (option)
                {
                    case 1: UserM(); break;
                    case 2: UserM(); break;
                    case 3: UserM(); break;
                    case 4: Environment.Exit(0); break;
                    default: break;
                }
            } 
        }

        public static void LoginM()
        {
            //Lineas de recuadro grafico ┌─┐└┘ │
            //Ventana para entrar al Sistema
            //Se determina el tamanno de la ventana
            Console.SetWindowSize(100, 50);
            //Se determina donde estara el cursor en la siguiente linea de codigo
            Console.SetCursorPosition(45, 30);
            Console.WriteLine("┌───────────────────────────┐");
            Console.SetCursorPosition(45, 31);
            Console.WriteLine("│      ACCESO A SISTEMA     │");
            Console.SetCursorPosition(45, 32);
            Console.WriteLine("│      User: [           ]  │");
            Console.SetCursorPosition(45, 33);
            Console.WriteLine("│  Password: [           ]  │");
            Console.SetCursorPosition(45, 34);
            Console.WriteLine("└───────────────────────────┘");
        }

        public static void MainM()
        {
            Console.Clear();
            Console.SetCursorPosition(45, 30);
            Console.WriteLine("┌───────────────────────────────────────┐");
            Console.SetCursorPosition(45, 31);
            Console.WriteLine("│             MENU PRINCIPAL            │");
            Console.SetCursorPosition(45, 32);
            Console.WriteLine("│                                       │");
            Console.SetCursorPosition(45, 33);
            Console.WriteLine("│  1.- Mantenedor de Usuarios           │");
            Console.SetCursorPosition(45, 34);
            Console.WriteLine("│  2.- Mantenedor de Familia Productos  │");            
            Console.SetCursorPosition(45, 35);
            Console.WriteLine("│  3.- Mantenedor de Productos          │");
            Console.SetCursorPosition(45, 36);
            Console.WriteLine("│  4.- Salir del Sistema                │");
            Console.SetCursorPosition(45, 37);
            Console.WriteLine("│                                       │");
            Console.SetCursorPosition(45, 38);
            Console.WriteLine("│        INGRESE OPCION [ ]             │");
            Console.SetCursorPosition(45, 39);
            Console.WriteLine("└───────────────────────────────────────┘");
            
        }
        
        public static void UserM()
        {
            Console.Clear();
            Console.SetCursorPosition(45, 30);
            Console.WriteLine("┌───────────────────────────────────────┐");
            Console.SetCursorPosition(45, 31);
            Console.WriteLine("│             MENU USUARIOS             │");
            Console.SetCursorPosition(45, 32);
            Console.WriteLine("│                                       │");
            Console.SetCursorPosition(45, 33);
            Console.WriteLine("│  1.- Ingresar Usuarios                │");
            Console.SetCursorPosition(45, 34);
            Console.WriteLine("│  2.- Modificar Usuarios               │");
            Console.SetCursorPosition(45, 35);
            Console.WriteLine("│  3.- Eliminar Usuarios                │");
            Console.SetCursorPosition(45, 36);
            Console.WriteLine("│  4.- Mostrar Usuarios                 │");
            Console.SetCursorPosition(45, 37);
            Console.WriteLine("│  5.- Salir                            │");
            Console.SetCursorPosition(45, 38);
            Console.WriteLine("│                                       │");
            Console.SetCursorPosition(45, 39);
            Console.WriteLine("│        INGRESE OPCION [  ]             │");
            Console.SetCursorPosition(45, 40);
            Console.WriteLine("└───────────────────────────────────────┘");
            Console.ReadLine();
        }

        public static bool LoginU(String u, String p)
        {
            String user = "";
            String pswd = "";

            bool result;

            string[] lines = File.ReadAllLines(file);
            foreach(String line in lines)
            {
                String[] separator = line.Split(';');
                if (separator.Length == 2)
                {
                    user = separator[0];
                    pswd = separator[1];
                }
            }

            p = GetMD5Hash(p.Trim());
            if ((u == user) && (p == pswd))
                result = true;
            else
                result = false;
            return result;
        }

        public static String GetMD5Hash(String input)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            String hash = s.ToString();
            return hash;
        }
    }
}
