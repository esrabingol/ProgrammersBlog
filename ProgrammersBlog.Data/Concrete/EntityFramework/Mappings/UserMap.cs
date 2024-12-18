﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
	public class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.Id);
			builder.Property(u => u.Id).ValueGeneratedOnAdd();
			builder.Property(u => u.Email).IsRequired();
			builder.Property(u => u.Email).HasMaxLength(50);
			builder.HasIndex(u => u.Email).IsUnique();
			builder.Property(u => u.UserName).HasMaxLength(20);
			builder.HasIndex(u => u.UserName).IsUnique();
			builder.Property(u => u.PasswordHash).IsRequired();
			builder.Property(u => u.PasswordHash).HasColumnName("VARBINARY(500)");
			builder.Property(u => u.Description).HasMaxLength(500);
			builder.Property(u => u.FirstName).HasMaxLength(30);
			builder.Property(u => u.LastName).IsRequired();
			builder.Property(u => u.LastName).HasMaxLength(30);
			builder.Property(u => u.Picture).IsRequired();
			builder.Property(u => u.Picture).HasMaxLength(250);
			builder.Property(u => u.Picture).HasMaxLength(250);
			builder.HasOne<Role>(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
			builder.Property(u => u.CreatedByName).IsRequired();
			builder.Property(u => u.CreatedByName).HasMaxLength(50);
			builder.Property(u => u.ModifiedByName).IsRequired();
			builder.Property(u => u.ModifiedByName).HasMaxLength(50);
			builder.Property(u => u.CreatedDate).IsRequired();
			builder.Property(u => u.ModifiedDate).IsRequired();
			builder.Property(u => u.IsActive).IsRequired();
			builder.Property(u => u.IsDeleted).IsRequired();
			builder.Property(u => u.Note).HasMaxLength(500);
			builder.ToTable("Users");

			builder.HasData(new User
			{
				Id = 1,
				RoleId = 1,
				FirstName= "Jack",
				LastName= "Flower",
				UserName="JFlower",
				Email="jack@flov.dev",
				IsActive=true,
				IsDeleted=false,
				CreatedByName ="InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName ="InitialCreate",
				ModifiedDate = DateTime.Now,
				Description ="First Admin User",
				Note="Admin User",
				PasswordHash=Encoding.ASCII.GetBytes("0192023a7bbd73250516f069df18b500"),
				Picture= "https://r.resimlink.com/qGxr54hQae.jpg",
			});
		}
	}
}
