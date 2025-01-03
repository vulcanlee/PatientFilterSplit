using Microsoft.EntityFrameworkCore;

namespace PatientFilterSplit.EntityModel
{
    public partial class ElkDBContext : DbContext
    {

        public ElkDBContext(DbContextOptions<ElkDBContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Sample.ElkUser> ElkUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Chinese_Taiwan_Stroke_CI_AS");

            #region 設定階層級的刪除政策(預設若關聯子資料表有紀錄，父資料表不可強制刪除
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            #endregion

            //modelBuilder.Entity<Sample.ElkUser>(entity =>
            //{
            //    entity.ToTable("ElkUser");
            //    entity.Property(e => e.Id).HasColumnName("Id");
            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //    entity.Property(e => e.CreatedUserId).HasColumnName("CreatedUserId");
            //    entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
            //    entity.Property(e => e.UpdatedUserId).HasColumnName("UpdatedUserId");
            //    entity.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
            //});
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
