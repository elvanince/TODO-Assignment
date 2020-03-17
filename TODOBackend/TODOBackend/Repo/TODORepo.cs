using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TODOBackend.Exceptions;
using TODOBackend.Model;

namespace TODOBackend.Repo
{
    public class TODORepo : ITODORepo
    {

        readonly List<TODOItemModel> toDoItems = new List<TODOItemModel>()
        {
            new TODOItemModel("1", "grocery shopping"),
            new TODOItemModel("2", "clean the kitchen")
        };

        IMapper Mapper { get; }

        public TODORepo(IMapper mapper)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public void Create(TODOItemModel e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            if (toDoItems.Any(x => x.Id == e.Id))
            {
                throw new DuplicateKeyException($"Can't create an object of a type {nameof(TODOItemModel)} with the key '{e.Id}'. The object with the same key is already exists");
            }

            if(string.IsNullOrWhiteSpace(e.Id))
               e.Id = Guid.NewGuid().ToString();
            toDoItems.Add(Mapper.Map<TODOItemModel>(e));
        }

        public void Delete(string id)
        {
            var p = toDoItems.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                throw new KeyNotFoundException($"An object of a type '{nameof(TODOItemModel)}' with the key '{id}' not found");
            }

            toDoItems.RemoveAll(x => x.Id == p.Id);
        }

        public IQueryable<TODOItemModel> Get()
        {
            return toDoItems.Select(Mapper.Map<TODOItemModel>).AsQueryable();
        }

        public void Update(TODOItemModel e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            var stored = toDoItems.FirstOrDefault(x => x.Id == e.Id);
            if (stored == null)
            {
                throw new KeyNotFoundException($"An object of a type '{nameof(TODOItemModel)}' with the key '{e.Id}' not found");
            }

            toDoItems.RemoveAll(x => x.Id == stored.Id);
            toDoItems.Add(Mapper.Map<TODOItemModel>(e));
        }

       
    }
}
