using System.Linq;
using System.Web.Http;
using System.Web.Http.Data.EntityFramework;

namespace ServiceBlazerMVC4.Controllers
{
    public partial class ServiceBlazerMVC4Controller : DbDataController<ServiceBlazerMVC4.Models.ServiceBlazerMVC4Context>
    {
        public IQueryable<ServiceBlazerMVC4.Models.TodoItem> GetTodoItems() {
            return DbContext.TodoItems.OrderBy(t => t.TodoItemId);
        }

        public void InsertTodoItem(ServiceBlazerMVC4.Models.TodoItem entity) {
            InsertEntity(entity);
        }

        public void UpdateTodoItem(ServiceBlazerMVC4.Models.TodoItem entity) {
            UpdateEntity(entity);
        }

        public void DeleteTodoItem(ServiceBlazerMVC4.Models.TodoItem entity) {
            DeleteEntity(entity);
        }
    }
}
