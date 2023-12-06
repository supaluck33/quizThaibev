

using WebAPI.Interface;
using WebAPI.Model.BusinessModel;
using WebAPI.Model.Database;

namespace WebAPI.Business
{
    public class MasterBC : IMaster
    {
        private readonly IConfiguration configuration;
        private string connectionString;
        public MasterBC(IConfiguration config)
        {
            configuration = config;
        }

        public List<TbComment> GetCommentBC()
        {
            List<TbComment> res = new List<TbComment>();
            try
            {
                using (var _db = new DbquizThaibevContext())
                {
                    res = _db.TbComments.ToList();
                    if (res == null)
                        throw new Exception(" find on TbComments");
                    return res;
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public List<TbPost> GetPostBC()
        {
            List<TbPost> res = new List<TbPost>();
            try
            {
                using (var _db = new DbquizThaibevContext())
                {
                    res = _db.TbPosts.ToList();
                    if (res == null)
                        throw new Exception(" find on TbPosts");
                    return res;
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public StandardResponse InsertComment(TbComment data)
        {
            throw new NotImplementedException();
        }


        public StandardResponse InsertPost(TbPost data)
        {
            throw new NotImplementedException();
        }
    }
}
