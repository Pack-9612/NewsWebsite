namespace NewsSystem.MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using NewsSystem.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class Context : DbContext
    {
        public Context()
            : base("NewsSystemDB")
        {
        }

        public virtual DbSet<AnonymousUser> AnonymousUsers { get; set; }
        public virtual DbSet<EventCategory> EventCategories { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventTag> EventTags { get; set; }
        public virtual DbSet<MainUser> Users { get; set; }
        public virtual DbSet<MediaFile> Files { get; set; }
        public virtual DbSet<MediaLibrary> MediaLibraries { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<NewsTag> NewsTags { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SocialNetwork> SocialNetworks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasRequired<MainUser>(e => e.User)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}