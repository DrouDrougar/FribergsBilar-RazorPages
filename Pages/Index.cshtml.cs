using FribergsBilar_RazorPages.Data.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergsBilar_RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<string> GetSessionInfo()
        {

            List<string> sessionInfo = new List<string>();
            if(string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUserEmail)))
            {
                HttpContext.Session.SetString(SessionVariables.SessionKeyUserEmail, "Current User");
                HttpContext.Session.SetString(SessionVariables.SessionKeyUserId, Guid.NewGuid().ToString());
            }
            var userEmail = HttpContext.Session.GetString(SessionVariables.SessionKeyUserEmail);
            var userId = HttpContext.Session.GetString(SessionVariables.SessionKeyUserId);

            sessionInfo.Add(userEmail);
            sessionInfo.Add(userId);
            return sessionInfo;
        }
        public void OnGet()
        {
            ViewData["AdminCookies"] = Request.Cookies["AdminCookies"];
            ViewData["UserCookies"] = Request.Cookies["UserCookies"];
        }
    }
}
