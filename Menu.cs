using System;
using System.Collections.Generic;

namespace Examen
{
    class Menu
    {

        private const int MAIN_MENU_EXIT_OPTION = 9;
        private const int GO_BACK_OPTION = 9;
        List<int> mainMenuOptions = new List<int>(new int[] { 1, 2, 3, 4, 5, 9 }); //opciones del menu

        public List<Camiones> listaCamiones = new List<Camiones>(); //lista de camiones 
        public List<string> listaRutas = new List<string>();

        private void DisplayWelcomeMessage() //mensaje de bienvenida
        {
            System.Console.WriteLine("Panel de Control");
            System.Console.WriteLine();
        }

        private void DisplayMainMenuOptions() //opciones del menu
        {
            System.Console.WriteLine("1) Ingreso de camión");
            System.Console.WriteLine("2) Salida de camión");
            System.Console.WriteLine("3) Exportar / Imprimir camiones");
            System.Console.WriteLine("4) Ver estadísticas");
            System.Console.WriteLine("5) Borrar información");
            System.Console.WriteLine();
            System.Console.WriteLine("9) Salir");
        }

        private void DisplayByeMessage() //mensaje de adios
        { //mensaje de despedida
            System.Console.WriteLine("¡Hasta luego!");
        }

        private int RequestOption(List<int> validOptions) //opciones validas
        {
            int userInputAsInt = 0;
            bool isUserInputValid = false;

            //Mientras no haya una respuesta válida...
            while (!isUserInputValid)
            {
                System.Console.WriteLine("Selecciona una opción:");
                string userInput = System.Console.ReadLine();


                try
                {
                    userInputAsInt = Convert.ToInt32(userInput);
                    isUserInputValid = validOptions.Contains(userInputAsInt);
                }
                catch (System.Exception)
                {
                    isUserInputValid = false;
                }


                if (!isUserInputValid)
                {
                    System.Console.WriteLine("La opción seleccionada no es válida.");
                }
            }

            return userInputAsInt;
        }

        //Mensajes
        private void IngresoMessage() //Mensaje de ingreso de camion 
        {
            System.Console.WriteLine("Ingreso de camión");
            System.Console.WriteLine();
        }

        private void SalidaMessage() //Mensaje de salida
        {
            System.Console.WriteLine("Salida de camión:");
            System.Console.WriteLine();
        }

        private void ImprimirMessage() //Mensaje de imprimir
        {
            System.Console.WriteLine("Exportar / Imprimir camiones");
            System.Console.WriteLine();

        }

        private void EstadisticasMessage() //mensaje de estadisticas 
        {
            System.Console.WriteLine("Ver estadísticas");
            System.Console.WriteLine();
        }

        private void BorrarMessage() //Mensaje de borrar camion 
        {
            System.Console.WriteLine("Información Eliminada");
            System.Console.WriteLine();
        }

        // acciones
        private void Ingreso() //ingreso de los camiones
        {
            DisplayWelcomeMessage();
            IngresoMessage();

            Camiones camionesObjeto = new Camiones();

            Console.Write("Ingrese Nombre: ");
            camionesObjeto.nombre = Console.ReadLine();

            Console.Write("Ingrese Ruta: ");
            camionesObjeto.ruta = Console.ReadLine();

            if((camionesObjeto.GetRuta()).Length == 1 && Char.IsUpper((camionesObjeto.GetRuta()), 0) && !camionesObjeto.GetNombre().Contains(" ")){

            camionesObjeto.IngresoConfirmar();

            listaCamiones.Add(camionesObjeto);
            listaRutas.Add(camionesObjeto.ruta);

            Console.Write("");

            }

            else{
                System.Console.WriteLine("Error de Ingreso");
            }

        }

        private void Salida() //quitar el primer camion
        {
            SalidaMessage();
            Console.WriteLine("Salida del Camión: {0}", listaCamiones[0]);
            listaCamiones.RemoveAt(0);
            Console.Write("");



        }

        private void Imprimir() //Imprimir todos los camiones
        {
            ImprimirMessage();
            foreach (Camiones fila in listaCamiones)
            {
                Console.WriteLine(fila);
            }

            Console.WriteLine("");


        }

        private void Estadisticas()
        {
            EstadisticasMessage();
            
            //Char count by char
            Dictionary<string, int> countByChar = new Dictionary<string, int>();

    	    //Iterar los caracteres uno por uno

            foreach (var caracter in listaRutas)
            {
                //Saltearse espacios vacíos
                if (caracter == " ")
                {
                    continue;
                }

                //1. Revisar si existe en el diccionario

                if (countByChar.ContainsKey(caracter)) {
                    //3. Consultar valor actual del diccionario

                    countByChar.TryGetValue(caracter, out int currentCount);

                    int nextCount = currentCount + 1;


                    //4. Registrar en diccionario

                    //4.1. Borrar registro actual
                    countByChar.Remove(caracter);

                    //4.2. Agregar valor
                    countByChar.Add(caracter, nextCount);
                } else {
                    //2. Agregar a diccionario con valor 1
                    countByChar.Add(caracter, 1);

                }
            }


            string highestRepeatedChar = " ";
            int highestRepeatedCount = 0;


            foreach (var item in countByChar)
            {

                if (item.Value > highestRepeatedCount) {
                    highestRepeatedChar = item.Key;
                    highestRepeatedCount = item.Value;
                }

                System.Console.WriteLine($"Ruta: {item.Key} -> {item.Value}");
            }
               Console.WriteLine("Total de camiones "+listaRutas.Count); 

        }

        private void BorrarInformacion()
        {
            Console.Write("");
            BorrarMessage();
            listaCamiones.Clear();
            listaRutas.Clear();


        }

        public void Display()  //Menu 
        {
            int selectedOption = 0;

            DisplayWelcomeMessage();

            while (selectedOption != MAIN_MENU_EXIT_OPTION)
            {
                DisplayMainMenuOptions();

                selectedOption = RequestOption(mainMenuOptions);

                switch (selectedOption)
                {
                    case 1: // Ingreso de camión
                        Ingreso();
                        break;

                    case 2: //Salida de camión
                        Salida();
                        break;

                    case 3:
                        Imprimir();
                        break;

                    case 4:
                        Estadisticas();
                        break;

                    case 5:
                        BorrarInformacion();
                        break;

                    case 9:
                        selectedOption = MAIN_MENU_EXIT_OPTION;
                        break;
                        // default:
                }
            }

            DisplayByeMessage();

        }


    }
}
