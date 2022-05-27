using ConsoleApp3.DAL;
using ConsoleApp3.DTO;
using System;
using System.IO;
using System.Security.Cryptography;


namespace ConsoleApp3
{
    internal class Program
    {
        static UserManager userManager = new UserManager();
        static string file = @"C:\Users\lucyf\source\repos\ConsoleApp3\users.txt";
        static void Main(string[] args)
        {
            //Definicion de variables
            String user, pswd;            

            //Llamar al Menu de Login, luego por cada tecla presionada en la posicion (59,14) aplicar un '*'
            do
            {
                DTO.Views.LoginM();
                ConsoleKeyInfo key;
                pswd = "";
                Console.SetCursorPosition(59, 12);
                user = Console.ReadLine().Trim();
                Console.SetCursorPosition(59, 13);
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
                DTO.Views.MainM();
                Console.SetCursorPosition(70, 19);
                int option;

                do
                {
                    String op = Console.ReadLine();
                    int.TryParse(op, out option);
                } while (option < 0 || option > 5);

                switch (option)
                {
                    case 1: DTO.Views.UserM(); break;
                    case 2: DTO.Views.UserM(); break;
                    case 3: DTO.Views.UserM(); break;
                    case 4: Environment.Exit(0); break;
                    default: break;
                }



            }
            
        }
        public static bool LoginU(String u, String p)
        {
            bool result = false;
            if (File.Exists(file))
            {
                String line;
                StreamReader read = File.OpenText(file);
                do
                {
                    line = read.ReadLine();
                    if (line != null)
                    {
                        String[] separator = line.Split(';');
                        if (u.Trim().Equals(separator[5]) && GetMD5Hash(p.Trim()).Equals(separator[6]))
                            result = true;
                        
                    }
                } while (line != null);

            }
            else
            {
                Console.WriteLine("No existe el archivo");
            }
            
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

        public static bool validaRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }
    }
}
