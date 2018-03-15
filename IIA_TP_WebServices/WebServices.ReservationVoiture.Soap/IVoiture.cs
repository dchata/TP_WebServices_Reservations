﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using WebServices.ReservationVoiture.Soap.Messages;

namespace WebServices.ReservationVoiture.Soap
{
    [ServiceContract]
    interface IVoiture
    {
        [OperationContract]
        MessageResponse GetVoitures(MessageRequest messageRequest);

        [OperationContract]
        MessageResponse GetInfosVoiture(MessageRequest messageRequest);

        [OperationContract]
        MessageResponse ReserverVoiture(MessageRequest messageRequest);
    }
}
