using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PaginationMVC1.Models;

public partial class AdventureWorksContext : DbContext
{
    public AdventureWorksContext()
    {
    }

    public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=POLLY\\SQLEXPRESS;Database=AdventureWorks2025;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Person_BusinessEntityID");

            entity.ToTable("Person", "Person", tb =>
                {
                    tb.HasComment("Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.");
                    tb.HasTrigger("iuPerson");
                });

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasComment("Primary key for Person records.");
            entity.Property(e => e.AdditionalContactInfo).HasComment("Additional contact information about the person stored in xml format. ");
            entity.Property(e => e.Demographics).HasComment("Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.");
            entity.Property(e => e.EmailPromotion).HasComment("0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners. ");
            entity.Property(e => e.FirstName).HasComment("First name of the person.");
            entity.Property(e => e.LastName).HasComment("Last name of the person.");
            entity.Property(e => e.MiddleName).HasComment("Middle name or middle initial of the person.");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Date and time the record was last updated.")
                .HasDefaultValueSql("(getdate())", "DF_Person_ModifiedDate");
            entity.Property(e => e.NameStyle).HasComment("0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.");
            entity.Property(e => e.PersonType)
                .IsFixedLength()
                .HasComment("Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact");
            entity.Property(e => e.Rowguid)
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasDefaultValueSql("(newid())", "DF_Person_rowguid");
            entity.Property(e => e.Suffix).HasComment("Surname suffix. For example, Sr. or Jr.");
            entity.Property(e => e.Title).HasComment("A courtesy title. For example, Mr. or Ms.");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
