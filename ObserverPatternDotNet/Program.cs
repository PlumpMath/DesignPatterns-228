using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPatternDotNet
{

    public class SourceEventArgs: EventArgs
    {
        public readonly Double temperature, pressure, humidity;
        public SourceEventArgs(Double temp,Double pressr,Double humid)
        {
            this.temperature = temp;
            this.pressure = pressr;
            this.humidity = humid;
        }

        public Double Temperature { get { return temperature; } }
        public Double Pressure { get { return pressure; } }
        public Double Humidity { get { return humidity; } }


    }

    public class VideoPlayerEventArgs : EventArgs
    {
        public readonly int volume;

        public readonly Double brightness;
        public readonly String color;

        public VideoPlayerEventArgs(int volume, Double brightness, String color)
        {
            this.volume = volume;
            this.color = color;
            this.brightness = brightness;
        }

        public Double Brightness
        {
            get { return brightness; }
        }

        public int Volume
        {
            get { return volume; }
        }

        public String Color
        {
            get { return color; }
        }
    }

    public class Source
    {
        public event EventHandler<SourceEventArgs> SourceEvtArgs = null;
        public event EventHandler<VideoPlayerEventArgs> VideoEventArgs = null;
        public event EventHandler UpdateEvent = null ;

        #region SourceEvtArgs
        protected void OnUpdateSource(SourceEventArgs e)
        {
            if (null != e)
            {
                EventHandler<SourceEventArgs> temp = SourceEvtArgs;
                temp(this, e);

            }
        }

        public void UpdateSource(Double temp, Double pressr, Double humid)
        {
            SourceEventArgs e = new SourceEventArgs(temp, pressr, humid);
            OnUpdateSource(e);
        }

        #endregion

        #region VideoEventArgs
        protected void OnUpdatePlayer(VideoPlayerEventArgs e)
        {
            EventHandler<VideoPlayerEventArgs> temp = VideoEventArgs;
            if (null != temp)
            {
                temp(this, e);
            }
        }

        public void UpdatePlayer(int volume, Double brightness, String color)
        {
            VideoPlayerEventArgs e = new VideoPlayerEventArgs(volume, brightness, color);
            OnUpdatePlayer(e);

        }
        #endregion

        #region UpdateEvent
        protected void OnUpdate(EventArgs e)
        {
            EventHandler temp = UpdateEvent;
            if (null != temp)
            {
                temp(this, e);
            }
        }

        public void Update()
        {
            EventArgs e = new EventArgs();
            OnUpdate(e);

        }
        #endregion
    }

    public class Display1
    {
        public Display1(Source src )
        {
            src.SourceEvtArgs += new EventHandler<SourceEventArgs>( PutDisplay);
        }

        private void PutDisplay(object sender, SourceEventArgs srcArgs)
        {
            Console.WriteLine("This is display1 where Temperature={0}, Pressure={1},Humidity={2}",
                srcArgs.Temperature, srcArgs.Pressure, srcArgs.Humidity);
        }


    }

    public class Display2
    {
        public Display2(Source src)
        {
            src.SourceEvtArgs += PutDisplay;
            src.VideoEventArgs += VideoSettings;
            src.UpdateEvent += new EventHandler( ListenToUpdate);
        }
        private void PutDisplay(Object sender, SourceEventArgs sourceEventArgs)
        {
            Console.WriteLine("This is display2 where Temperature={0}, Pressure={1},Humidity={2}",
                sourceEventArgs.Temperature, sourceEventArgs.Pressure, sourceEventArgs.Humidity);
        }

        private void VideoSettings(object sender, VideoPlayerEventArgs e)
        {
            Console.WriteLine("This is display2's Video settings where Volume={0}, Brightness={1},Color={2}",
                e.Volume, e.Brightness, e.Color);
        }

        private void ListenToUpdate(object sender, EventArgs e)
        {
            Console.WriteLine("Fired event is Consumed");
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            Source src = new Source();

            Display1 disp1 = new Display1(src);
            Display2 disp2 = new Display2(src);

            src.UpdateSource(11.5, 23.6, 12.2);
            src.UpdatePlayer(10, 22.5, "Red");
            src.Update();
        }
    }
}
