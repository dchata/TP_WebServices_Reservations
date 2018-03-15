using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.ReservationVoiture.Soap
{
    public class BaseAgence
    {
        #region Properties
        private int Id;
        private string Nom;
        #endregion

        #region Accesseurs
        public BaseAgence()
        {

        }

             
        public string nom
        {
            get { return Nom; }
            set { Nom = value; }
        }


        public int id
        {
            get { return Id; }
            set { Id = value; }
        }
        #endregion

        #region Constructors
        public BaseAgence(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }
        #endregion

        public List<BaseAgence> GetBaseAgences()
        {
            var listeAgences = new List<BaseAgence>();

            listeAgences.Add(new BaseAgence(1, "Agence1"));
            listeAgences.Add(new BaseAgence(2, "Agence2"));
            listeAgences.Add(new BaseAgence(3, "Agence3"));
            listeAgences.Add(new BaseAgence(4, "Agence4"));
            listeAgences.Add(new BaseAgence(5, "Agence5"));

            return listeAgences;
        }
    }
}