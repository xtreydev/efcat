﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sample.Model.Configuration;

#nullable disable

namespace Sample.Model.Migrations
{
    [DbContext(typeof(TestDbContext))]
    partial class TestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Sample.Model.Entity.AdvancedEmailVerificationCode", b =>
                {
                    b.Property<Guid>("CODE_ID")
                        .HasColumnType("char(36)");

                    b.Property<int>("Random")
                        .HasColumnType("int(5)")
                        .HasColumnName("RANDOM");

                    b.HasKey("CODE_ID", "Random");

                    b.ToTable("ADVANCED_EMAIL_CODES", (string)null);
                });

            modelBuilder.Entity("Sample.Model.Entity.BadPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.HasKey("Id");

                    b.ToTable("BAD_PEOPLE", (string)null);
                });

            modelBuilder.Entity("Sample.Model.Entity.Code", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("ID");

                    b.Property<string>("DISCRIMINATOR")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ExpiresAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("EXPIRES_AT");

                    b.Property<int?>("USER_ID")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("VALUE");

                    b.HasKey("Id");

                    b.HasIndex("USER_ID");

                    b.ToTable("USER_HAS_CODES", (string)null);

                    b.HasDiscriminator<string>("DISCRIMINATOR").HasValue("Code");
                });

            modelBuilder.Entity("Sample.Model.Entity.NicePerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasColumnName("LAST_NAME");

                    b.HasKey("Id");

                    b.ToTable("NICE_PEOPLE", (string)null);
                });

            modelBuilder.Entity("Sample.Model.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<decimal>("Balance")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("BALANCE");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(16)")
                        .HasColumnName("NAME");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasColumnName("PASSWORD");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("USERS", (string)null);
                });

            modelBuilder.Entity("Sample.Model.Entity.ZMail", b =>
                {
                    b.Property<int>("USER_ID")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasColumnName("VALUE");

                    b.HasKey("USER_ID");

                    b.ToTable("ZMAILS", (string)null);
                });

            modelBuilder.Entity("Sample.Model.Entity.EmailVerificationCode", b =>
                {
                    b.HasBaseType("Sample.Model.Entity.Code");

                    b.HasDiscriminator().HasValue("EMAIL");
                });

            modelBuilder.Entity("Sample.Model.Entity.AdvancedEmailVerificationCode", b =>
                {
                    b.HasOne("Sample.Model.Entity.EmailVerificationCode", "Code")
                        .WithMany()
                        .HasForeignKey("CODE_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EFCAT.Model.Data.Image", "Image", b1 =>
                        {
                            b1.Property<Guid>("AdvancedEmailVerificationCodeCODE_ID")
                                .HasColumnType("char(36)");

                            b1.Property<int>("AdvancedEmailVerificationCodeRandom")
                                .HasColumnType("int(5)");

                            b1.Property<byte[]>("Content")
                                .IsRequired()
                                .HasColumnType("longblob")
                                .HasColumnName("IMAGE_CONTENT");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("varchar(32)")
                                .HasColumnName("IMAGE_TYPE");

                            b1.HasKey("AdvancedEmailVerificationCodeCODE_ID", "AdvancedEmailVerificationCodeRandom");

                            b1.ToTable("ADVANCED_EMAIL_CODES");

                            b1.WithOwner()
                                .HasForeignKey("AdvancedEmailVerificationCodeCODE_ID", "AdvancedEmailVerificationCodeRandom");
                        });

                    b.Navigation("Code");

                    b.Navigation("Image")
                        .IsRequired();
                });

            modelBuilder.Entity("Sample.Model.Entity.BadPerson", b =>
                {
                    b.OwnsOne("Sample.Model.Entity.Person", "Person", b1 =>
                        {
                            b1.Property<int>("BadPersonId")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("varchar(32)")
                                .HasColumnName("PERSON_FIRST_NAME");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("varchar(32)")
                                .HasColumnName("PERSON_LAST_NAME");

                            b1.HasKey("BadPersonId");

                            b1.ToTable("BAD_PEOPLE");

                            b1.WithOwner()
                                .HasForeignKey("BadPersonId");
                        });

                    b.Navigation("Person")
                        .IsRequired();
                });

            modelBuilder.Entity("Sample.Model.Entity.Code", b =>
                {
                    b.HasOne("Sample.Model.Entity.User", "User")
                        .WithMany("Codes")
                        .HasForeignKey("USER_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sample.Model.Entity.User", b =>
                {
                    b.OwnsOne("Sample.Model.Entity.Implemented", "Impl", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("varchar(32)")
                                .HasColumnName("IMPL_TEXT");

                            b1.HasKey("UserId");

                            b1.ToTable("USERS");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("EFCAT.Model.Data.Image", "Image", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<byte[]>("Content")
                                .IsRequired()
                                .HasColumnType("longblob")
                                .HasColumnName("IMAGE_CONTENT");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("varchar(32)")
                                .HasColumnName("IMAGE_TYPE");

                            b1.HasKey("UserId");

                            b1.ToTable("USERS");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Image");

                    b.Navigation("Impl");
                });

            modelBuilder.Entity("Sample.Model.Entity.ZMail", b =>
                {
                    b.HasOne("Sample.Model.Entity.User", "User")
                        .WithOne("Mail")
                        .HasForeignKey("Sample.Model.Entity.ZMail", "USER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sample.Model.Entity.User", b =>
                {
                    b.Navigation("Codes");

                    b.Navigation("Mail");
                });
#pragma warning restore 612, 618
        }
    }
}
