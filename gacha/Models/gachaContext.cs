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

    public virtual DbSet<rolePermission> rolePermission { get; set; }

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
            entity.HasKey(e => e.id).HasName("PK__achievem__3213E83FB8FF15EA");

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
            entity.HasKey(e => e.id).HasName("PK__achievem__3213E83F4C305089");

            entity.HasOne(d => d.achievement).WithMany(p => p.achievementProgress)
                .HasForeignKey(d => d.achievementID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__achieveme__achie__1332DBDC");

            entity.HasOne(d => d.user).WithMany(p => p.achievementProgress)
                .HasForeignKey(d => d.userID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__achieveme__userI__123EB7A3");
        });

        modelBuilder.Entity<activity>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__activity__3213E83FD6BD5F10");

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
                .HasConstraintName("FK__activity__activi__02FC7413");
        });

        modelBuilder.Entity<activityLinkVoucher>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__activity__3213E83F5FC4242E");

            entity.HasOne(d => d.activity).WithMany(p => p.activityLinkVoucher)
                .HasForeignKey(d => d.activityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activityL__activ__05D8E0BE");

            entity.HasOne(d => d.voucher).WithMany(p => p.activityLinkVoucher)
                .HasForeignKey(d => d.voucherID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activityL__vouch__06CD04F7");
        });

        modelBuilder.Entity<activityType>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__activity__3213E83F38356440");

            entity.Property(e => e.createdAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<admin>(entity =>
        {
            entity.HasKey(e => e.account).HasName("PK__admin__EA162E1058964464");

            entity.Property(e => e.account)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(10);
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
                .HasConstraintName("FK__admin__roleId__4E88ABD4");
        });

        modelBuilder.Entity<announcement>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__announce__3213E83F2571612E");

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
            entity.HasKey(e => e.id).HasName("PK__bag__3213E83F4E97CDE0");

            entity.Property(e => e.date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.gachaStatus)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.gachaProduct).WithMany(p => p.bag)
                .HasForeignKey(d => d.gachaProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bag__gachaProduc__37A5467C");

            entity.HasOne(d => d.user).WithMany(p => p.bag)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bag__userId__36B12243");
        });

        modelBuilder.Entity<chatRoom>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__chatRoom__3213E83F9F20B21D");

            entity.Property(e => e.createdAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.user1).WithMany(p => p.chatRoomuser1)
                .HasForeignKey(d => d.user1ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chatRoom__user1I__1AD3FDA4");

            entity.HasOne(d => d.user2).WithMany(p => p.chatRoomuser2)
                .HasForeignKey(d => d.user2ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chatRoom__user2I__1BC821DD");
        });

        modelBuilder.Entity<checkIn>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__checkIn__3213E83F70A68191");

            entity.Property(e => e.checkInDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.checkIn)
                .HasForeignKey(d => d.userID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__checkIn__userID__17036CC0");
        });

        modelBuilder.Entity<convenienceStore>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__convenie__3213E83FD8C9655F");

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
            entity.HasKey(e => e.Id).HasName("PK__convenie__3214EC070AFF43F4");

            entity.HasOne(d => d.shippingDetail).WithMany(p => p.convenienceStoreInfo)
                .HasForeignKey(d => d.shippingDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__shipp__5535A963");

            entity.HasOne(d => d.store).WithMany(p => p.convenienceStoreInfo)
                .HasForeignKey(d => d.storeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__store__5441852A");

            entity.HasOne(d => d.user).WithMany(p => p.convenienceStoreInfo)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__convenien__userI__534D60F1");
        });

        modelBuilder.Entity<exchangeRecord>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__exchange__3213E83F46E5F884");

            entity.Property(e => e.exchangeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.gachaIdFromNavigation).WithMany(p => p.exchangeRecordgachaIdFromNavigation)
                .HasForeignKey(d => d.gachaIdFrom)
                .HasConstraintName("FK__exchangeR__gacha__5AEE82B9");

            entity.HasOne(d => d.gachaIdToNavigation).WithMany(p => p.exchangeRecordgachaIdToNavigation)
                .HasForeignKey(d => d.gachaIdTo)
                .HasConstraintName("FK__exchangeR__gacha__5BE2A6F2");

            entity.HasOne(d => d.userIdFromNavigation).WithMany(p => p.exchangeRecorduserIdFromNavigation)
                .HasForeignKey(d => d.userIdFrom)
                .HasConstraintName("FK__exchangeR__userI__59063A47");

            entity.HasOne(d => d.userIdToNavigation).WithMany(p => p.exchangeRecorduserIdToNavigation)
                .HasForeignKey(d => d.userIdTo)
                .HasConstraintName("FK__exchangeR__userI__59FA5E80");
        });

        modelBuilder.Entity<gachaDetailList>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__gachaDet__3213E83FE8D180C4");

            entity.HasOne(d => d.bag).WithMany(p => p.gachaDetailList)
                .HasForeignKey(d => d.bagId)
                .HasConstraintName("FK__gachaDeta__bagId__628FA481");

            entity.HasOne(d => d.exchangeRecord).WithMany(p => p.gachaDetailList)
                .HasForeignKey(d => d.exchangeRecordId)
                .HasConstraintName("FK__gachaDeta__excha__6383C8BA");

            entity.HasOne(d => d.shippingDetail).WithMany(p => p.gachaDetailList)
                .HasForeignKey(d => d.shippingDetailId)
                .HasConstraintName("FK__gachaDeta__shipp__656C112C");

            entity.HasOne(d => d.uploadRecord).WithMany(p => p.gachaDetailList)
                .HasForeignKey(d => d.uploadRecordId)
                .HasConstraintName("FK__gachaDeta__uploa__6477ECF3");
        });

        modelBuilder.Entity<gachaMachine>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__gachaMac__3213E83F74F58690");

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
            entity.Property(e => e.status).HasDefaultValue(true);

            entity.HasOne(d => d.theme).WithMany(p => p.gachaMachine)
                .HasForeignKey(d => d.themeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gachaMach__theme__2F10007B");
        });

        modelBuilder.Entity<gachaProduct>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__gachaPro__3213E83FCB7DE642");

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
                .HasConstraintName("FK__gachaProd__machi__32E0915F");
        });

        modelBuilder.Entity<gachaTheme>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__gachaThe__3213E83F47350142");

            entity.Property(e => e.status).HasDefaultValue(true);
            entity.Property(e => e.themeName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<message>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__message__3213E83FF269ECFD");

            entity.Property(e => e.content).HasMaxLength(500);
            entity.Property(e => e.sendDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.chatRoom).WithMany(p => p.message)
                .HasForeignKey(d => d.chatRoomID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message__chatRoo__1F98B2C1");

            entity.HasOne(d => d.sender).WithMany(p => p.message)
                .HasForeignKey(d => d.senderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message__senderI__208CD6FA");
        });

        modelBuilder.Entity<permission>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__permissi__3213E83FC9C24127");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.permissionDesc)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<pointList>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__pointLis__3213E83FCCB26DC5");

            entity.HasOne(d => d.achievement).WithMany(p => p.pointList)
                .HasForeignKey(d => d.achievementId)
                .HasConstraintName("FK__pointList__achie__787EE5A0");

            entity.HasOne(d => d.bag).WithMany(p => p.pointList)
                .HasForeignKey(d => d.bagId)
                .HasConstraintName("FK__pointList__bagId__778AC167");

            entity.HasOne(d => d.rechargeList).WithMany(p => p.pointList)
                .HasForeignKey(d => d.rechargeListId)
                .HasConstraintName("FK__pointList__recha__76969D2E");
        });

        modelBuilder.Entity<rechargeList>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__recharge__3213E83FDE8A527D");

            entity.Property(e => e.paymentMode)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.rechargeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.rechargePlan).WithMany(p => p.rechargeList)
                .HasForeignKey(d => d.rechargePlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rechargeL__recha__72C60C4A");

            entity.HasOne(d => d.user).WithMany(p => p.rechargeList)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rechargeL__userI__73BA3083");
        });

        modelBuilder.Entity<rechargePlan>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__recharge__3213E83FCA7B7F63");

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
            entity.HasKey(e => e.id).HasName("PK__role__3213E83F23533654");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.title)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<rolePermission>(entity =>
        {
            entity.HasKey(e => new { e.roleId, e.permissionId }).HasName("PK__rolePerm__101A550384658F50");

            entity.HasOne(d => d.permission).WithMany(p => p.rolePermission)
                .HasForeignKey(d => d.permissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rolePermi__permi__4BAC3F29");

            entity.HasOne(d => d.role).WithMany(p => p.rolePermission)
                .HasForeignKey(d => d.roleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rolePermi__roleI__4AB81AF0");
        });

        modelBuilder.Entity<shipping>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__shipping__3213E83F67FBC34F");

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
                .HasConstraintName("FK__shipping__userId__3B75D760");
        });

        modelBuilder.Entity<shippingDetail>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__shipping__3213E83FC2484DB6");

            entity.HasOne(d => d.bag).WithMany(p => p.shippingDetail)
                .HasForeignKey(d => d.bagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__shippingD__bagId__3F466844");

            entity.HasOne(d => d.shipping).WithMany(p => p.shippingDetail)
                .HasForeignKey(d => d.shippingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__shippingD__shipp__3E52440B");
        });

        modelBuilder.Entity<trackingList>(entity =>
        {
            entity.HasKey(e => new { e.userId, e.gachaMachineId }).HasName("PK__tracking__62AB230BBE4D9406");

            entity.Property(e => e.noteStatus)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.trackingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.gachaMachine).WithMany(p => p.trackingList)
                .HasForeignKey(d => d.gachaMachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__trackingL__gacha__440B1D61");

            entity.HasOne(d => d.user).WithMany(p => p.trackingList)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__trackingL__userI__4316F928");
        });

        modelBuilder.Entity<uploadRecord>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__uploadRe__3213E83F2619A0BF");

            entity.Property(e => e.uploadDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.bag).WithMany(p => p.uploadRecord)
                .HasForeignKey(d => d.bagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__uploadRec__bagId__5FB337D6");
        });

        modelBuilder.Entity<userAchievement>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__userAchi__3213E83F05540D89");

            entity.Property(e => e.achievedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.achievement).WithMany(p => p.userAchievement)
                .HasForeignKey(d => d.achievementID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userAchie__achie__0F624AF8");

            entity.HasOne(d => d.user).WithMany(p => p.userAchievement)
                .HasForeignKey(d => d.userID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userAchie__userI__0E6E26BF");
        });

        modelBuilder.Entity<userInfo>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__userInfo__3213E83F4751E5EF");

            entity.HasIndex(e => e.email, "UQ__userInfo__AB6E61648FD44934").IsUnique();

            entity.Property(e => e.email)
                .IsRequired()
                .HasMaxLength(254);
            entity.Property(e => e.emailConfirm).HasDefaultValue(false);
            entity.Property(e => e.gender)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.phoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.userName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<userPassword>(entity =>
        {
            entity.HasKey(e => e.email).HasName("PK__userPass__AB6E6165D15698AB");

            entity.Property(e => e.email).HasMaxLength(254);
            entity.Property(e => e.userPassword1)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userPassword");
        });

        modelBuilder.Entity<userVoucher>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__userVouc__3213E83F2487ED70");

            entity.Property(e => e.endDate).HasColumnType("datetime");
            entity.Property(e => e.startDate).HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.userVoucher)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userVouch__userI__09A971A2");

            entity.HasOne(d => d.voucher).WithMany(p => p.userVoucher)
                .HasForeignKey(d => d.voucherID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userVouch__vouch__0A9D95DB");
        });

        modelBuilder.Entity<voucher>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__voucher__3213E83F661A658F");

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