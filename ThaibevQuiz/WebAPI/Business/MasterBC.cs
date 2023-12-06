

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

        public List<TbComment> GetCommentBC(int PostId)
        {
            List<TbComment> res = new List<TbComment>();
            try
            {
                using (var _db = new DbquizThaibevContext())
                {
                    res = _db.TbComments.Where(x => x.PostId == PostId).ToList();
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

        public TbPost GetPostBC(int PostId)
        {
            TbPost res = new TbPost();
            try
            {
                using (var _db = new DbquizThaibevContext())
                {
                    res = _db.TbPosts.Where(x => x.PostId == PostId).FirstOrDefault();
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

        public StandardResponse InsertCommentBC(CommentReq data)
        {
            TbComment dataInsert = new TbComment();
            dataInsert.Comment = data.Comment;
            dataInsert.PostId = data.PostId;
            dataInsert.CommentBy = data.CommentBy;
            StandardResponse res = new StandardResponse();
            try
            {
                using (var _db = new DbquizThaibevContext())
                {
                    _db.TbComments.Add(dataInsert);
                    _db.SaveChanges();

                    res.status = "success";
                    res.message = "success";

                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
