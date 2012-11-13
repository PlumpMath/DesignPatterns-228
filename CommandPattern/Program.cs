using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    public interface Command
    {
        void Execute();

    }

    public class LightONCommand : Command
    {
        private Light light;
        public LightONCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.OnLight();

        }
    }

    public class Light
    {
        public void OnLight()
        {
            Console.WriteLine( "Light is Switched ON");
        }
    }

    public class SimpleRemoteControl
    {
       
        Command command;
        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ButtonWasPressed()
        {
            command.Execute();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Light light = new Light();
            Command lightBtn = new LightONCommand(light);
            SimpleRemoteControl simpRemoteCntrl = new SimpleRemoteControl();
            simpRemoteCntrl.SetCommand(lightBtn);
            simpRemoteCntrl.ButtonWasPressed();
            

        }
    }
}
