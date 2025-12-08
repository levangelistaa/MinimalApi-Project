using MinimalAPI.Domain.Entities;

namespace MinimalAPI.Domain.Interfaces {
    public interface IVehichleService {

        List<Vehicle> Todos(int pagina = 1, string? nome = null, string? marca = null);

        Vehicle? BuscarPorId(int id);

        void Incluir(Vehicle veiculo);

        void Atualizar(Vehicle veiculo);

        void Apagar(Vehicle veiculo);
    }
}
