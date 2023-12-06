using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface;
using WebAPI.Model.Database;

namespace WebAPI.Controllers
{
    [Route("api/Master")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly ILogger<ControllerBase> _log;
        readonly IConfiguration _configuration;
        IMaster _master;

        static IConfiguration conf = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
        public static string PathUploadTemplate = conf["AppSettings:PATH_UPLOAD_FILE"].ToString();

        public MasterController(ILogger<ControllerBase> logger, IConfiguration configuration, IMaster master)
        {
            _log = logger;
            _configuration = configuration;
            _master = master;
        }

        [HttpPost]
        [Route("GetFiles")]
        public async Task<List<TbPost>> GetPosts()
        {
            try
            {
                List<TbPost> data = _master.GetPostBC();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
