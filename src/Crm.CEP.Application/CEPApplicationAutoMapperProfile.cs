using AutoMapper;
using Crm.CEP.Coupons;
using Crm.CEP.CustomerCoupons;
using Crm.CEP.Customers;
using Crm.CEP.Items;
using Crm.CEP.Queries;
using Crm.CEP.Referrals;
using Crm.CEP.Segments;
using Crm.CEP.TransactionItems;
using Crm.CEP.Transactions;
using Crm.CEP.TransactionsItems;

namespace Crm.CEP;

public class CEPApplicationAutoMapperProfile : Profile
{
    public CEPApplicationAutoMapperProfile()
    {
        //Segments
        CreateMap<Segment, SegmentDto>();
        CreateMap<SegmentQuery, SegmentQueryDto>();
        CreateMap<CreateUpdateSegmentDto, Segment>();

        //Queries
        CreateMap<Query, QueryDto>();
        CreateMap<CreateUpdateQueryDto, Query>();

        //JsonFieldQuery
        CreateMap<GetSegmentQueryDto, CreateUpdateSegmentQueryDto>();
        CreateMap<Coupon, CouponDto>();

        //Coupon
        CreateMap<CouponDto, Coupon>();
        CreateMap<CreateUpdateCouponDto, Coupon>();

        //Customer
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateUpdateCustomerDto, Customer>();

        //CustomerCoupon
        CreateMap<CustomerCoupon, CustomerCouponDto>();
        CreateMap<CreateUpdateCustCouponDto, CustomerCoupon>();

        //Transaction
        CreateMap<Transaction, TransactionDto>();
        CreateMap<CreateUpdateTransactionDto, Transaction>();


        CreateMap<SegmentDto, DropdownSegmentDto>();
        CreateMap<CouponDto, DropdownCouponDto>();
        CreateMap<CreateUpdateItemDto, Item>();
        CreateMap<Item, ItemDto>();

        CreateMap<CreateUpdateTransactionItemDto, TransactionItem>();
        CreateMap<TransactionItem, TransactionItemDto>();

        

        CreateMap<Referral, ReferralDto>();
        CreateMap<CreateUpdateReferralDto, Referral>();


    }
}
