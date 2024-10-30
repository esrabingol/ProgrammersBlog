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
	public class ArticleMap : IEntityTypeConfiguration<Article>
	{
		public void Configure(EntityTypeBuilder<Article> builder)
		{
			builder.HasKey(a => a.Id);
			builder.Property(a => a.Id).ValueGeneratedOnAdd();
			builder.Property(a => a.Title).HasMaxLength(100);
			builder.Property(a => a.Title).IsRequired(true);
			builder.Property(a => a.Content).IsRequired();
			builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
			builder.Property(a => a.Date).IsRequired();
			builder.Property(a =>a.SeoAuthor).IsRequired();
			builder.Property(a => a.SeoAuthor).HasMaxLength(50);
			builder.Property(a => a.SeoDescription).HasMaxLength(150);
			builder.Property(a => a.SeoDescription).IsRequired();
			builder.Property(a => a.SeaTags).IsRequired();
			builder.Property(a => a.SeaTags).HasMaxLength(70);
			builder.Property(a => a.ViewsCount).IsRequired();
			builder.Property(a => a.CommentCount).IsRequired();
			builder.Property(a => a.Thumbnail).IsRequired();
			builder.Property(a => a.Thumbnail).HasMaxLength(250);
			builder.Property(a => a.CreatedByName).IsRequired();
			builder.Property(a => a.CreatedByName).HasMaxLength(50);
			builder.Property(a => a.ModifiedByName).IsRequired();
			builder.Property(a => a.ModifiedByName).HasMaxLength(50);
			builder.Property(a => a.CreatedDate).IsRequired();
			builder.Property(a => a.ModifiedDate).IsRequired();
			builder.Property(a => a.IsActive).IsRequired();
			builder.Property(a => a.IsDeleted).IsRequired();
			builder.Property(a => a.Note).HasMaxLength(500);
			builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
			builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);

			builder.ToTable("Articles");

			builder.HasData(
				new Article
				{
					Id = 1,
					CategoryId = 1,
					Title="C# 9.0 and .Net news",
					Content= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
					"Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
					"when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
					"It has survived not only five centuries, but also the leap into electronic typesetting," +
					" remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, " +
					"and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
					Thumbnail="Default.jpg",
					SeoDescription= "C# 9.0 and .Net news",
					SeaTags ="C#,C# 9, .Net Core",
					SeoAuthor="Jack Flower",
					Date =DateTime.Now,
					IsActive = true,
					IsDeleted = false,
					CreatedByName = "InitialCreate",
					CreatedDate = DateTime.Now,
					ModifiedByName = "InitialCreate",
					ModifiedDate = DateTime.Now,
					Note = "C# 9.0 and .Net news",
					UserId =1,
					ViewsCount= 100,
					CommentCount=1
					
				},
				new Article
				{
					Id = 2,
					CategoryId = 2,
					Title = "C# 11.0 and .Net news",
					Content = "There are many variations of passages of Lorem Ipsum available, " +
					"but the majority have suffered alteration in some form, by injected humour," +
					" or randomised words which don't look even slightly believable." +
					" If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything " +
					"embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to" +
					" repeat predefined chunks as necessary, making this the first true generator on the Internet." +
					" It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, " +
					"to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free " +
					"from repetition, injected humour, or non-characteristic words etc.",
					Thumbnail = "Default.jpg",
					SeoDescription = "C# 11.0 and .Net news",
					SeaTags = "C#,C# 11, .Net Framework,Asp.Net",
					SeoAuthor = "Jack Flower",
					Date = DateTime.Now,
					IsActive = true,
					IsDeleted = false,
					CreatedByName = "InitialCreate",
					CreatedDate = DateTime.Now,
					ModifiedByName = "InitialCreate",
					ModifiedDate = DateTime.Now,
					Note = "C# 11.0 and .Net news",
					UserId = 1,
					ViewsCount = 200,
					CommentCount = 1
				},
				new Article
				{
					Id = 3,
					CategoryId = 3,
					Title = "JavaScript ES2022 and .Net news",
					Content = "There are many variations of passages of Lorem Ipsum available, " +
					"but the majority have suffered alteration in some form, by injected humour," +
					" or randomised words which don't look even slightly believable.",
					Thumbnail = "Default.jpg",
					SeoDescription =" JavaScript ES2022 and.Net news",
					SeaTags = "JavaScript, .Net Framework,Asp.Net",
					SeoAuthor = "Jack Flower",
					Date = DateTime.Now,
					IsActive = true,
					IsDeleted = false,
					CreatedByName = "InitialCreate",
					CreatedDate = DateTime.Now,
					ModifiedByName = "InitialCreate",
					ModifiedDate = DateTime.Now,
					Note = "JavaScript ES2022 and .Net news",
					UserId = 1,
					ViewsCount = 300,
					CommentCount = 1
				}
				);

		}
	}
}
