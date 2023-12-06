using WebAPI.Model.BusinessModel;
using WebAPI.Model.Database;

namespace WebAPI.Interface
{
    public interface IMaster
    {
        StandardResponse InsertComment(TbComment data);
        List<TbPost> GetPostBC();
        List<TbComment> GetCommentBC();

    }
}