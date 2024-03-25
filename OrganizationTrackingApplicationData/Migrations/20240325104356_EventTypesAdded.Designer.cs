﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrganizationTrackingApplicationData;

#nullable disable

namespace OrganizationTrackingApplicationData.Migrations
{
    [DbContext(typeof(OrganizationTrackingApplicationDbContext))]
    [Migration("20240325104356_EventTypesAdded")]
    partial class EventTypesAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Domain.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EventTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrganizatorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("LocationId");

                    b.HasIndex("OrganizatorId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Entities.Domain.Follow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FollowedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FollowedId");

                    b.HasIndex("FollowerId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("Entities.Domain.Friend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FriendOneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FriendTwoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FriendOneId");

                    b.HasIndex("FriendTwoId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("Entities.Domain.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Entities.Domain.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Entities.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Entities.EventType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EventTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("903571e4-4496-4216-99df-6f121a133ef5"),
                            Name = "Concert"
                        },
                        new
                        {
                            Id = new Guid("f862b959-e44f-40f5-9c53-f62b6e31991c"),
                            Name = "Carnival"
                        },
                        new
                        {
                            Id = new Guid("c3b33b3f-483a-423e-af09-4c8ce7a6d252"),
                            Name = "Festival"
                        },
                        new
                        {
                            Id = new Guid("f6c29eb7-ecdb-49eb-a212-3b63bc9bc00f"),
                            Name = "Meeting"
                        },
                        new
                        {
                            Id = new Guid("74213cbf-efe3-43d0-8cc1-68dca8438a23"),
                            Name = "Activity"
                        },
                        new
                        {
                            Id = new Guid("4f5d2d19-b8a1-4e7a-af4f-e07a92a66bd6"),
                            Name = "Trip"
                        });
                });

            modelBuilder.Entity("Entities.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormattedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Entities.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Entities.Entities.Organizator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizators");
                });

            modelBuilder.Entity("Entities.Entities.Rules", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Rule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("Entities.Domain.Event", b =>
                {
                    b.HasOne("Entities.Entities.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Entities.Location", "Location")
                        .WithMany("Events")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Entities.Organizator", "Organizator")
                        .WithMany("Events")
                        .HasForeignKey("OrganizatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventType");

                    b.Navigation("Location");

                    b.Navigation("Organizator");
                });

            modelBuilder.Entity("Entities.Domain.Follow", b =>
                {
                    b.HasOne("Entities.Domain.User", "Followed")
                        .WithMany("Followeds")
                        .HasForeignKey("FollowedId");

                    b.HasOne("Entities.Domain.User", "Follower")
                        .WithMany("Followers")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Followed");

                    b.Navigation("Follower");
                });

            modelBuilder.Entity("Entities.Domain.Friend", b =>
                {
                    b.HasOne("Entities.Domain.User", "FriendOne")
                        .WithMany("FriendOnes")
                        .HasForeignKey("FriendOneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Domain.User", "FriendTwo")
                        .WithMany("FriendTwos")
                        .HasForeignKey("FriendTwoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FriendOne");

                    b.Navigation("FriendTwo");
                });

            modelBuilder.Entity("Entities.Domain.Rating", b =>
                {
                    b.HasOne("Entities.Domain.Event", "Event")
                        .WithMany("Ratings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Domain.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Domain.Ticket", b =>
                {
                    b.HasOne("Entities.Domain.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Domain.User", "Owner")
                        .WithMany("Tickets")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Event");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Entities.Entities.Notification", b =>
                {
                    b.HasOne("Entities.Domain.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Entities.Rules", b =>
                {
                    b.HasOne("Entities.Domain.Event", "Event")
                        .WithMany("Rules")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Entities.Domain.Event", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Rules");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Entities.Domain.User", b =>
                {
                    b.Navigation("Followeds");

                    b.Navigation("Followers");

                    b.Navigation("FriendOnes");

                    b.Navigation("FriendTwos");

                    b.Navigation("Notifications");

                    b.Navigation("Ratings");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Entities.Entities.EventType", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Entities.Entities.Location", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Entities.Entities.Organizator", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
