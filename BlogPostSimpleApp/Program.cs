using BlogPostSimpleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();
        if (!context.BlogTypes.Any())
        {
            var type1 = new BlogType { Name = "Tech", Description = "Tech Blog", Status = 1 };
            var type2 = new BlogType { Name = "food", Description = "food Blog", Status = 2 };

            context.BlogTypes.AddRange(type1, type2);
            context.SaveChanges();
        }
        if (!context.PostTypes.Any())
        {
            var type1 = new PostType { Name = "Animal", Description = "Animal Blog", Status = 1 };
            var type2 = new PostType { Name = "Cars", Description = "Cars Blog", Status = 2 };

            context.PostTypes.AddRange(type1, type2);
            context.SaveChanges();
        }
        if (!context.Blogs.Any())
        {
            var type1 = new Blog { Url = "https://myblog.com", isPublic = true, BlogTypeId = 1 };
            var type2 = new Blog { Url = "https://myfoodblog.com", isPublic = true, BlogTypeId = 2 };

            context.Blogs.AddRange(type1, type2);
            context.SaveChanges();
        }
        if (!context.Posts.Any())
        {
            var type1 = new Post { Title = "Maths", Content = "Math Posts", BlogId = 1, PostTypeId = 1, UserId = 1 };
            var type2 = new Post { Title = "Games", Content = "Game Posts", BlogId = 2, PostTypeId = 2, UserId = 2 };

            context.Posts.AddRange(type1, type2);
            context.SaveChanges();
        }



        var blogTypes = new List<BlogType>

        {
            new BlogType {Name = "Corporate", Status = 1, Description = "Corporate blog"},
            new BlogType {Name = "Personal", Status= 2, Description = "Personal blog"},
            new BlogType {Name = "Private", Status= 3, Description = "Private blog"},
        };

        var blogs = new List<Blog>
        {
            new Blog {Url = "www.corporateblog.com", BlogType = blogTypes[0]},
            new Blog {Url = "www.personalblog.com", BlogType = blogTypes[1]},
            new Blog {Url = "www.privateblog.com", BlogType=blogTypes[2]},
        };

        context.BlogTypes.AddRange(blogTypes);
        context.Blogs.AddRange(blogs);

        context.SaveChanges();

        //var users = new List<User>
        //{
        //    new User { Name = "Tanziya", Email = "tanziya@gmail.com", PhoneNumber = "9845329852" },
        //    new User { Name = "Nupur", Email = "nupur@gmail.com", PhoneNumber = "9065489654" },
        //    new User { Name = "Suzan", Email = "suzan@gmail.com", PhoneNumber = "9876086543" }
        //};

        //context.users.AddRange(users);
        //context.SaveChanges();

        ////Add a Blog
        //Console.Write("Enter blog URL: ");
        //var url = Console.ReadLine();
        //var blog = new Blog { Url = url };
        //context.Blogs.Add(blog);
        //context.SaveChanges();

        //// Add a Post using one of the Users
        //var user = context.users.First();
        //var post = new Post
        //{
        //    Title = "Hello EF Core",
        //    Content = "This is my first post!",
        //    BlogId = blog.BlogId,
        //    UserId = user.UserId,
        //    PostTypeId = 1
        //};

        //context.Posts.Add(post);
        //context.SaveChanges();

        // Display all blogs and their posts with authors
        //var blogs = context.Blogs
        //                   .Include(b => b.Posts)
        //                   .ThenInclude(p => p.User)
        //                   .ToList();

        //foreach (var b in blogs)
        //{
        //    Console.WriteLine($"Blog: {b.Url}");
        //    foreach (var p in b.Posts)
        //    {
        //        Console.WriteLine($"  Post: {p.Title} - {p.Content} (by {p.User?.Name ?? "Unknown"})");
        //    }
        //}

        //using var context = new AppDbContext();


        //// Clear existing data
        //context.Posts.RemoveRange(context.Posts);
        //context.Blogs.RemoveRange(context.Blogs);
        //context.BlogTypes.RemoveRange(context.BlogTypes);
        //context.PostTypes.RemoveRange(context.PostTypes);
        //context.users.RemoveRange(context.users);
        //context.SaveChanges();

        //// Reset identity counters
        //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('BlogType', RESEED, 0)"); // because table name is BlogType
        //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Blogs', RESEED, 0)");
        //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Posts', RESEED, 0)");
        //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('PostTypes', RESEED, 0)"); // because table name is PostType
        //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Users', RESEED, 0)");


    }
}



