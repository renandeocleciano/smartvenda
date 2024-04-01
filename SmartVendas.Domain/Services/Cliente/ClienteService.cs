using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IClienteReadOnlyRepository _readOnlyRepository;

        public ClienteService(IClienteRepository repository, IClienteReadOnlyRepository readOnlyRepository)
            :base(repository)
        {
            _repository = repository;
            _readOnlyRepository = readOnlyRepository;
        }

        public override IEnumerable<Cliente> GetAll()
        {
            return _readOnlyRepository.GetAll();
        }

        public override Cliente GetById(Guid id)
        {
            return _repository.GetById(id);
        }

    }
}
