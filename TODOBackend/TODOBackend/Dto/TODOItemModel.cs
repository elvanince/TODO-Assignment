namespace TODOBackend.Dto
{
    public class TODOItemModel
    {

        /// <summary>
        /// ToDoItem id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// ToDo Item name
        /// </summary>
        /// <example>lime</example>
        public string Name { get; set; }

        /// <summary>
        /// ToDo Item status
        /// </summary>
        /// <example>lime</example>
        public bool Status { get; set; }
    }
}
