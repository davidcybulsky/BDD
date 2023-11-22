using Api.Entities;

namespace Api.Interfaces
{
    public interface ICaretakerService
    {
        Task<Caretaker> ReadById(int id);
        Task<IEnumerable<Caretaker>> Read();
        Task Create(Caretaker caretaker);
        Task Update(int id, Caretaker caretaker);
        Task Delete(int id);
    }
}
