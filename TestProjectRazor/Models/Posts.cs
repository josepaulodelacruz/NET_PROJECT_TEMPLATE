namespace TestProjectRazor.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; } 
    }
}
