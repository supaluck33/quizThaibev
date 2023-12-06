using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface;
using WebAPI.Model.Database;
using WebAPI.Model.BusinessModel;

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
        public async Task<TbPost> GetPosts(int PostId)
        {
            try
            {
                TbPost data = _master.GetPostBC(PostId);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("GetComments")]
        public async Task<List<TbComment>> GetComment(int PostId)
        {
            try
            {
                List<TbComment> data = _master.GetCommentBC(PostId);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertComment")]
        public async Task<StandardResponse> InsertComment(CommentReq req)
        {
            try
            {
                StandardResponse data = _master.InsertCommentBC(req);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
