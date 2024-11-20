using LinkExchange.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LinkExchange.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // �������� ������� ������������� � ���� ������
            if (!DataBase.Instance.GetLinksList().Any()) // ���� ��� ������ � ����
            {
                // �������� �������������
                var userArtem = new UserModel("artem", "123" ,DateTime.Now);
                var userIgnat = new UserModel("ignat", "321",DateTime.Now);
                var userRoma = new UserModel("roma", "231", DateTime.Now);

                var linkArtem = new LinkModel("https://test.com", "description", 15, DateTime.Now, userArtem);
                var linkIgnat = new LinkModel("http://google.ru", "description", 20, DateTime.Now, userIgnat);
                var linkRoma = new LinkModel("https://x.com", "description", 30, DateTime.Now, userRoma);

                // ���������� ������������� � ���� ������
                DataBase.Instance.AddUser(userArtem);
                DataBase.Instance.AddUser(userIgnat);
                DataBase.Instance.AddUser(userRoma);
                //userArtem.Links.Add(linkArtem);
                //userIgnat.Links.Add(linkIgnat);
                //userRoma.Links.Add(linkRoma);
                // �������� � ���������� ������
                DataBase.Instance.AddLink(linkArtem);
                DataBase.Instance.AddLink(linkIgnat);
                DataBase.Instance.AddLink(linkRoma);
            }

            // ��������� ������ ������ �� ���� ������
            var links = DataBase.Instance.GetLinksList();

            // �������� ������ ������ � �������������
            return View(links);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
