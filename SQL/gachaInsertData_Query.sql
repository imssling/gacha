INSERT INTO userInfo (userName, phoneNumber, email, address, gender, points)
VALUES
    ('Tzuyu', '0912345678', 'tzuyu@gmail.com', N'花蓮縣復興路292號', N'女', 0),
    ('Mina', '0948752364', 'mina@gmail.com', N'台南市中西區成功路189號', N'女', 0),
    ('Sana', '0974385296', 'sana@gmail.com', N'嘉義縣和平路491號', N'女', 0),
    ('faker', '0943891253', 'faker@gmail.com', N'雲林縣民族路83號', N'男', 0),
    ('Nlnl', '0973168456', 'Nlnl@gmail.com', N'嘉義縣光復路20號', N'男', 0),
    ('Sullyon', '0911358962', 'sullyon@gmail.com', N'高雄市茄萣區光復路311號', N'女', 0),
    ('Bae', '0974123589', 'bae@gmail.com', N'連江縣信義路293號', N'女', 0),
    ('Yuna', '0985231265', 'yuna@gmail.com', N'雲林縣和平路150號', N'女', 0),
    ('Momo', '0978523654', 'momo@gmail.com', N'台中市西區中山路255號', N'女', 0),
    ('Johnson', '0944123669', 'johnson@gmail.com', N'雲林縣和平路380號', N'男', 0);
GO


-- 插入 userPassword
INSERT INTO userPassword (email, userPassword)
VALUES
    ('tzuyu@gmail.com', 'Tzuyu123'),
    ('mina@gmail.com', 'Mina456'),
    ('sana@gmail.com', 'Sana789'),
    ('faker@gmail.com', 'faker012'),
    ('Nlnl@gmail.com', 'Nlnl877'),
    ('sullyon@gmail.com', 'Sullyon555'),
    ('bae@gmail.com', 'Bae666'),
    ('yuna@gmail.com', 'Yuna999'),
    ('momo@gmail.com', 'Momo123'),
    ('johnson@gmail.com', 'Johnson456');
GO



-- 插入 gachaTheme 
INSERT INTO gachaTheme (themeName)
VALUES
    (N'食物'),
    (N'動漫'),
    (N'小物'),
    (N'動物'),
    (N'偶像'),
    (N'迪士尼'),
    (N'三麗鷗'),
    (N'文具'),
    (N'交通'),
    (N'搞怪');
GO



-- 插入 gachaMachine 資料
INSERT INTO gachaMachine (themeId, machineName, machineDescription, machinePictureName, createTime, price,status)
VALUES
    (1, N'BASE FOOD', NULL, 'BaseFoodMiniatureMascotCharm.jpg', '2024-05-20 17:20:20', 150,N'TRUE'),
    (1, N'維也納外星人', NULL, 'NarabuWiener.jpg', '2024-05-21 17:20:20', 200,N'TRUE'),
    (1, N'等待麵包3', NULL, 'STILLWAITINGFORYOUBREAD3.jpg', '2024-05-22 17:20:20', 150,N'TRUE'),
    (1, N'木村屋總本店迷你紅豆麵包', NULL, 'GINZA-KIMURAYA-SOHONTEN-ANPAN-MINI-CHARM.jpg', '2024-05-23 17:20:20', 150,N'TRUE'),
    (1, N'POMME 蘋果樹迷你蛋包飯吊飾', NULL, 'POMUNOKI-MINIATURE-CHARM.jpg', '2024-05-24 17:20:20', 100,N'TRUE'),
    (2, N'吉伊卡哇系列', NULL, 'ChiikawaCapchara.jpg', '2024-05-25 17:20:20', 250,N'TRUE'),
    (2, N'蠟筆小新烤肉系列', NULL, 'CrayonShin-chan.jpg', '2024-05-26 17:20:20', 150,N'FALSE'),
    (2, N'葬送的芙莉蓮系列', NULL, 'Frieren-Beyond-Journey-End.jpg', '2024-05-27 17:20:20', 200,N'FALSE'),
    (2, N'我獨自升級系列', NULL, 'SoloLeveling.jpg', '2024-05-28 17:20:20', 200,N'FALSE'),
    (2, N'怪獸電力公司系列', NULL, 'MonstersInc.jpg', '2024-05-29 17:20:20', 150,N'FALSE');
GO


-- 插入gachaProduct
INSERT INTO gachaProduct (machineId, productName, stock, productPictureName, createTime)
VALUES
    (1, N'BASEFOOD麵包-巧克力', 50, 'BASEFOODMiniatureMascotCharm-1.jpg', '2024-05-10 17:20:20'),
    (2, N'紅色外星人NarabuWiener', 50, 'narabundesu-wiener-1.jpg', '2024-05-11 17:20:20'),
    (3, N'等待麵包-蛋三明治', 50, 'STILLWAITINGFORYOUBREAD-1.jpg', '2024-05-12 17:20:20'),
    (4, N'酒種紅豆麵包櫻花餡 & 小禮盒', 50, 'GINZA KIMURAYA SOHONTEN ANPAN MINI CHARM-1.jpg', '2024-05-13 17:20:20'),
    (5, N'經典蛋包飯', 50, 'POMUNOKI MINIATURE CHARM-1.jpg', '2024-05-14 17:20:20'),
    (6, N'吉伊卡哇系列-吉伊卡哇', 50, 'ChiikawaCapchara1.jpg', '2024-05-15 17:20:20'),
    (7, N'蠟筆小新烤肉系列-小新和肉', 50, 'CrayonShin-chan1.jpg', '2024-05-16 17:20:20'),
    (8, N'葬送的芙莉蓮系列-芙莉蓮A', 50, 'Frieren-Beyond-Journey-End-1.jpg', '2024-05-17 17:20:20'),
    (9, N'我獨自升級系列-成振宇A', 50, 'SoloLeveling-1.jpg', '2024-05-18 17:20:20'),
    (10, N'怪獸電力公司系列-毛怪', 50, 'MonstersInc-1.jpg', '2024-05-19 17:20:20');
GO



-- 插入 bag
INSERT INTO bag (date, userId, gachaProductId, gachaStatus, isViewed )
VALUES
    ('2024-06-20 15:05:00', 1, 1,N'已上架',1),
    ('2024-06-21 15:05:00', 2, 2,N'新獲得',0),
    ('2024-06-22 15:05:00', 3, 3,N'已上架',1),
    ('2024-06-23 15:05:00', 4, 4,N'新獲得',0),
    ('2024-06-24 15:05:00', 5, 5,N'已交換',1),
    ('2024-06-25 15:05:00', 6, 6,N'已交換',1),
    ('2024-06-26 15:05:00', 7, 7,N'已上架',1),
    ('2024-06-27 15:05:00', 8, 8,N'已交換',1),
    ('2024-06-28 15:05:00', 9, 9,N'新獲得',0),
    ('2024-06-29 15:05:00', 10, 10,N'已上架',1);
GO



-- 插入 shipping 資料
INSERT INTO shipping (userId, shippingDate, shippingStatus, shippingAddress, contactPhone, shippingMethod, shippingFee)
VALUES
    (1, '2024-06-20 18:00:00', N'待處理', N'南投縣和平路215號', '0945963278', N'宅配', 70),
    (2, '2024-06-21 18:00:00', N'已發貨', N'超商地址', N'取件人手機', N'711', 60),
    (3, '2024-06-22 18:00:00', N'已取消', N'超商地址', N'取件人手機', N'711', 60),
    (4, '2024-06-23 18:00:00', N'已完成', N'苗栗縣和平路258號', '0971357412', N'宅配', 70),
    (5, '2024-06-24 18:00:00', N'待處理', N'超商地址', N'取件人手機', N'711', 60),
    (6, '2024-06-25 18:00:00', N'待處理', N'超商地址', N'取件人手機', N'711', 60),
    (7, '2024-06-26 18:00:00', N'待處理', N'超商地址', N'取件人手機', N'711', 60),
    (8, '2024-06-27 18:00:00', N'已發貨', N'高雄市小港區仁愛路231號', '0934972352', N'宅配', 70),
    (9, '2024-06-28 18:00:00', N'已發貨', N'超商地址', N'取件人手機', N'711', 60),
    (10, '2024-06-29 18:00:00', N'已完成', N'超商地址', N'取件人手機', N'711', 60);
GO


-- 插入 shippingDetail 資料
INSERT INTO shippingDetail (shippingId, bagId)
VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 4),
    (5, 5),
    (6, 6),
    (7, 7),
    (8, 8),
    (9, 9),
    (10, 10);
GO


-- 插入 trackingList 資料
INSERT INTO trackingList (userId, gachaMachineId, trackingDate, noteStatus)
VALUES
    (1, 1, '2024-06-21 17:20:20', N'待通知'),
    (2, 2, '2024-06-22 17:20:20', N'待通知'),
    (3, 3, '2024-06-23 17:20:20', N'無須通知'),
    (4, 4, '2024-06-24 17:20:20', N'待通知'),
    (5, 5, '2024-06-25 17:20:20', N'待通知'),
    (6, 6, '2024-06-26 17:20:20', N'已通知'),
    (7, 7, '2024-06-27 17:20:20', N'無須通知'),
    (8, 8, '2024-06-28 17:20:20', N'已通知'),
    (9, 9, '2024-06-29 17:20:20', N'已通知'),
    (10, 10, '2024-06-30 17:20:20', N'已通知');
GO



-- 插入role資料
INSERT INTO role (id, title) VALUES 
(1, '管理員'), (2, '商家');
go


-- 插入 permission 資料
INSERT INTO permission (id, permissionDesc) VALUES 
(1, N'全站管理'), 
(2, N'商品上下架管理');
go



-- 插入 rolePermission 資料
INSERT INTO rolePermission (roleId, permissionId) VALUES 
(1, 1), 
(2, 2);
go



-- 插入 admin 資料
INSERT INTO admin (account, roleId, email, phoneNumber, password,name) VALUES 
( 'aa', 1, 'admin001@example.com', '0912-345-678', '123',N'小明'),
( 'manager002', 2, 'manager002@example.com', '0934-567-890', 'manager2',N'大壯'),
( 'supervisor3', 2, 'supervisor3@example.com', '0967-890-123', 'sup12345',N'小美'),
( 'admin004', 1, 'admin004@example.com', '0956-123-456', 'admin456',N'小王'),
( 'manager005', 2, 'manager005@example.com', '0987-654-321', 'manage5',N'小帥');
go





-- Insert data into convenienceStore Table 超商 (暫存)
INSERT INTO convenienceStore (storeType, storeName, storeAddress, shippingFee)
VALUES
('722', N'中翔', N'南投縣埔里鎮中正路704號', 20),
('722', N'中群', N'苗栗縣頭份市中正路317、319號1樓', 20),
('722', N'松坪', N'高雄市小港區高松路12-26號', 20),
('722', N'自強', N'高雄市前金區自強二路39號', 20),
('722', N'幸福川', N'高雄市前金區自強一路149號1樓2樓', 20),
('FamilyFart', N'籃城', N'南投縣埔里鎮中正路９８１號', 20),
('FamilyFart', N'頭份上公園', N'苗栗縣頭份市中正路３５６號', 20),
('FamilyFart', N'港福', N'高雄市小港區港平路１８號', 20),
('FamilyFart', N'三鳳', N'高雄市前金區中華三路２５１號', 20),
('FamilyFart', N'中華', N'高雄市前金區中華三路２１號１樓', 20);
go


-- Insert data into convenienceStoreInfo Table超商詳細資料
INSERT INTO convenienceStoreInfo (storeId, userId, shippingDetailId)
VALUES
(1, 1, 1),
( 2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5),
(6, 6, 6),
(7, 7, 7),
(8, 8, 8),
(9, 9, 9),
(10, 10, 10);
go



-- 插入 exchangeRecord 資料
INSERT INTO exchangeRecord (userIdFrom, userIdTo, gachaIdFrom, gachaIdTo) VALUES
(1, 2, 1, 2),
(3, 4, 3, 4),
(2, 3, 2, 3),
(4, 1, 4, 1),
(5, 6, 5, 6),
(6, 5, 6, 5),
(7, 8, 7, 8),
(8, 7, 8, 7),
(9, 10, 9, 10),
(10, 9, 10, 9);
go


-- 插入 uploadRecord 資料
INSERT INTO uploadRecord (bagId, wantProductId) VALUES
(1, 10),
(2, 9),
(3, 8),
(4, 7),
(5, 6),
(6, 5),
(7, 4),
(8, 3),
(9, 2),
(10, 1);
go


-- 插入 gachaDetailList 資料
INSERT INTO gachaDetailList (bagId, exchangeRecordId, uploadRecordId,shippingDetailId)
VALUES
    (1, null, null, null),
    (2, null, null, null),
    (3, null, null, null),
    (null, 4, null, null),
    (null, 5, null, null),
    (null, 6, null, null),
    (null, null, 7, null),
    (null, null, 8, null),
    (null, null, null,9),
    (null, null, null,10);
GO


-- 插入 achievement 資料
INSERT INTO achievement ([name], [description], achievementType, [target]) VALUES
(N'初次儲值', N'完成首次儲值。', N'儲值', 1),
(N'連續簽到達人', N'連續簽到7天。', N'簽到', 7),
(N'交換新手', N'成功進行首次交換。', N'交換', 1),
(N'扭蛋初心者', N'累計擁有10個扭蛋。', N'扭蛋擁有數量', 10),
(N'儲值達人', N'累計儲值達到1000元。', N'儲值', 1000),
(N'簽到忠實粉絲', N'累計簽到達到30天。', N'簽到', 30),
(N'交換高手', N'成功進行50次交換。', N'交換', 50),
(N'扭蛋收藏家', N'累計擁有100個扭蛋。', N'扭蛋擁有數量', 100),
(N'儲值大亨', N'單次儲值金額達到500元。', N'儲值', 500),
(N'簽到王', N'簽到30次。', N'簽到', 30);
go



-- 插入 voucher 資料
INSERT INTO voucher (voucherName, voucherCode, voucherDescription, duration) VALUES 
(N'贈100點', 'NEWUSER50', N'搭配活動儲值送優惠', 30),
(N'8折優惠券', 'SUMMER20', N'搭配活動首儲優惠', 60),
(N'9折優惠券', 'SAVE100', N'搭配活動連續簽到送', 10),
(N'85折優惠券', 'MEMBER10', N'搭配活動交換達人', 90),
(N'95折優惠券', 'ANNIV25', N'搭配活動週末驚喜', 7),
(N'8折優惠券', 'WINTER15', N'搭配活動成就大師', 45),
(N'首次購物優惠', 'FIRSTBUY', N'搭配活動2倍送', 30),
(N'贈兩倍點數!', 'XMAS30', N'搭配活動動漫主題日', 15),
(N'85折優惠券', 'LOYALTY50', N'搭配活動我是扭蛋大富翁', 60),
(N'免運券', 'FLASHSALE', N'搭配活動快閃優惠', 3);
go



-- 插入 rechargePlan 資料
INSERT INTO rechargePlan (name, description, point, price, status, createdAt, updatedAt) VALUES 
(N'正五品方案', N'100 點數，無附加優惠。', 100, 100, N'TRUE', '2024-06-20 10:00:00', '2024-06-20 10:00:00'),
(N'正四品方案', N'200 點數，無附加優惠。', 200, 200, N'TRUE', '2024-06-20 10:05:00', '2024-06-20 10:05:00'),
(N'正三品方案', N'500 點數，無附加優惠。', 500, 500, N'TRUE', '2024-06-20 10:10:00', '2024-06-20 10:10:00'),
(N'正二品方案', N'1000 點數，無附加優惠。', 1000, 1000, N'TRUE', '2024-06-20 10:15:00', '2024-06-20 10:15:00'),
(N'正一品方案', N'2000 點數，無附加優惠。', 2000, 2000, N'TRUE', '2024-06-20 10:20:00', '2024-06-20 10:20:00'),
(N'皇后方案', N'5000 點數，無附加優惠。', 5000, 5000, N'TRUE', '2024-06-20 10:25:00', '2024-06-20 10:25:00');
go



-- 插入 rechargeList 資料
INSERT INTO rechargeList (quantity, amount, paymentMode, rechargePlanId, userId)
VALUES
    (1, 100, N'信用卡', 1, 1),
    (2, 500, N'信用卡', 3, 2),
    (1, 300, N'信用卡', 2, 3),
    (1, 100, N'信用卡', 1, 4),
    (3, 500, N'信用卡', 3, 5),
    (2, 300, N'信用卡', 2, 6),
    (1, 100, N'信用卡', 1, 7),
    (1, 500, N'信用卡', 3, 8),
    (2, 300, N'信用卡', 2, 9),
    (1, 100, N'信用卡', 1, 10);
GO



-- 插入 pointList 資料
INSERT INTO pointList (rechargeListId, bagId, achievementId)
VALUES
    (1, null, null),
    (2, null, null),
    (3, null, null),
    (null, 4, null),
    (null, 5, null),
    (null, 6, null),
    (null, 7, null),
    (null,null, 8),
    (null, null, 9),
    (null, null, 10);
GO



-- 插入 announcement 資料
INSERT INTO announcement (title, content, [image]) VALUES
(N'維護通知', N'為了提供更好的服務，我們的系統將於凌晨12點至2點進行維護。請見諒。', 'maintenance.png'),
(N'新功能預告', N'我們正在努力開發新功能，預計下個月推出。敬請期待！', 'features.png'),
(N'假日簽到送', N'假日來臨，只要簽到即可獲得優惠券，不容錯過！', 'sale.png'),
(N'交換活動', N'活動期間交換滿十次，即可獲得八五折優惠券!。', 'exchange_event.png'),
(N'系統更新', N'為了提供更好的用戶體驗，我們的系統將進行更新。請提前做好準備。', 'update.png'),
(N'用戶支援', N'如果您在使用我們的服務時遇到任何問題，請隨時聯繫我們的用戶支援團隊。我們隨時在這裡為您提供幫助。', 'support.png'),
(N'我是扭蛋大富翁', N'只要活動期間內累積獲得50顆扭蛋，即可拿到免運券!', 'upgrade.png'),
(N'新會員禮遇', N'新會員註冊七天內儲值任意面額點數，即可額外獲得八折優惠券，快來加入吧！', 'new_member.png'),
(N'動漫主題日', N'動漫主題系列扭蛋全面打八五折!', 'animeDay.png'),
(N'安全警告', N'為了您的賬號安全，請不要洩露您的個人信息。', 'security.png');
go



-- 插入 activityType 資料
INSERT INTO activityType ([name]) VALUES
(N'儲值'),
(N'簽到'),
(N'成就'),
(N'交換'),
(N'主題日'),
(N'扭蛋擁有數量');
go



-- 插入 activity 資料
INSERT INTO [activity] (title, [description], activityTypeId, activityStart, activityEnd) VALUES
(N'儲值送優惠', N'一次儲值滿1000點即送100點', 1, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'首儲優惠', N'新辦帳戶七天內儲值獲得8折優惠券', 1, '2024-12-01 00:00:00', '2024-12-31 23:59:59'),
(N'連續簽到送', N'連續十天登入送9折優惠券', 2, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'交換達人', N'交換十次獲得85折優惠券', 4, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'週末驚喜', N'假日登入送95折優惠券', 2, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'成就大師', N'十天內獲得五個成就可以拿到8折優惠券', 3, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'2倍送', N'活動期間內儲值獲得兩倍點數!', 1, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'動漫主題日', N'只要符合動漫主題扭蛋所需點數折85折', 5, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'我是扭蛋大富翁', N'期間內只要背包內擁有50顆扭蛋即可免運費', 6, '2024-07-01 00:00:00', '2024-07-31 23:59:59');
go



-- 插入 activityLinkVoucher 資料
INSERT INTO activityLinkVoucher (activityID, voucherID) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9);
go



-- 插入 userVoucher 資料
INSERT INTO userVoucher (userId, voucherID, quantity,startDate , endDate) VALUES
(1, 1, 5,'2024-06-15 00:00:00' , '2024-07-01 00:00:00'),
(2, 2, 10,'2024-06-15 00:00:00' , '2024-07-01 00:00:00'),
(3, 3, 2,'2024-06-15 00:00:00' , '2024-07-01 00:00:00'),
(4, 4, 3,'2024-06-15 00:00:00' , '2024-07-01 00:00:00'),
(5, 5, 7,'2024-06-15 00:00:00' , '2024-07-01 00:00:00'),
(6, 6, 1,'2024-06-15 00:00:00' , '2024-07-01 00:00:00'),
(7, 7, 4,'2024-06-15 00:00:00' , '2024-07-01 00:00:00'),
(8, 8, 6,'2024-06-15 00:00:00' , '2024-07-01 00:00:00'),
(9, 9, 8,'2024-06-15 00:00:00' , '2024-07-01 00:00:00'),
(10, 10, 9,'2024-06-15 00:00:00' , '2024-07-01 00:00:00');
go




-- 插入 userAchievement 資料
INSERT INTO userAchievement (userID, achievementID) VALUES
(1, 10),
(2, 9),
(3, 8),
(4, 7),
(5, 6),
(6, 5),
(7, 4),
(8, 3),
(9, 2),
(10, 1);
go



-- 插入 achievementProgress 資料
INSERT INTO achievementProgress (userID, achievementID, progress, [target]) VALUES
(1, 2, 3, 7),
(2, 2, 5, 7),
(3, 4, 3, 10),
(4, 4, 5, 10),
(5, 5, 512, 1000),
(6, 6, 3, 30),
(7, 7, 10, 50),
(8, 8, 30, 100),
(9, 9, 5, 500),
(10, 10, 15, 30);
go



-- 插入 checkIn 資料
INSERT INTO checkIn (userID) VALUES
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10);
go
