using RobloxShop.Entities;
using RobloxShop.Repository.Interfaces;
using RobloxShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Services
{
    public class TagService : ITagService
    {

        private readonly ITagRepository _tagRepository;

        public Tag Add(Tag entity)
        {
            return _tagRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _tagRepository.Delete(id);
        }

        public Tag Get(int id)
        {
            return _tagRepository.Get(id);
        }

        public List<Tag> GetAll()
        {
            return _tagRepository.GetAll();
        }

        public Tag Update(Tag entity)
        {
            return _tagRepository.Update(entity);
        }
    }
}
