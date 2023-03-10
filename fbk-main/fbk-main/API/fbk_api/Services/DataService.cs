using System;
using fbk_api.Models;
using fbk_api.Repository;

namespace fbk_api.Services {
    public interface IDataService{
    
        List<ViewPurchase> List();
        List<ViewPurchase> ListByMonth();
        List<Purchase> Data(string? custId);
        
    }

    public sealed class DataService: IDataService{
        private readonly IPurchasesRepository _repository;
        public DataService(IPurchasesRepository repository){
           
            _repository =repository;
            
        }
        
        
        public List<ViewPurchase> List(){
            List<ViewPurchase> _objList = _repository.List(0,8);
            return _objList;
        }

        public List<ViewPurchase> ListByMonth(){
            List<ViewPurchase> _objList = _repository.List(2,6);
            return _objList;
        }
        
        public List<Purchase> Data(string? custId){
            List<Purchase> _objList = _repository.Data(custId);
            return _objList;
        }

    }
}