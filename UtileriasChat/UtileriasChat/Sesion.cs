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
            private string _sessionAlias;
            private List<Contacto> _integrantes;
        #endregion

        #region Constructores
            public Sesion(int sesionId, string sesionAlias)
            {
                this._sessionId = sesionId;
                this._sessionAlias = sesionAlias;
            }
            public Sesion(int sesionId)
            {
                this._sessionId = sesionId;
            }
        #endregion

        #region Métodos
            public void AgregarParticipante(Contacto integrante)
            {
                this._integrantes.Add(integrante);
            }
            public void EliminarParticipante(Contacto integrante)
            {
                _integrantes.Remove(integrante);
            }          
        #endregion 
    }  
}
