using EasyAbp.PaymentService.Installment.InstallmentRecords;
using EasyAbp.PaymentService.Installment.InstallmentRecords.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PaymentService.Installment.EasyAbp.PaymentService.InstallmentRecord
{
    [RemoteService(Name = "EasyAbpPaymentServiceInstallment")]
    [Route("/api/payment-service/installment/installment-record")]
    public class InstallmentRecordController : InstallmentController, IInstallmentRecordAppService
    {
        private readonly IInstallmentRecordAppService _service;

        public InstallmentRecordController(IInstallmentRecordAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public Task<InstallmentRecordDto> CreateAsync(CreateInstallmentRecordDto input)
        {
            return _service.CreateAsync(input);
        }

        [Route("{id}")]
        [HttpDelete]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [Route("{id}")]
        [HttpGet]
        public Task<InstallmentRecordDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<InstallmentRecordDto>> GetListAsync(GetInstallmentListInput input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPut]
        [Route("id")]
        public Task<InstallmentRecordDto> UpdateAsync(Guid id, UpdateInstallmentRecordDto input)
        {
            return _service.UpdateAsync(id, input);
        }
    }
}
