using Ecom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.App.Services
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetAllPhotosByProductPublisherAsync(int productPublisherId);
        Task<Photo> GetPhotoById(int id);
        public void Delete(Photo photo);
    }
}
