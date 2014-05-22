using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtileriasChat
{
    public class Sesion
    {
        #region Campos
        private int _sessionId;

        public int SessionId
        {
            get { return _sessionId; }
            set { _sessionId = value; }
        }
        private string _sessionAlias;

        public string SessionAlias
        {
            get { return _sessionAlias; }
            set { _sessionAlias = value; }
        }
        private List<String> _integrantes;

        public List<String> Integrantes
        {
            get { return _integrantes; }
            set { _integrantes = value; }
        }
        #endregion

        #region Constructores
            public Sesion(int sesionId, string sesionAlias)
            {
                this._sessionId = sesionId;
                this._sessionAlias = sesionAlias;
                this._integrantes = new List<string>();
            }
            public Sesion(int sesionId)
            {
                this._sessionId = sesionId;
                this._integrantes = new List<string>();
            }
            public Sesion(string alias)
            {
                this._sessionAlias = alias;
                this._integrantes = new List<string>();
            }
        #endregion

        #region Métodos
            public void AgregarParticipante(String integrante)
            {
                this._integrantes.Add(integrante);
            }
            public void EliminarParticipante(String integrante)
            {
                _integrantes.Remove(integrante);
            }          
        #endregion 
    }  
}
