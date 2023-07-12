using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.ZarinPal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CustomerMoghimiHome.Server.Controllers.Shop;
[ApiController]
public class ZarinPalController: ControllerBase
{
    private static readonly HttpClient client = new HttpClient();

    [HttpPost(ShopRoutes.ZarinPal + CRUDRouts.RequestPayment)]
    public async Task<IActionResult> RequestPayment(ZarinPalRequestModel model)
    {
        //SandBox Mode
        //var _url = "https://sandbox.zarinpal.com/pg/rest/WebGate/PaymentRequest.json";
        var _url = "https://www.zarinpal.com/pg/rest/WebGate/PaymentRequest.json";

        var _values = new Dictionary<string, string>
                {
                    { "MerchantID", model.MerchantID }, //Change This To work, some thing like this : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
                    { "Amount", model.Amount }, //Toman
                    { "CallbackURL", "http://localhost:5000/Home/VerifyPayment" },
                    { "Mobile", model.Mobile }, //Mobile number will be shown in the transactions list of the wallet as a separate field.
                    { "Description", model.Description }
                };

        var _paymentRequestJsonValue = JsonConvert.SerializeObject(_values);
        var content = new StringContent(_paymentRequestJsonValue, Encoding.UTF8, "application/json");

        var _response = await client.PostAsync(_url, content);
        var _responseString = await _response.Content.ReadAsStringAsync();

        ZarinPalRequestResponseModel _zarinPalResponseModel =
         JsonConvert.DeserializeObject<ZarinPalRequestResponseModel>(_responseString);


        //SandBox Mode
        //return Redirect("https://sandbox.zarinpal.com/pg/StartPay/"+_zarinPalResponseModel.Authority/*+"/Sad"*/); 

        // [/ُSad] will redirect to the sadad gateway if you already have zarin gate enabled, let's read here
        // https://www.zarinpal.com/blog/زرین-گیت،-درگاهی-اختصاصی-به-نام-وبسایت/
        return Redirect("https://www.zarinpal.com/pg/StartPay/" + _zarinPalResponseModel.Authority/*+"/Sad"*/);
    }

    [HttpPost(ShopRoutes.ZarinPal + CRUDRouts.VerifyPayment)]
    public async Task<IActionResult> VerifyPayment(string Authority, ZarinPalRequestModel model)
    {
        //SandBox Mode
        //var _url = "https://sandbox.zarinpal.com/pg/rest/WebGate/PaymentVerification.json";
        var _url = "https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json";

        var _values = new Dictionary<string, string>
                {
                    { "MerchantID", model.MerchantID }, //Change This To work, some thing like this : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
                    { "Authority", Authority },
                    { "Amount", model.Amount } //Toman
                };

        var _paymenResponsetJsonValue = JsonConvert.SerializeObject(_values);
        var content = new StringContent(_paymenResponsetJsonValue, Encoding.UTF8, "application/json");

        var _response = await client.PostAsync(_url, content);
        var _responseString = await _response.Content.ReadAsStringAsync();

        ZarinPalVerifyResponseModel _zarinPalResponseModel =
         JsonConvert.DeserializeObject<ZarinPalVerifyResponseModel>(_responseString);
        return Redirect("https://www.zarinpal.com/pg/StartPay/");
    }
}
