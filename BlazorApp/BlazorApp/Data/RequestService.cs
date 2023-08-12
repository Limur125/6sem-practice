using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BlazorApp.Data
{
    public class RequestService
    {
        private readonly IDbContextFactory<PurchaseContext> _contextFactory;

        public RequestService(IDbContextFactory<PurchaseContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<Request[]> Index()
        {
            var context = _contextFactory.CreateDbContext();
            return Task.FromResult(context.Request.ToArray());
        }

        public async Task<Request> Get(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var request = await context.Request.FindAsync(id);
            return request;
        }

        public async Task<Request> Create(Request request)
        {
            var context = _contextFactory.CreateDbContext();
            context.Add(request);
            await context.SaveChangesAsync();
            return request;
        }

        public async Task<Request> Edit(int id, Request request)
        {
            var context = _contextFactory.CreateDbContext();
            if (id != request.Id)
                return null;
            try
            {
                context.Update(request);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(request.Id))
                    return null;
                else
                    throw;
            }
            return request;
        }

        public async Task<Request> DeleteConfirmed(int id)
        {
            var context = _contextFactory.CreateDbContext();
            if (context.Request == null)
                return null;
            var request = await context.Request.FindAsync(id);
            if (request != null)
                context.Request.Remove(request);
            await context.SaveChangesAsync();
            return request;
        }

        private bool RequestExists(int id)
        {
            var context = _contextFactory.CreateDbContext();
            return (context.Request?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
