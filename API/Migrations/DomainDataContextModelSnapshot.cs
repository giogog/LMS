﻿// <auto-generated />
using System;
using Infrastructure.DataConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DomainDataContext))]
    partial class DomainDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculty", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LectureCapacity")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lecture", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("PersonType").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = -2,
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = -3,
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        },
                        new
                        {
                            Id = -4,
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        });
                });

            modelBuilder.Entity("Domain.Models.Seminar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SeminarCapacity")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Seminar", (string)null);
                });

            modelBuilder.Entity("Domain.Models.StudentEnrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Grades")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Grades");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPassed")
                        .HasColumnType("bit");

                    b.Property<int?>("LectureId")
                        .HasColumnType("int");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("SeminarId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.HasIndex("SeminarId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentEnrollment", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<int>("MaxLectures")
                        .HasColumnType("int");

                    b.Property<int>("MaxSeminars")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("gradeTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("gradeTypes");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("Domain.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreditsToGraduate")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SemesterPayment")
                        .HasColumnType("int");

                    b.Property<int>("SubjectPayment")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("University", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreditsToGraduate = 240,
                            Name = "Example",
                            SemesterPayment = 1125,
                            SubjectPayment = 200
                        });
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Student", b =>
                {
                    b.HasBaseType("Domain.Models.Person");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("CurrentSemester")
                        .HasColumnType("int");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<double>("Grant")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal?>("SemesterPay")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("TotalCredits")
                        .HasColumnType("int");

                    b.Property<int>("YearlyAvailableCredits")
                        .HasColumnType("int");

                    b.HasIndex("FacultyId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Domain.Models.Teacher", b =>
                {
                    b.HasBaseType("Domain.Models.Person");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("Domain.Models.Faculty", b =>
                {
                    b.HasOne("Domain.Models.University", "University")
                        .WithMany("Faculties")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("Domain.Models.Lecture", b =>
                {
                    b.HasOne("Domain.Models.Subject", "Subject")
                        .WithMany("Lectures")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Teacher", "Teacher")
                        .WithMany("Lectures")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.Props.ScheduleProperty", "Schedule", b1 =>
                        {
                            b1.Property<int>("LectureId")
                                .HasColumnType("int");

                            b1.Property<int>("DayOfWeek")
                                .HasColumnType("int");

                            b1.Property<string>("EndTime")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StartTime")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LectureId");

                            b1.ToTable("Lecture");

                            b1.WithOwner()
                                .HasForeignKey("LectureId");
                        });

                    b.Navigation("Schedule")
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Domain.Models.Person", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithOne("Person")
                        .HasForeignKey("Domain.Models.Person", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Seminar", b =>
                {
                    b.HasOne("Domain.Models.Subject", "Subject")
                        .WithMany("Seminars")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Models.Teacher", "Teacher")
                        .WithMany("Seminars")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.Props.ScheduleProperty", "Schedule", b1 =>
                        {
                            b1.Property<int>("SeminarId")
                                .HasColumnType("int");

                            b1.Property<int>("DayOfWeek")
                                .HasColumnType("int");

                            b1.Property<string>("EndTime")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StartTime")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SeminarId");

                            b1.ToTable("Seminar");

                            b1.WithOwner()
                                .HasForeignKey("SeminarId");
                        });

                    b.Navigation("Schedule")
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Domain.Models.StudentEnrollment", b =>
                {
                    b.HasOne("Domain.Models.Lecture", "Lecture")
                        .WithMany("StudentEnrollments")
                        .HasForeignKey("LectureId");

                    b.HasOne("Domain.Models.Seminar", "Seminar")
                        .WithMany("StudentEnrollments")
                        .HasForeignKey("SeminarId");

                    b.HasOne("Domain.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecture");

                    b.Navigation("Seminar");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.Models.Subject", b =>
                {
                    b.HasOne("Domain.Models.Faculty", "Faculty")
                        .WithMany("Subjects")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Domain.Models.UserRole", b =>
                {
                    b.HasOne("Domain.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Domain.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Student", b =>
                {
                    b.HasOne("Domain.Models.Faculty", "Faculty")
                        .WithMany("Students")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Domain.Models.Faculty", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Domain.Models.Lecture", b =>
                {
                    b.Navigation("StudentEnrollments");
                });

            modelBuilder.Entity("Domain.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Models.Seminar", b =>
                {
                    b.Navigation("StudentEnrollments");
                });

            modelBuilder.Entity("Domain.Models.Subject", b =>
                {
                    b.Navigation("Lectures");

                    b.Navigation("Seminars");
                });

            modelBuilder.Entity("Domain.Models.University", b =>
                {
                    b.Navigation("Faculties");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("Person")
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Domain.Models.Student", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Domain.Models.Teacher", b =>
                {
                    b.Navigation("Lectures");

                    b.Navigation("Seminars");
                });
#pragma warning restore 612, 618
        }
    }
}
