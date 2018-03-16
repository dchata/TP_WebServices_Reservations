using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.ReservationVoiture.Soap
{
    public class BaseUtilisateur
    {
        #region Properties
        private int Id;
        private string _Username;
        private string _Password;
        #endregion
        #region Accesseurs
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }


        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        #endregion
        #region Constructor
        public BaseUtilisateur()
        {

        }
        public BaseUtilisateur(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
        #endregion

        public List<BaseUtilisateur> GetBaseUtilisateur()
        {
            var listeUtilisateur = new List<BaseUtilisateur>();
            listeUtilisateur.Add(new BaseUtilisateur(1, "weba","services"));
            listeUtilisateur.Add(new BaseUtilisateur(2, "webb", "services"));
            listeUtilisateur.Add(new BaseUtilisateur(3, "webc", "services"));
            listeUtilisateur.Add(new BaseUtilisateur(4, "webd", "services"));
            listeUtilisateur.Add(new BaseUtilisateur(5, "webe", "services"));
            listeUtilisateur.Add(new BaseUtilisateur(6, "webf", "services"));

            return listeUtilisateur;
        }

    }
}