﻿using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Infra.Data.Context;

namespace SmartVendas.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente, SmartVendasContext>, IClienteRepository
    {
    }
}
