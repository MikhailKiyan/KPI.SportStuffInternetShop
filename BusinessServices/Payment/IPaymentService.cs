using System;
using System.Threading;
using System.Threading.Tasks;
using KPI.SportStuffInternetShop.Domains;

namespace KPI.SportStuffInternetShop.BusinessServices.Payment {
    public interface IPaymentService {
        Task<CustomerBasket> CreateOrUpdatePaymentIntentAsync(
            Guid basketId,
            CancellationToken ct);
    }
}
