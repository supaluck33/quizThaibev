using WebAPI.Model.BusinessModel;
using WebAPI.Model.Database;

namespace WebAPI.Interface
{
    public interface IMaster
    {
        TbPost GetPostBC(int PostId);
        List<TbComment> GetCommentBC(int PostId);
        StandardResponse InsertCommentBC(CommentReq req);
    }
}