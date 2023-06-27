using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using to_do_list.Contracts;
using to_do_list.Models;

namespace to_do_list.Repository
{
    public class RepoMission : RepoBase<Mission>, IRepoMission
    {
        public RepoMission(to_do_listDbContext DbContext) : base(DbContext)
        {

        }

        public void CreateMission(Mission mission)
        {
            Create(mission);
            save();
        }

        public void DeleteMission(string id, string UserId)
        {
            var missions = GetAllMissions(UserId).ToList();

            foreach (var mission in missions)
            {
                if (mission.Id.ToString() == id)
                {
                    Delete(mission);
                    save();
                    break;
                }
            }
        }

        public void UpdateMission(Mission mission , string UserId)
        {
            var missions = GetAllMissions(UserId).ToList();

            foreach (var m in missions)
            { 
                if(m.Id == mission.Id)
                {
                    m.Name = mission.Name;
                    m.Description = mission.Description;
                    m.DeadLine = mission.DeadLine;
                    Update(m);
                    save();
                    break;
                }
            }
        }

        public void MarkAsCompleted(string [] ids, string UserId)
        {
            var missions = GetAllMissions(UserId).ToList();
            var dict = new Dictionary<string, Mission>();

            foreach (var mission in missions)
            {
                dict.Add(mission.Id.ToString(), mission);
            }

            foreach (var id in ids)
            {
                if (dict.ContainsKey(id))
                {
                    Mission mission = dict[id];
                    mission.IsCompleted = true;
                    Update(mission);
                    save();
                }
            }
        }

        public void MarkNotCompleted(string [] ids, string UserId)
        {
            var missions = GetAllMissions(UserId).ToList();
            var dict = new Dictionary<string, Mission>();

            foreach (var mission in missions)
            {
                dict.Add(mission.Id.ToString(), mission);
            }

            foreach (var id in ids)
            {
                if (dict.ContainsKey(id))
                {
                    Mission mission = dict[id];
                    mission.IsCompleted = false;
                    Update(mission);
                    save();
                }
            }
        }

        public IQueryable<Mission> GetAllMissions(string UserId)
        {
            return FindByCondition(t => UserId == t.UserId);
        }
    }
}
