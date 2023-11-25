using Api.Entities;

namespace Api.Interfaces
{
    public interface ICaretakerService
    {
        Task<Caretaker> ReadById(Guid id);
        Task<IEnumerable<Caretaker>> Read();
        Task Create(Caretaker caretaker);
        Task<Caretaker> Update(Guid id, Caretaker caretaker);
        Task<Caretaker> Delete(Guid id);
    }
}
