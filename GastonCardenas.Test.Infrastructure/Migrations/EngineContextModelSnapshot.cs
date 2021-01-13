using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using GastonCardenas.Test.Infrastructure.Data;

namespace GastonCardenas.Test.Infrastructure.Migrations
{
    [DbContext(typeof(EngineContext))]
    partial class EngineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GastonCardenas.Test.Domain.Posts.Post", b =>
            {
                b.Property<int>("PostId")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime?>("ApprovalDate");

                b.Property<string>("ApproverName")
                    .HasMaxLength(100);

                b.Property<string>("AuthorName")
                    .IsRequired()
                    .HasMaxLength(100);

                b.Property<DateTime>("CreationtDate");

                b.Property<DateTime>("LastUpdateDate");

                b.Property<int>("PostStatusId");

                b.Property<string>("Text")
                    .IsRequired()
                    .HasMaxLength(4000);

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(300);

                b.HasKey("PostId");

                b.HasIndex("PostStatusId");

                b.ToTable("Post");
            });

            modelBuilder.Entity("GastonCardenas.Test.Domain.Posts.PostComment", b =>
            {
                b.Property<int>("PostCommentId")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("AuthorEmail")
                    .IsRequired()
                    .HasMaxLength(100);

                b.Property<string>("AuthorName")
                    .IsRequired()
                    .HasMaxLength(100);

                b.Property<string>("Comment")
                    .IsRequired()
                    .HasMaxLength(4000);

                b.Property<DateTime>("CreationtDate");

                b.Property<int>("PostId");

                b.HasKey("PostCommentId");

                b.HasIndex("PostId");

                b.ToTable("PostComment");
            });

            modelBuilder.Entity("GastonCardenas.Test.Domain.Posts.PostStatus", b =>
            {
                b.Property<int>("PostStatusId");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(100);

                b.HasKey("PostStatusId");

                b.ToTable("PostStatus");

                b.HasData(
                    new { PostStatusId = 0, Name = "Draft" },
                    new { PostStatusId = 1, Name = "Pending Publish Approval" },
                    new { PostStatusId = 2, Name = "Published" }
                );
            });

            modelBuilder.Entity("GastonCardenas.Test.Domain.Posts.Post", b =>
            {
                b.HasOne("GastonCardenas.Test.Domain.Posts.PostStatus", "PostStatus")
                    .WithMany()
                    .HasForeignKey("PostStatusId")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity("GastonCardenas.Test.Domain.Posts.PostComment", b =>
            {
                b.HasOne("GastonCardenas.Test.Domain.Posts.Post", "Post")
                    .WithMany("PostComments")
                    .HasForeignKey("PostId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
#pragma warning restore 612, 618
        }
    }
}
