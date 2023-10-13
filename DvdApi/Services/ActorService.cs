using DvdApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DvdApi.DatabaseOperations;

namespace DvdApi.Services
{

    public class ActorService
    {
        private readonly ActorOperations _dbAccess;

        public ActorService()
        {
            _dbAccess = new ActorOperations();
        }

        public async Task<List<Actor>> GetAllActorsAsync()
        {
            return await _dbAccess.GetAllActorsAsync();
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            // Here you could include business logic to handle what happens if the actor doesn't exist.
            return await _dbAccess.GetActorByIdAsync(id);
        }

        public async Task<Actor> AddActorAsync(Actor actor)
        {
            // You could add business logic here to handle, for example, what happens if the actor information is not complete.
            return await _dbAccess.AddActorAsync(actor);
        }

        public async Task<bool> UpdateActorAsync(Actor actor)
        {
            // Business logic related to updating an actor could go here.
            return await _dbAccess.UpdateActorAsync(actor);
        }

        public async Task<bool> DeleteActorAsync(int id)
        {
            // Business logic related to deleting an actor could go here.
            return await _dbAccess.DeleteActorAsync(id);
        }

        // Additional methods related to business operations can be added here.
    }

}
