namespace DomainLayer.Models
{
    public class Reply : CommentBaseEntity
    {
        public Reply()
        {

        }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }


    }
}
