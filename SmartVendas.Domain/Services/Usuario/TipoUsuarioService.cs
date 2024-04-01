using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class TipoUsuarioService : ServiceBase<TipoUsuario>, ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _repository;
        private readonly ITipoUsuarioReadOnlyRepository _readOnlyRepository;

        public TipoUsuarioService(ITipoUsuarioRepository repository, ITipoUsuarioReadOnlyRepository readOnlyRepository)
            :base(repository)
        {
            _repository = repository;
            _readOnlyRepository = readOnlyRepository;
        }

        public override IEnumerable<TipoUsuario> GetAll()
        {
            return _readOnlyRepository.GetAll();
        }

        public override TipoUsuario GetById(Guid id)
        {
            return _readOnlyRepository.GetById(id);
        }
    }
}
