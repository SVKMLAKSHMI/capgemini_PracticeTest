using System.Collections.Generic;
namespace Q3{

    public enum CommodityCategory{

        Furniture,
        Grocery,
        Service
    }

    public class Commodity{

        public CommodityCategory Category{get;set;}
        public string CommodityName{get; set;}
        public int CommodityQuantity{get; set;}
        public double CommodityPrice{get;set;}

        public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice){

            Category = category;
            CommodityName = commodityName;
            CommodityQuantity = commodityQuantity;
            CommodityPrice = commodityPrice;

        }
    }

    public class PaperBill{

        private readonly IDictionary<CommodityCategory,double> _taxRates;

        public PaperBill(){

            Dictionary<CommodityCategory,double> dict = new Dictionary<CommodityCategory,double>();
            _taxRates = dict;

        }

        public void SetTaxRates(CommodityCategory category, double taxRate){

            if(!_taxRates.ContainsKey(category)){
                _taxRates.Add(category,taxRate);
            }
        }

        public double CalculateAmount(IList<Commodity> items){

            double sum = 0;

            foreach(var item in items){
                if(!_taxRates.ContainsKey(item.Category)){
                    throw new ArgumentException("Invalid commodity");
                }
                else{
                    sum += item.CommodityPrice * item.CommodityQuantity * (_taxRates[item.Category]/100);
                }
            }

            return sum;
        }
    }
    public class Q3{

        public static void Main(String[] args){

            var commodities = new List<Commodity>(){

                new Commodity(CommodityCategory.Furniture,"Bed",2,50000),
                new Commodity(CommodityCategory.Grocery,"Flour",5,80),
                new Commodity(CommodityCategory.Service,"Insurance",8,8500)

            };

            var paperBill = new PaperBill();
            paperBill.SetTaxRates(CommodityCategory.Furniture,18);
            paperBill.SetTaxRates(CommodityCategory.Grocery,5);
            paperBill.SetTaxRates(CommodityCategory.Service,12);

            var billAmount = paperBill.CalculateAmount(commodities);
            Console.WriteLine(billAmount);

        }
    }
}