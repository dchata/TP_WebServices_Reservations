using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.ReservationVoiture.Soap
{
    public class BaseVoiture //Notre "table de base de données" Voiture
    {
        #region Properties
        private int Id;
        private string Modele;
        private bool Disponible;
        private TypeVoiture Type;
        private DateTime DateDispoStart;
        private DateTime DateDispoEnd;
        private BaseAgence Agence;
        [Flags]
        public enum TypeVoiture { Citadine = 1, SUV = 2, Berline = 3, Sport = 4 };
        #endregion

        #region Accesseurs
        public BaseAgence agence
        {
            get { return Agence; }
            set { Agence = value; }
        }


        public DateTime dateDispoStart
        {
            get { return DateDispoStart; }
            set { DateDispoStart = value; }
        }


        public DateTime dateDispoEnd
        {
            get { return DateDispoEnd; }
            set { DateDispoEnd = value; }
        }


        public TypeVoiture type
        {
            get { return Type; }
            set { Type = value; }
        }


        public bool diponible
        {
            get { return Disponible; }
            set { Disponible = value; }
        }


        public string modele
        {
            get { return Modele; }
            set { Modele = value; }
        }


        public int id
        {
            get { return Id; }
            set { Id = value; }
        }
        #endregion

        #region Construcors
        public BaseVoiture()
        {

        }
        public BaseVoiture(int id, string modele, bool dispo, TypeVoiture type, DateTime dateDispoStart, DateTime dateDispoEnd, BaseAgence agence)
        {
            Id = id;
            Modele = modele;
            Disponible = dispo;
            Type = type;
            DateDispoStart = dateDispoStart;
            DateDispoEnd = dateDispoEnd;
            Agence = agence;
        }
        #endregion

        public List<BaseVoiture> GetBaseVoitures()
        {
            var listeVoitures = new List<BaseVoiture>();
            var baseAgence = new BaseAgence();
            var agences = baseAgence.GetBaseAgences();

            listeVoitures.Add(new BaseVoiture(1, "Renault Talisman", true, TypeVoiture.Berline, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("15/03/2018 00:00:00"), agences.Where(a => a.id == 1).FirstOrDefault()));
            listeVoitures.Add(new BaseVoiture(2, "Citroën C4", true, TypeVoiture.Berline, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("12/03/2020 00:00:00"), agences.Where(a => a.id == 1).FirstOrDefault()));
            listeVoitures.Add(new BaseVoiture(3, "Renault Mégane RS", true, TypeVoiture.Sport, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("12/05/2018 00:00:00"), agences.Where(a => a.id == 2).FirstOrDefault()));
            listeVoitures.Add(new BaseVoiture(4, "Peugeot 208", true, TypeVoiture.Citadine, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("12/07/2018 00:00:00"), agences.Where(a => a.id == 2).FirstOrDefault()));
            listeVoitures.Add(new BaseVoiture(5, "Peugeot 308", false, TypeVoiture.Citadine, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("22/03/2018 00:00:00"), agences.Where(a => a.id == 4).FirstOrDefault()));
            listeVoitures.Add(new BaseVoiture(6, "Range Rover Evoque", true, TypeVoiture.SUV, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("20/03/2018 00:00:00"), agences.Where(a => a.id == 4).FirstOrDefault()));
            listeVoitures.Add(new BaseVoiture(7, "Porsche Cayenne", true, TypeVoiture.SUV, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("12/04/2018 00:00:00"), agences.Where(a => a.id == 5).FirstOrDefault()));
            listeVoitures.Add(new BaseVoiture(8, "Renault Twingo", false, TypeVoiture.Citadine, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("12/12/2018 00:00:00"), agences.Where(a => a.id == 5).FirstOrDefault()));
            listeVoitures.Add(new BaseVoiture(9, "Citroën C4 Picasso", true, TypeVoiture.Citadine, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("12/03/2020 00:00:00"), agences.Where(a => a.id == 1).FirstOrDefault()));
            listeVoitures.Add(new BaseVoiture(10, "Citroën C3", true, TypeVoiture.Citadine, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("12/03/2020 00:00:00"), agences.Where(a => a.id == 1).FirstOrDefault()));
            listeVoitures.Add(new BaseVoiture(11, "Citroën C5", true, TypeVoiture.Berline, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("12/03/2020 00:00:00"), agences.Where(a => a.id == 1).FirstOrDefault()));
            listeVoitures.Add(new BaseVoiture(12, "Citroën C1", true, TypeVoiture.Citadine, Convert.ToDateTime("12/03/2018 00:00:00"), Convert.ToDateTime("12/03/2020 00:00:00"), agences.Where(a => a.id == 1).FirstOrDefault()));

            return listeVoitures;
        }
    }
}