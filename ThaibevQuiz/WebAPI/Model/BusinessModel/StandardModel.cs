using WebAPI.Model.Database;

namespace WebAPI.Model.BusinessModel
{
    public class StandardResponse
    {
        public string status { get; set; }
        public string message { get; set; }
    }

    public class CommentReq
    {
        public string? Comment { get; set; }

        public int PostId { get; set; }

        public string? CommentBy { get; set; }
    }
}
