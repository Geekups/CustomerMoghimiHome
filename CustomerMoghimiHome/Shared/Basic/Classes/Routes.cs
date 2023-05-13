namespace CustomerMoghimiHome.Shared.Basic.Classes;

public record CRUDRouts
{
    public const string Create = "create";
    public const string ReadOneById = "read-one-by-id";
    public const string ReadAll = "read-all";
    public const string ReadListByFilter = "read-list-by-filter";
    public const string Update = "update";
    public const string Delete = "delete";
}
public record ShopRoutes
{
    public const string ShopApi = "shop-api/";
    public const string Product = ShopApi + "product/";
    public const string ProductCategory = ShopApi + "product-category/";
    public const string UserBasket = ShopApi + "user-basket/";
    public const string UserOrder = ShopApi + "user-order/";
}
public record SeoRoutes
{
    public const string AltApi = "alt-api/";
    public const string Alt = AltApi + "alt/";
    public const string Tag = AltApi + "tag/";
}
public record FileRoutes
{
    public const string FileApi = "file-api/";

    #region Image
    public const string ImageFile = FileApi + "image-file/";
    public const string GetAllImageFile = FileApi + "get-all-image-file/";
    #endregion

    public const string StaticFile = FileApi + "static-file/";
}
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

public record BasketRoutes
{
    public const string BasketApi = "basket-api/";
    public const string Basket = BasketApi + "basket/";
}