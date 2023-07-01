using to_do_list.Models;

namespace to_do_list.Contracts
{
    public interface IRepoMission : IRepoBase<Mission>
    {
        Task<IQueryable<Mission>> GetAllMissions(string UserId);

        Task CreateMission(Mission mission);

        Task UpdateMission(Mission mission, string UserId);

        Task DeleteMission(string id, string UserId);

        Task MarkAsCompleted(string[] ids, string UserId);

        Task MarkNotCompleted(string [] ids, string UserId);

    }
}
