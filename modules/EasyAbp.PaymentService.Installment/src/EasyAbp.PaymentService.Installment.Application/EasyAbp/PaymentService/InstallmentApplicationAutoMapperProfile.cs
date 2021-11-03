using EasyAbp.PaymentService.Installment.InstallmentRecords;
using EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos;
using AutoMapper;

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
            CreateMap<CreateInstallmentRecordDto, InstallmentRecord>(MemberList.Source);
            CreateMap<UpdateInstallmentRecordDto, InstallmentRecord>(MemberList.Source);
        }
    }
}
