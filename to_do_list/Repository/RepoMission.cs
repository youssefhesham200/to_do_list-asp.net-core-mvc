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

        public async Task CreateMission(Mission mission)
        {
            await CreateAsync(mission);
        }

        public async Task DeleteMission(string id, string UserId)
        {
            var missions = await GetAllMissions(UserId);

            foreach (var mission in missions)
            {
                if (mission.Id.ToString() == id)
                {
                    await DeleteAsync(mission);
                    break;
                }
            }
        }

        public async Task UpdateMission(Mission mission , string UserId)
        {
            var missions = await GetAllMissions(UserId);

            foreach (var m in missions)
            { 
                if(m.Id == mission.Id)
                {
                    m.Name = mission.Name;
                    m.Description = mission.Description;
                    m.DeadLine = mission.DeadLine;
                    await UpdateAsync(m);
                    break;
                }
            }
        }

        public async Task MarkAsCompleted(string [] ids, string UserId)
        {
            var missions = await GetAllMissions(UserId);
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
                    await UpdateAsync(mission);
                }
            }
        }

        public async Task MarkNotCompleted(string [] ids, string UserId)
        {
            var missions = await GetAllMissions(UserId);
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
                    await UpdateAsync(mission);
                }
            }
        }

        public async Task<IQueryable<Mission>> GetAllMissions(string UserId)
        {
            return await FindByConditionAsync(t => UserId == t.UserId);
        }
    }
}
