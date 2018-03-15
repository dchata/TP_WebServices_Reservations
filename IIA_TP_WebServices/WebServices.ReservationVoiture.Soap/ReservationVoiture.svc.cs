using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services.Protocols;

namespace WebServices.ReservationVoiture.Soap
{
    public class Service1 : IVoiture
    {
        public List<BaseVoiture> GetVoitures(DateTime dateResaStart, DateTime dateResaEnd, BaseVoiture.TypeVoiture Type, int Agence)
        {
            var baseVoiture = new BaseVoiture();
            var voitures = baseVoiture.GetBaseVoitures();
            
           return voitures.Where(v => v.diponible == true && v.dateDispoStart <= dateResaStart && v.dateDispoEnd > dateResaEnd && v.type == Type && v.agence.id == Agence).ToList();
        }

        public BaseVoiture GetInfosVoiture(int voitureId)
        {
            var baseVoiture = new BaseVoiture();
            var voitures = baseVoiture.GetBaseVoitures();

            return voitures.Where(v => v.id == voitureId).FirstOrDefault();
        }

        public bool ReserverVoiture(int agence, int voitureId, DateTime dateResaStart, DateTime dateResaEnd)
        {
            var baseVoiture = new BaseVoiture();
            var voitures = baseVoiture.GetBaseVoitures();
            var voitureReservee = false;

            foreach (var item in voitures)
            {
                if (item.diponible == true && item.agence.id == agence && item.id == voitureId && item.dateDispoStart <= dateResaStart && item.dateDispoEnd > dateResaEnd)
                {
                    voitureReservee = true;
                    break;
                }
            }

            //Commenté car a fonctionné mais ne fonctionne plus, d'où le foreach
            //var voitureReservee = voitures.Select(v => v.id == voitureId && v.agence.id == agence && v.diponible == true && v.dateDispoStart <= dateResaStart && v.dateDispoEnd > dateResaEnd).FirstOrDefault();

            return voitureReservee;
        }
    }
}
