using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.IO;


namespace UtileriasChat
{
    public class Sounds
    {
        public static void Buzz()
        {
            string file = "buzz.wav";
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            SoundPlayer simpleSound = new SoundPlayer(wanted_path + "\\Sounds\\"+file);
            simpleSound.Play();
        }

        public static void MessageAlert()
        {
            try
            {
                string file = "message.wav";
                string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))
                    + "\\Sounds\\" + file;
                if (File.Exists(wanted_path))
                {
                    SoundPlayer simpleSound = new SoundPlayer(wanted_path);
                    simpleSound.Play();
                }
            }
            catch(Exception)
            {

            }
        }
    }
}
