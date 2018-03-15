using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WebServices.ReservationVoiture.Soap
{
    [ServiceContract]
    interface IVoiture
    {
        [OperationContract]
        List<BaseVoiture> GetVoitures(DateTime dateResaStart, DateTime dateResaEnd, BaseVoiture.TypeVoiture Type, int Agence);

        [OperationContract]
        BaseVoiture GetInfosVoiture(int voitureId);

        [OperationContract]
        bool ReserverVoiture(int agence, int voitureId, DateTime dateResaStart, DateTime dateResaEnd);
    }
}
