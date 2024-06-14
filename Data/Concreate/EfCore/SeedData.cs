using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concreate.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
           var context= app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>(); // "BlogContext" nesnesi oluşturulur
            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any()) // uygulanmayı bekleyen herhangi bir migration var mı kontrol eder
                {
                    context.Database.Migrate();
                }

                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(  //AddRange metodu, tek bir işlemde birden fazla nesneyi koleksiyona eklemek için kullanılır. 
                        new Tag{ Text="web programlama", Url="web-programlama", Color=TagColors.warning},
                        new Tag{ Text="backend", Url="backend",Color=TagColors.info},
                        new Tag{ Text="frontend", Url="frontend",Color=TagColors.danger},
                        new Tag{ Text="fullstack", Url="fullstack",Color=TagColors.secondary},
                        new Tag{ Text="php", Url="php",Color=TagColors.success}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User {UserName="bestamigocer",Name="Bestami Göçer",Email="best@gmail.com",Password="123456",Image="01.jpg"},
                        new User {UserName="eminegocer",Name="Emine Göçer",Email="emine@gmail.com",Password="123456",Image="02.jpg"}
                    );
                    context.SaveChanges();
                }

                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post{
                            Title="Asp.Net core",
                            Content="Asp.net Core Dersleri",
                            Description="Asp.net Core Dersleri",
                            Url="aspnet-core",
                            IsActive=true,
                            Image="asp.net.jpeg",
                            PublishedOn=DateTime.Now.AddDays(-10),
                            Tags=context.Tags.Take(3).ToList(),
                            UserId=1,
                            Comments=new List<Comment>
                            {
                                new Comment{Text="iyi bir kurs", PublishedOn=DateTime.Now.AddDays(-20),UserId=1},
                                new Comment{Text="çok faydalı bir kurs", PublishedOn=DateTime.Now.AddDays(-10),UserId=2}
                            }
                        } ,
                        new Post{
                            Title="Php",
                            Content="Php Core Dersleri",
                            Description="Php Core Dersleri",
                            Url="php",
                            IsActive=true,
                            Image="php.jpeg",
                            PublishedOn=DateTime.Now.AddDays(-20),
                            Tags=context.Tags.Take(2).ToList(),
                            UserId=1
                        } ,
                        new Post{
                            Title="Django",
                            Content="Django Dersleri",
                            Description="Django Dersleri",
                            Url="django",
                            IsActive=true,
                            Image="django.jpeg",
                            PublishedOn=DateTime.Now.AddDays(-30),
                            Tags=context.Tags.Take(4).ToList(),
                            UserId=2
                        } ,
                          new Post{
                            Title="React Dersleri",
                            Content="React Dersleri",
                            Description="React Dersleri",
                            Url="react-dersleri",
                            IsActive=true,
                            Image="react.jpeg",
                            PublishedOn=DateTime.Now.AddDays(-40),
                            Tags=context.Tags.Take(4).ToList(),
                            UserId=2
                        } ,
                          new Post{
                            Title="Angular",
                            Content="Angular Dersleri",
                            Description="Angular Dersleri",
                            Url="angular",
                            IsActive=true,
                            Image="angular.jpeg",
                            PublishedOn=DateTime.Now.AddDays(-50),
                            Tags=context.Tags.Take(4).ToList(),
                            UserId=2
                        },
                          new Post{
                            Title="Web Tasarım",
                            Content="Web Tasarım Dersleri",
                            Description="Web Tasarım Dersleri",
                            Url="web-tasarim",
                            IsActive=true,
                            Image="we.jpeg",
                            PublishedOn=DateTime.Now.AddDays(-60),
                            Tags=context.Tags.Take(4).ToList(),
                            UserId=2
                        }
                        
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}