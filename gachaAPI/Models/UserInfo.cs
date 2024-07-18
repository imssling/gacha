﻿using System;
using System.Collections.Generic;

namespace gachaAPI.Models;

public partial class UserInfo
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string Gender { get; set; } = null!;

    public bool? EmailConfirm { get; set; }

    public virtual ICollection<AchievementProgress> AchievementProgresses { get; set; } = new List<AchievementProgress>();

    public virtual ICollection<Bag> Bags { get; set; } = new List<Bag>();

    public virtual ICollection<ChatRoom> ChatRoomUser1s { get; set; } = new List<ChatRoom>();

    public virtual ICollection<ChatRoom> ChatRoomUser2s { get; set; } = new List<ChatRoom>();

    public virtual ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();

    public virtual ICollection<ConvenienceStoreInfo> ConvenienceStoreInfos { get; set; } = new List<ConvenienceStoreInfo>();

    public virtual ICollection<ExchangeRecord> ExchangeRecordUserIdFromNavigations { get; set; } = new List<ExchangeRecord>();

    public virtual ICollection<ExchangeRecord> ExchangeRecordUserIdToNavigations { get; set; } = new List<ExchangeRecord>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<RechargeList> RechargeLists { get; set; } = new List<RechargeList>();

    public virtual ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();

    public virtual ICollection<TrackingList> TrackingLists { get; set; } = new List<TrackingList>();

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();

    public virtual ICollection<UserVoucher> UserVouchers { get; set; } = new List<UserVoucher>();
}
