using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Models;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LAPTOP-OHON0AP6; Database=LibraryDB; Trusted_Connection=true; Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("books_pk");

            entity.ToTable("books");

            entity.Property(e => e.BookId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("book_id");
            entity.Property(e => e.Author)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("author");
            entity.Property(e => e.PublicationDate)
                .HasColumnType("date")
                .HasColumnName("publication_date");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
