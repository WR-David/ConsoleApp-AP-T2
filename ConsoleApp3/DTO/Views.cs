using ConsoleApp3.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.DTO
{
    class Views
    {
        static string file = @"C:\Users\edgar\OneDrive\Documentos\Progra Avanzada\Repos\Raito\users.txt";
        static int x = 43, y = 8;

        public static void LoginM()
        {
            //Lineas de recuadro grafico ┌─┐└┘ │
            //Ventana para entrar al Sistema
            //Se determina el tamanno de la ventana
            //Se determina donde estara el cursor en la siguiente linea de codigo
            Console.SetCursorPosition(x, y);
            Console.WriteLine("┌───────────────────────────┐");
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine("│      ACCESO A SISTEMA     │");
            Console.SetCursorPosition(x, y+2);
            Console.WriteLine("│      User: [           ]  │");
            Console.SetCursorPosition(x, y+3);
            Console.WriteLine("│  Password: [           ]  │");
            Console.SetCursorPosition(x, y+4);
            Console.WriteLine("└───────────────────────────┘");

        }
        public static void MainM()
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.WriteLine("┌───────────────────────────────────────┐");
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine("│             MENU PRINCIPAL            │");
            Console.SetCursorPosition(x, y+2);
            Console.WriteLine("│                                       │");
            Console.SetCursorPosition(x, y+3);
            Console.WriteLine("│  1.- Mantenedor de Usuarios           │");
            Console.SetCursorPosition(x, y+4);
            Console.WriteLine("│  2.- Mantenedor de Familia Productos  │");
            Console.SetCursorPosition(x, y+5);
            Console.WriteLine("│  3.- Mantenedor de Productos          │");
            Console.SetCursorPosition(x, y+6);
            Console.WriteLine("│  4.- Salir del Sistema                │");
            Console.SetCursorPosition(x, y+7);
            Console.WriteLine("│                                       │");
            Console.SetCursorPosition(x, y+8);
            Console.WriteLine("│        INGRESE OPCION [ ]             │");
            Console.SetCursorPosition(x, y+9);
            Console.WriteLine("└───────────────────────────────────────┘");

        }
        public static void UserM()
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.WriteLine("┌───────────────────────────────────────┐");
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine("│             MENU USUARIOS             │");
            Console.SetCursorPosition(x, y+2);
            Console.WriteLine("│                                       │");
            Console.SetCursorPosition(x, y+3);
            Console.WriteLine("│  1.- Ingresar Usuarios                │");
            Console.SetCursorPosition(x, y+4);
            Console.WriteLine("│  2.- Modificar Usuarios               │");
            Console.SetCursorPosition(x, y+5);
            Console.WriteLine("│  3.- Eliminar Usuarios                │");
            Console.SetCursorPosition(x, y+6);
            Console.WriteLine("│  4.- Mostrar Usuarios                 │");
            Console.SetCursorPosition(x, y+7);
            Console.WriteLine("│  5.- Salir                            │");
            Console.SetCursorPosition(x, y+8);
            Console.WriteLine("│                                       │");
            Console.SetCursorPosition(x, y+9);
            Console.WriteLine("│        INGRESE OPCION [ ]             │");
            Console.SetCursorPosition(x, y+10);
            Console.WriteLine("└───────────────────────────────────────┘");

            while (true)
            {
                Console.SetCursorPosition(x+25, y+9);
                int option;

                do
                {
                    String op = Console.ReadLine();
                    int.TryParse(op, out option);
                } while (option < 0 || option > 5);

                switch (option)
                {
                    case 1: UserAddM(); break;
                    case 2: UserModM(); break;
                    case 3: UserM(); break;
                    case 4: UserList(); break;
                    case 5: Environment.Exit(0); break;
                    default: break;
                }

            }

        }
        public static void UserAddM()
        {
            {
                Console.Clear();
                Console.SetCursorPosition(45, 30);
                Console.WriteLine("┌────────────────────────────────────────────────┐");
                Console.SetCursorPosition(45, 31);
                Console.WriteLine("│  AGREGAR USUARIO                               │");
                Console.SetCursorPosition(45, 32);
                Console.WriteLine("│                                                │");
                Console.SetCursorPosition(45, 33);
                Console.WriteLine("│  RUT              [                          ] │");
                Console.SetCursorPosition(45, 34);
                Console.WriteLine("│  Nombre           [                          ] │");
                Console.SetCursorPosition(45, 35);
                Console.WriteLine("│  Apellido Paterno [                          ] │");
                Console.SetCursorPosition(45, 36);
                Console.WriteLine("│  Apellido Materno [                          ] │");
                Console.SetCursorPosition(45, 37);
                Console.WriteLine("│  Correo           [                          ] │");
                Console.SetCursorPosition(45, 38);
                Console.WriteLine("│  Usuario          [                          ] │");
                Console.SetCursorPosition(45, 39);
                Console.WriteLine("│  Contraseña       [                          ] │");
                Console.SetCursorPosition(45, 40);
                Console.WriteLine("└────────────────────────────────────────────────┘");
                Console.SetCursorPosition(66, 13);
                String rut = Console.ReadLine().Trim();
                Console.SetCursorPosition(66, 14);
                String nombre = Console.ReadLine().Trim();
                Console.SetCursorPosition(66, 15);
                String ap_paterno = Console.ReadLine().Trim();
                Console.SetCursorPosition(66, 16);
                String ap_materno = Console.ReadLine().Trim();
                Console.SetCursorPosition(66, 17);
                String mail = Console.ReadLine().Trim();
                Console.SetCursorPosition(66, 18);
                String usuario = Console.ReadLine().Trim();
                Console.SetCursorPosition(66, 19);
                ConsoleKeyInfo key;

                String pass = "";

                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        pass += key.KeyChar;
                        Console.Write("*");
                    }
                } while (key.Key != ConsoleKey.Enter);

                String p = Program.GetMD5Hash(pass);

                Users u = new Users(rut, nombre, ap_paterno, ap_materno, mail, usuario, p, 1);

                UserManager.Add(u, file);

                UserM();

            }
        }
        public static void UserModM()
        {
            Console.Clear();
            UserList();
            Console.SetCursorPosition(x, y);
            Console.WriteLine("┌────────────────────────────────────────────────┐");
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine("│  MODIFICAR USUARIO                             │");
            Console.SetCursorPosition(x, y+2);
            Console.WriteLine("│                                                │");
            Console.SetCursorPosition(x, y+3);
            Console.WriteLine("│  Usuario a Modificar [ ]                       │");
            Console.SetCursorPosition(x, y+4);
            Console.WriteLine("│  Nombre           [                          ] │");
            Console.SetCursorPosition(x, y+5);
            Console.WriteLine("│  Apellido Paterno [                          ] │");
            Console.SetCursorPosition(x, y+6);
            Console.WriteLine("│  Apellido Materno [                          ] │");
            Console.SetCursorPosition(x, y+7);
            Console.WriteLine("│  Correo           [                          ] │");
            Console.SetCursorPosition(x, y+8);
            Console.WriteLine("└────────────────────────────────────────────────┘");
            Console.SetCursorPosition(66, 14);
            String rut = Console.ReadLine().Trim();
            Console.SetCursorPosition(66, 15);
            String nombre = Console.ReadLine().Trim();
            Console.SetCursorPosition(66, 16);
            String ap_paterno = Console.ReadLine().Trim();
            Console.SetCursorPosition(66, 17);
            String ap_materno = Console.ReadLine().Trim();
            Console.SetCursorPosition(66, 18);
            String mail = Console.ReadLine().Trim();
            Console.SetCursorPosition(66, 19);
            String usuario = Console.ReadLine().Trim();
            Console.SetCursorPosition(66, 20);
            ConsoleKeyInfo key;
            String pswd = "";

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    pswd += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.SetCursorPosition(20, 32);
            

        } 
        public static void UserList()
        {
            Console.Clear();
            Console.SetCursorPosition(x, y-5);
            Console.WriteLine("┌────────────────────────────────────────────────┐");
            Console.SetCursorPosition(x, y-4);
            Console.WriteLine("│  LISTA DE USUARIOS                             │");
            Console.SetCursorPosition(x, y-3);
            Console.WriteLine("└────────────────────────────────────────────────┘");

            String listado;
            int fila=0;
            StreamReader listusr = File.OpenText(file);
            do
            {
                listado = listusr.ReadLine();
                if (listado != null)
                {
                    String[] separar = listado.ToString().Split(';');
                    Console.SetCursorPosition(x, y + fila);
                    Console.WriteLine(" {0}.- {1}, {2}, {3}, {4}, {5} ", fila, separar[0], separar[1], separar[2], separar[3], separar[4]);
                    fila++;

                }

            } while (listado != null);
            Console.ReadKey();
            UserM();
        }

    }
}
