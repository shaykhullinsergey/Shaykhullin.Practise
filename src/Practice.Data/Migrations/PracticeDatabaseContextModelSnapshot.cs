﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Practice;

namespace Practice.Migrations
{
    [DbContext(typeof(PracticeDatabaseContext))]
    partial class PracticeDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Practice.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<bool>("Correct")
                        .HasColumnName("correct");

                    b.Property<int>("QuestionId")
                        .HasColumnName("questionId");

                    b.Property<string>("Text")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("answers");
                });

            modelBuilder.Entity("Practice.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("LectureId")
                        .HasColumnName("lectureId");

                    b.Property<string>("Text")
                        .HasColumnName("text");

                    b.Property<string>("Title")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("chapters");
                });

            modelBuilder.Entity("Practice.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Title")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("lectures");
                });

            modelBuilder.Entity("Practice.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created");

                    b.Property<string>("Group")
                        .HasColumnName("group");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Session")
                        .HasColumnName("session");

                    b.HasKey("Id");

                    b.ToTable("profiles");
                });

            modelBuilder.Entity("Practice.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("LectureId");

                    b.Property<string>("Text")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("Practice.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("LectureId")
                        .HasColumnName("lectureId");

                    b.Property<int>("ProfileId")
                        .HasColumnName("profileId");

                    b.Property<int?>("Result")
                        .HasColumnName("result");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.HasIndex("ProfileId");

                    b.ToTable("quizzes");
                });

            modelBuilder.Entity("Practice.Answer", b =>
                {
                    b.HasOne("Practice.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Practice.Chapter", b =>
                {
                    b.HasOne("Practice.Lecture", "Lecture")
                        .WithMany("Chapters")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Practice.Question", b =>
                {
                    b.HasOne("Practice.Lecture")
                        .WithMany("Questions")
                        .HasForeignKey("LectureId");
                });

            modelBuilder.Entity("Practice.Quiz", b =>
                {
                    b.HasOne("Practice.Lecture", "Lecture")
                        .WithMany("Quizzes")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Practice.Profile", "Profile")
                        .WithMany("Quizzes")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
