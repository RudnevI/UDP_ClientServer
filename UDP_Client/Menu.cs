using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Client
{
    static class Menu
    {

        private static readonly ClientService _service = new ClientService();
        public enum WorkMode
        {
            Standard,
            MessagesEnMasse
        }

        private readonly static string _promptMessage = "[1] - Standard mode\n[2] - Emulate sending 100 messages\n[0] - exit:\n";

        public static WorkMode CurrentWorkMode { get; set; }

        public static int CurrentAnswer { get; set; } = -1;

        public static void Display()
        {
            while (true)
            {
                Console.WriteLine(_promptMessage);
                ResetCurrentAnswer();
                ReadAnswer();
                if (CheckExit()) break;
                SetWorkMode();
                PerformChosenOperation();
            }
        }

        private static void ResetCurrentAnswer()
        {
            CurrentAnswer = -1;
        }

        private static  void SendEnMasse()
        {
             _service.SendEnMasse();
        }

        private static void Send()
        {
            _service.Receive();
        }

        private static bool CheckExit()
        {
            return CurrentAnswer == 0;
        }

        private static void PerformChosenOperation()
        {
            if (CurrentWorkMode == WorkMode.Standard)
            {
                Send();
            }
            else
            {
                SendEnMasse();
            }

        }

        private static void ReadAnswer()
        {
            while (!Enumerable.Range(0, 3).Contains(CurrentAnswer))
            {
                try
                {
                    CurrentAnswer = int.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Please enter your option");
                }
                catch (FormatException)
                {
                    Console.WriteLine("No such option");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("No such option");
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, something went wrong");
                }
            }
        }

        

        private static void SetWorkMode()
        {
            CurrentWorkMode = (CurrentAnswer == 1) ? (WorkMode.Standard) : (WorkMode.MessagesEnMasse);
        }
    }
}
