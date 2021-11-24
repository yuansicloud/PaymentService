using EasyAbp.PaymentService.Installment.InstallmentRecords;
using EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos;
using AutoMapper;
using EasyAbp.PaymentService.Installment.RepaymentRecords;

namespace EasyAbp.PaymentService.Installment
{
    public class InstallmentApplicationAutoMapperProfile : Profile
    {
        public InstallmentApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<InstallmentRecord, InstallmentRecordDto>();
            CreateMap<RepaymentRecord, RepaymentRecordDto>();
        }
    }
}
