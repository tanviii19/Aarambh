using System;
using OnlineStore.Models.Database;
using OnlineStore.Services;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Data
{
    public class Seed
    {
        public void SeedData(ModelBuilder builder)
        {
            //CREATE USER ROLES
            var simpleRole = new UserRole() {Id = 1,Name = "SimpleUser"};
            var adminRole = new UserRole() {Id = 2,Name = "Administrator"};
            var moderRole = new UserRole() {Id = 3,Name = "Vendor"};

            //CREATE CATEGORIES
            var Vegetables = new Category() { Id = 1, Name = "Vegetables" };
            var Fruit = new Category() { Id = 2, Name = "Fruit" };
            var Groceries = new Category() { Id = 3, Name = "Groceries" };

            //CREATE IMAGES
            var potatos = new Image() { Id = 1, Path = "potatos.jpg" };
            var onions = new Image() { Id = 2, Path = "onions.jpg" };
            var Carrots = new Image() { Id = 3, Path = "carrots.jpg" };
            var oranges = new Image() { Id = 4, Path = "oranges.jpg" };
            var Handwash = new Image() { Id = 5, Path = "handwash.jpg" };

            //CREATE USERS
            //pasword for the user = 12345678
            //role - simple user
            var user1 = new User() {
                Id = 1,
                CreationTime = DateTime.Now,
                Name = "Vasyl",
                Surname = "Vlasiuk",
                Email="vasylvlasiuk@gmail.com",
                PasswordHash = PasswordConverter.Hash("12345678"),
                RoleId=1,
                Adress=""                
            };
            //password = qwerty12
            //role - moderator
            var user2 = new User()
            {
                Id = 2,
                CreationTime = DateTime.Now,
                Name = "John",
                Surname = "Doe",
                Email = "johndoe@gmail.com",
                PasswordHash = PasswordConverter.Hash("qwerty12"),
                RoleId = 2,
                Adress = ""
            };
            //password = 87654321
            //role = administrator
            var user3 = new User()
            {
                Id = 3,
                CreationTime = DateTime.Now,
                Name = "Ostap",
                Surname = "Bondar",
                Email = "ostepbondar@gmail.com",
                PasswordHash = PasswordConverter.Hash("87654321"),
                RoleId = 3,
                Adress = ""
            };

            //CREATE PRODUCTS
            var product1 = new Product()
            {
                Id = 1,
                CreatorUserId=3,
                CategoryId=1,
                Producer="Farmer",
                Model="Potatos",
                Price=25.00m,
                Description="Organic fresh Potatos.",
                ImageId=1,
                CreationTime=DateTime.Now,
                CommentsEnabled=true
            };
            var product2 = new Product()
            {
                Id = 2,
                CreatorUserId = 3,
                CategoryId = 1,
                Producer = "Farmer",
                Model = "Onions",
                Price = 40.00m,
                Description = "Organic fresh onions.",
                ImageId = 2,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };
            var product3 = new Product()
            {
                Id = 3,
                CreatorUserId = 3,
                CategoryId = 2,
                Producer = "Farmer",
                Model = "Carrots",
                Price = 30.00m,
                Description = "organic fresh Carrots.",
                ImageId = 3,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };
            var product4 = new Product()
            {
                Id = 4,
                CreatorUserId = 3,
                CategoryId = 2,
                Producer = "Farmer",
                Model = "Oranges",
                Price = 40.00m,
                Description = "organic fresh oranges.",
                ImageId = 4,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };
            var product5 = new Product()
            {
                Id = 5,
                CreatorUserId = 3,
                CategoryId = 3,
                Producer = "Dettol",
                Model = "Handwash",
                Price = 110.00m,
                Description = "New germicheck handwash.",
                ImageId = 5,
                CreationTime = DateTime.Now,
                CommentsEnabled = true
            };

            builder.Entity<UserRole>().HasData(adminRole, moderRole, simpleRole);
            builder.Entity<Image>().HasData(potatos, onions, Carrots, oranges, Handwash);
            builder.Entity<Category>().HasData(Vegetables, Fruit, Groceries);
            builder.Entity<User>().HasData(user1,user2,user3);
            builder.Entity<Product>().HasData(product1, product2, product3, product4, product5);

        }
    }
}
