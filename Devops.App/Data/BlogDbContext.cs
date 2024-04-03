using Devops.App.Models.BlogModels;

namespace Devops.App.Data
{
    public class BlogDbContext
    {
        public List<BlogModel> Blogs = new List<BlogModel>{new BlogModel
            {
            Title = "Wow Car",
            Category = "Vehicles",
            Content = "Lamborghini Launched it's new car",
            Description = "Lamborghini launched another stylish car named 'Lamborghini Urus' this day, the car comes with many features and company claims it is the best car in SUV segment",
            Author = "Harish",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7TBTTzWM5ndcMhEDRDCo1LCToGrGOzfmPhUz2jmWHoA&s"
            },
           new BlogModel
           {
            Title = "Ferrari",
            Category = "Vehicles",
            Content = "Ferrari Launched it's new car named 'Ferrari Purosangue'",
            Description = "Ferrari launched an SUV named 'Purosangue' and it costs around 8.00 crore in India, this car can be the best competitor of Lamborghini Urus",
            Author = "Ramesh",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkMna14MswKF6wNIxAq5mbp2qUlf-Yk1ZL7A&s"
           }
       };

        public void AddBlog(BlogModel blogmodel)
        {
            Blogs.Add(blogmodel);
        }

        public List<BlogModel> GetBlogs()
        {
            return Blogs;
        }
    }
}
