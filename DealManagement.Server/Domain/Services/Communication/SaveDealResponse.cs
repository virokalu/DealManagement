using DealManagement.Server.Domain.Models;

namespace DealManagement.Server.Domain.Services.Communication
{
    public class SaveDealResponse : BaseResponse
    {
        public Deal Deal { get; private set; }

        private SaveDealResponse(bool success, string message, Deal deal) : base(success, message)
        {
            Deal = deal;
        }

        public SaveDealResponse(Deal deal) : this(true, string.Empty, deal)
        {
        }

        public SaveDealResponse(string message) : this(false, message, null!)
        {
        }
    }
}
