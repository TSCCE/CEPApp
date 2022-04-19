using Crm.CEP.Coupons;
using Crm.CEP.CustomerCoupons;
using Crm.CEP.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Crm.CEP.Customers
{
    public class Customer : AuditedAggregateRoot<long>
    {

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }


        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string MaritalStatus { get; set; }

        public string LoyaltyId { get; set; }

        public string LoyaltyStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime LoyaltyExpiryDate { get; set; }

        public string MembershipStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime? JoiningDate { get; set; }

        public string PhoneNo { get; set; }

        public string EmailId { get; set; }

        public Customer()
        {

        }

        //Relations

       

        public IList<Transaction> Transactions { get; set; }

        public IList<CustomerCoupon> CustomerCoupons { get; set; }


    }
}
