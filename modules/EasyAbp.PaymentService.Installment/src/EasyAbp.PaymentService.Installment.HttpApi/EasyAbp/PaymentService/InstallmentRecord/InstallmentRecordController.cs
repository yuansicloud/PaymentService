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

        [Route("{id}")]
        [HttpGet]
        public Task<InstallmentRecordDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [Route("by-payment/{paymentId}")]
        [HttpGet]
        public Task<InstallmentRecordDto> GetByPaymentId(Guid paymentId)
        {
            return _service.GetByPaymentId(paymentId);
        }

        [HttpGet]
        public Task<PagedResultDto<InstallmentRecordDto>> GetListAsync(GetInstallmentListInput input)
        {
            return _service.GetListAsync(input);
        }

        [Route("{id}/remove-repayment")]
        [HttpPost]
        public Task RemoveRepaymentAsync(Guid id, RemoveRepaymentInput input)
        {
            return _service.RemoveRepaymentAsync(id, input);
        }

        [Route("{id}/repay")]
        [HttpPost]
        public Task RepayAsync(Guid id, RepayInput input)
        {
            return _service.RepayAsync(id, input);
        }
    }
}
