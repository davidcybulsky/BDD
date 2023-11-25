using Api.Entities;

namespace Api.Interfaces
{
    public interface ICaretakerService
    {
        Task<Caretaker> ReadById(Guid id);
        Task<IEnumerable<Caretaker>> Read();
        Task Create(Caretaker caretaker);
        Task Update(Guid id, Caretaker caretaker);
        Task Delete(Guid id);
    }
}
