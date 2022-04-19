using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Crm.CEP.Customers
{
    public class CustomerDto : AuditedEntityDto<long>
    {
        private List<CustomerDto> customerDtos;

        public CustomerDto(List<CustomerDto> customerDtos)
        {
            this.customerDtos = customerDtos;
        }

        public string Name { get; set; }

        public string Nationality { get; set; }

        // [DataType(DataType.Date)]
        //public DateTime DOB { get; set; }
        public string DOB { get; set; }
        public GenderEnum Gender { get; set; }

        public MaritalStatusEnum? MaritalStatus { get; set; }

        public long? LoyaltyId { get; set; }

        public long? MembershipStatusId { get; set; }

        public long? CustomerStatusId { get; set; }

        public string OTPType { get; set; }

        [DataType(DataType.Date)]
        public DateTime? JoinDate { get; set; }
    }
}
