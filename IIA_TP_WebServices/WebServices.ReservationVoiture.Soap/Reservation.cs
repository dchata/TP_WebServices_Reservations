using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.ReservationVoiture.Soap
{
    public class Reservation
    {
        #region Properties
        private int Id;
        private int _IdVoiture;
        private string _User;
        private DateTime _DateResaStart;
        private DateTime _DateResaEnd;
        #endregion

        #region Accesseurs
        public int IdVoiture
        {
            get { return _IdVoiture; }
            set { _IdVoiture = value; }
        }
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        public DateTime DateResaStart
        {
            get { return _DateResaStart; }
            set { _DateResaStart = value; }
        }
        public DateTime DateResaEnd
        {
            get { return _DateResaEnd; }
            set { _DateResaEnd = value; }
        }
        #endregion

        #region Constructor
        public Reservation(int idVoiture, string user, DateTime dateResaStart, DateTime dateResaEnd)
        {
            User = user;
            IdVoiture = idVoiture;
            DateResaStart = dateResaStart;
            DateResaEnd = dateResaEnd;
        }
        #endregion
    }
}