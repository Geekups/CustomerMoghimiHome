using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.ZarinPal;
public class ZarinPalRequestModel
{
    public string MerchantID { get; set; }
    public string Amount { get; set; }
    public string CallbackURL { get; set; }
    public string Mobile { get; set; }
    public string Description { get; set; }
}
