using CommandPattern.Classes;
using CommandPattern.Classes.Commands;
using CommandPattern.Interfaces;
using Xunit;

namespace CommandPattern.Tests
{
    public class RemoteControlTests
    {
        private static string[] Run(Action action)
        {
            TextWriter originalOut = Console.Out;
            using StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            try
            {
                action();
            }
            finally
            {
                Console.SetOut(originalOut);
            }
            return writer.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }

        [Fact]
        public void OnButton_ExecutesOnCommand()
        {
            RemoteControl remote = new RemoteControl();
            Light light = new Light("Living Room");
            remote.SetCommand(1, new LightOnCommand(light), new LightOffCommand(light));

            string[] output = Run(() => remote.OnButtonWasPushed(1));

            Assert.Equal(new[] { "Living Room Light is turned on" }, output);
        }

        [Fact]
        public void OffButton_ExecutesOffCommand()
        {
            RemoteControl remote = new RemoteControl();
            Light light = new Light("Living Room");
            remote.SetCommand(1, new LightOnCommand(light), new LightOffCommand(light));

            string[] output = Run(() => remote.OffButtonWasPushed(1));

            Assert.Equal(new[] { "Living Room Light is turned off" }, output);
        }

        [Fact]
        public void EmptySlot_DoesNothing()
        {
            RemoteControl remote = new RemoteControl();

            string[] output = Run(() =>
            {
                remote.OnButtonWasPushed(0);
                remote.OffButtonWasPushed(6);
            });

            Assert.Empty(output);
        }

        [Fact]
        public void SetCommand_OverwritesPreviousCommand()
        {
            RemoteControl remote = new RemoteControl();
            Light kitchen = new Light("Kitchen");
            Light living = new Light("Living Room");
            remote.SetCommand(2, new LightOnCommand(kitchen), new LightOffCommand(kitchen));
            remote.SetCommand(2, new LightOnCommand(living), new LightOffCommand(living));

            string[] output = Run(() => remote.OnButtonWasPushed(2));

            Assert.Equal(new[] { "Living Room Light is turned on" }, output);
        }

        [Fact]
        public void Undo_RevertsLastOn()
        {
            RemoteControl remote = new RemoteControl();
            Light light = new Light("Living Room");
            remote.SetCommand(1, new LightOnCommand(light), new LightOffCommand(light));

            string[] output = Run(() =>
            {
                remote.OnButtonWasPushed(1);
                remote.UndoButtonWasPushed();
            });

            Assert.Equal(new[] { "Living Room Light is turned on", "Living Room Light is turned off" }, output);
        }

        [Fact]
        public void Undo_WithEmptyHistory_DoesNothing()
        {
            RemoteControl remote = new RemoteControl();

            string[] output = Run(() => remote.UndoButtonWasPushed());

            Assert.Empty(output);
        }

        [Fact]
        public void Undo_RevertsActionsInReverseOrder()
        {
            RemoteControl remote = new RemoteControl();
            Light living = new Light("Living Room");
            Light kitchen = new Light("Kitchen");
            remote.SetCommand(1, new LightOnCommand(living), new LightOffCommand(living));
            remote.SetCommand(2, new LightOnCommand(kitchen), new LightOffCommand(kitchen));

            string[] output = Run(() =>
            {
                remote.OnButtonWasPushed(1);
                remote.OnButtonWasPushed(2);
                remote.UndoButtonWasPushed();
                remote.UndoButtonWasPushed();
            });

            Assert.Equal(
                new[]
                {
                    "Living Room Light is turned on",
                    "Kitchen Light is turned on",
                    "Kitchen Light is turned off",
                    "Living Room Light is turned off"
                },
                output);
        }

        [Fact]
        public void Undo_CeilingFan_RestoresPreviousSpeed()
        {
            RemoteControl remote = new RemoteControl();
            CeilingFan fan = new CeilingFan("Fan");
            remote.SetCommand(3, new CeilingFanHighCommand(fan), new CeilingFanOffCommand(fan));

            Run(() =>
            {
                remote.OnButtonWasPushed(3);
                remote.OffButtonWasPushed(3);
                remote.UndoButtonWasPushed();
            });

            Assert.Equal(fan.HIGH, fan.GetSpeed());
        }

        [Fact]
        public void Undo_CeilingFan_FromOff_RestoresOff()
        {
            RemoteControl remote = new RemoteControl();
            CeilingFan fan = new CeilingFan("Fan");
            remote.SetCommand(3, new CeilingFanHighCommand(fan), new CeilingFanOffCommand(fan));

            Run(() =>
            {
                remote.OnButtonWasPushed(3);
                remote.OffButtonWasPushed(3);
                remote.UndoButtonWasPushed();
                remote.UndoButtonWasPushed();
            });

            Assert.Equal(fan.OFF, fan.GetSpeed());
        }

        [Fact]
        public void Undo_CeilingFan_MediumAndLow_RestoreTheirSpeed()
        {
            RemoteControl remote = new RemoteControl();
            CeilingFan fan = new CeilingFan("Fan");
            remote.SetCommand(3, new CeilingFanMediumCommand(fan), new CeilingFanOffCommand(fan));
            remote.SetCommand(4, new CeilingFanLowCommand(fan), new CeilingFanOffCommand(fan));

            Run(() =>
            {
                remote.OnButtonWasPushed(3);
                remote.OnButtonWasPushed(4);
                remote.UndoButtonWasPushed();
            });

            Assert.Equal(fan.MEDIUM, fan.GetSpeed());
        }

        [Fact]
        public void Undo_GarageDoor_ReversesMovement()
        {
            RemoteControl remote = new RemoteControl();
            GarageDoor door = new GarageDoor(new Light("Garage"));
            remote.SetCommand(4, new GarageDoorUpCommand(door), new GarageDoorDownCommand(door));

            string[] output = Run(() =>
            {
                remote.OnButtonWasPushed(4);
                remote.UndoButtonWasPushed();
            });

            Assert.Equal(new[] { "Door is open", "Door is closed" }, output);
        }

        [Fact]
        public void Undo_Stereo_TurnsItOff()
        {
            RemoteControl remote = new RemoteControl();
            Stereo stereo = new Stereo();
            remote.SetCommand(5, new StereoOnWithCdCommand(stereo), new StereoOffCommand(stereo));

            string[] output = Run(() =>
            {
                remote.OnButtonWasPushed(5);
                remote.UndoButtonWasPushed();
            });

            Assert.Equal("Stereo was turned off", output.Last());
        }

        [Fact]
        public void MacroCommand_ExecutesAllAndUndoesAll()
        {
            RemoteControl remote = new RemoteControl();
            Light light = new Light("Living Room");
            CeilingFan fan = new CeilingFan("Fan");
            Command macroOn = new MacroCommand(new Command[] { new LightOnCommand(light), new CeilingFanHighCommand(fan) });
            Command macroOff = new MacroCommand(new Command[] { new LightOffCommand(light), new CeilingFanOffCommand(fan) });
            remote.SetCommand(6, macroOn, macroOff);

            string[] output = Run(() =>
            {
                remote.OnButtonWasPushed(6);
                remote.UndoButtonWasPushed();
            });

            Assert.Equal(
                new[]
                {
                    "Living Room Light is turned on",
                    "Fan is on: 3",
                    "Living Room Light is turned off",
                    "Fan is set on: 0"
                },
                output);
        }

        [Fact]
        public void NoCommand_ExecuteAndUndo_DoNothing()
        {
            NoCommand noCommand = new NoCommand();

            string[] output = Run(() =>
            {
                noCommand.Execute();
                noCommand.Undo();
            });

            Assert.Empty(output);
        }
    }
}
