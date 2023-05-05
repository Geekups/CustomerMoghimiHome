using CustomerMoghimiHome.Shared.EntityFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class BasketDto: BaseDto
{
    public string UserId { get; set; }
    public int Quantity { get; set; }
    public long ProductId { get; set; }
}
