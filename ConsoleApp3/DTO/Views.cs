﻿using ConsoleApp3.DAL;
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
            Console.WriteLine("│        INGRESE OPCION [ ]             │");
            Console.SetCursorPosition(45, 40);
            Console.WriteLine("└───────────────────────────────────────┘");
            while (true)
            {
                Console.SetCursorPosition(70, 20);
                int option;

                do
                {
                    String op = Console.ReadLine();
                    int.TryParse(op, out option);
                } while (option < 0 || option > 5);

                switch (option)
                {
                    case 1: UserAddM(); break;
                    case 2: UserM(); break;
                    case 3: UserM(); break;
                    case 4: Environment.Exit(0); break;
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
                String user = Console.ReadLine().Trim();
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

                int state = 1;
                Users newUser = new Users(rut, nombre, ap_paterno, ap_materno, mail, user, pswd, state);
                UserManager newUserManager = new UserManager();

                newUserManager.Add(newUser);
            }
        }

    }
}