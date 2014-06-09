using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtileriasChat
{
    public class Archivo
    {
        #region Campos
        private string extension;

        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }
        private byte[] fileData;

        public byte[] FileData
        {
            get { return fileData; }
            set { fileData = value; }
        }
        private string fileDataStr;

        public string FileDataStr
        {
            get { return fileDataStr; }
            set { fileDataStr = value; }
        }
        string fileName;
        int size;
        #endregion

        #region Propiedades
        #endregion

        #region Constructores
        #endregion

        #region Metodos
        #endregion
    }
}
