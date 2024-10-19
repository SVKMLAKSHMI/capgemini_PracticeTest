// namespace System.Collections.Generic;
namespace Q4{

    public interface IBroadBandPlan{

        public int GetBroadBandPlanAmount();

    }

    public class Black : IBroadBandPlan{

        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 3000;

        public Black(bool isSubscriptionValid, int discountPercentage){

            try{
                if((discountPercentage < 0) || (discountPercentage > 50)){

                    throw new ArgumentOutOfRangeException("Invalid discount percentage");

                }
                else{

                    this._isSubscriptionValid = isSubscriptionValid;
                    this._discountPercentage = discountPercentage;
                
                }
            }
            catch(ArgumentOutOfRangeException ex){
                
                Console.WriteLine(ex.Message);

            }
        }

        public int GetBroadBandPlanAmount(){

            if(_isSubscriptionValid){

                return PlanAmount - PlanAmount*_discountPercentage/100;
            
            }
            else{

                return PlanAmount;
            
            }
        }
    }

    public class Gold : IBroadBandPlan{

        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 1500;

        public Gold(bool isSubscriptionValid, int discountPercentage){

            try{

                if((discountPercentage < 0) || (discountPercentage > 30)){

                    throw new ArgumentOutOfRangeException("Invalid discountPercentage");

                } 
                else{

                    _isSubscriptionValid = isSubscriptionValid;
                    _discountPercentage = discountPercentage;

                }
            }
            catch(ArgumentOutOfRangeException ex){

                Console.WriteLine(ex.Message);

            }

        }

        public int GetBroadBandPlanAmount(){

            if(_isSubscriptionValid){

                return PlanAmount - PlanAmount * _discountPercentage/100;
            }
            else{

                return PlanAmount;
            }
        }
    }

    public class SubscriptionPlan{

        private readonly IList<IBroadBandPlan> _broadbandPlans;

        public SubscriptionPlan(IList<IBroadBandPlan> broadbandPlans){

            try{

                if(broadbandPlans == null){

                    throw new ArgumentNullException("Null exception");
                }
                else{

                    _broadbandPlans = broadbandPlans;
                }
            }
            catch(ArgumentNullException ex){

                Console.WriteLine(ex.Message);
            }
        }

        public IList<Tuple<string,int>> GetSubscriptionPlan(){

            List<Tuple<string,int>> list = new List<Tuple<string,int>>();
            
            try{

                if(_broadbandPlans == null){

                    throw new ArgumentNullException("Null exception");
                }

                foreach(var item in _broadbandPlans){
                    list.Add(Tuple.Create(item.GetType().Name,item.GetBroadBandPlanAmount()));
                }

                return list;
            }
            catch(ArgumentNullException ex){

                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
    
    public class Q4{

        public static void Main(String[] args){

            var plans = new List<IBroadBandPlan>{

                new Black(true, 50),
                new Black(false, 10),
                new Gold(true, 30),
                new Black(true, 20),
                new Gold(false, 20)
            };

            var subscriptionPlans = new SubscriptionPlan(plans);
            
            var result = subscriptionPlans.GetSubscriptionPlan();

            foreach(var item in result){

                Console.WriteLine($"{item.Item1},{item.Item2}");
            }

        }
    }
}
