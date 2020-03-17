using System;

namespace TODOBackend.Model
{
    public class TODOItemModel : IEntity
    {

        public TODOItemModel()
        {
        }

        public TODOItemModel(string id)
        {
            Id = id;
        }
        public TODOItemModel(string id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public string Id { get; set; }
        public string Name { get; set; }

        public bool Status { get; set; }
    }
}
