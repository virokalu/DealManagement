using DealManagement.Server.Domain.Models;

namespace DealManagement.Server.Domain.Services.Communication
{
    public class DealResponse : BaseResponse
    {
        public Deal Deal { get; private set; }

        private DealResponse(bool success, string message, Deal deal) : base(success, message)
        {
            Deal = deal;
        }

        public DealResponse(Deal deal) : this(true, string.Empty, deal)
        {
        }

        public DealResponse(string message) : this(false, message, null!)
        {
        }
    }
}
