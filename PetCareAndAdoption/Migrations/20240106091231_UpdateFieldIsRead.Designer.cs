﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetCareAndAdoption.Data;

#nullable disable

namespace PetCareAndAdoption.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240106091231_UpdateFieldIsRead")]
    partial class UpdateFieldIsRead
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

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

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.Breeds", b =>
                {
                    b.Property<string>("breedID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("breedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("speciesID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("breedID");

                    b.HasIndex("speciesID");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.FavoritePost", b =>
                {
                    b.Property<string>("FavId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("postID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FavId");

                    b.ToTable("FavoritePost");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.HistoryVaccine", b =>
                {
                    b.Property<string>("historyVaccineID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("petID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("historyVaccineID");

                    b.ToTable("HistoryVaccine");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.ImagePost", b =>
                {
                    b.Property<string>("imgPostID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("imgPostID");

                    b.ToTable("ImagePost");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.MyPets", b =>
                {
                    b.Property<string>("petID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("petName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("petID");

                    b.ToTable("MyPets");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.NextVaccine", b =>
                {
                    b.Property<string>("nextVaccineID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("petID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nextVaccineID");

                    b.ToTable("NextVaccine");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.Notifications", b =>
                {
                    b.Property<string>("notiID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isRead")
                        .HasColumnType("bit");

                    b.Property<string>("receiverID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senderID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("notiID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.PetImages", b =>
                {
                    b.Property<string>("imgPetID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("petID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("imgPetID");

                    b.ToTable("PetImages");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.PetPosts", b =>
                {
                    b.Property<string>("postID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdopt")
                        .HasColumnType("bit");

                    b.Property<bool>("isDone")
                        .HasColumnType("bit");

                    b.Property<bool>("isVaccinated")
                        .HasColumnType("bit");

                    b.Property<string>("petName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("receiverID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("postID");

                    b.ToTable("PetPosts");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.Posts", b =>
                {
                    b.Property<string>("postID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdopt")
                        .HasColumnType("bit");

                    b.Property<bool>("isDone")
                        .HasColumnType("bit");

                    b.Property<bool>("isVaccinated")
                        .HasColumnType("bit");

                    b.Property<string>("petName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("postID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.Species", b =>
                {
                    b.Property<string>("speciesID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("speciesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("speciesID");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.UserInfo", b =>
                {
                    b.Property<string>("userID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.UserRequest", b =>
                {
                    b.Property<string>("requestID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("postID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("requestID");

                    b.ToTable("UserRequest");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.UserToken", b =>
                {
                    b.Property<string>("tokenID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tokenID");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PetCareAndAdoption.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PetCareAndAdoption.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetCareAndAdoption.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PetCareAndAdoption.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.Breeds", b =>
                {
                    b.HasOne("PetCareAndAdoption.Data.Species", "Species")
                        .WithMany("Breeds")
                        .HasForeignKey("speciesID");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("PetCareAndAdoption.Data.Species", b =>
                {
                    b.Navigation("Breeds");
                });
#pragma warning restore 612, 618
        }
    }
}
