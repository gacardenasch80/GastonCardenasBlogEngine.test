using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GastonCardenas.Test.Domain.Posts;

namespace GastonCardenas.Test.Infrastructure.Data.EntityConfigurations
{
    class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entityConfiguration)
        {
            entityConfiguration.ToTable("Post");
            entityConfiguration.HasKey(t => t.PostId);
            entityConfiguration.Property(t => t.PostId).ValueGeneratedOnAdd();
            entityConfiguration.Property(t => t.CreationtDate).IsRequired(true);
            entityConfiguration.Property(t => t.LastUpdateDate).IsRequired(true);
            entityConfiguration.Property(t => t.PostStatusId).IsRequired(true);
            entityConfiguration.Property(t => t.Title).IsRequired(true).HasMaxLength(300);
            entityConfiguration.Property(t => t.Text).IsRequired(true).HasMaxLength(4000);
            entityConfiguration.Property(t => t.AuthorName).IsRequired(true).HasMaxLength(100);
            entityConfiguration.Property(t => t.ApprovalDate).IsRequired(false);
            entityConfiguration.Property(t => t.ApproverName).IsRequired(false).HasMaxLength(100);

            var navigation = entityConfiguration.Metadata.FindNavigation(nameof(Post.PostComments));

            // DDD Patterns comment:
            //Set as field to access the Comment collection property through its field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            entityConfiguration.HasOne(t => t.PostStatus)
                .WithMany()
                .HasForeignKey("PostStatusId")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
