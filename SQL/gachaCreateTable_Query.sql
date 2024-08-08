--create database gacha

--會員基本資料userInfo Table
CREATE TABLE userInfo (
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY, -- 會員ID-自動增量，用於唯一標識每個訂單
    userName nvarchar(50) NOT NULL, -- 會員姓名
    phoneNumber varchar(20) NOT NULL, -- 電話
    email nvarchar(254) NOT NULL UNIQUE, -- 信箱
    address nvarchar(max), -- 地址, 如果需要儲存郵寄地址
    gender nvarchar(10) NOT NULL, -- 性別
emailConfirm bit default(0), --信箱確認
emailToken nvarchar(256),  -- token
points int NOT NULL default 0 --會員總點數
);
go

 
--會員密碼userPassword Table
CREATE TABLE userPassword (
    email nvarchar(254) NOT NULL PRIMARY KEY, -- 信箱
    userPassword varchar(256) NOT NULL -- 會員密碼
);
go

--gachaTheme 扭蛋主題表
CREATE TABLE [gachaTheme](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[themeName] [nvarchar](50) NOT NULL,
[status] bit NOT NULL DEFAULT 1,

) 
go

--gachaMachine 扭蛋機台表
CREATE TABLE [dbo].[gachaMachine](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[themeId] [int] NOT NULL,
	[machineName] [nvarchar](100) NOT NULL,
	[machineDescription] [nvarchar](500) NULL,
	[machinePictureName] [nvarchar](100) NOT NULL,
	[createTime] [datetime] default getDate(),
	[price] [int] NOT NULL,
[status] bit NOT NULL DEFAULT 1,

FOREIGN KEY (themeId) REFERENCES gachaTheme(id)
) 
go

--gachaProduct 扭蛋本人表
CREATE TABLE [gachaProduct](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[machineId] [int] NOT NULL,
	[productName] [nvarchar](100) NOT NULL,
	[stock] [int] NOT NULL,
	[productPictureName] [nvarchar](100) NOT NULL,
	[createTime] [datetime] default getDate(),
FOREIGN KEY (machineId) REFERENCES gachaMachine(id)
) 
go

--背包bag Table
CREATE TABLE bag (
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY, -- 背包ID
    [date] datetime NOT NULL DEFAULT GETDATE(), -- 加入背包的日期
    userId int NOT NULL FOREIGN KEY REFERENCES userInfo(id), -- 使用者 (外鍵，參照userInfo表)
    gachaProductId int NOT NULL FOREIGN KEY REFERENCES [gachaProduct]([id]), -- 商品ID (外鍵，參照Product表)
    gachaStatus nvarchar(50) NOT NULL, -- 交換狀態(已交換/未交換/已上架)
isViewed bit NOT NULL default(0)  --是否查看過
);
go





--創建shipping
create table [shipping](
id int not null identity(1,1),
userId int not null,
shippingDate datetime default getdate(),
shippingStatus nvarchar(20) not null,
shippingAddress nvarchar(100) not null,
contactPhone varchar(20) not null,
shippingMethod nvarchar(20) not null,
shippingFee int not null,
primary key(id),
foreign key(userId) references userInfo(id)
);
go

--創建shippingDetail
create table shippingDetail(
id int not null identity(1,1),
shippingId int not null,
bagId int not null,
primary key(id),
foreign key(shippingId) references shipping(id),
foreign key(bagId) references bag(id),
);
go

--創建trackingList
create table trackingList(
userId int not null,
gachaMachineId int not null,
trackingDate datetime default getdate(),
noteStatus nvarchar(20) not null,
primary key(userId, gachaMachineId),
foreign key(userId) references userInfo(id),
foreign key(gachaMachineId) references gachaMachine(id)
);
go

--創建role
create table  role(
id int not null,
title nvarchar(20) not null ,
primary key(id)
);
go

--創建permission
create table permission(
id int not null,
permissionDesc nvarchar(20) not null ,
primary key(id)
);
go

--創建rolePermission
create table rolePermission (
roleId int not null,
permissionId int not null,
nono int,
primary key (roleId, permissionId),
foreign key(roleId) references role(id),
foreign key(permissionId) references permission(id)
);
go

--創建admin
create table admin (
account varchar(30) not null,
name nvarchar(10) not null,
roleId int not null,
email varchar(50) not null,
phoneNumber nvarchar(20) not null,
password varchar(256) not null,
primary key (account ),
foreign key(roleId) references role(id)
);
go

--convenienceStore 超商表 (暫存)
CREATE TABLE [convenienceStore](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[storeType] [nvarchar](20) NOT NULL,
	[storeName] [nvarchar](20) NOT NULL,
	[storeAddress] [nvarchar](100) NOT NULL,
	[shippingFee] [int] NOT NULL
) 
go

--convenienceStoreInfo 超商詳細表
CREATE TABLE [convenienceStoreInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[storeId] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[shippingDetailId] [int] NOT NULL,
	FOREIGN KEY (userId) REFERENCES userInfo(id),
FOREIGN KEY (storeId) REFERENCES convenienceStore(id),
FOREIGN KEY (shippingDetailId) REFERENCES shippingDetail(id)
)
go
 
--交換紀錄表
CREATE TABLE exchangeRecord (
    id INT PRIMARY KEY identity(1,1),
    userIdFrom INT,
    userIdTo INT,
    gachaIdFrom INT,
    gachaIdTo INT,
    exchangeDate DATETIME default getDate(),
    FOREIGN KEY (userIdFrom) REFERENCES userInfo(id),
    FOREIGN KEY (userIdTo) REFERENCES userInfo(id),
    FOREIGN KEY (gachaIdFrom) REFERENCES [gachaProduct]([id]),
    FOREIGN KEY (gachaIdTo) REFERENCES [gachaProduct]([id])
);
go



--上架記錄表（未交換）
CREATE TABLE uploadRecord (
    id INT PRIMARY KEY identity(1,1),
    bagId INT NOT NULL,
	wantProductId INT NOT NULL,
    uploadDate DATETIME default getDate(),
    FOREIGN KEY (bagId) REFERENCES bag(id),
	FOREIGN KEY (wantProductId) REFERENCES [gachaProduct](id)
);
go

--gachaDetailList 扭蛋詳細異動表
CREATE TABLE [gachaDetailList](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[bagId] [int],
	[exchangeRecordId] [int],
	[uploadRecordId] [int],
[shippingDetailId] [int],
 	FOREIGN KEY (bagId) REFERENCES bag(id),
	FOREIGN KEY (exchangeRecordId) REFERENCES exchangeRecord(id),
	FOREIGN KEY (uploadRecordId) REFERENCES uploadRecord(id),
FOREIGN KEY (shippingDetailId) REFERENCES shippingDetail(id),



)
go 


--成就表
CREATE TABLE achievement(
    id INT PRIMARY KEY identity(1,1),
    [name] NVARCHAR(100) NOT NULL,
    [description] NVARCHAR(500),
    achievementType NVARCHAR(50),
    --point INT NOT NULL,
    [target] INT NOT NULL,
    createdAt DATETIME default getDate()
);
go

--優惠券voucher Table
CREATE TABLE voucher (
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY, -- 優惠券ID
    voucherName nvarchar(50) NOT NULL, -- 優惠券名稱
    voucherCode nvarchar(50) NOT NULL, -- 優惠碼
    voucherDescription nvarchar(500), -- 優惠券描述 (Changed to nvarchar(500) to support longer descriptions in Chinese)
 duration INT not null -- 優惠券天數
);
go


--儲值方案表
CREATE TABLE rechargePlan (
    id INT PRIMARY KEY identity(1,1),
    [name] NVARCHAR(100) NOT NULL,
    [description] NVARCHAR(500),
    point INT NOT NULL,
    price INT NOT NULL,
    [status] bit NOT NULL DEFAULT 1,
    createdAt DATETIME default getDate(),
    updatedAt DATETIME default getDate()
);
go


--儲值紀錄表rechargeList Table
-- rechargeList Table
CREATE TABLE rechargeList (
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY, -- 儲值紀錄明細ID
    quantity int NOT NULL, -- 點數配套購買數量
    amount int NOT NULL, -- 金額
    paymentMode nvarchar(50) NOT NULL, -- 付款方式
    rechargeDate datetime default getDate(), --儲值日期
    rechargePlanId int NOT NULL FOREIGN KEY REFERENCES rechargePlan(id), -- 儲值方案ID (外鍵，參照rechargePlan表)
    userId int NOT NULL FOREIGN KEY REFERENCES userInfo(id) -- 會員ID (外鍵，參照userInfo表)
);
go

--pointList 點數詳細異動表
CREATE TABLE [pointList](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[rechargeListId] [int],
	[bagId] [int],
	[achievementId] [int],
	[changedPoint] [int],
FOREIGN KEY (rechargeListId) REFERENCES rechargeList(id),
FOREIGN KEY (bagId) REFERENCES bag(id),
FOREIGN KEY (achievementId) REFERENCES achievement(id)
) 
go


--公告表
CREATE TABLE announcement(
    id INT PRIMARY KEY identity(1,1),
    title NVARCHAR(100) NOT NULL,
    content NVARCHAR(500) NOT NULL,
    [image] NVARCHAR(100),
    createdAt DATETIME default getDate()
);
go



--活動類別表
CREATE TABLE activityType(
    id INT PRIMARY KEY identity(1,1),
    [name] NVARCHAR(50) NOT NULL,
    createdAt DATETIME default getDate(),
    [status] bit NOT NULL DEFAULT 1
);
go




--活動表
CREATE TABLE [activity](
    id INT PRIMARY KEY identity(1,1),
    title NVARCHAR(100) NOT NULL,
    [description] NVARCHAR(500),
	[status] bit NOT NULL DEFAULT 1,
	activityTypeId INT NOT NULL,
    createdAt DATETIME default getDate(),
    activityStart DATETIME,
    activityEnd DATETIME,
	FOREIGN KEY (activityTypeId) REFERENCES activityType(id)
);
go

--活動與優惠券關聯表
CREATE TABLE activityLinkVoucher(
	id INT PRIMARY KEY identity(1,1),
	activityID INT NOT NULL,
	voucherID INT NOT NULL,
	FOREIGN KEY (activityID) REFERENCES [activity](id),
	FOREIGN KEY (voucherID) REFERENCES voucher(id)
);
go

--會員持有優惠券數量表
CREATE TABLE userVoucher(
	id INT PRIMARY KEY identity(1,1),
	userId INT NOT NULL,
	voucherID INT NOT NULL,
	quantity INT NOT NULL,
	startDate datetime not null,
	endDate datetime not null,
	FOREIGN KEY (userId) REFERENCES userInfo(id),
	FOREIGN KEY (voucherID) REFERENCES voucher(id)
);
go



--使用者成就表
CREATE TABLE userAchievement(
    id INT PRIMARY KEY identity(1,1),
    userID INT NOT NULL,
    achievementID INT NOT NULL,
    achievedAt DATETIME default getDate(),
FOREIGN KEY (userID) REFERENCES userInfo(id),
FOREIGN KEY (achievementID) REFERENCES achievement(id)
);
go


--使用者成就進度表
CREATE TABLE achievementProgress(
    id INT PRIMARY KEY identity(1,1),
    userID INT NOT NULL,
    achievementID INT NOT NULL,
    progress INT NOT NULL,
    [target] INT NOT NULL,
FOREIGN KEY (userID) REFERENCES userInfo(id),
FOREIGN KEY (achievementID) REFERENCES achievement(id)
);
go

--簽到表
CREATE TABLE checkIn(
    id INT PRIMARY KEY identity(1,1),
    userID INT NOT NULL,
    checkInDate DATETIME default getDate(),
FOREIGN KEY (userID) REFERENCES userInfo(id)
);
go

--離線聊天室表
CREATE TABLE chatRoom(
    id INT PRIMARY KEY identity(1,1),
    user1ID INT NOT NULL,
    user2ID INT NOT NULL,
    createdAt DATETIME default getDate(),
FOREIGN KEY (user1ID) REFERENCES userInfo(id),
FOREIGN KEY (user2ID) REFERENCES userInfo(id)
);
go

--離線聊天室訊息表
CREATE TABLE message(
    id INT PRIMARY KEY identity(1,1),
    chatRoomID INT NOT NULL,
    senderID INT NOT NULL,
    content nvarchar(500),
    sendDate DATETIME default getDate(),
FOREIGN KEY (chatRoomID) REFERENCES chatRoom(id),
FOREIGN KEY (senderID) REFERENCES userInfo(id)
);
go



