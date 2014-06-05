using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtileriasChat
{
    public class Grupo
    {
        #region Campos
        private int id;
        private string alias;
        private List<String> integrantes;

            
        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Alias
        {
            get { return alias; }
            set { alias = value; }
        }
        public List<String> Integrantes
        {
            get { return integrantes; }
            set { integrantes = value; }
        }    
        #endregion

        #region Constructores
        public Grupo() { }
        public Grupo(int id, string alias)
        {
            this.id = id;
            this.alias = alias;
        }        
        #endregion

        #region Métodos
            public void AgregarParticipante(String integrante)
            {
                this.integrantes.Add(integrante);
            }
            public void EliminarParticipante(String integrante)
            {
                integrantes.Remove(integrante);
            }         
        #endregion 
    }  
}
