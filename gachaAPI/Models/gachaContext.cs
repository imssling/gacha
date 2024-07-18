using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gachaAPI.Models;

public partial class gachaContext : DbContext
{
    public gachaContext()
    {
    }

    public gachaContext(DbContextOptions<gachaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<AchievementProgress> AchievementProgresses { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityLinkVoucher> ActivityLinkVouchers { get; set; }

    public virtual DbSet<ActivityType> ActivityTypes { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Bag> Bags { get; set; }

    public virtual DbSet<ChatRoom> ChatRooms { get; set; }

    public virtual DbSet<CheckIn> CheckIns { get; set; }

    public virtual DbSet<ConvenienceStore> ConvenienceStores { get; set; }

    public virtual DbSet<ConvenienceStoreInfo> ConvenienceStoreInfos { get; set; }

    public virtual DbSet<ExchangeRecord> ExchangeRecords { get; set; }

    public virtual DbSet<GachaDetailList> GachaDetailLists { get; set; }

    public virtual DbSet<GachaMachine> GachaMachines { get; set; }

    public virtual DbSet<GachaProduct> GachaProducts { get; set; }

    public virtual DbSet<GachaTheme> GachaThemes { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PointList> PointLists { get; set; }

    public virtual DbSet<RechargeList> RechargeLists { get; set; }

    public virtual DbSet<RechargePlan> RechargePlans { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    public virtual DbSet<ShippingDetail> ShippingDetails { get; set; }

    public virtual DbSet<TrackingList> TrackingLists { get; set; }

    public virtual DbSet<UploadRecord> UploadRecords { get; set; }

    public virtual DbSet<UserAchievement> UserAchievements { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UserPassword> UserPasswords { get; set; }

    public virtual DbSet<UserVoucher> UserVouchers { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=gacha;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__achievem__3213E83F55FEB655");

            entity.ToTable("achievement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchievementType)
                .HasMaxLength(50)
                .HasColumnName("achievementType");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Target).HasColumnName("target");
        });

        modelBuilder.Entity<AchievementProgress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__achievem__3213E83F9E078046");

            entity.ToTable("achievementProgress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchievementId).HasColumnName("achievementID");
            entity.Property(e => e.Progress).HasColumnName("progress");
            entity.Property(e => e.Target).HasColumnName("target");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Achievement).WithMany(p => p.AchievementProgresses)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__achieveme__achie__14270015");

            entity.HasOne(d => d.User).WithMany(p => p.AchievementProgresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__achieveme__userI__1332DBDC");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__activity__3213E83F20DEEB0F");

            entity.ToTable("activity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityEnd)
                .HasColumnType("datetime")
                .HasColumnName("activityEnd");
            entity.Property(e => e.ActivityStart)
                .HasColumnType("datetime")
                .HasColumnName("activityStart");
            entity.Property(e => e.ActivityTypeId).HasColumnName("activityTypeId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.ActivityType).WithMany(p => p.Activities)
                .HasForeignKey(d => d.ActivityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activity__activi__03F0984C");
        });

        modelBuilder.Entity<ActivityLinkVoucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__activity__3213E83FB860C063");

            entity.ToTable("activityLinkVoucher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityId).HasColumnName("activityID");
            entity.Property(e => e.VoucherId).HasColumnName("voucherID");

            entity.HasOne(d => d.Activity).WithMany(p => p.ActivityLinkVouchers)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activityL__activ__06CD04F7");

            entity.HasOne(d => d.Voucher).WithMany(p => p.ActivityLinkVouchers)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activityL__vouch__07C12930");
        });

        modelBuilder.Entity<ActivityType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__activity__3213E83F7C4058F8");

            entity.ToTable("activityType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__admin__3213E83F7DDC6455");

            entity.ToTable("admin");

            entity.HasIndex(e => e.Account, "UQ__admin__EA162E1138F4A4A7").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("account");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.RoleId).HasColumnName("roleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Admins)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__admin__roleId__4F7CD00D");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__announce__3213E83F3AB17D4B");

            entity.ToTable("announcement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .HasColumnName("image");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Bag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bag__3213E83FA4B10CB1");

            entity.ToTable("bag");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.GachaProductId).HasColumnName("gachaProductId");
            entity.Property(e => e.GachaStatus)
                .HasMaxLength(50)
                .HasColumnName("gachaStatus");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.GachaProduct).WithMany(p => p.Bags)
                .HasForeignKey(d => d.GachaProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bag__gachaProduc__37A5467C");

            entity.HasOne(d => d.User).WithMany(p => p.Bags)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bag__userId__36B12243");
        });

        modelBuilder.Entity<ChatRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__chatRoom__3213E83F73A671A5");

            entity.ToTable("chatRoom");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.User1Id).HasColumnName("user1ID");
            entity.Property(e => e.User2Id).HasColumnName("user2ID");

            entity.HasOne(d => d.User1).WithMany(p => p.ChatRoomUser1s)
                .HasForeignKey(d => d.User1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chatRoom__user1I__1BC821DD");

            entity.HasOne(d => d.User2).WithMany(p => p.ChatRoomUser2s)
                .HasForeignKey(d => d.User2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chatRoom__user2I__1CBC4616");
        });

        modelBuilder.Entity<CheckIn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__checkIn__3213E83FF522B980");

            entity.ToTable("checkIn");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckInDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("checkInDate");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.CheckIns)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__checkIn__userID__17F790F9");
        });

        modelBuilder.Entity<ConvenienceStore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__convenie__3213E83F02F6544D");

            entity.ToTable("convenienceStore");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ShippingFee).HasColumnName("shippingFee");
            entity.Property(e => e.StoreAddress)
                .HasMaxLength(100)
                .HasColumnName("storeAddress");
            entity.Property(e => e.StoreName)
                .HasMaxLength(20)
                .HasColumnName("storeName");
            entity.Property(e => e.StoreType)
                .HasMaxLength(20)
                .HasColumnName("storeType");
        });

        modelBuilder.Entity<ConvenienceStoreInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__convenie__3214EC079263A96F");

            entity.ToTable("convenienceStoreInfo");

            entity.Property(e => e.ShippingDetailId).HasColumnName("shippingDetailId");
            entity.Property(e => e.StoreId).HasColumnName("storeId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.ShippingDetail).WithMany(p => p.ConvenienceStoreInfos)
                .HasForeignKey(d => d.ShippingDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__shipp__5629CD9C");

            entity.HasOne(d => d.Store).WithMany(p => p.ConvenienceStoreInfos)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__store__5535A963");

            entity.HasOne(d => d.User).WithMany(p => p.ConvenienceStoreInfos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__userI__5441852A");
        });

        modelBuilder.Entity<ExchangeRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__exchange__3213E83FCCC3F65D");

            entity.ToTable("exchangeRecord");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ExchangeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("exchangeDate");
            entity.Property(e => e.GachaIdFrom).HasColumnName("gachaIdFrom");
            entity.Property(e => e.GachaIdTo).HasColumnName("gachaIdTo");
            entity.Property(e => e.UserIdFrom).HasColumnName("userIdFrom");
            entity.Property(e => e.UserIdTo).HasColumnName("userIdTo");

            entity.HasOne(d => d.GachaIdFromNavigation).WithMany(p => p.ExchangeRecordGachaIdFromNavigations)
                .HasForeignKey(d => d.GachaIdFrom)
                .HasConstraintName("FK__exchangeR__gacha__5BE2A6F2");

            entity.HasOne(d => d.GachaIdToNavigation).WithMany(p => p.ExchangeRecordGachaIdToNavigations)
                .HasForeignKey(d => d.GachaIdTo)
                .HasConstraintName("FK__exchangeR__gacha__5CD6CB2B");

            entity.HasOne(d => d.UserIdFromNavigation).WithMany(p => p.ExchangeRecordUserIdFromNavigations)
                .HasForeignKey(d => d.UserIdFrom)
                .HasConstraintName("FK__exchangeR__userI__59FA5E80");

            entity.HasOne(d => d.UserIdToNavigation).WithMany(p => p.ExchangeRecordUserIdToNavigations)
                .HasForeignKey(d => d.UserIdTo)
                .HasConstraintName("FK__exchangeR__userI__5AEE82B9");
        });

        modelBuilder.Entity<GachaDetailList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gachaDet__3213E83F39178AA5");

            entity.ToTable("gachaDetailList");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BagId).HasColumnName("bagId");
            entity.Property(e => e.ExchangeRecordId).HasColumnName("exchangeRecordId");
            entity.Property(e => e.ShippingDetailId).HasColumnName("shippingDetailId");
            entity.Property(e => e.UploadRecordId).HasColumnName("uploadRecordId");

            entity.HasOne(d => d.Bag).WithMany(p => p.GachaDetailLists)
                .HasForeignKey(d => d.BagId)
                .HasConstraintName("FK__gachaDeta__bagId__6383C8BA");

            entity.HasOne(d => d.ExchangeRecord).WithMany(p => p.GachaDetailLists)
                .HasForeignKey(d => d.ExchangeRecordId)
                .HasConstraintName("FK__gachaDeta__excha__6477ECF3");

            entity.HasOne(d => d.ShippingDetail).WithMany(p => p.GachaDetailLists)
                .HasForeignKey(d => d.ShippingDetailId)
                .HasConstraintName("FK__gachaDeta__shipp__66603565");

            entity.HasOne(d => d.UploadRecord).WithMany(p => p.GachaDetailLists)
                .HasForeignKey(d => d.UploadRecordId)
                .HasConstraintName("FK__gachaDeta__uploa__656C112C");
        });

        modelBuilder.Entity<GachaMachine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gachaMac__3213E83F4236092F");

            entity.ToTable("gachaMachine");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.MachineDescription)
                .HasMaxLength(500)
                .HasColumnName("machineDescription");
            entity.Property(e => e.MachineName)
                .HasMaxLength(100)
                .HasColumnName("machineName");
            entity.Property(e => e.MachinePictureName)
                .HasMaxLength(100)
                .HasColumnName("machinePictureName");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.ThemeId).HasColumnName("themeId");

            entity.HasOne(d => d.Theme).WithMany(p => p.GachaMachines)
                .HasForeignKey(d => d.ThemeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gachaMach__theme__2F10007B");
        });

        modelBuilder.Entity<GachaProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gachaPro__3213E83F1781BF0B");

            entity.ToTable("gachaProduct");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.MachineId).HasColumnName("machineId");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("productName");
            entity.Property(e => e.ProductPictureName)
                .HasMaxLength(100)
                .HasColumnName("productPictureName");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Machine).WithMany(p => p.GachaProducts)
                .HasForeignKey(d => d.MachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gachaProd__machi__32E0915F");
        });

        modelBuilder.Entity<GachaTheme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gachaThe__3213E83FB3CB7694");

            entity.ToTable("gachaTheme");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.ThemeName)
                .HasMaxLength(50)
                .HasColumnName("themeName");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__message__3213E83F1E7A172C");

            entity.ToTable("message");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChatRoomId).HasColumnName("chatRoomID");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .HasColumnName("content");
            entity.Property(e => e.SendDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("sendDate");
            entity.Property(e => e.SenderId).HasColumnName("senderID");

            entity.HasOne(d => d.ChatRoom).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ChatRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message__chatRoo__208CD6FA");

            entity.HasOne(d => d.Sender).WithMany(p => p.Messages)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message__senderI__2180FB33");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permissi__3213E83F3263AE67");

            entity.ToTable("permission");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PermissionDesc)
                .HasMaxLength(20)
                .HasColumnName("permissionDesc");
        });

        modelBuilder.Entity<PointList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pointLis__3213E83F611E4D28");

            entity.ToTable("pointList");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchievementId).HasColumnName("achievementId");
            entity.Property(e => e.BagId).HasColumnName("bagId");
            entity.Property(e => e.RechargeListId).HasColumnName("rechargeListId");

            entity.HasOne(d => d.Achievement).WithMany(p => p.PointLists)
                .HasForeignKey(d => d.AchievementId)
                .HasConstraintName("FK__pointList__achie__797309D9");

            entity.HasOne(d => d.Bag).WithMany(p => p.PointLists)
                .HasForeignKey(d => d.BagId)
                .HasConstraintName("FK__pointList__bagId__787EE5A0");

            entity.HasOne(d => d.RechargeList).WithMany(p => p.PointLists)
                .HasForeignKey(d => d.RechargeListId)
                .HasConstraintName("FK__pointList__recha__778AC167");
        });

        modelBuilder.Entity<RechargeList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recharge__3213E83F129AFBE5");

            entity.ToTable("rechargeList");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(50)
                .HasColumnName("paymentMode");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RechargeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("rechargeDate");
            entity.Property(e => e.RechargePlanId).HasColumnName("rechargePlanId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.RechargePlan).WithMany(p => p.RechargeLists)
                .HasForeignKey(d => d.RechargePlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rechargeL__recha__73BA3083");

            entity.HasOne(d => d.User).WithMany(p => p.RechargeLists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rechargeL__userI__74AE54BC");
        });

        modelBuilder.Entity<RechargePlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recharge__3213E83FACBAC0F1");

            entity.ToTable("rechargePlan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role__3213E83F557AC59D");

            entity.ToTable("role");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasColumnName("title");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.PermissionId }).HasName("PK__rolePerm__101A5503FEC5C946");

            entity.ToTable("rolePermission");

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.PermissionId).HasColumnName("permissionId");
            entity.Property(e => e.Nono).HasColumnName("nono");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rolePermi__permi__4BAC3F29");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rolePermi__roleI__4AB81AF0");
        });

        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__shipping__3213E83FDBD25934");

            entity.ToTable("shipping");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contactPhone");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(100)
                .HasColumnName("shippingAddress");
            entity.Property(e => e.ShippingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("shippingDate");
            entity.Property(e => e.ShippingFee).HasColumnName("shippingFee");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(20)
                .HasColumnName("shippingMethod");
            entity.Property(e => e.ShippingStatus)
                .HasMaxLength(20)
                .HasColumnName("shippingStatus");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Shippings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__shipping__userId__3B75D760");
        });

        modelBuilder.Entity<ShippingDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__shipping__3213E83F93BF9880");

            entity.ToTable("shippingDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BagId).HasColumnName("bagId");
            entity.Property(e => e.ShippingId).HasColumnName("shippingId");

            entity.HasOne(d => d.Bag).WithMany(p => p.ShippingDetails)
                .HasForeignKey(d => d.BagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__shippingD__bagId__3F466844");

            entity.HasOne(d => d.Shipping).WithMany(p => p.ShippingDetails)
                .HasForeignKey(d => d.ShippingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__shippingD__shipp__3E52440B");
        });

        modelBuilder.Entity<TrackingList>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.GachaMachineId }).HasName("PK__tracking__62AB230B47C3D7A2");

            entity.ToTable("trackingList");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.GachaMachineId).HasColumnName("gachaMachineId");
            entity.Property(e => e.NoteStatus)
                .HasMaxLength(20)
                .HasColumnName("noteStatus");
            entity.Property(e => e.TrackingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("trackingDate");

            entity.HasOne(d => d.GachaMachine).WithMany(p => p.TrackingLists)
                .HasForeignKey(d => d.GachaMachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__trackingL__gacha__440B1D61");

            entity.HasOne(d => d.User).WithMany(p => p.TrackingLists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__trackingL__userI__4316F928");
        });

        modelBuilder.Entity<UploadRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__uploadRe__3213E83FE7C14D17");

            entity.ToTable("uploadRecord");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BagId).HasColumnName("bagId");
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("uploadDate");

            entity.HasOne(d => d.Bag).WithMany(p => p.UploadRecords)
                .HasForeignKey(d => d.BagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__uploadRec__bagId__60A75C0F");
        });

        modelBuilder.Entity<UserAchievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userAchi__3213E83F4EA1F7A6");

            entity.ToTable("userAchievement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchievedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("achievedAt");
            entity.Property(e => e.AchievementId).HasColumnName("achievementID");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Achievement).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userAchie__achie__10566F31");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userAchie__userI__0F624AF8");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userInfo__3213E83F57C4851B");

            entity.ToTable("userInfo");

            entity.HasIndex(e => e.Email, "UQ__userInfo__AB6E61642B3C1711").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.EmailConfirm)
                .HasDefaultValue(false)
                .HasColumnName("emailConfirm");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<UserPassword>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__userPass__AB6E61650FD51A32");

            entity.ToTable("userPassword");

            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.UserPassword1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userPassword");
        });

        modelBuilder.Entity<UserVoucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userVouc__3213E83FC22F9031");

            entity.ToTable("userVoucher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.VoucherId).HasColumnName("voucherID");

            entity.HasOne(d => d.User).WithMany(p => p.UserVouchers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userVouch__userI__0A9D95DB");

            entity.HasOne(d => d.Voucher).WithMany(p => p.UserVouchers)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userVouch__vouch__0B91BA14");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__voucher__3213E83F7649127D");

            entity.ToTable("voucher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.VoucherCode)
                .HasMaxLength(50)
                .HasColumnName("voucherCode");
            entity.Property(e => e.VoucherDescription)
                .HasMaxLength(500)
                .HasColumnName("voucherDescription");
            entity.Property(e => e.VoucherName)
                .HasMaxLength(50)
                .HasColumnName("voucherName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
