using CustomerInformation_Web.Data;

namespace CustomerInformation_Web.Services
{
    public abstract class CustAbstract
    {
        public abstract List<CustomerDetailViewModel> WebApiSearch();
    }
}
