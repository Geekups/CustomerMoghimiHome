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
}
public record SeoRoutes
{
    public const string AltApi = "alt-api/";
    public const string Alt = AltApi + "alt/";
    public const string Tag = AltApi + "tag/";
}
