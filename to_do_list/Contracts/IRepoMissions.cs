using to_do_list.Models;

namespace to_do_list.Contracts
{
    public interface IRepoMission : IRepoBase<Mission>
    {
        IQueryable<Mission> GetAllMissions(string UserId);

        void CreateMission(Mission mission);

        void UpdateMission(Mission mission, string UserId);

        void DeleteMission(string id, string UserId);

        void MarkAsCompleted(string[] ids, string UserId);

        void MarkNotCompleted(string [] ids, string UserId);

    }
}
