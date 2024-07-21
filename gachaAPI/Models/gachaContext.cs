﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gachaAPI.Models;

public partial class gachaContext : DbContext
{
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__achievem__3213E83FCB8C6B44");

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
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Target).HasColumnName("target");
        });

        modelBuilder.Entity<AchievementProgress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__achievem__3213E83F344508DE");

            entity.ToTable("achievementProgress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchievementId).HasColumnName("achievementID");
            entity.Property(e => e.Progress).HasColumnName("progress");
            entity.Property(e => e.Target).HasColumnName("target");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Achievement).WithMany(p => p.AchievementProgresses)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__achieveme__achie__1332DBDC");

            entity.HasOne(d => d.User).WithMany(p => p.AchievementProgresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__achieveme__userI__123EB7A3");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__activity__3213E83F8827ADAC");

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
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.ActivityType).WithMany(p => p.Activities)
                .HasForeignKey(d => d.ActivityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activity__activi__02FC7413");
        });

        modelBuilder.Entity<ActivityLinkVoucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__activity__3213E83FECD8629B");

            entity.ToTable("activityLinkVoucher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityId).HasColumnName("activityID");
            entity.Property(e => e.VoucherId).HasColumnName("voucherID");

            entity.HasOne(d => d.Activity).WithMany(p => p.ActivityLinkVouchers)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activityL__activ__05D8E0BE");

            entity.HasOne(d => d.Voucher).WithMany(p => p.ActivityLinkVouchers)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activityL__vouch__06CD04F7");
        });

        modelBuilder.Entity<ActivityType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__activity__3213E83FA502E6CF");

            entity.ToTable("activityType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Account).HasName("PK__admin__EA162E10A27575D5");

            entity.ToTable("admin");

            entity.Property(e => e.Account)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("account");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.RoleId).HasColumnName("roleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Admins)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__admin__roleId__4E88ABD4");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__announce__3213E83F81C9B54E");

            entity.ToTable("announcement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .IsRequired()
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
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Bag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bag__3213E83F70E4BE71");

            entity.ToTable("bag");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.GachaProductId).HasColumnName("gachaProductId");
            entity.Property(e => e.GachaStatus)
                .IsRequired()
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
            entity.HasKey(e => e.Id).HasName("PK__chatRoom__3213E83F0FF68F63");

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
                .HasConstraintName("FK__chatRoom__user1I__1AD3FDA4");

            entity.HasOne(d => d.User2).WithMany(p => p.ChatRoomUser2s)
                .HasForeignKey(d => d.User2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chatRoom__user2I__1BC821DD");
        });

        modelBuilder.Entity<CheckIn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__checkIn__3213E83FC2B62925");

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
                .HasConstraintName("FK__checkIn__userID__17036CC0");
        });

        modelBuilder.Entity<ConvenienceStore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__convenie__3213E83F492F7B8E");

            entity.ToTable("convenienceStore");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ShippingFee).HasColumnName("shippingFee");
            entity.Property(e => e.StoreAddress)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("storeAddress");
            entity.Property(e => e.StoreName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("storeName");
            entity.Property(e => e.StoreType)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("storeType");
        });

        modelBuilder.Entity<ConvenienceStoreInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__convenie__3214EC076334850F");

            entity.ToTable("convenienceStoreInfo");

            entity.Property(e => e.ShippingDetailId).HasColumnName("shippingDetailId");
            entity.Property(e => e.StoreId).HasColumnName("storeId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.ShippingDetail).WithMany(p => p.ConvenienceStoreInfos)
                .HasForeignKey(d => d.ShippingDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__shipp__5535A963");

            entity.HasOne(d => d.Store).WithMany(p => p.ConvenienceStoreInfos)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__store__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.ConvenienceStoreInfos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__userI__534D60F1");
        });

        modelBuilder.Entity<ExchangeRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__exchange__3213E83F8D18C860");

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
                .HasConstraintName("FK__exchangeR__gacha__5AEE82B9");

            entity.HasOne(d => d.GachaIdToNavigation).WithMany(p => p.ExchangeRecordGachaIdToNavigations)
                .HasForeignKey(d => d.GachaIdTo)
                .HasConstraintName("FK__exchangeR__gacha__5BE2A6F2");

            entity.HasOne(d => d.UserIdFromNavigation).WithMany(p => p.ExchangeRecordUserIdFromNavigations)
                .HasForeignKey(d => d.UserIdFrom)
                .HasConstraintName("FK__exchangeR__userI__59063A47");

            entity.HasOne(d => d.UserIdToNavigation).WithMany(p => p.ExchangeRecordUserIdToNavigations)
                .HasForeignKey(d => d.UserIdTo)
                .HasConstraintName("FK__exchangeR__userI__59FA5E80");
        });

        modelBuilder.Entity<GachaDetailList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gachaDet__3213E83F2A909DBC");

            entity.ToTable("gachaDetailList");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BagId).HasColumnName("bagId");
            entity.Property(e => e.ExchangeRecordId).HasColumnName("exchangeRecordId");
            entity.Property(e => e.ShippingDetailId).HasColumnName("shippingDetailId");
            entity.Property(e => e.UploadRecordId).HasColumnName("uploadRecordId");

            entity.HasOne(d => d.Bag).WithMany(p => p.GachaDetailLists)
                .HasForeignKey(d => d.BagId)
                .HasConstraintName("FK__gachaDeta__bagId__628FA481");

            entity.HasOne(d => d.ExchangeRecord).WithMany(p => p.GachaDetailLists)
                .HasForeignKey(d => d.ExchangeRecordId)
                .HasConstraintName("FK__gachaDeta__excha__6383C8BA");

            entity.HasOne(d => d.ShippingDetail).WithMany(p => p.GachaDetailLists)
                .HasForeignKey(d => d.ShippingDetailId)
                .HasConstraintName("FK__gachaDeta__shipp__656C112C");

            entity.HasOne(d => d.UploadRecord).WithMany(p => p.GachaDetailLists)
                .HasForeignKey(d => d.UploadRecordId)
                .HasConstraintName("FK__gachaDeta__uploa__6477ECF3");
        });

        modelBuilder.Entity<GachaMachine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gachaMac__3213E83F52536B7E");

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
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("machineName");
            entity.Property(e => e.MachinePictureName)
                .IsRequired()
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
            entity.HasKey(e => e.Id).HasName("PK__gachaPro__3213E83F58EA11D3");

            entity.ToTable("gachaProduct");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createTime");
            entity.Property(e => e.MachineId).HasColumnName("machineId");
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("productName");
            entity.Property(e => e.ProductPictureName)
                .IsRequired()
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
            entity.HasKey(e => e.Id).HasName("PK__gachaThe__3213E83F82169F52");

            entity.ToTable("gachaTheme");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.ThemeName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("themeName");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__message__3213E83F2E5BF4FA");

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
                .HasConstraintName("FK__message__chatRoo__1F98B2C1");

            entity.HasOne(d => d.Sender).WithMany(p => p.Messages)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message__senderI__208CD6FA");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permissi__3213E83FB271BDBE");

            entity.ToTable("permission");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PermissionDesc)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("permissionDesc");
        });

        modelBuilder.Entity<PointList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pointLis__3213E83FE09CB556");

            entity.ToTable("pointList");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchievementId).HasColumnName("achievementId");
            entity.Property(e => e.BagId).HasColumnName("bagId");
            entity.Property(e => e.RechargeListId).HasColumnName("rechargeListId");

            entity.HasOne(d => d.Achievement).WithMany(p => p.PointLists)
                .HasForeignKey(d => d.AchievementId)
                .HasConstraintName("FK__pointList__achie__787EE5A0");

            entity.HasOne(d => d.Bag).WithMany(p => p.PointLists)
                .HasForeignKey(d => d.BagId)
                .HasConstraintName("FK__pointList__bagId__778AC167");

            entity.HasOne(d => d.RechargeList).WithMany(p => p.PointLists)
                .HasForeignKey(d => d.RechargeListId)
                .HasConstraintName("FK__pointList__recha__76969D2E");
        });

        modelBuilder.Entity<RechargeList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recharge__3213E83FA19110E2");

            entity.ToTable("rechargeList");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.PaymentMode)
                .IsRequired()
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
                .HasConstraintName("FK__rechargeL__recha__72C60C4A");

            entity.HasOne(d => d.User).WithMany(p => p.RechargeLists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rechargeL__userI__73BA3083");
        });

        modelBuilder.Entity<RechargePlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recharge__3213E83F28D3760A");

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
                .IsRequired()
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
            entity.HasKey(e => e.Id).HasName("PK__role__3213E83F1AC549C5");

            entity.ToTable("role");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("title");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.PermissionId }).HasName("PK__rolePerm__101A5503D429BC12");

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
            entity.HasKey(e => e.Id).HasName("PK__shipping__3213E83F2D4788C2");

            entity.ToTable("shipping");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactPhone)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contactPhone");
            entity.Property(e => e.ShippingAddress)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("shippingAddress");
            entity.Property(e => e.ShippingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("shippingDate");
            entity.Property(e => e.ShippingFee).HasColumnName("shippingFee");
            entity.Property(e => e.ShippingMethod)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("shippingMethod");
            entity.Property(e => e.ShippingStatus)
                .IsRequired()
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
            entity.HasKey(e => e.Id).HasName("PK__shipping__3213E83F69FAFD1D");

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
            entity.HasKey(e => new { e.UserId, e.GachaMachineId }).HasName("PK__tracking__62AB230B7EEFDBDE");

            entity.ToTable("trackingList");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.GachaMachineId).HasColumnName("gachaMachineId");
            entity.Property(e => e.NoteStatus)
                .IsRequired()
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
            entity.HasKey(e => e.Id).HasName("PK__uploadRe__3213E83FE5DE4002");

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
                .HasConstraintName("FK__uploadRec__bagId__5FB337D6");
        });

        modelBuilder.Entity<UserAchievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userAchi__3213E83FB96ADA81");

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
                .HasConstraintName("FK__userAchie__achie__0F624AF8");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userAchie__userI__0E6E26BF");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userInfo__3213E83F92885A5B");

            entity.ToTable("userInfo");

            entity.HasIndex(e => e.Email, "UQ__userInfo__AB6E6164FAC8D4E0").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.EmailConfirm)
                .HasDefaultValue(false)
                .HasColumnName("emailConfirm");
            entity.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<UserPassword>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__userPass__AB6E6165B6D46E6A");

            entity.ToTable("userPassword");

            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.UserPassword1)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userPassword");
        });

        modelBuilder.Entity<UserVoucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userVouc__3213E83F560FFBA4");

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
                .HasConstraintName("FK__userVouch__userI__09A971A2");

            entity.HasOne(d => d.Voucher).WithMany(p => p.UserVouchers)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userVouch__vouch__0A9D95DB");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__voucher__3213E83FA716D140");

            entity.ToTable("voucher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.VoucherCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("voucherCode");
            entity.Property(e => e.VoucherDescription)
                .HasMaxLength(500)
                .HasColumnName("voucherDescription");
            entity.Property(e => e.VoucherName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("voucherName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}