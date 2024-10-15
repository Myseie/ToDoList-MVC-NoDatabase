using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoItem> TodoItems = new List<TodoItem>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(TodoItems);
        }

        [HttpPost]
        public IActionResult AddItem(string newItem, string priority)
        {
            if(!string.IsNullOrEmpty(newItem))
            {
                ViewBag.Error = "Lämna inte fältet tomt";
                TodoItems.Add(new TodoItem
                {
                    Text = newItem,
                    Priority = priority
                });
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditItem(int index)
        {
            if(index >= 0 && index < TodoItems.Count)
            {
                TodoItem currentItem = TodoItems[index];
                ViewBag.Index = index;
                return View("Edit", currentItem);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult UpdateItem(int index, string updatedText, string updatedPriority)
        {
            if(!string.IsNullOrEmpty (updatedText) && index >= 0 && index < TodoItems.Count)
            {
                TodoItems[index].Text = updatedText;
                TodoItems[index].Priority = updatedPriority;

            }
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult RemoveItem(int index)
        {
            if (index >= 0 && index < TodoItems.Count)
            {
                TodoItems.RemoveAt(index);
            }
            return RedirectToAction("Index");
        } 
    }
}
