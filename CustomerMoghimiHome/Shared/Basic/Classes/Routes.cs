namespace CustomerMoghimiHome.Shared.Basic.Classes;

#region Crud
public record CRUDRouts
{
    public const string Create = "create";
    public const string ReadOneById = "read-one-by-id";
    public const string ReadAll = "read-all";
    public const string ReadListByFilter = "read-list-by-filter";
    public const string Update = "update";
    public const string Delete = "delete";

    #region Custom
    public const string CustomReadList = "custom-read-list";
    public const string IsSuggested = "is-suggested";
    public const string RequestPayment = "request-payment";
    public const string VerifyPayment = "verify-payment";
    #endregion
}
#endregion

#region Shop
public record ShopRoutes
{
    public const string ShopApi = "shop-api/";
    public const string Product = ShopApi + "product/";
    public const string ProductCategory = ShopApi + "product-category/";
    public const string UserBasket = ShopApi + "user-basket/";
    public const string UserOrder = ShopApi + "user-order/";
    public const string ZarinPal = ShopApi + "zarin-pal/";
}
#endregion

#region Seo
public record SeoRoutes
{
    public const string AltApi = "alt-api/";
    public const string Alt = AltApi + "alt/";
    public const string Tag = AltApi + "tag/";
}
#endregion

#region File
public record FileRoutes
{
    public const string FileApi = "file-api/";

    #region Image
    public const string ImageFile = FileApi + "image-file/";
    public const string GetAllImageFile = FileApi + "get-all-image-file/";
    #endregion

    public const string StaticFile = FileApi + "static-file/";
}
#endregion

#region Identity
public record AuthRoutes
{
    public const string AuthApi = "auth-api/";

    #region Register
    public const string Account = AuthApi + "account-handel-methods/";
    public const string Register = Account + "register/";
    #endregion

    #region Login
    public const string Login = AuthApi + "login-handler/";
    public const string LoginUser = Login + "login-user/";
    #endregion
}
#endregion

#region Customer
public record CustomerRoute
{
    public const string CustomerApi = "customer-api/";
    public const string PersonDetail = CustomerApi + "person-detail/";
    public const string ContactForm = CustomerApi + "contact-form/";
}
#endregion