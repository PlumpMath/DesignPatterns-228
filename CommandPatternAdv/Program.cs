using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
   
    public interface Command
    {
        void Execute();
        void Undo();

    }

    #region Fan class
    public class CeilingFan
    {
        public static readonly Int32 HIGH = 3;
        public static readonly Int32 MEDIUM = 2;
        public static readonly Int32 LOW = 1;
        public static readonly Int32 OFF = 0;
        private String location;
        private Int32 speed;

        public CeilingFan(String location)
        {
            this.location = location;
            speed = OFF;
        }
        
        public void High()
        {
            this.speed = HIGH;
            Console.WriteLine("Fan spped is set to HIGH");
        }

        public void Medium()
        {
            speed = MEDIUM;
            Console.WriteLine("Fan spped is set to MEDIUM");
        }

        public void Low()
        {
            this.speed = LOW;
            Console.WriteLine("Fan spped is set to LOW");
        }

        public void Off()
        {
            speed = OFF;
            Console.WriteLine("Fan spped is set to OFF");
        }

        public Int32 GetCurrentSpeed()
        {
            return speed;
        }



    }
    #endregion

    #region Fan command classes
    public class CeilingFanHighCommand : Command
    {
        private CeilingFan ceilingFan = null;
        Int32 previousSpeed;
        public CeilingFanHighCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan; 
        }

        public void Execute()
        {
            previousSpeed = ceilingFan.GetCurrentSpeed();
            ceilingFan.High();
        }

        public void Undo()
        {
            if (previousSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            else if (previousSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            else if (previousSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            else if (previousSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }

    public class CeilingFanLowCommand : Command
    {
        private CeilingFan ceilingFan = null;
        Int32 previousSpeed;
        public CeilingFanLowCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            previousSpeed = ceilingFan.GetCurrentSpeed();
            ceilingFan.Low();
        }

        public void Undo()
        {
            if (previousSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            else if (previousSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            else if (previousSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            else if (previousSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }

    public class CeilingFanMediumCommand : Command
    {
        private CeilingFan ceilingFan = null;
        Int32 previousSpeed;
        public CeilingFanMediumCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            previousSpeed = ceilingFan.GetCurrentSpeed();
            ceilingFan.Medium();
        }

        public void Undo()
        {
            if (previousSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            else if (previousSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            else if (previousSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            else if (previousSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }

    public class CeilingFanOffCommand : Command
    {
        private CeilingFan ceilingFan = null;
        Int32 previousSpeed;
        public CeilingFanOffCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            previousSpeed = ceilingFan.GetCurrentSpeed();
            ceilingFan.Off();
        }

        public void Undo()
        {
            if (previousSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            else if (previousSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            else if (previousSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            else if (previousSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }
    #endregion

    #region Light Command classes
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


        public void Undo()
        {
            light.OFFLight();
        }
    }

    public class LightOFFCommand : Command
    {
        private Light light;
        public LightOFFCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.OFFLight();

        }


        public void Undo()
        {
            light.OnLight();
        }
    }
    #endregion

    #region Macrocommand

    public class MacroCommand : Command
    {
        private Command[] commands;
        public MacroCommand(Command[] commands)
        {
            this.commands = commands;
        }



        public void Execute()
        {
            foreach (Command cmd in commands)
            {
                cmd.Execute();
            }
        }

        public void Undo()
        {
            foreach (Command cmd in commands)
            {
                cmd.Undo();
            }
        }
    }

    #endregion

    #region Light class
    public class Light
    {
        private String place;
        public Light(String place)
        {
            this.place = place;
        }
        public void OnLight()
        {
            Console.WriteLine(place+ " Light is Switched ON");
        }

        public void OFFLight()
        {
            Console.WriteLine(place +" Light is Switched OFF");
        }
    }
    #endregion

    public class SimpleRemoteControl
    {
        Command[] onCommands;
        Command[] offCommands;
        Command undoCommand;

        MacroCommand onCommandsMacro;
        MacroCommand offCommandsMacro;

      public SimpleRemoteControl()
        {
           
            onCommands = new Command[7];
            offCommands = new Command[7];
        }

        public void SetCommand(int slot,Command onCommand, Command offCommand)
        {

            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void SetCommand(int slot, MacroCommand onCommands, MacroCommand offCommands)
        {
            this.onCommandsMacro = onCommands;
            this.offCommandsMacro = offCommands;
        }

        public void OnButtonPushed()
        {
            this.onCommandsMacro.Execute();
        }

        public void OffButtonPushed()
        {
            this.offCommandsMacro.Execute();
        }

        public void OnButtonPushed(int slot)
        {
            onCommands[slot].Execute();
            undoCommand = onCommands[slot];
        }

        public void OffButtonPushed(int slot)
        {
            offCommands[slot].Execute();
            undoCommand = offCommands[slot];
        }

        public void UndoButtonPushed(int slot)
        {
            undoCommand.Undo();
        }

        public void UndoButtonPushed()
        {
            undoCommand.Undo();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n----------------Remote Control functions List\n");
            foreach (Command cmd in onCommands)
            {
                if (cmd != null)
                {

                    sb.Append(cmd.GetType().FullName);
                }
            }
            foreach (Command cmd in offCommands)
            {
                if (cmd != null)
                {
                    sb.Append(cmd.GetType().FullName);
                }
            }

            sb.Append("\n----------------Remote Control functions End\n");
            
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Light light = new Light("Any");
            Light kitchenLight = new Light("Kitchen");
            Light livingRoomLight = new Light("Living room");
            Light bedroomLight = new Light("Bedroom");

            Command lightONBtn = new LightONCommand(light);
            Command lightOffBtn = new LightOFFCommand(light);

            Command kitchenLightON = new LightONCommand(kitchenLight);
            Command kitchenLightOFF = new LightOFFCommand(kitchenLight);

            Command livingRoomON = new LightONCommand(livingRoomLight);
            Command livingRoomOFF = new LightOFFCommand(livingRoomLight);


            SimpleRemoteControl simpRemoteCntrl = new SimpleRemoteControl();

            simpRemoteCntrl.SetCommand(0,lightONBtn,lightOffBtn);
            simpRemoteCntrl.SetCommand(1, kitchenLightON, kitchenLightOFF);
            simpRemoteCntrl.SetCommand(2, livingRoomON, livingRoomOFF);

            simpRemoteCntrl.OnButtonPushed(0);
            simpRemoteCntrl.OffButtonPushed(0);

            simpRemoteCntrl.OnButtonPushed(1);
            simpRemoteCntrl.OffButtonPushed(1);

            simpRemoteCntrl.OnButtonPushed(2);
            simpRemoteCntrl.OffButtonPushed(2);


            CeilingFan ceilingFanLivingRoom = new CeilingFan("Living Room");
            Command ceilingFanHighCommand = new CeilingFanHighCommand(ceilingFanLivingRoom);
            Command ceilingFanOffCommand = new CeilingFanOffCommand(ceilingFanLivingRoom);
            simpRemoteCntrl.SetCommand(3, ceilingFanHighCommand, ceilingFanOffCommand);

            simpRemoteCntrl.OnButtonPushed(3);


            Console.WriteLine("\n Start of macro \n");

            Command[] partyCommandsOn = new Command[] { lightONBtn,kitchenLightON,livingRoomON};
            Command[] partyCommandsOff = new Command[] {lightOffBtn,kitchenLightOFF,livingRoomOFF };



            MacroCommand macroCommandON = new MacroCommand(partyCommandsOn);
            MacroCommand macroCommandOff = new MacroCommand(partyCommandsOff);

            simpRemoteCntrl.SetCommand(0, macroCommandON, macroCommandOff);

            simpRemoteCntrl.OnButtonPushed();
            simpRemoteCntrl.OffButtonPushed();


            
            Console.WriteLine(simpRemoteCntrl.ToString());
            

        }
    }
}
