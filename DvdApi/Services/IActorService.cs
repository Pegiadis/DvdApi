using DvdApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DvdApi.Services
{
    public interface IActorService
    {
        Task<List<Actor>> GetAllActorsAsync();
        Task<Actor> GetActorByIdAsync(int id);
        Task<Actor> AddActorAsync(Actor actor);
        Task<bool> UpdateActorAsync(Actor actor);
        Task<bool> DeleteActorAsync(int id);
    }
}