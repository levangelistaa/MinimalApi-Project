using Microsoft.EntityFrameworkCore;
using MinimalApi.Infrastructure.Database;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.Interfaces;

namespace MinimalAPI.Domain.Services {
    public class VehichleService : IVehichleService {

        private readonly ContextDb _context;
        public VehichleService(ContextDb context) {
            _context = context;
        }
        public void Apagar(Vehicle veiculo) {
            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();
        }

        public void Atualizar(Vehicle veiculo) {
            _context.Veiculos.Update(veiculo);
            _context.SaveChanges();
        }

        public Vehicle? BuscarPorId(int id) {
            return _context.Veiculos.Where(v => v.Id == id).FirstOrDefault();
        }

        public void Incluir(Vehicle veiculo) {
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
        }

        public List<Vehicle> Todos(int pagina = 1, string? nome = null, string? marca = null) {
            var query = _context.Veiculos.AsQueryable();

            if (!string.IsNullOrEmpty(nome)) {
                query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome}%"));
            }

            int itensPorPagina = 10;

            query = query.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);

            return query.ToList();
        }
    }
}
