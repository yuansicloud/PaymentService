using System;
using EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.PaymentService.Installment.InstallmentRecords
{
    public interface IInstallmentRecordAppService :
        ICrudAppService< 
            InstallmentRecordDto, 
            Guid, 
            GetInstallmentListInput,
            CreateInstallmentRecordDto,
            UpdateInstallmentRecordDto>
    {

    }
}