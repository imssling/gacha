-- Create database gacha (if not already created)
-- CREATE DATABASE gacha;

-- Use the gacha database
-- USE gacha;

-- 會員基本資料 userInfo Table
CREATE TABLE userInfo (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    userName NVARCHAR(50) NOT NULL,
    phoneNumber VARCHAR(20) NOT NULL,
    email NVARCHAR(254) NOT NULL UNIQUE,
    address NVARCHAR(MAX),
    gender NVARCHAR(10) NOT NULL,
    emailConfirm BIT DEFAULT 0
);
GO

-- 會員密碼 userPassword Table
CREATE TABLE userPassword (
    email NVARCHAR(254) NOT NULL PRIMARY KEY,
    userPassword VARCHAR(20) NOT NULL
);
GO

-- 扭蛋主題表 gachaTheme
CREATE TABLE gachaTheme (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    themeName NVARCHAR(50) NOT NULL,
    status BIT NOT NULL DEFAULT 1
);
GO

-- 扭蛋機台表 gachaMachine
CREATE TABLE gachaMachine (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    themeId INT NOT NULL,
    machineName NVARCHAR(100) NOT NULL,
    machineDescription NVARCHAR(500),
    machinePictureName NVARCHAR(100) NOT NULL,
    createTime DATETIME DEFAULT GETDATE(),
    price INT NOT NULL,
    status BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (themeId) REFERENCES gachaTheme(id)
);
GO

-- 扭蛋本人表 gachaProduct
CREATE TABLE gachaProduct (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    machineId INT NOT NULL,
    productName NVARCHAR(100) NOT NULL,
    stock INT NOT NULL,
    productPictureName NVARCHAR(100) NOT NULL,
    createTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (machineId) REFERENCES gachaMachine(id)
);
GO

-- 背包 bag Table
CREATE TABLE bag (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    date DATETIME NOT NULL DEFAULT GETDATE(),
    userId INT NOT NULL,
    gachaProductId INT NOT NULL,
    gachaStatus NVARCHAR(50) NOT NULL,
    FOREIGN KEY (userId) REFERENCES userInfo(id),
    FOREIGN KEY (gachaProductId) REFERENCES gachaProduct(id)
);
GO

-- 創建 shipping
CREATE TABLE shipping (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    userId INT NOT NULL,
    shippingDate DATETIME DEFAULT GETDATE(),
    shippingStatus NVARCHAR(20) NOT NULL,
    shippingAddress NVARCHAR(100) NOT NULL,
    contactPhone VARCHAR(20) NOT NULL,
    shippingMethod NVARCHAR(20) NOT NULL,
    shippingFee INT NOT NULL,
    FOREIGN KEY (userId) REFERENCES userInfo(id)
);
GO

-- 創建 shippingDetail
CREATE TABLE shippingDetail (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    shippingId INT NOT NULL,
    bagId INT NOT NULL,
    FOREIGN KEY (shippingId) REFERENCES shipping(id),
    FOREIGN KEY (bagId) REFERENCES bag(id)
);
GO

-- 創建 trackingList
CREATE TABLE trackingList (
    userId INT NOT NULL,
    gachaMachineId INT NOT NULL,
    trackingDate DATETIME DEFAULT GETDATE(),
    noteStatus NVARCHAR(20) NOT NULL,
    PRIMARY KEY (userId, gachaMachineId),
    FOREIGN KEY (userId) REFERENCES userInfo(id),
    FOREIGN KEY (gachaMachineId) REFERENCES gachaMachine(id)
);
GO

-- 創建 role
CREATE TABLE role (
    id INT NOT NULL PRIMARY KEY,
    title NVARCHAR(20) NOT NULL
);
GO

-- 創建 permission
CREATE TABLE permission (
    id INT NOT NULL PRIMARY KEY,
    permissionDesc NVARCHAR(20) NOT NULL
);
GO

-- 創建 rolePermission
CREATE TABLE rolePermission (
    roleId INT NOT NULL,
    permissionId INT NOT NULL,
    PRIMARY KEY (roleId, permissionId),
    FOREIGN KEY (roleId) REFERENCES role(id),
    FOREIGN KEY (permissionId) REFERENCES permission(id)
);
GO

-- 創建 admin
CREATE TABLE admin (
    account VARCHAR(30) NOT NULL PRIMARY KEY,
    name NVARCHAR(10) NOT NULL,
    roleId INT NOT NULL,
    email VARCHAR(50) NOT NULL,
    phoneNumber NVARCHAR(20) NOT NULL,
    password VARCHAR(20) NOT NULL,
    FOREIGN KEY (roleId) REFERENCES role(id)
);
GO

-- 創建 convenienceStore
CREATE TABLE convenienceStore (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    storeType NVARCHAR(20) NOT NULL,
    storeName NVARCHAR(20) NOT NULL,
    storeAddress NVARCHAR(100) NOT NULL,
    shippingFee INT NOT NULL
);
GO

-- 創建 convenienceStoreInfo
CREATE TABLE convenienceStoreInfo (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    storeId INT NOT NULL,
    userId INT NOT NULL,
    shippingDetailId INT NOT NULL,
    FOREIGN KEY (storeId) REFERENCES convenienceStore(id),
    FOREIGN KEY (userId) REFERENCES userInfo(id),
    FOREIGN KEY (shippingDetailId) REFERENCES shippingDetail(id)
);
GO

-- 創建 exchangeRecord
CREATE TABLE exchangeRecord (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    userIdFrom INT,
    userIdTo INT,
    gachaIdFrom INT,
    gachaIdTo INT,
    exchangeDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (userIdFrom) REFERENCES userInfo(id),
    FOREIGN KEY (userIdTo) REFERENCES userInfo(id),
    FOREIGN KEY (gachaIdFrom) REFERENCES gachaProduct(id),
    FOREIGN KEY (gachaIdTo) REFERENCES gachaProduct(id)
);
GO

-- 創建 uploadRecord
CREATE TABLE uploadRecord (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    bagId INT NOT NULL,
    uploadDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (bagId) REFERENCES bag(id)
);
GO

-- 創建 gachaDetailList
CREATE TABLE gachaDetailList (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    bagId INT,
    exchangeRecordId INT,
    uploadRecordId INT,
    shippingDetailId INT,
    FOREIGN KEY (bagId) REFERENCES bag(id),
    FOREIGN KEY (exchangeRecordId) REFERENCES exchangeRecord(id),
    FOREIGN KEY (uploadRecordId) REFERENCES uploadRecord(id),
    FOREIGN KEY (shippingDetailId) REFERENCES shippingDetail(id)
);
GO

-- 創建 achievement
CREATE TABLE achievement (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(500),
    achievementType NVARCHAR(50),
    target INT NOT NULL,
    createdAt DATETIME DEFAULT GETDATE()
);
GO

-- 創建 voucher
CREATE TABLE voucher (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    voucherName NVARCHAR(50) NOT NULL,
    voucherCode NVARCHAR(50) NOT NULL,
    voucherDescription NVARCHAR(500),
    duration INT NOT NULL
);
GO

-- 創建 rechargePlan
CREATE TABLE rechargePlan (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(500),
    point INT NOT NULL,
    price INT NOT NULL,
    status BIT NOT NULL DEFAULT 1,
    createdAt DATETIME DEFAULT GETDATE(),
    updatedAt DATETIME DEFAULT GETDATE()
);
GO

-- 創建 rechargeList
CREATE TABLE rechargeList (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    quantity INT NOT NULL,
    amount INT NOT NULL,
    paymentMode NVARCHAR(50) NOT NULL,
    rechargeDate DATETIME DEFAULT GETDATE(),
    rechargePlanId INT NOT NULL,
    userId INT NOT NULL,
    FOREIGN KEY (rechargePlanId) REFERENCES rechargePlan(id),
    FOREIGN KEY (userId) REFERENCES userInfo(id)
);
GO

-- 創建 pointList
CREATE TABLE pointList (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    rechargeListId INT,
    bagId INT,
    achievementId INT,
    FOREIGN KEY (rechargeListId) REFERENCES rechargeList(id),
    FOREIGN KEY (bagId) REFERENCES bag(id),
    FOREIGN KEY (achievementId) REFERENCES achievement(id)
);
GO

-- 創建 announcement
CREATE TABLE announcement (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    title NVARCHAR(100) NOT NULL,
    content NVARCHAR(500) NOT NULL,
    image NVARCHAR(100),
    createdAt DATETIME DEFAULT GETDATE()
);
GO

-- 創建 activityType
CREATE TABLE activityType (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    createdAt DATETIME DEFAULT GETDATE(),
    status BIT NOT NULL DEFAULT 1
);
GO

-- 創建 activity
CREATE TABLE activity (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    title NVARCHAR(100) NOT NULL,
    description NVARCHAR(500),
    status BIT NOT NULL DEFAULT 1,
    activityTypeId INT NOT NULL,
    createdAt DATETIME DEFAULT GETDATE(),
    activityStart DATETIME,
    activityEnd DATETIME,
    FOREIGN KEY (activityTypeId) REFERENCES activityType(id)
);
GO

-- 創建 activityLinkVoucher
CREATE TABLE activityLinkVoucher (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    activityID INT NOT NULL,
    voucherID INT NOT NULL,
    FOREIGN KEY (activityID) REFERENCES activity(id),
    FOREIGN KEY (voucherID) REFERENCES voucher(id)
);
GO

-- 創建 userVoucher
CREATE TABLE userVoucher (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    userId INT NOT NULL,
    voucherID INT NOT NULL,
    quantity INT NOT NULL,
    startDate DATETIME NOT NULL,
    endDate DATETIME NOT NULL,
    FOREIGN KEY (userId) REFERENCES userInfo(id),
    FOREIGN KEY (voucherID) REFERENCES voucher(id)
);
GO

-- 創建 userAchievement
CREATE TABLE userAchievement (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    userID INT NOT NULL,
    achievementID INT NOT NULL,
    achievedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (userID) REFERENCES userInfo(id),
    FOREIGN KEY (achievementID) REFERENCES achievement(id)
);
GO

-- 創建 achievementProgress
CREATE TABLE achievementProgress (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    userID INT NOT NULL,
    achievementID INT NOT NULL,
    progress INT NOT NULL,
    target INT NOT NULL,
    FOREIGN KEY (userID) REFERENCES userInfo(id),
    FOREIGN KEY (achievementID) REFERENCES achievement(id)
);
GO

-- 創建 checkIn
CREATE TABLE checkIn (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    userID INT NOT NULL,
    checkInDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (userID) REFERENCES userInfo(id)
);
GO

-- 創建 chatRoom
CREATE TABLE chatRoom (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    user1ID INT NOT NULL,
    user2ID INT NOT NULL,
    createdAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user1ID) REFERENCES userInfo(id),
    FOREIGN KEY (user2ID) REFERENCES userInfo(id)
);
GO

-- 創建 message
CREATE TABLE message (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    chatRoomID INT NOT NULL,
    senderID INT NOT NULL,
    content NVARCHAR(500),
    sendDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (chatRoomID) REFERENCES chatRoom(id),
    FOREIGN KEY (senderID) REFERENCES userInfo(id)
);
GO
