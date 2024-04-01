using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class PedidoService : ServiceBase<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository _PedidoRepository;
        private readonly IPedidoReadOnlyRepository _PedidoReadOnlyRepository;

        public PedidoService(IPedidoRepository PedidoRepository, IPedidoReadOnlyRepository PedidoReadOnlyRepository)
            : base(PedidoRepository)
        {
            _PedidoRepository = PedidoRepository;
            _PedidoReadOnlyRepository = PedidoReadOnlyRepository;
        }

        public override IEnumerable<Pedido> GetAll()
        {
            return _PedidoRepository.GetAll();
        }

        public Pedido GetByIdReadOnly(Guid id)
        {
            return _PedidoReadOnlyRepository.GetByIdReadOnly(id);
        }
    }
}
