namespace EcommerceProject.App.Routes
{
    public class ConstRoutes
    {
        public const string AddProduct = "/product/Add";
        public const string EditProduct = "/product/edit/{ProductId:int}";
        public const string ProductIndex = "/product";

        public const string AddCategory = "/category/Add";
        public const string EditCategory = "/category/edit/{CategoryId:int}";
        public const string CategoryIndex = "/category";

        public const string AddBrand = "/brand/Add";
        public const string EditBrand = "/brand/edit/{BrandId:int}";
        public const string BrandIndex = "/brand";

        public const string AddCustomer = "/customer/Add";
        public const string EditCustomer = "/customer/edit/{CustomerId:int}";
        public const string CustomerIndex = "/customer";

        public const string OrderIndex = "/order";

        public const string OrderHistory = "/orderHistory";

        public const string UserIndex = "/user";

        public const string EmailTemplates = "/emailTemplate";
        public const string EditEmailTemplates = "/emailTemplate/edit/{Code}";
        public const string AddEmailTemplates = "/emailTemplate/Add";

        public const string Sendmail = "/sendMail";




    }
}
