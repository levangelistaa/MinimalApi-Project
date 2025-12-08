using MinimalApi.Domain.Entities;
using MinimalApi.DTOs;

namespace MinimalAPI.Domain.Interfaces {
    public interface IAdminService {
        Admin? Login(LoginDTO loginDTO); 
    }
}
