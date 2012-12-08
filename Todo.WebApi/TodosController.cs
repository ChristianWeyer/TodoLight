using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Todo.Base;
using Todo.Contracts;
using Todo.Entities;

namespace Todo.WebApi
{
    public class TodosController : ApiController
    {
        private IGenericRepository<TodoItem> repository;

        public TodosController(IGenericRepository<TodoItem> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<TodoItemDto> Get()
        {
            return repository.GetAll().Map();
        }

        public TodoItemDto Get(int id)
        {
            return repository.FindBy(t => t.Id == id).FirstOrDefault().Map();
        }

        public TodoItemDto Post(TodoItemDto item)
        {
            var newItem = repository.Insert(item.Map());

            return newItem.Map();
        }

        public TodoItemDto Put(TodoItemDto item)
        {
            var updatedItem = repository.Update(item.Map());

            return updatedItem.Map();
        }

        public void Delete(int id)
        {
            repository.Delete(new TodoItem { Id = id });
        }
    }
}