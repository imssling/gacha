--create database gacha

--�|���򥻸��userInfo Table
CREATE TABLE userInfo (
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY, -- �|��ID-�۰ʼW�q�A�Ω�ߤ@���ѨC�ӭq��
    userName nvarchar(50) NOT NULL, -- �|���m�W
    phoneNumber varchar(20) NOT NULL, -- �q��
    email nvarchar(254) NOT NULL UNIQUE, -- �H�c
    address nvarchar(max), -- �a�}, �p�G�ݭn�x�s�l�H�a�}
    gender nvarchar(10) NOT NULL, -- �ʧO
emailConfirm bit default(0), --�H�c�T�{
emailToken nvarchar(256),  -- token
points int NOT NULL default 0 --�|���`�I��
);
go

 
--�|���K�XuserPassword Table
CREATE TABLE userPassword (
    email nvarchar(254) NOT NULL PRIMARY KEY, -- �H�c
    userPassword varchar(256) NOT NULL -- �|���K�X
);
go

--gachaTheme ��J�D�D��
CREATE TABLE [gachaTheme](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[themeName] [nvarchar](50) NOT NULL,
[status] bit NOT NULL DEFAULT 1,

) 
go

--gachaMachine ��J���x��
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

--gachaProduct ��J���H��
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

--�I�]bag Table
CREATE TABLE bag (
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY, -- �I�]ID
    [date] datetime NOT NULL DEFAULT GETDATE(), -- �[�J�I�]�����
    userId int NOT NULL FOREIGN KEY REFERENCES userInfo(id), -- �ϥΪ� (�~��A�ѷ�userInfo��)
    gachaProductId int NOT NULL FOREIGN KEY REFERENCES [gachaProduct]([id]), -- �ӫ~ID (�~��A�ѷ�Product��)
    gachaStatus nvarchar(50) NOT NULL, -- �洫���A(�w�洫/���洫/�w�W�[)
isViewed bit NOT NULL default(0)  --�O�_�d�ݹL
);
go





--�Ы�shipping
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

--�Ы�shippingDetail
create table shippingDetail(
id int not null identity(1,1),
shippingId int not null,
bagId int not null,
primary key(id),
foreign key(shippingId) references shipping(id),
foreign key(bagId) references bag(id),
);
go

--�Ы�trackingList
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

--�Ы�role
create table  role(
id int not null,
title nvarchar(20) not null ,
primary key(id)
);
go

--�Ы�permission
create table permission(
id int not null,
permissionDesc nvarchar(20) not null ,
primary key(id)
);
go

--�Ы�rolePermission
create table rolePermission (
roleId int not null,
permissionId int not null,
nono int,
primary key (roleId, permissionId),
foreign key(roleId) references role(id),
foreign key(permissionId) references permission(id)
);
go

--�Ы�admin
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

--convenienceStore �W�Ӫ� (�Ȧs)
CREATE TABLE [convenienceStore](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[storeType] [nvarchar](20) NOT NULL,
	[storeName] [nvarchar](20) NOT NULL,
	[storeAddress] [nvarchar](100) NOT NULL,
	[shippingFee] [int] NOT NULL
) 
go

--convenienceStoreInfo �W�ӸԲӪ�
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
 
--�洫������
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



--�W�[�O����]���洫�^
CREATE TABLE uploadRecord (
    id INT PRIMARY KEY identity(1,1),
    bagId INT NOT NULL,
	wantProductId INT NOT NULL,
    uploadDate DATETIME default getDate(),
    FOREIGN KEY (bagId) REFERENCES bag(id),
	FOREIGN KEY (wantProductId) REFERENCES [gachaProduct](id)
);
go

--gachaDetailList ��J�ԲӲ��ʪ�
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


--���N��
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

--�u�f��voucher Table
CREATE TABLE voucher (
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY, -- �u�f��ID
    voucherName nvarchar(50) NOT NULL, -- �u�f��W��
    voucherCode nvarchar(50) NOT NULL, -- �u�f�X
    voucherDescription nvarchar(500), -- �u�f��y�z (Changed to nvarchar(500) to support longer descriptions in Chinese)
 duration INT not null -- �u�f��Ѽ�
);
go


--�x�Ȥ�ת�
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


--�x�Ȭ�����rechargeList Table
-- rechargeList Table
CREATE TABLE rechargeList (
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY, -- �x�Ȭ�������ID
    quantity int NOT NULL, -- �I�ưt�M�ʶR�ƶq
    amount int NOT NULL, -- ���B
    paymentMode nvarchar(50) NOT NULL, -- �I�ڤ覡
    rechargeDate datetime default getDate(), --�x�Ȥ��
    rechargePlanId int NOT NULL FOREIGN KEY REFERENCES rechargePlan(id), -- �x�Ȥ��ID (�~��A�ѷ�rechargePlan��)
    userId int NOT NULL FOREIGN KEY REFERENCES userInfo(id) -- �|��ID (�~��A�ѷ�userInfo��)
);
go

--pointList �I�ƸԲӲ��ʪ�
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


--���i��
CREATE TABLE announcement(
    id INT PRIMARY KEY identity(1,1),
    title NVARCHAR(100) NOT NULL,
    content NVARCHAR(500) NOT NULL,
    [image] NVARCHAR(100),
    createdAt DATETIME default getDate()
);
go



--�������O��
CREATE TABLE activityType(
    id INT PRIMARY KEY identity(1,1),
    [name] NVARCHAR(50) NOT NULL,
    createdAt DATETIME default getDate(),
    [status] bit NOT NULL DEFAULT 1
);
go




--���ʪ�
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

--���ʻP�u�f�����p��
CREATE TABLE activityLinkVoucher(
	id INT PRIMARY KEY identity(1,1),
	activityID INT NOT NULL,
	voucherID INT NOT NULL,
	FOREIGN KEY (activityID) REFERENCES [activity](id),
	FOREIGN KEY (voucherID) REFERENCES voucher(id)
);
go

--�|�������u�f��ƶq��
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



--�ϥΪ̦��N��
CREATE TABLE userAchievement(
    id INT PRIMARY KEY identity(1,1),
    userID INT NOT NULL,
    achievementID INT NOT NULL,
    achievedAt DATETIME default getDate(),
FOREIGN KEY (userID) REFERENCES userInfo(id),
FOREIGN KEY (achievementID) REFERENCES achievement(id)
);
go


--�ϥΪ̦��N�i�ת�
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

--ñ���
CREATE TABLE checkIn(
    id INT PRIMARY KEY identity(1,1),
    userID INT NOT NULL,
    checkInDate DATETIME default getDate(),
FOREIGN KEY (userID) REFERENCES userInfo(id)
);
go

--���u��ѫǪ�
CREATE TABLE chatRoom(
    id INT PRIMARY KEY identity(1,1),
    user1ID INT NOT NULL,
    user2ID INT NOT NULL,
    createdAt DATETIME default getDate(),
FOREIGN KEY (user1ID) REFERENCES userInfo(id),
FOREIGN KEY (user2ID) REFERENCES userInfo(id)
);
go

--���u��ѫǰT����
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



