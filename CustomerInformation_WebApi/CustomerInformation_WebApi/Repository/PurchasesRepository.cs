using System;
using System.Linq;
using CustomerInformation_WebApi.Models;
using CustomerInformation_WebApi.Shared;


namespace CustomerInformation_WebApi.Repository
{
    public interface IPurchasesRepository
    {
        List<Purchase> ReadData();
        List<ViewPurchase> List(int _DataStart, int _DataLenght);
        List<ViewPurchase> ListPerMonth(int _DataStart, int _DataLenght);
        List<Purchase> Data(string? custId);

    }


    public sealed class PurchasesRepository : IPurchasesRepository
    {

        private readonly ReadDatFileShared _rdf = new ReadDatFileShared();
        private static List<Purchase> _listPuchases = new List<Purchase>();
        private readonly IConfiguration _configuration;

        public PurchasesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _listPuchases = readDatLines();
        }

        public List<Purchase> ReadData()
        {
            return _listPuchases;
        }

        private List<Purchase> readDatLines()
        {
            string path = _configuration.GetValue<string>("pathDatFile") + "Purchases.dat";
            string[] _lines = _rdf.ReadDatFile(path);

            Purchase _purchase = new Purchase();
            List<Purchase> _list = new List<Purchase>();


            string _cust = "";
            string _date = "";

            foreach (var item in _lines)
            {
                string _value = item.Substring(4);
                string _key = item.Substring(0, 4);

                switch (_key.ToUpper())
                {
                    case "CUST":

                        _cust = _value;
                        break;
                    case "DATE":
                        _date = _value;
                        break;
                    case "ITEM":
                        _purchase = new Purchase();
                        _purchase.cust = _cust;
                        _purchase.date = _date;
                        _purchase.item = _value;
                        _list.Add(_purchase);
                        break;
                    default:

                        break;
                }

            }

            return _list;
        }

        public List<ViewPurchase> List(int _DataStart, int _DataLenght)
        {
            List<ViewPurchase> _list = new List<ViewPurchase>();
            ViewPurchase _dett = new ViewPurchase();
            List<Purchase> _purchase = _listPuchases;

            var unique = _purchase.Select(x => x.item).Distinct().OrderBy(q => q).ToList();

            foreach (string _item in unique)
            {

                List<ViewPurchasedetail> _result = _purchase
                .Where(q => q.item.Equals(_item))
                .Select(s => new { data = s.date.Substring(_DataStart, _DataLenght), cust = s.cust })
                .GroupBy(g => new { gdata = g.data })
                .Select(s => new ViewPurchasedetail { date = DateTime.ParseExact(s.Key.gdata, "ddmmyyyy", null).ToString("dd-mm-yyyy"), total = s.Select(c => c.cust).Distinct().Count(), cust = s.Select(c => c.cust).Distinct().Order().ToList() })
                .OrderBy(o => o.date)
                .ToList();

                _dett = new ViewPurchase();
                _dett.item = _item;
                _dett.detail = _result;

                _list.Add(_dett);


            }

            return _list;
        }
        public List<ViewPurchase> ListPerMonth(int _DataStart, int _DataLenght)
        {
            List<ViewPurchase> _list = new List<ViewPurchase>();
            ViewPurchase _dett = new ViewPurchase();
            List<Purchase> _purchase = _listPuchases;

            var unique = _purchase.Select(x => x.item).Distinct().OrderBy(q => q).ToList();

            foreach (string _item in unique)
            {

                List<ViewPurchasedetail> _result = _purchase
                .Where(q => q.item.Equals(_item))
                .Select(s => new { data = s.date.Substring(_DataStart, _DataLenght), cust = s.cust })
                .GroupBy(g => new { gdata = g.data })
                .Select(s => new ViewPurchasedetail { date = DateTime.ParseExact(s.Key.gdata, "mmyyyy", null).ToString("mm-yyyy"), total = s.Select(c => c.cust).Distinct().Count(), cust = s.Select(c => c.cust).Distinct().Order().ToList() })
                .OrderBy(o => o.date)
                .ToList();

                _dett = new ViewPurchase();
                _dett.item = _item;
                _dett.detail = _result;

                _list.Add(_dett);


            }

            return _list;
        }

        public List<Purchase> Data(string? custId)
        {
            List<Purchase> _purchase = _listPuchases;
            List<Purchase> _listFilterd = new List<Purchase>();
            if (!String.IsNullOrEmpty(custId))
            {
                if (custId.Length > 0)
                {
                    _listFilterd = _purchase.FindAll(x => x.cust == custId);
                }
            }
            else
            {
                _listFilterd = _purchase;
            }
            return _listFilterd;
        }

    }
}