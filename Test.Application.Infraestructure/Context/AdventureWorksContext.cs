using System;
using System.Collections.Generic;
using Console.Infrastructure.Console.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Console.Infrastructure.Context;

public partial class AdventureWorksContext : DbContext
{
    public AdventureWorksContext()
    {
    }

    public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("HumanResources")
            .UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_Employee_EmployeeID");

            entity.ToTable("Employee", tb =>
                {
                    tb.HasComment("Employee information such as salary, department, and title.");
                    tb.HasTrigger("dEmployee");
                });

            entity.HasIndex(e => e.LoginId, "AK_Employee_LoginID").IsUnique();

            entity.HasIndex(e => e.NationalIdnumber, "AK_Employee_NationalIDNumber").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_Employee_rowguid").IsUnique();

            entity.HasIndex(e => e.ManagerId, "IX_Employee_ManagerID");

            entity.Property(e => e.EmployeeId)
                .HasComment("Primary key for Employee records.")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.BirthDate)
                .HasComment("Date of birth.")
                .HasColumnType("datetime");
            entity.Property(e => e.ContactId)
                .HasComment("Identifies the employee in the Contact table. Foreign key to Contact.ContactID.")
                .HasColumnName("ContactID");
            entity.Property(e => e.CurrentFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Inactive, 1 = Active");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("M = Male, F = Female");
            entity.Property(e => e.HireDate)
                .HasComment("Employee hired on this date.")
                .HasColumnType("datetime");
            entity.Property(e => e.LoginId)
                .HasMaxLength(256)
                .HasComment("Network login.")
                .HasColumnName("LoginID");
            entity.Property(e => e.ManagerId)
                .HasComment("Manager to whom the employee is assigned. Foreign Key to Employee.M")
                .HasColumnName("ManagerID");
            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("M = Married, S = Single");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.NationalIdnumber)
                .HasMaxLength(15)
                .HasComment("Unique national identification number such as a social security number.")
                .HasColumnName("NationalIDNumber");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasColumnName("rowguid");
            entity.Property(e => e.SalariedFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining.");
            entity.Property(e => e.SickLeaveHours).HasComment("Number of available sick leave hours.");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("Work title such as Buyer or Sales Representative.");
            entity.Property(e => e.VacationHours).HasComment("Number of available vacation hours.");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasForeignKey(d => d.ManagerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
