using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UtileriasChat
{
    public static class Extensiones
    {
        public static void Encriptar(this Mensaje mensaje)
        {
            mensaje.Contenido = Encriptador.Encrypt(mensaje.Contenido);
        }

        public static void Desencriptar(this Mensaje mensaje)
        {
            mensaje.Contenido = Encriptador.Decrypt(mensaje.Contenido);
        }

        public static void PrintRTB(this RichTextBox rtb, Mensaje mensaje)
        {
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            int TextAlreadyLength = rtb.TextLength;
            rtb.AppendText(mensaje.Remitente+ ": " + mensaje.Contenido + Environment.NewLine);
            for (int i = 0; i < Mensaje.EmoticonList.Length / 3; i++)
            {
                int indexfound = -1;
                int indexNext = 0;
                int EmoticonLength = Mensaje.EmoticonList[i, 0].Length;
                while (true)
                {
                   indexfound = mensaje.Contenido.IndexOf(Mensaje.EmoticonList[i, 0], indexNext);
                    //indexfound = rtb.Text.IndexOf(Mensaje.EmoticonList[i, 0], indexNext);
                    if (indexfound >= 0)
                    {
                        try
                        {
                            string emoticonoPath = wanted_path + Mensaje.EmoticonList[i, 1];
                            if (File.Exists(emoticonoPath))
                            {
                                Bitmap image = new Bitmap(emoticonoPath);
                                System.Windows.Forms.Clipboard.SetDataObject(image);
                                rtb.Select(indexfound + TextAlreadyLength, EmoticonLength);
                                rtb.Paste();
                                indexNext += EmoticonLength;
                            }
                            else
                            {
                                indexNext += EmoticonLength;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else { break; }
                }

            }
        }

        public static bool SendToFile(this RichTextBox rtb,string identity)
        {
            try
            {
                string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                string filename = identity + DateTime.Now.ToShortDateString().Replace("/","");
                string completePath = wanted_path + "\\Conversaciones\\" + filename+".txt";
                if (File.Exists(completePath))
                {   
                    StreamWriter sw = new StreamWriter(completePath, true);
                    sw.Write(rtb.Text);
                    rtb.Text = "";
                    sw.Close();
                }
                else 
                {
                    StreamWriter sw = File.CreateText(completePath);
                    sw.Write(rtb.Text);
                    rtb.Text = "";
                    sw.Close();
                }
                return  true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
