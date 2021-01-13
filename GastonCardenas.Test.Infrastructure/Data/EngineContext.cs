using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using GastonCardenas.Test.Common.Framework;
using GastonCardenas.Test.Domain.Posts;
using GastonCardenas.Test.Infrastructure.Data.EntityConfigurations;

namespace GastonCardenas.Test.Infrastructure.Data
{
    public class EngineContext : DbContext, IUnitOfWork
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostStatus> PostStatus { get; set; }


        public EngineContext(DbContextOptions<EngineContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostStatusEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostCommentEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
