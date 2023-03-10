using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public abstract class CustAbstract
    {
        public abstract List<CustomerDetailViewModel> WebApiSearch();
    }
}
