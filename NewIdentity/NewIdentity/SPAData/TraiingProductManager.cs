using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAData
{
    public class TrainingProductManager
    {
        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public bool validate(TrainingProduct entity)
        {
            bool isvalid = false;
            ValidationErrors.Clear();

            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                if (entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("Custom error", "Sample cutom error"));
                }
            }
            if (ValidationErrors.Count <= 0)
            {
                isvalid = true;
            }
            return isvalid; //(ValidationErrors.Count == 0);
        }


        public TrainingProduct Get(int ProductID)
        {
            List<TrainingProduct> lst = new List<TrainingProduct>();
            TrainingProduct ret = new TrainingProduct();
            //db call get data
            lst = CreateMockData();
            ret = lst.Find(p => p.ProductID == ProductID);
            return ret;

        }

        public bool Update(TrainingProduct entity,out List<TrainingProduct> lstupdated)
        {
            bool ret = false;
            List<TrainingProduct> lst = new List<TrainingProduct>();
            TrainingProduct tempProd = new TrainingProduct();
            ret = validate(entity);
            if (ret)
            {
                lst = CreateMockData();
                tempProd = lst.Find(p => p.ProductID == entity.ProductID);
                lst.Remove(tempProd);
                tempProd = new TrainingProduct();
                tempProd.ProductID = entity.ProductID;
                tempProd.ProductName = entity.ProductName;
                tempProd.IntroductionDate = entity.IntroductionDate;
                tempProd.Url = entity.Url;
                tempProd.Price = entity.Price;
                //update in DB
                
            }

            lst.Add(tempProd);
            lstupdated = lst;
            return ret;
        }

        List<TrainingProduct> lstProdAdd = new List<TrainingProduct>();
        public bool Insert(TrainingProduct entity,out List<TrainingProduct> lst)
        {
          //lstProdAdd = new List<TrainingProduct>();
            lstProdAdd = CreateMockData();
            bool ret = false;
            ret = validate(entity);
            if (ret)
            {
                //insert
                lstProdAdd.Add(new TrainingProduct()
                {
                    ProductID = entity.ProductID,
                    ProductName = entity.ProductName,
                    IntroductionDate = entity.IntroductionDate,
                    Url = entity.Url,
                    Price = entity.Price
                });


            }
            lst = lstProdAdd;
            return ret;
        }

        public bool Delete(TrainingProduct entity,out List<TrainingProduct> lstupdated)
        {

            bool ret = false;
            List<TrainingProduct> lst = new List<TrainingProduct>();
            TrainingProduct tempProd = new TrainingProduct();
            ret = validate(entity);
            if (ret)
            {
                lst = CreateMockData();
                tempProd = lst.Find(p => p.ProductID == entity.ProductID);
                lst.Remove(tempProd);
               
                //delete from DB

            }
            lstupdated = lst;
            return ret;
        }
        public List<TrainingProduct> Get(TrainingProduct entity,List<TrainingProduct> prd,string mode="")
        {
            if (mode.ToLower() == "delete")
            {
                return prd;
            }
            List<TrainingProduct> ret = new List<TrainingProduct>();

            //TODO - Add Empower Data Fetch Call method here
            
            ret = prd.Count >= 5 ? prd : CreateMockData();

            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName.ToLower()));
            }
            return ret;
        }

        private List<TrainingProduct> CreateMockData()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();
            ret.Add(new TrainingProduct() {
                ProductID = 1,
                ProductName = "SPA Poc for Empower",
                IntroductionDate = Convert.ToDateTime("05/04/2018"),
                Url="http://test.com",
                Price=Convert.ToDecimal(100)
            });

            ret.Add(new TrainingProduct()
            {
                ProductID = 2,
                ProductName = "Sample Product 2",
                IntroductionDate = Convert.ToDateTime("05/05/2018"),
                Url = "http://SampleProduct.com",
                Price = Convert.ToDecimal(200)
            });

            ret.Add(new TrainingProduct()
            {
                ProductID = 3,
                ProductName = "Sample Product 3",
                IntroductionDate = Convert.ToDateTime("05/05/2018"),
                Url = "http://SampleProduct3.com",
                Price = Convert.ToDecimal(300)
            });

            ret.Add(new TrainingProduct()
            {
                ProductID = 4,
                ProductName = "Sample Product 4",
                IntroductionDate = Convert.ToDateTime("05/05/2018"),
                Url = "http://SampleProduct4.com",
                Price = Convert.ToDecimal(400)
            });

            ret.Add(new TrainingProduct()
            {
                ProductID = 5,
                ProductName = "Sample Product 5",
                IntroductionDate = Convert.ToDateTime("05/05/2018"),
                Url = "http://SampleProduct5.com",
                Price = Convert.ToDecimal(500)
            });

            return ret;
           
        }
    }
}
