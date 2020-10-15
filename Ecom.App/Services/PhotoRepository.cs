using Ecom.App.Data;
using Ecom.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationDbContext context;
        public PhotoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Photo>> GetAllPhotosByProductPublisherAsync(int productPublisherId)
        {
            return await context.Photos.Where(p => p.ProductPublisherId == productPublisherId).ToListAsync();
        }

        public async Task<Photo> GetPhotoById(int id)
        {
            return await context.Photos.FindAsync(id);
        }

        public void Delete(Photo photo)
        {
            context.Photos.Remove(photo);
        }
    }
}
