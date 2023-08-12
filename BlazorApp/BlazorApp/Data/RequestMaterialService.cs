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
    public class RequestMaterialService
    {
        private readonly IDbContextFactory<PurchaseContext> _contextFactory;

        public RequestMaterialService(IDbContextFactory<PurchaseContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<RequestMaterial[]> Index()
        {
            var context = _contextFactory.CreateDbContext();
            return await Task.FromResult(context.Material.ToArray());
        }

        public async Task<RequestMaterial> Get(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var material = await context.Material.FindAsync(id);
            return material;
        }

        public async Task<RequestMaterial[]?> GetMaterials(int requestId)
        {
            var context = _contextFactory.CreateDbContext();
            var materials = await Task.FromResult(context.Material.Where(m => m.RequestId == requestId).ToArray());
            return materials;
        }

        public async Task<RequestMaterial> Create(RequestMaterial material)
        {
            var context = _contextFactory.CreateDbContext();
            context.Add(material);
            await context.SaveChangesAsync();
            return material;
        }

        public async Task<RequestMaterial> Edit(int id, RequestMaterial material)
        {
            var context = _contextFactory.CreateDbContext();
            if (id != material.Id)
                return null;
            try
            {
                context.Update(material);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(material.Id))
                    return null;
                else
                    throw;
            }
            return material;
        }

        public async Task<RequestMaterial> DeleteConfirmed(int id)
        {
            var context = _contextFactory.CreateDbContext();
            if (context.Material == null)
                return null;
            var material = await context.Material.FindAsync(id);
            if (material != null)
                context.Material.Remove(material);
            await context.SaveChangesAsync();
            return material;
        }

        private bool RequestExists(int id)
        {
            var context = _contextFactory.CreateDbContext();
            return (context.Material?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
