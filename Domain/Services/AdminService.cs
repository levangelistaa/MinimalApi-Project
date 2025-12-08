using MinimalApi.Domain.Entities;
using MinimalApi.DTOs;
using MinimalApi.Infrastructure.Database;
using MinimalAPI.Domain.Interfaces;

namespace MinimalAPI.Domain.Services {
    public class AdminService : IAdminService {


        private readonly ContextDb _context;
        public AdminService(ContextDb context) {
            _context = context;
        }
        public Admin? Login(LoginDTO loginDTO) {
            var adm = _context.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
        }
    }
}
