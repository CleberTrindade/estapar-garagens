﻿using Estapar.Garagens.Infrastructure.Models;

namespace Estapar.Garagens.Infrastructure.ExternalServices.Interfaces
{
    public interface IFormaPagamentoExternalService
    {
        Task<List<FormaPagamentoFileDto>> GetData();
    }
}
