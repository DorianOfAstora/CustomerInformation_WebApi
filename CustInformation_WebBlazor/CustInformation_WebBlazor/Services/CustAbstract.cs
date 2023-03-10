using CustInformation_WebBlazor.Data;

namespace CustInformation_WebBlazor.Services
{
    public abstract class CustAbstract
    {
        public abstract List<CustomerDetailViewModel> WebApiSearch();
    }
}
