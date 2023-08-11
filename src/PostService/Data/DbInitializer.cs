using Microsoft.EntityFrameworkCore;
using PostService.Data;
using PostService.Entities;

namespace PostService;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<DataContext>());
    }

    private static void SeedData(DataContext context)
    {
        context.Database.Migrate();

        if (context.Posts.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        var posts = new List<Post>()
        {
            new Post
            {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                Title = "Title",
                Content = "Content",
                ImageUrl = "ImageUrl",
                Comments = new List<Comment>()
                {
                    new Comment
                    {
                        Content = "Content",
                    },
                    new Comment
                    {
                        Content = "Content2",
                    }                        
                }
            },
            new Post
            {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0d"),
                Title = "Title2",
                Content = "Content2",
                ImageUrl = "ImageUrl2",
                Comments = new List<Comment>()
                {
                    new Comment
                    {
                        Content = "Content",
                    },
                    new Comment
                    {
                        Content = "Content2",
                    }                        
                }
            },
            new Post
            {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0e"),
                Title = "Title3",
                Content = "Content3",
                ImageUrl = "ImageUrl3",
                Comments = new List<Comment>()
                {
                    new Comment
                    {
                        Content = "Content",
                    },
                    new Comment
                    {
                        Content = "Content2",
                    }                        
                }
            }
        };

        context.AddRange(posts);

        context.SaveChanges();
    }
}