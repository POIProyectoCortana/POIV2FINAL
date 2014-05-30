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
                    if (indexfound >= 0)
                    {
                        try
                        {
                            string emoticonoPath = wanted_path + "\\" + Mensaje.EmoticonList[i, 1];
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
                        catch (Exception ex)
                        {
                        }
                    }
                    else { break; }
                }

            }
        }
    }
}
