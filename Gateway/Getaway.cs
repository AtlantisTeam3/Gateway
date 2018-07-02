using System;
using System.IO.Ports;
using System.Threading;
using System.ServiceModel;
using WCFInterfaces;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Gateway
{
    class Getaway 
    {
        
        static void Main(string[] args)
        {
            
//            Console.WriteLine("Hello World!");
            
            //Provisoire - Manque Delegates
            Console.WriteLine("DmArToPc : 1 DmPcToAr : 2");
            ConsoleKeyInfo menuChoice = Console.ReadKey(true);            
            
            switch (menuChoice.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("--- Lancement DmArToPc ---");
                    DmArToPc();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("--- Lancement DmArToPc ---");
                    DmPcToAr();
                    break;
                case ConsoleKey.Q:
                    Console.WriteLine("Quitter");
                    
                    Environment.Exit(0);
                    break;
            }
        }
        
        
        public static void DmArToPc()
        {
            Console.WriteLine("Tu viens d'acceder a DmArToPc");
            SerialPort serialPort = new SerialPort();
            serialPort.PortName = "COM5";//Set your board COM
            serialPort.BaudRate = 9600; //Set your baud rate
//            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort.Open();
            string a = serialPort.ReadExisting();
            Console.WriteLine(a);
//            return a;
        }
        

        public static void DmPcToAr()
        {
            Console.WriteLine("Tu viens d'acceder a DmArToPc");
            SerialPort port = null;
                
                if (port==null)
            {
                port = new SerialPort("COM5", 9600);//Set your board COM
                port.Open();
            }
                
            while (true)
            {
                Console.WriteLine("Allumer la DEL : 1, Eteindre la DEL : 0, Quitter : q");
                ConsoleKeyInfo inputKeyboard = Console.ReadKey(true);
    
                switch (inputKeyboard.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Allumer la LED");
                        port.Write("1");
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine("Eteindre la LED");
                        port.Write("0");
                        break;
                    case ConsoleKey.Q:
                        Console.WriteLine("Quitter");
                            
                        if(port !=null &&port.IsOpen)
                        {
                            port.Close();
                        }
                            
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
