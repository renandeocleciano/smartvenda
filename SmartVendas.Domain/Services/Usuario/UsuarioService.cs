using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioReadOnlyRepository _readOnlyRepository;

        public UsuarioService(IUsuarioRepository repository, IUsuarioReadOnlyRepository readOnlyRepository)
            : base(repository)
        {
            _repository = repository;
            _readOnlyRepository = readOnlyRepository;
        }

        public override IEnumerable<Usuario> GetAll()
        {
            return _readOnlyRepository.GetAll();
        }

        public override Usuario GetById(Guid id)
        {
            return _readOnlyRepository.GetById(id);
        }

        public Usuario GetByUserAndPass(string username, string pass)
        {
            return _readOnlyRepository.GetByUserAndPass(username, pass);
        }
    }
}
