namespace WebApplication1
{
    public class TodoService
    {
        private readonly List<TodoItem> _todoItems = new List<TodoItem>();
        private long _currentId = 1;

        public IEnumerable<TodoItem> GetAll() => _todoItems;

        public TodoItem GetById(long id)
        {
            return _todoItems.FirstOrDefault(x => x.Id == id);
        }

        public TodoItem Add(TodoItem newItem)
        {
            newItem.Id = _currentId++;
            _todoItems.Add(newItem);
            return newItem;
        }

        public bool Update(long id, TodoItem updatedItem)
        {
            var todoItem = _todoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem == null)
                return false;

            todoItem.Name = updatedItem.Name;
            todoItem.IsComplete = updatedItem.IsComplete;
            return true;
        }

        public bool Delete(long id)
        {
            var todoItem = _todoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem == null)
                return false;

            _todoItems.Remove(todoItem);
            return true;
        }
    }
}
