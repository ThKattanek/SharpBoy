using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using SharpBoy.Core;

namespace SharpBoy
{
    public class GameBoyWindow
    {
        public RenderWindow gameboyWindow;
        public float videoOutputScale = 4.0f;   // Scalefactor for Output Video 

        public void Init()
        {
            gameboyWindow = new RenderWindow(new VideoMode((uint)(160 * videoOutputScale), (uint)(144 * videoOutputScale)), "SharpBoy", Styles.Close);
            gameboyWindow.SetActive();

            gameboyWindow.KeyPressed += Window_KeyPressed;
            gameboyWindow.Closed += Window_Closed;

           // logging all Videomodes 
            foreach(VideoMode videoMode in VideoMode.FullscreenModes)
            {
                Logging.Log("ScreenWidth: " + videoMode.Width + " ScreenHeight: " + videoMode.Height + " Bits per Pixel: " + videoMode.BitsPerPixel ,Severity.Information);
            }

            // set sfml window to center desktop
            uint desktop_w = VideoMode.DesktopMode.Width;
            uint desktop_h = VideoMode.DesktopMode.Height;
            
            // check if video mode from 2 Monitor desktop
            // experimentel !!
            if(((float)desktop_w / (float)desktop_h) > 3.0f)
            {
                desktop_w /= 2;
            }

            Vector2i vector1;
            vector1.X = (int)(desktop_w/2 - gameboyWindow.Size.X/2);
            vector1.Y = (int)(desktop_h/2 - gameboyWindow.Size.Y/2);
            gameboyWindow.Position = vector1;
        }

        private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            var window = (SFML.Window.Window)sender;
            if (e.Code == SFML.Window.Keyboard.Key.Escape)
            {
                
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            var window = (SFML.Window.Window)sender;
                window.Close();
        }
    }
}
