using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using contacts_lib.models.entities;
using Microsoft.Extensions.Configuration;
namespace contacts_lib.dal;

public partial class ContactsDevContext : DbContext
{
    private readonly IConfigurationRoot _appSettings;
    public ContactsDevContext()
    {
        _appSettings = new ConfigurationBuilder().AddUserSecrets<ContactsDevContext>().Build();
    }

    public ContactsDevContext(DbContextOptions<ContactsDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookLine> BookLines { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_appSettings["connection_string"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__490D1AE12BC01E41");

            entity.ToTable("Book");

            entity.HasIndex(e => e.BookName, "UQ__Book__AFEBF55110BC22EC").IsUnique();

            entity.Property(e => e.BookId)
                .HasMaxLength(32)
                .HasColumnName("book_id");
            entity.Property(e => e.BookName)
                .HasMaxLength(200)
                .HasColumnName("book_name");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateUpdated)
                .HasColumnType("datetime")
                .HasColumnName("date_updated");
            entity.Property(e => e.UserId)
                .HasMaxLength(32)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Books)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_User");
        });

        modelBuilder.Entity<BookLine>(entity =>
        {
            entity.HasKey(e => e.LineId).HasName("PK__BookLine__F5AE5F62B21EBD76");

            entity.ToTable("BookLine");

            entity.Property(e => e.LineId).HasColumnName("line_id");
            entity.Property(e => e.BookId)
                .HasMaxLength(32)
                .HasColumnName("book_id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");

            entity.HasOne(d => d.Book).WithMany(p => p.BookLines)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_Contact");

            entity.HasOne(d => d.Contact).WithMany(p => p.BookLines)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookline_Contact");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__contact__024E7A86E4E4E7B2");

            entity.ToTable("contact");

            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(200)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .HasColumnName("contact_name");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(10)
                .HasColumnName("contact_phone");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateUpdated)
                .HasColumnType("datetime")
                .HasColumnName("date_updated");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USER__B9BE370F9D425D0A");

            entity.ToTable("USER");

            entity.HasIndex(e => e.UserName, "UQ__USER__7C9273C483F366B2").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__USER__AB6E6164FD904A88").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(32)
                .HasColumnName("user_id");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateUpdated)
                .HasColumnType("datetime")
                .HasColumnName("date_updated");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("last_login");
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .IsFixedLength()
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Salt).HasColumnName("salt");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
