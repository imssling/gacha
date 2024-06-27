﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gacha.Models;

public partial class gachaContext : DbContext
{
    public gachaContext(DbContextOptions<gachaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<achievement> achievement { get; set; }

    public virtual DbSet<achievementProgress> achievementProgress { get; set; }

    public virtual DbSet<activity> activity { get; set; }

    public virtual DbSet<activityLinkVoucher> activityLinkVoucher { get; set; }

    public virtual DbSet<activityType> activityType { get; set; }

    public virtual DbSet<admin> admin { get; set; }

    public virtual DbSet<announcement> announcement { get; set; }

    public virtual DbSet<bag> bag { get; set; }

    public virtual DbSet<chatRoom> chatRoom { get; set; }

    public virtual DbSet<checkIn> checkIn { get; set; }

    public virtual DbSet<convenienceStore> convenienceStore { get; set; }

    public virtual DbSet<convenienceStoreInfo> convenienceStoreInfo { get; set; }

    public virtual DbSet<exchangeRecord> exchangeRecord { get; set; }

    public virtual DbSet<gachaDetailList> gachaDetailList { get; set; }

    public virtual DbSet<gachaMachine> gachaMachine { get; set; }

    public virtual DbSet<gachaProduct> gachaProduct { get; set; }

    public virtual DbSet<gachaTheme> gachaTheme { get; set; }

    public virtual DbSet<message> message { get; set; }

    public virtual DbSet<permission> permission { get; set; }

    public virtual DbSet<pointList> pointList { get; set; }

    public virtual DbSet<rechargeList> rechargeList { get; set; }

    public virtual DbSet<rechargePlan> rechargePlan { get; set; }

    public virtual DbSet<role> role { get; set; }

    public virtual DbSet<shipping> shipping { get; set; }

    public virtual DbSet<shippingDetail> shippingDetail { get; set; }

    public virtual DbSet<trackingList> trackingList { get; set; }

    public virtual DbSet<uploadRecord> uploadRecord { get; set; }

    public virtual DbSet<userAchievement> userAchievement { get; set; }

    public virtual DbSet<userInfo> userInfo { get; set; }

    public virtual DbSet<userPassword> userPassword { get; set; }

    public virtual DbSet<userVoucher> userVoucher { get; set; }

    public virtual DbSet<voucher> voucher { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<achievement>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__achievem__3213E83FEE5EAD32");

            entity.Property(e => e.achievementType).HasMaxLength(50);
            entity.Property(e => e.createdAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.description).HasMaxLength(500);
            entity.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<achievementProgress>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__achievem__3213E83F1D8FA396");

            entity.HasOne(d => d.achievement).WithMany(p => p.achievementProgress)
                .HasForeignKey(d => d.achievementID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__achieveme__achie__2180FB33");

            entity.HasOne(d => d.user).WithMany(p => p.achievementProgress)
                .HasForeignKey(d => d.userID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__achieveme__userI__208CD6FA");
        });

        modelBuilder.Entity<activity>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__activity__3213E83F2EEFC7F2");

            entity.Property(e => e.activityEnd).HasColumnType("datetime");
            entity.Property(e => e.activityStart).HasColumnType("datetime");
            entity.Property(e => e.createdAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.description).HasMaxLength(500);
            entity.Property(e => e.status).HasDefaultValue(true);
            entity.Property(e => e.title)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.activityType).WithMany(p => p.activity)
                .HasForeignKey(d => d.activityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activity__activi__114A936A");
        });

        modelBuilder.Entity<activityLinkVoucher>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__activity__3213E83F9560F4D0");

            entity.HasOne(d => d.activity).WithMany(p => p.activityLinkVoucher)
                .HasForeignKey(d => d.activityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activityL__activ__14270015");

            entity.HasOne(d => d.voucher).WithMany(p => p.activityLinkVoucher)
                .HasForeignKey(d => d.voucherID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activityL__vouch__151B244E");
        });

        modelBuilder.Entity<activityType>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__activity__3213E83FE4233626");

            entity.Property(e => e.createdAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<admin>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__admin__3213E83F5B5E6F1A");

            entity.HasIndex(e => e.account, "UQ__admin__EA162E11059476EA").IsUnique();

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.account)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.password)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.phoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasOne(d => d.role).WithMany(p => p.admin)
                .HasForeignKey(d => d.roleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__admin__roleId__5EBF139D");
        });

        modelBuilder.Entity<announcement>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__announce__3213E83F22D6D4DE");

            entity.Property(e => e.content)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.createdAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.image).HasMaxLength(100);
            entity.Property(e => e.title)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<bag>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__bag__3213E83FB97B40E2");

            entity.Property(e => e.date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.gachaStatus)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.gachaProduct).WithMany(p => p.bag)
                .HasForeignKey(d => d.gachaProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bag__gachaProduc__46E78A0C");

            entity.HasOne(d => d.user).WithMany(p => p.bag)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bag__userId__45F365D3");
        });

        modelBuilder.Entity<chatRoom>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__chatRoom__3213E83F4D854479");

            entity.Property(e => e.createdAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.user1).WithMany(p => p.chatRoomuser1)
                .HasForeignKey(d => d.user1ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chatRoom__user1I__29221CFB");

            entity.HasOne(d => d.user2).WithMany(p => p.chatRoomuser2)
                .HasForeignKey(d => d.user2ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chatRoom__user2I__2A164134");
        });

        modelBuilder.Entity<checkIn>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__checkIn__3213E83FC16CC2D3");

            entity.Property(e => e.checkInDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.checkIn)
                .HasForeignKey(d => d.userID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__checkIn__userID__25518C17");
        });

        modelBuilder.Entity<convenienceStore>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__convenie__3213E83F6149771F");

            entity.Property(e => e.storeAddress)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.storeName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.storeType)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<convenienceStoreInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__convenie__3214EC072F2BB084");

            entity.HasOne(d => d.shippingDetail).WithMany(p => p.convenienceStoreInfo)
                .HasForeignKey(d => d.shippingDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__shipp__656C112C");

            entity.HasOne(d => d.store).WithMany(p => p.convenienceStoreInfo)
                .HasForeignKey(d => d.storeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__store__6477ECF3");

            entity.HasOne(d => d.user).WithMany(p => p.convenienceStoreInfo)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__userI__6383C8BA");
        });

        modelBuilder.Entity<exchangeRecord>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__exchange__3213E83F0686FB2C");

            entity.Property(e => e.exchangeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.gachaIdFromNavigation).WithMany(p => p.exchangeRecordgachaIdFromNavigation)
                .HasForeignKey(d => d.gachaIdFrom)
                .HasConstraintName("FK__exchangeR__gacha__6B24EA82");

            entity.HasOne(d => d.gachaIdToNavigation).WithMany(p => p.exchangeRecordgachaIdToNavigation)
                .HasForeignKey(d => d.gachaIdTo)
                .HasConstraintName("FK__exchangeR__gacha__6C190EBB");

            entity.HasOne(d => d.userIdFromNavigation).WithMany(p => p.exchangeRecorduserIdFromNavigation)
                .HasForeignKey(d => d.userIdFrom)
                .HasConstraintName("FK__exchangeR__userI__693CA210");

            entity.HasOne(d => d.userIdToNavigation).WithMany(p => p.exchangeRecorduserIdToNavigation)
                .HasForeignKey(d => d.userIdTo)
                .HasConstraintName("FK__exchangeR__userI__6A30C649");
        });

        modelBuilder.Entity<gachaDetailList>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__gachaDet__3213E83FAFB046EC");

            entity.HasOne(d => d.bag).WithMany(p => p.gachaDetailList)
                .HasForeignKey(d => d.bagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gachaDeta__bagId__72C60C4A");

            entity.HasOne(d => d.exchangeRecord).WithMany(p => p.gachaDetailList)
                .HasForeignKey(d => d.exchangeRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gachaDeta__excha__73BA3083");

            entity.HasOne(d => d.uploadRecord).WithMany(p => p.gachaDetailList)
                .HasForeignKey(d => d.uploadRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gachaDeta__uploa__74AE54BC");
        });

        modelBuilder.Entity<gachaMachine>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__gachaMac__3213E83FCE659D55");

            entity.Property(e => e.createTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.machineDescription).HasMaxLength(500);
            entity.Property(e => e.machineName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.machinePictureName)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.theme).WithMany(p => p.gachaMachine)
                .HasForeignKey(d => d.themeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gachaMach__theme__3E52440B");
        });

        modelBuilder.Entity<gachaProduct>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__gachaPro__3213E83FFEC2A549");

            entity.Property(e => e.createTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.productName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.productPictureName)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.machine).WithMany(p => p.gachaProduct)
                .HasForeignKey(d => d.machineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gachaProd__machi__4222D4EF");
        });

        modelBuilder.Entity<gachaTheme>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__gachaThe__3213E83FD92D3E44");

            entity.Property(e => e.themeName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<message>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__message__3213E83F447BD635");

            entity.Property(e => e.content).HasMaxLength(500);
            entity.Property(e => e.sendDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.chatRoom).WithMany(p => p.message)
                .HasForeignKey(d => d.chatRoomID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message__chatRoo__2DE6D218");

            entity.HasOne(d => d.sender).WithMany(p => p.message)
                .HasForeignKey(d => d.senderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message__senderI__2EDAF651");
        });

        modelBuilder.Entity<permission>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__permissi__3213E83FABE20579");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.permissionDesc)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<pointList>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__pointLis__3213E83FC5658519");

            entity.HasOne(d => d.achievement).WithMany(p => p.pointList)
                .HasForeignKey(d => d.achievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pointList__achie__06CD04F7");

            entity.HasOne(d => d.bag).WithMany(p => p.pointList)
                .HasForeignKey(d => d.bagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pointList__bagId__05D8E0BE");

            entity.HasOne(d => d.rechargeList).WithMany(p => p.pointList)
                .HasForeignKey(d => d.rechargeListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pointList__recha__04E4BC85");
        });

        modelBuilder.Entity<rechargeList>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__recharge__3213E83FC467A1A3");

            entity.Property(e => e.paymentMode)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.rechargePlan).WithMany(p => p.rechargeList)
                .HasForeignKey(d => d.rechargePlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rechargeL__recha__01142BA1");

            entity.HasOne(d => d.user).WithMany(p => p.rechargeList)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rechargeL__userI__02084FDA");
        });

        modelBuilder.Entity<rechargePlan>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__recharge__3213E83FAF0ADFC3");

            entity.Property(e => e.createdAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.description).HasMaxLength(500);
            entity.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.status).HasDefaultValue(true);
            entity.Property(e => e.updatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__role__3213E83FE94FBD27");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.title)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasMany(d => d.permission).WithMany(p => p.role)
                .UsingEntity<Dictionary<string, object>>(
                    "rolePermission",
                    r => r.HasOne<permission>().WithMany()
                        .HasForeignKey("permissionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__rolePermi__permi__5AEE82B9"),
                    l => l.HasOne<role>().WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__rolePermi__roleI__59FA5E80"),
                    j =>
                    {
                        j.HasKey("roleId", "permissionId").HasName("PK__rolePerm__101A55034A2FE5C6");
                    });
        });

        modelBuilder.Entity<shipping>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__shipping__3213E83F9201019A");

            entity.Property(e => e.contactPhone)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.shippingAddress)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.shippingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.shippingMethod)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.shippingStatus)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasOne(d => d.user).WithMany(p => p.shipping)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__shipping__userId__4AB81AF0");
        });

        modelBuilder.Entity<shippingDetail>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__shipping__3213E83F6536E6E0");

            entity.HasOne(d => d.bag).WithMany(p => p.shippingDetail)
                .HasForeignKey(d => d.bagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__shippingD__bagId__4E88ABD4");

            entity.HasOne(d => d.shipping).WithMany(p => p.shippingDetail)
                .HasForeignKey(d => d.shippingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__shippingD__shipp__4D94879B");
        });

        modelBuilder.Entity<trackingList>(entity =>
        {
            entity.HasKey(e => new { e.userId, e.gachaMachineId }).HasName("PK__tracking__62AB230B2C26096F");

            entity.Property(e => e.noteStatus)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.trackingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.gachaMachine).WithMany(p => p.trackingList)
                .HasForeignKey(d => d.gachaMachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__trackingL__gacha__534D60F1");

            entity.HasOne(d => d.user).WithMany(p => p.trackingList)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__trackingL__userI__52593CB8");
        });

        modelBuilder.Entity<uploadRecord>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__uploadRe__3213E83F973C8D4B");

            entity.Property(e => e.uploadDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.bag).WithMany(p => p.uploadRecord)
                .HasForeignKey(d => d.bagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__uploadRec__bagId__6FE99F9F");
        });

        modelBuilder.Entity<userAchievement>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__userAchi__3213E83FAF8FDCA5");

            entity.Property(e => e.achievedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.achievement).WithMany(p => p.userAchievement)
                .HasForeignKey(d => d.achievementID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userAchie__achie__1DB06A4F");

            entity.HasOne(d => d.user).WithMany(p => p.userAchievement)
                .HasForeignKey(d => d.userID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userAchie__userI__1CBC4616");
        });

        modelBuilder.Entity<userInfo>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__userInfo__3213E83FE163101A");

            entity.HasIndex(e => e.email, "UQ__userInfo__AB6E6164EB89DD83").IsUnique();

            entity.Property(e => e.email)
                .IsRequired()
                .HasMaxLength(254);
            entity.Property(e => e.gender)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(true);
            entity.Property(e => e.phoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.userName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);
        });

        modelBuilder.Entity<userPassword>(entity =>
        {
            entity.HasKey(e => e.email).HasName("PK__userPass__AB6E616537451556");

            entity.Property(e => e.email).HasMaxLength(254);
            entity.Property(e => e.userPassword1)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userPassword");
        });

        modelBuilder.Entity<userVoucher>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__userVouc__3213E83F4965956A");

            entity.Property(e => e.endDate).HasColumnType("datetime");
            entity.Property(e => e.startDate).HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.userVoucher)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userVouch__userI__17F790F9");

            entity.HasOne(d => d.voucher).WithMany(p => p.userVoucher)
                .HasForeignKey(d => d.voucherID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userVouch__vouch__18EBB532");
        });

        modelBuilder.Entity<voucher>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__voucher__3213E83F6E05E036");

            entity.Property(e => e.voucherCode)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.voucherDescription).HasMaxLength(500);
            entity.Property(e => e.voucherName)
                .IsRequired()
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}