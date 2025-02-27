﻿using DvdApi.Models;
using DvdApi.DatabaseOperations;
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
    public class ActorService : IActorService
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
            return await _dbAccess.GetActorByIdAsync(id);
        }

        public async Task<Actor> AddActorAsync(Actor actor)
        {
            return await _dbAccess.AddActorAsync(actor);
        }

        public async Task<bool> UpdateActorAsync(Actor actor)
        {
            return await _dbAccess.UpdateActorAsync(actor);
        }

        public async Task<bool> DeleteActorAsync(int id)
        {
            return await _dbAccess.DeleteActorAsync(id);
        }

    }
}