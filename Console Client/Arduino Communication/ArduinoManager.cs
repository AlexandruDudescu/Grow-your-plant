using System;
using System.Threading;
using System.IO.Ports;
using System.IO;
using Grow_your_plant.Models;

namespace Grow_your_plant.Arduino
{
    public class ArduinoManager : IArduinoManager
    {
        public SerialPort arduinoPort;
        public bool portFound;
        private char[] message = new char[12];

        private static DateTime startTime = DateTime.Now;
        private static TimeSpan spanTime = TimeSpan.FromMilliseconds(50);

        private static PlantStatus CurrentPlantStatus = new PlantStatus();
        private static PlantStatus NullPlantStatus = new PlantStatus(0,0,0, DateTime.Now.ToString());
        public ArduinoManager()
        {
            arduinoPort = new SerialPort("COM7", 9600);
            arduinoPort.Open();
        }

        public PlantStatus GetPlantStatus()
        {
            arduinoPort.Write("s");
            arduinoPort.Read(message, 0, 12);
            message[10] = message[11] = '\0';

            //Message Control test
            while(!(message[0] == '#' && message[9] == '#'))
            {
                //Small Delay beetween requests
                startTime = DateTime.Now;
                while (DateTime.Now < startTime + spanTime) ;

                arduinoPort.Write("s");
                arduinoPort.Read(message, 0, 12);
                message[10] = message[11] = '\0';
            }

            if (message[0] == '#' && message[9] == '#')
            {
                //Break String
                CurrentPlantStatus.Luminosity = (message[1] - '0') * 10 + (message[2] - '0');
                CurrentPlantStatus.Temperature = (message[4] - '0') * 10 + (message[5] - '0');
                CurrentPlantStatus.Humidity = (message[7] - '0') * 10 + (message[8] - '0');
                CurrentPlantStatus.StatusTime = DateTime.Now.ToString();
            }

            return CurrentPlantStatus;

        }
    }
}