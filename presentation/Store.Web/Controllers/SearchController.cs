using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBookRepository bookRepository;
        public SearchController(IBookRepository bookReporsitory)
        {
            this.bookRepository = bookReporsitory;
        }
        public IActionResult Index(string query)
        {
            var books = bookRepository.GetAllByTitle(query);
            return View(books);
        }
    }
}
