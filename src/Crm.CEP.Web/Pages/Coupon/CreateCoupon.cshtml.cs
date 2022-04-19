using Crm.CEP.Coupons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Crm.CEP.Web.Pages.Coupon
{
    public class CreateCouponModel : CEPPageModel
    {
        public CreateUpdateCouponDto Coupon { get; set; }

        private readonly ICouponAppService _couponAppService;

        public void OnGet()
        {
            Coupon = new CreateUpdateCouponDto();
        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    await _couponAppService.CreateAsync(Coupon);
        //    return NoContent();
        //}
    }
}
