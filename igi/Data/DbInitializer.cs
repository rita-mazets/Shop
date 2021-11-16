using igi.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace igi.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };

                await roleManager.CreateAsync(roleAdmin);
            }

            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };

                await userManager.CreateAsync(user, "123456");

                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };

                await userManager.CreateAsync(admin, "654321");

                admin = await userManager.FindByNameAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                new List<Category>
                {
                    new Category { Name = "Выпечка", Description = "Прямо из печи"},
                    
                    new Category { Name = "Гоячие напитки", Description = "Согреют в любое время года" },
                    new Category { Name = "Сезонные напитки", Description = "Помогут влюбится в любую погоду" },
                    new Category { Name = "Фруктовые десерты", Description = "Если желаете что-то легкое и полезное" },
                    new Category { Name = "Смузи", Description = "Рискуете нарваться на огромное количество витаминов" },
                    new Category { Name = "Торты", Description = "На любой вкус"},
                });
                await context.SaveChangesAsync();
            }

            if(context.Products.Count()==2)
            {
                context.Products.AddRange(
                    new List<Product>
            {
                 new Product{
                        Name = "Роллини",
                        Description="Полезное и вкусное блюдо с самыми различными начинками",
                        Image="/images/Rollini.jpg",
                        Price = 1.29f,
                        CategoryId=1,
                        Category = context.Categories.First()
                    },
                    new Product{
                        Name = "Круассан",
                        Description="Попробуй Францию",
                        Image="/images/Kruassan.jpg",
                        Price =1.95f,
                        CategoryId=1,
                        Category = context.Categories.First()

                    },
                    new Product{
                        Name = "Наполеон",
                        Image="/images/Napoleon.jpg",
                        Price =2.25f,
                        CategoryId=2,
                        Category = context.Categories.Where(p=>p.Id==6).First()
                    },
                    new Product{
                        Name = "Птичье молоко",
                        Image="/images/BoardMilk.jpg",
                        Price =2.12f,
                        CategoryId=2,
                        Category = context.Categories.Where(p=>p.Id==6).First()
                    }
            }) ;
                await context.SaveChangesAsync();
            }
        }
    }
}
