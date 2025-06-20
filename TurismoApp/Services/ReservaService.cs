using TurismoApp.Data;
using TurismoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace TurismoApp.Services
{
    public class ReservaService
    {
        private readonly AgenciaTurismoContext _context;
        private readonly Logger _logger;

        public ReservaService(AgenciaTurismoContext context)
        {
            _context = context;
            _logger = new Logger();
        }

        public delegate decimal CalculoDescontoDelegate(int quantidadeDiarias, decimal precoDiaria);

        // Desconto de 10% para reserva com mais de 3 diárias
        public static decimal DescontoParaMaisDeTresDiarias(int quantidadeDiarias, decimal precoDiaria)
        {
            if (quantidadeDiarias > 3)
            {
                return precoDiaria * 0.9m;
            }
            return precoDiaria;
        }

        public decimal CalcularValorReserva(int quantidadeDiarias, decimal precoDiaria, CalculoDescontoDelegate calculoDesconto)
        {
            decimal precoFinalDiaria = calculoDesconto(quantidadeDiarias, precoDiaria);
            return precoFinalDiaria * quantidadeDiarias;
        }

        public async Task<bool> CriarReservaAsync(int clienteId, int pacoteId, int dias)
        {
            _logger.Log($"Iniciando criação de reserva para ClienteId={clienteId} e PacoteId={pacoteId}.");

            var cliente = await _context.Clientes.FindAsync(clienteId);
            if (cliente == null)
            {
                _logger.Log($"Cliente com ID {clienteId} não encontrado.");
                throw new Exception("Cliente não encontrado.");
            }

            var pacote = await _context.PacotesTuristicos.FindAsync(pacoteId);
            if (pacote == null)
            {
                _logger.Log($"Pacote com ID {pacoteId} não encontrado.");
                throw new Exception("Pacote não encontrado.");
            }

            int reservasAtuais = await _context.Reservas.CountAsync(r => r.PacoteTuristicoId == pacoteId);

            pacote.CapacityReached += (s, e) =>
            {
                string msg = $"Capacidade máxima do pacote '{pacote.Titulo}' atingida!";
                _logger.Log(msg);
                Console.WriteLine(msg);
            };

            pacote.VerificarCapacidade(reservasAtuais);

            if (reservasAtuais >= pacote.CapacidadeMaxima)
            {
                _logger.Log($"Reserva bloqueada - capacidade máxima atingida para o pacote '{pacote.Titulo}'.");
                return false;
            }

            decimal totalReserva = CalcularValorReserva(dias, pacote.Preco, DescontoParaMaisDeTresDiarias);
            _logger.Log($"Valor total da reserva para {dias} dia(s): {totalReserva:C}.");

            var reserva = new Reserva
            {
                Cliente = cliente,
                ClienteId = cliente.Id,
                PacoteTuristico = pacote,
                PacoteTuristicoId = pacote.Id,
                DataReserva = DateTime.Now,
                QuantidadeDiarias = dias 
            };

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            _logger.Log($"Reserva criada com sucesso para ClienteId={clienteId} no PacoteId={pacoteId}.");

            return true;
        }
    }
}
