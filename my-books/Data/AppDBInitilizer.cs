using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDBInitilizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "First Book Title",
                        Description = "First book description",
                        IsRead = true,
                        DateRead = DateTime.UtcNow.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.UtcNow
                    },
                    new Book()
                    {
                        Title = "Second Book Title",
                        Description = "Second book description",
                        IsRead = false,
                        Genre = "Biography",
                        CoverUrl = "https...",
                        DateAdded = DateTime.UtcNow
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
