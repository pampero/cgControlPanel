using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscador.Domain.com.clarin.entities
{
    public enum PublicationOrderState
    {
        /// <summary>
        /// "Pendiente"
        /// </summary>
        Pending,

        /// <summary>
        /// "Activa"
        /// </summary>
        Active,

        /// <summary>
        /// "Finalizada por vencimiento"
        /// </summary>
        FinishedByExpiration,

        /// <summary>
        /// "Finalizada por fraude"
        /// </summary>
        FinishedByFraud,

        /// <summary>
        /// "Cancelada"
        /// </summary>
        Canceled,

        /// <summary>
        /// "Suspendida por falta de pago"
        /// </summary>
        SuspendedByNonPayment,

        /// <summary>
        /// "Suspendida por fraude"
        /// </summary>
        SuspendedByFraud,

        /// <summary>
        /// "Suspendida por baja de usuario"
        /// </summary>
        SuspendedByLowUser,

        /// <summary>
        ///"Activada por Clienting" 
        /// </summary>
        ActivatedByClienting,

        /// <summary>
        /// Finalizado por el usuario
        /// </summary>
        FinalizedByUser
    }
}
