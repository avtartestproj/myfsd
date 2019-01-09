using System;
using System.ComponentModel.DataAnnotations;

namespace SPAData
{
    public class TrainingProduct
    {
        public int ProductID { get; set; }

        //[Required(ErrorMessage ="Product name is mandatory")]
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
              ErrorMessageResourceName = "ProductNameRequired")]
        [Display(Description = "Product infoo", Name = "ProductName", ResourceType = typeof(Resources.Resource))]
        [StringLength(50,MinimumLength =2, ErrorMessageResourceType = typeof(Resources.Resource),
              ErrorMessageResourceName = "Productnamemustbegreaterthen2andlessthan51")]
        public string ProductName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
             ErrorMessageResourceName = "IntroductionDateisRequired")]
        [Range(typeof(DateTime),"1/1/2018","12/12/2018", ErrorMessageResourceType = typeof(Resources.Resource),
              ErrorMessageResourceName = "Notindaterange")]
        [Display(Name = "IntroductionDate", ResourceType = typeof(Resources.Resource))]
        public DateTime IntroductionDate { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
               ErrorMessageResourceName = "Urlismandatory")]

        [Display(Name = "URL", ResourceType = typeof(Resources.Resource))]
        public string Url { get; set; }


        [Display(Name = "Price", ResourceType = typeof(Resources.Resource))]
        public decimal Price {get;set;}

    }
}
