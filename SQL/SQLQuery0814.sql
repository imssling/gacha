
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
--1
    (1, N'BASE FOOD', NULL, 'BaseFoodMiniatureMascotCharm.jpg', '2024-05-20 17:20:20', 150,N'TRUE'),
	--2
    (1, N'維也納外星人', NULL, 'NarabuWiener.jpg', '2024-05-21 17:20:20', 200,N'TRUE'),
	--3
    (1, N'等待麵包3', NULL, 'STILLWAITINGFORYOUBREAD3.jpg', '2024-05-22 17:20:20', 150,N'TRUE'),
	--4
    (1, N'木村屋總本店迷你紅豆麵包', NULL, 'GINZA-KIMURAYA-SOHONTEN-ANPAN-MINI-CHARM.jpg', '2024-05-23 17:20:20', 150,N'TRUE'),
	--5
    (1, N'POMME 蘋果樹迷你蛋包飯吊飾', NULL, 'POMUNOKI-MINIATURE-CHARM.jpg', '2024-05-24 17:20:20', 100,N'TRUE'),
	--6
    (2, N'吉伊卡哇系列', NULL, 'ChiikawaCapchara.jpg', '2024-05-25 17:20:20', 250,N'TRUE'),
	--7
    (2, N'蠟筆小新烤肉系列', NULL, 'CrayonShin-chan.jpg', '2024-05-26 17:20:20', 150,N'FALSE'),
	--8
    (2, N'葬送的芙莉蓮系列', NULL, 'Frieren-Beyond-Journey-End.jpg', '2024-05-27 17:20:20', 200,N'FALSE'),
	--9
    (2, N'我獨自升級系列', NULL, 'SoloLeveling.jpg', '2024-05-28 17:20:20', 200,N'FALSE'),
	--10
    (2, N'怪獸電力公司系列', NULL, 'MonstersInc.jpg', '2024-05-29 17:20:20', 150,N'FALSE'),
		--11
(3, N'漫威扭蛋鞋子系列', NULL, 'marvel-shoes.jpg', '2024-08-12 13:45:30', 150, N'TRUE'),
--12
(3, N'Maxell MD 迷你吊飾系列', NULL, 'maxellMD.jpg', '2024-08-12 13:45:30', 200, N'TRUE'), 
	--13
(3, N'無限氣泡 PuchipuchiAIR扭蛋ver', NULL, 'putiputi.jpg', '2024-08-12 13:45:30', 100, N'TRUE'), 
	--14
(3, N'Pioneer DJ 迷你系列', NULL, 'pioneerdj.jpg', '2024-08-12 13:45:30', 250, N'TRUE'), 
	--15
(3, N'復古咖啡店戒指系列', NULL, 'retrocafe-ring.jpg', '2024-08-12 13:45:30', 150, N'TRUE'),
	--16
(5,N'IVE壓克力杯墊展示架', NULL, 'ive_accoaster.jpg', '2024-05-29 17:20:20', 200,N'TRUE' ),
	--17
(5, N'PetiTEEN from SEVENTEEN-PERFORMANCE TEAM', NULL, 'petiteen_suwa_pa.jpg', '2024-05-29 17:20:20', 250, N'TRUE'), 
	--18
(5, N'TWICE-BABYLOVELYS戒指收藏', NULL, 'TWICE-FIVE.jpg', '2024-05-29 17:20:20', 250, N'TRUE'), 
	--19
(5, N'TWICE-LOVELY可愛吉祥物', NULL, 'TWICE-FOUR.jpg', '2024-05-29 17:20:20', 250, N'TRUE'),
	--20
(6, N'迪士尼100周年紀念', NULL, 'disney100.jpg', '2024-05-21 17:20:20', 200, N'TRUE'),
	--21
(8, N'豆本流行文具Mook系列', NULL, 'mamegashabook_popular_stationery_mook_collection.jpg', '2024-05-21 17:20:20', 150, N'TRUE'), 
	--22
(4, N'生物百科全書展示模型收藏野生犬科動物', NULL, N'dc_wilddog_main01.jpg', '2024-08-13 15:15:00', 150, 'TRUE'),

	--23
(8, N'豆本TOEIC公式教材', NULL, '01_DP_mamegasyaTOEIC_1200.jpg', '2024-05-21 17:20:20', 150, N'TRUE'),
	--24
(9, N'JR山手線音效機', NULL, 'yamanote_sound.jpg', '2024-05-26 17:20:20', 150, N'TRUE'),
	--25
(10, N'絕對打不開的扭蛋', NULL, 'never_open.jpg', '2024-05-26 17:20:20', 100, N'TRUE'),
	--26
(1, N'ACECOOK迷你吊飾收藏系列 2', NULL, N'ACECOOK_MINIATURE_CHARM_COLLECTION_2.jpg', '2024-05-20 17:20:20', 150, N'TRUE'),
	--27
(1, N'松田點心麵BABY STAR 吊飾', NULL, N'OYATSU-COMPANY-BABY-STAR-SHAKING-CHARM.jpg', '2024-03-15 10:25:30', 150, N'TRUE'),
	--28
(1, N'共親製菓迷你吊飾', NULL, N'KYOSHIN-MINI-CHARM.jpg', '2024-07-08 14:42:10', 200, N'TRUE'),
	--29
(1, N'爵士爆米花搖動吊飾', NULL, N'JAZZ-POPCORN-SHAKING-CHARM.jpg', '2024-01-22 09:15:45', 250, N'TRUE'),
	--30
(1, N'日本製乳株式會社OSHIDORI牛奶蛋糕吊飾', NULL, N'NIHON-SEINYU-OSHIDOR-MILK-CAKE-MINI-CHARM.jpg', '2024-06-30 11:55:25', 300, N'TRUE'),
	--31
(1, N'依然在等你便利商店餐', NULL, N'WAITING-FOR-YOU便利商店餐.jpg', '2024-03-10 10:30:00', 150, N'TRUE'),
	--32
(1, N'依然在等你團子', NULL, N'STILL-WAITING-FOR-YOU-DANGO.jpg', '2024-05-15 12:45:00', 200, N'TRUE'),
	--33
(1, N'依然在等你點心', NULL, N'STILL-WAITING-FOR-YOU-SNACK.jpg', '2024-08-01 14:10:00', 250, N'TRUE'),
	--34
(1, N'依然在等你便當盒2', NULL, N'STILL-WAITING-FOR-YOU-BENTO-BOX-2.jpg', '2024-08-02 14:10:00', 150, N'TRUE'),
	--35
(6, N'迪士尼小鹿斑比系列', NULL, 'DisneyBambi.jpg', '2024-08-12 17:20:20', 200,N'TRUE'),
	--36
(7, N'三麗鷗咖啡系列', NULL, 'SANRIO-CAFE.jpg', '2024-08-12 17:20:20', 250,N'TRUE'),
	--37
(7, N'三麗鷗人物膠囊-HelloKitty系列', NULL, 'Sanrio-characters-HelloKitty.jpg', '2024-08-12 17:20:20', 300,N'TRUE'),
	--38
(8, N'三菱文具系列', NULL, 'MITSUBISHI-PENCIL.jpg', '2024-08-12 17:20:20', 200,N'TRUE'),
	--39
(6, N'迪士尼歡樂時光系列', NULL, 'DisneyFunnyTime.jpg', '2024-08-12 17:20:20', 250,N'TRUE'),
	--40
(9, N'GT-R-R32系列', NULL, 'SKYLINE-GT-R-R32.jpg', '2024-08-12 17:20:20', 300,N'TRUE'),
	--41
(9, N'Nissan-GT-R-收藏鑰匙系列', NULL, 'Nissan-GT-R-Keys.jpg', '2024-08-12 17:20:20', 200,N'TRUE'),
	--42
(6, N'迪士尼白色吊飾系列', NULL, 'DisneyWhite.jpg', '2024-08-12 17:20:20', 250,N'TRUE'),
--43
(4, N'掛在電線上的鳥鳥 8', NULL, N'HUGCOT-CHILLING-ON-CORDS-８.jpg', '2024-08-13 15:15:00', 150, 'TRUE'),
--44
(4, N'掛在電線上的鳥鳥 7', NULL, N'HUGCOT-CHILLING-ON-CORDS-7.jpg', '2024-08-13 15:15:00', 150, 'TRUE'),
--45
(4, N'掛在電線上的鳥鳥 6', NULL, N'HUGCOT-CHILLING-ON-CORDS-6.jpg', '2024-08-13 15:15:00', 150, 'TRUE'),
	--46
(4, N'掛在電線上的鳥鳥 5', NULL, N'HUGCOT-CHILLING-ON-CORDS-5.jpg', '2024-08-13 15:15:00', 150, 'TRUE'),
	--47
	(10, N'哈利波特微型收藏', NULL, N'dp_saihanharrypotterminiaturecollection2.jpg', '2024-08-13 15:15:00', 200, 'TRUE'), 
	--48
(10, N'扭蛋青蛙風神與雷神鵰像的藝術', NULL, N'aig_frog_gol_main.jpg', '2024-08-13 15:15:00', 200, 'TRUE'), 
	--49
(10, N'愛情小鎮冒險', NULL, N'loveez_machiboke_main.jpg', '2024-08-13 15:15:00', 200, 'TRUE');
-- Insert data for themeId 8 with price 200
INSERT INTO gachaMachine (themeId, machineName, machineDescription, machinePictureName, createTime, price, status)
VALUES
	--50
(8, N'吉祥物連文具系列～甜點～', NULL, N'maindp_OBG.jpg', '2024-08-13 15:15:00', 200, 'TRUE'),
	--51
(3, N'安克微型收藏', NULL, N'dp_anker_miniature.jpg', '2024-08-13 15:15:00', 200, 'TRUE'),
	--52
(2, N'烈之黃金之地', NULL, N'abyss_tororin_main.jpg', '2024-08-13 15:15:00', 200, 'TRUE'),
	--53
(4, N'中二病～我們的黑歷史精選～', NULL, N'chu2byou.jpg', '2024-08-13 15:15:00', 150, 'TRUE'),
	--54
(4, N'寺岡夏美的各種狗狗', NULL, N'ironnnainu.jpg', '2024-08-13 15:15:00', 150, 'TRUE'),
	--55
(4, N'生物百科高級龜', NULL, N'kame.jpg', '2024-08-13 15:15:00', 150, 'TRUE'),
	--56
(4, N'生物大百科全書手指卷系列小動物', NULL, N'yubi.jpg', '2024-08-13 15:15:00', 150, 'TRUE'),
	--57
(4, N'生物百科迷你版鯊魚', NULL, N'shark-1.jpg', '2024-08-13 15:15:00', 150, 'TRUE');




-- 插入gachaProduct
INSERT INTO gachaProduct (machineId, productName, stock, productPictureName, createTime)
VALUES
    (1, N'BASEFOOD麵包-巧克力', 50, 'BASEFOODMiniatureMascotCharm-1.jpg', '2024-05-10 17:20:20'),
(1, N'BASEFOOD麵包-巧克力', 50, 'BASEFOODMiniatureMascotCharm-1.jpg', '2024-05-10 17:20:20'),
 (1, N'BASEFOOD麵包-楓糖', 50, 'BASEFOODMiniatureMascotCharm-3.jpg', '2024-05-10 17:20:20'), 
(1, N'BASEFOOD餅乾-椰子', 50, 'BASEFOODMiniatureMascotCharm-4.jpg', '2024-05-10 17:20:20'), 
(1, N'BASEFOOD餅乾-巧克力', 50, 'BASEFOODMiniatureMascotCharm-5.jpg', '2024-05-10 17:20:20'),
    (2, N'紅色外星人', 50, 'narabundesu-wiener-1.jpg', '2024-05-11 17:20:20'),
 (2, N'維納外星人', 50, 'narabundesu-wiener-2.jpg', '2024-05-10 17:20:20'),
 (2, N'Chiku Wiener外星人', 50, 'narabundesu-wiener-3.jpg', '2024-05-10 17:20:20'), 
(2, N'嬰兒起司外星人', 50, 'narabundesu-wiener-4.jpg', '2024-05-10 17:20:20'),
 (2, N'外星人維納(形象變化)', 50, 'narabundesu-wiener-5.jpg', '2024-05-10 17:20:20'),
    (3, N'蛋三明治', 50, 'STILLWAITINGFORYOUBREAD-1.jpg', '2024-05-12 17:20:20'),
    (3, N'紅豆麵包', 50, 'STILLWAITINGFORYOUBREAD-2.jpg', '2024-05-10 17:20:20'), 
(3, N'巧克力豆波羅麵包', 50, 'STILLWAITINGFORYOUBREAD-3.jpg', '2024-05-10 17:20:20'), 
(3, N'披薩吐司', 50, 'STILLWAITINGFORYOUBREAD-4.jpg', '2024-05-10 17:20:20'), 
(3, N'一條麵包', 50, 'STILLWAITINGFORYOUBREAD-5.jpg', '2024-05-10 17:20:20'),
(11, N'鋼鐵人', 50, 'marvel-shoes1.jpg', '2024-08-12 13:50:45'), 
(11, N'美國隊長', 50, 'marvel-shoes2.jpg', '2024-08-12 13:50:45'), 
(11, N'索爾', 50, 'marvel-shoes3.jpg', '2024-08-12 13:50:45'), 
(11, N'洛基', 50, 'marvel-shoes4.jpg', '2024-08-12 13:50:45'), 
(12, N'藍色', 50, 'maxellMD1.jpg', '2024-08-12 13:50:45'), 
(12, N'粉紅色', 50, 'maxellMD2.jpg', '2024-08-12 13:50:45'), 
(12, N'綠色', 50, 'maxellMD3.jpg', '2024-08-12 13:50:45'), 
(12, N'條紋藍', 50, 'maxellMD4.jpg', '2024-08-12 13:50:45'),
 (12, N'條紋粉', 50, 'maxellMD5.jpg', '2024-08-12 13:50:45'), 
(12, N'條紋橙', 50, 'maxellMD6.jpg', '2024-08-12 13:50:45'),
 (13, N'黑色', 50, 'putiputi1.jpg', '2024-08-12 13:50:45'),
 (13, N'粉色', 50, 'putiputi2.jpg', '2024-08-12 13:50:45'),
 (13, N'藍色', 50, 'putiputi3.jpg', '2024-08-12 13:50:45'),
 (13, N'綠色', 50, 'putiputi4.jpg', '2024-08-12 13:50:45'), 
(14, N'CDJ-3000 DJ 多功能播放器', 50, 'pioneerdj1.jpg', '2024-08-12 13:50:45'), 
(14, N'PLX-1000 轉盤', 50, 'pioneerdj2.jpg', '2024-08-12 13:50:45'), 
(14, N'VM-50 主動式監聽揚聲器和 HDJ-X10 旗艦DJ 耳機', 50, 'pioneerdj3.jpg', '2024-08-12 13:50:45'), 
(14, N'DJM-A9 4頻道專業DJ混音器', 50, 'pioneerdj4.jpg', '2024-08-12 13:50:45'), 
(15, N'奶油蘇打', 50, 'retrocafe-ring1.jpg', '2024-08-12 13:50:45'), 
(15, N'布丁', 50, 'retrocafe-ring2.jpg', '2024-08-12 13:50:45'), 
(15, N'鬆餅', 50, 'retrocafe-ring3.jpg', '2024-08-12 13:50:45'),
 (15, N'咖啡', 50, 'retrocafe-ring4.jpg', '2024-08-12 13:50:45'), 
(15, N'厚片土司', 50, 'retrocafe-ring5.jpg', '2024-08-12 13:50:45'),
    (4, N'櫻花餡 & 小禮盒', 50, 'GINZA KIMURAYA SOHONTEN ANPAN MINI CHARM-1.jpg', '2024-05-13 17:20:20'),
(4, N'小倉紅豆餡 &木村屋招牌 A', 50, 'GINZA KIMURAYA SOHONTEN ANPAN MINI CHARM-2.jpg', '2024-05-10 17:20:20'), 
(4, N'罌粟籽配料 &木村屋招牌 A', 50, 'GINZA KIMURAYA SOHONTEN ANPAN MINI CHARM-3.jpg', '2024-05-10 17:20:20'),
 (4, N'白腎豆餡 & 大禮盒', 50, 'GINZA KIMURAYA SOHONTEN ANPAN MINI CHARM-4.jpg', '2024-05-10 17:20:20'),
 (4, N'綜合 (5種口味/5個)', 50, 'GINZA KIMURAYA SOHONTEN ANPAN MINI CHARM-5.jpg', '2024-05-10 17:20:20'),
    (5, N'經典蛋包飯', 50, 'POMUNOKI MINIATURE CHARM-1.jpg', '2024-05-14 17:20:20'),
 (5, N'雙重起司蛋包飯配特製多蜜醬汁', 50, 'POMUNOKI MINIATURE CHARM-2.jpg', '2024-05-10 17:20:20'),
 (5, N'牛肉醬漢堡排蛋包飯', 50, 'POMUNOKI MINIATURE CHARM-3.jpg', '2024-05-10 17:20:20'), 
(5, N'美乃滋和辣明太子蛋包飯', 50, 'POMUNOKI MINIATURE CHARM-4.jpg', '2024-05-10 17:20:20'),
 (5, N'日式焗烤蛋包飯', 50, 'POMUNOKI MINIATURE CHARM-5.jpg', '2024-05-10 17:20:20'),
(16, N'兪真', 50, 'ive_accoaster_thum_1.jpg', '2024-08-12 12:34:56'), 
(16, N'秋天', 50, 'ive_accoaster_thum_2.jpg', '2024-08-12 12:34:56'), 
(16, N'REI', 50, 'ive_accoaster_thum_3.jpg', '2024-08-12 12:34:56'),
 (16, N'員瑛', 50, 'ive_accoaster_thum_4.jpg', '2024-08-12 12:34:56'),
 (16, N'LIZ', 50, 'ive_accoaster_thum_5.jpg', '2024-08-12 12:34:56'),
 (16, N'李瑞', 50, 'ive_accoaster_thum_6.jpg', '2024-08-12 12:34:56'),
 (16, N'兪真和秋天', 50, 'ive_accoaster_thum_7.jpg', '2024-08-12 12:34:56'),
 (16, N'REI和LIZ', 50, 'ive_accoaster_thum_8.jpg', '2024-08-12 12:34:56'),
 (16, N'員瑛和李瑞', 50, 'ive_accoaster_thum_9.jpg', '2024-08-12 12:34:56'), 
(17, N'HOSHI', 50, 'petiteen_suwa_pa_tm_hoshi.jpg', '2024-08-12 12:34:56'),
 (17, N'JUN', 50, 'petiteen_suwa_pa_tm_jun.jpg', '2024-08-12 12:34:56'), 
(17, N'THE8', 50, 'petiteen_suwa_pa_tm_the8.jpg', '2024-08-12 12:34:56'), 
(17, N'DINO', 50, 'petiteen_suwa_pa_tm_dino.jpg', '2024-08-12 12:34:56'), 
(18, N'BABY NAVELY', 50, 'TWICE-FIVE-1.jpg', '2024-08-12 12:34:56'),
 (18, N'BABY JEONGVELY', 50, 'TWICE-FIVE-2.jpg', '2024-08-12 12:34:56'), 
(18, N'BABY MOVELY', 50, 'TWICE-FIVE-3.jpg', '2024-08-12 12:34:56'), 
(18, N'BABY SAVELY', 50, 'TWICE-FIVE-4.jpg', '2024-08-12 12:34:56'), 
(18, N'BABY JIVELY', 50, 'TWICE-FIVE-5.jpg', '2024-08-12 12:34:56'), 
(18, N'BABY MIVELY', 50, 'TWICE-FIVE-6.jpg', '2024-08-12 12:34:56'), 
(18, N'BABY DAVELY', 50, 'TWICE-FIVE-7.jpg', '2024-08-12 12:34:56'),
 (18, N'BABY CHAENGVELY', 50, 'TWICE-FIVE-8.jpg', '2024-08-12 12:34:56'),
 (18, N'BABY TZUVELY', 50, 'TWICE-FIVE-9.jpg', '2024-08-12 12:34:56'), 
(19, N'NAVELY', 50, 'TWICE-FOUR-1.jpg', '2024-08-12 12:34:56'), 
(19, N'JEONGVELY', 50, 'TWICE-FOUR-2.jpg', '2024-08-12 12:34:56'), 
(19, N'MOVELY', 50, 'TWICE-FOUR-3.jpg', '2024-08-12 12:34:56'), 
(19, N'SAVELY', 50, 'TWICE-FOUR-4.jpg', '2024-08-12 12:34:56'),
 (19, N'JIVELY', 50, 'TWICE-FOUR-5.jpg', '2024-08-12 12:34:56'), 
(19, N'MIVELY', 50, 'TWICE-FOUR-6.jpg', '2024-08-12 12:34:56'),
 (19, N'DAVELY', 50, 'TWICE-FOUR-7.jpg', '2024-08-12 12:34:56'),
 (19, N'CHAENGVELY', 50, 'TWICE-FOUR-8.jpg', '2024-08-12 12:34:56'), 
(19, N'TZUVELY', 50, 'TWICE-FOUR-9.jpg', '2024-08-12 12:34:56'),
   (6, N'吉伊卡哇系列-吉伊卡哇', 50, 'ChiikawaCapchara1.jpg', '2024-05-15 17:20:20'),
(6, N'吉伊卡哇系列-小八貓', 50, 'ChiikawaCapchara2.jpg', '2024-08-12 17:20:20'),
(6, N'吉伊卡哇系列-兔兔', 50, 'ChiikawaCapchara3.jpg', '2024-08-12 17:20:20'),
(6, N'吉伊卡哇系列-小桃鼠', 50, 'ChiikawaCapchara4.jpg', '2024-08-12 17:20:20'),
(20, N'小熊維尼', 50, 'disney100-1.jpg', '2024-08-12 12:34:56'),
 (20, N'鋼鐵人', 50, 'disney100-2.jpg', '2024-08-12 12:34:56'), 
(20, N'米妮', 50, 'disney100-3.jpg', '2024-08-12 12:34:56'), 
(20, N'胡迪', 50, 'disney100-4.jpg', '2024-08-12 12:34:56'), 
(20, N'白雪公主', 50, 'disney100-5.jpg', '2024-08-12 12:34:56'),
    (7, N'小新和肉', 50, 'CrayonShin-chan1.jpg', '2024-05-16 17:20:20'),
	(7, N'廣志和最棒的一杯', 50, 'CrayonShin-chan2.jpg', '2024-08-12 17:20:20'),
	(7, N'美冴和萵苣', 50, 'CrayonShin-chan3.jpg', '2024-08-12 17:20:20'),
	(7, N'烤肉架和桌子及佐藤九日堂塑膠袋', 50, 'CrayonShin-chan4.jpg', '2024-08-12 17:20:20'),
	(7, N'小白和飼料盤', 50, 'CrayonShin-chan5.jpg', '2024-08-12 17:20:20'),
	(7, N'小葵和奶瓶', 50, 'CrayonShin-chan6.jpg', '2024-08-12 17:20:20'),
    (8, N'芙莉蓮A', 50, 'Frieren-Beyond-Journey-End-1.jpg', '2024-05-17 17:20:20'),
	(8, N'芙莉蓮B', 50, 'Frieren-Beyond-Journey-End-2.jpg', '2024-08-12 17:20:20'),
	(8, N'寶箱怪與芙莉蓮', 50, 'Frieren-Beyond-Journey-End-3.jpg', '2024-08-12 17:20:20'),
	(8, N'欣梅爾', 50, 'Frieren-Beyond-Journey-End-4.jpg', '2024-08-12 17:20:20'),
	(8, N'銅像欣梅爾', 50, 'Frieren-Beyond-Journey-End-5.jpg', '2024-08-12 17:20:20'),
(21, N'蠟筆', 50, '01_crepas_4582769714443.jpg', '2024-08-12 12:34:56'),
 (21, N'圖案速寫本', 50, '02_sketch_book_4582769714450.jpg', '2024-08-12 12:34:56'), 
(21, N'MONO橡皮擦', 50, '03_mono_eraser_4582769714467.jpg', '2024-08-12 12:34:56'),
 (21, N'A4多功能收納袋', 50, '04_croquis_book_4582769714474.jpg', '2024-08-12 12:34:56'),
 -- Insert for machineId: 22
(22, N'狼（白）', 50, 'dc_wilddog_02.jpg', '2024-08-13 15:15:00'),
(22, N'狼（普通）', 50, 'dc_wilddog_01.jpg', '2024-08-13 15:15:00'),
(22, N'狐狸', 50, 'dc_wilddog_03.jpg', '2024-08-13 15:15:00'),
(22, N'貉', 50, 'dc_wilddog_04.jpg', '2024-08-13 15:15:00'),

(23, N'聽力和閱讀800+', 50, '03_ListeningReading_800_1200.jpg', '2024-08-12 12:34:56'),
 (23, N'聽力和閱讀官方詞彙書', 50, '04_ListeningReading_vocabulary_1200.jpg', '2024-08-12 12:34:56'), 
(23, N'聽力和閱讀問題集1', 50, '05_ListeningReading_1_1200.jpg', '2024-08-12 12:34:56'),
 (23, N'聽力和閱讀問題集10', 50, '06_ListeningReading_10_1200.jpg', '2024-08-12 12:34:56'),
    (9, N'成振宇A', 50, 'SoloLeveling-1.jpg', '2024-05-18 17:20:20'),
	(9, N'成振宇B', 50, 'SoloLeveling-2.jpg', '2024-08-12 17:20:20'),
	(9, N'成振宇C', 50, 'SoloLeveling-3.jpg', '2024-08-12 17:20:20'),
	(9, N'成振宇D', 50, 'SoloLeveling-4.jpg', '2024-08-12 17:20:20'),
	(9, N'成振宇與柳軫皓', 50, 'SoloLeveling-5.jpg', '2024-08-12 17:20:20'),
	(9, N'成振宇與車海印', 50, 'SoloLeveling-6.jpg', '2024-08-12 17:20:20'),
(24, N'秋葉原站外圈-SpringBox', 50, 'yamanote_sound1.jpg', '2024-08-12 12:34:56'),
 (24, N'秋葉原站內圈-小溪流水聲', 50, 'yamanote_sound2.jpg', '2024-08-12 12:34:56'),
 (24, N'新宿站外圈-Twilight', 50, 'yamanote_sound3.jpg', '2024-08-12 12:34:56'), 
(24, N'新宿站內圈-新季節', 50, 'yamanote_sound4.jpg', '2024-08-12 12:34:56'),
 (24, N'澀谷站內圈-花朵綻放', 50, 'yamanote_sound5.jpg', '2024-08-12 12:34:56'),
 (24, N'目黑站外圈-DanceOn', 50, 'yamanote_sound6.jpg', '2024-08-12 12:34:56'),
(25, N'白色-Level1', 50, 'never_open1.jpg', '2024-08-12 12:34:56'), 
(25, N'黑色-Level1', 50, 'never_open2.jpg', '2024-08-12 12:34:56'), 
(25, N'白色-Level2', 50, 'never_open3.jpg', '2024-08-12 12:34:56'),
 (25, N'黑色-Level2', 50, 'never_open4.jpg', '2024-08-12 12:34:56'),
 (25, N'白色-Level3', 50, 'never_open5.jpg', '2024-08-12 12:34:56'), 
(25, N'黑色-Level3', 50, 'never_open6.jpg', '2024-08-12 12:34:56'),
    (10, N'毛怪', 50, 'MonstersInc-1.jpg', '2024-05-19 17:20:20'),
	(10, N'阿布', 50, 'MonstersInc-2.jpg', '2024-08-12 17:20:20'),
	(10, N'大眼仔', 50, 'MonstersInc-3.jpg', '2024-08-12 17:20:20'),
	(10, N'藍道', 50, 'MonstersInc-4.jpg', '2024-08-12 17:20:20'),
-- Insert for machineId: 26
    (26, N'味噌奶油拉麵', 30, 'ACECOOK_01.jpg', '2024-03-15 10:30:00'),
    (26, N'擔擔風味粉絲湯', 30, 'ACECOOK_02.jpg', '2024-03-15 10:30:00'),
    (26, N'超級咖哩味噌拉麵', 20, 'ACECOOK_03.jpg', '2024-04-10 11:25:00'),
    (26, N'雲吞麵', 40, 'ACECOOK_04.jpg', '2024-05-01 09:45:00'),
    (26, N'Mocchicchi日式炒麵', 35, 'ACECOOK_05.jpg', '2024-07-22 14:10:00'),
    (26, N'芝麻醬油味海帶拉麵', 25, 'ACECOOK_06.jpg', '2024-08-02 13:20:00'),
    -- Insert for machineId: 27
    (27, N'酥脆雞汁風味拉麵點心麵', 45, 'OYATSU_01.jpg', '2024-03-20 12:00:00'),
    (27, N'酥脆雞汁風味拉麵點心(第二代)', 35, 'OYATSU_02.jpg', '2024-04-15 11:00:00'),
    (27, N'酥脆雞汁風味拉麵點心麵(初代版)', 50, 'OYATSU_03.jpg', '2024-05-10 13:30:00'),
    (27, N'酥脆日式炒麵醬風味點心麵', 40, 'OYATSU_04.jpg', '2024-06-05 14:20:00'),
    (27, N'酥脆醬油風味拉麵點心麵', 30, 'OYATSU_05.jpg', '2024-07-15 15:10:00'),
    (27, N'酥脆鹽味拉麵點心麵', 20, 'OYATSU_06.jpg', '2024-08-01 10:00:00'),
    (27, N'圓形酥脆雞汁風味拉麵點心麵', 25, 'OYATSU_07.jpg', '2024-02-28 09:20:00'),
    (27, N'酥脆雞汁風味花生點心麵', 30, 'OYATSU_08.jpg', '2024-03-15 16:00:00'),
  -- Insert for machineId: 28
    (28, N'水果之森', 15, 'KYOSHIN_01.jpg', '2024-01-25 09:00:00'),
    (28, N'可樂糖果', 20, 'KYOSHIN_02.jpg', '2024-02-20 10:30:00'),
    (28, N'糖果盒', 25, 'KYOSHIN_03.jpg', '2024-03-30 11:00:00'),
    (28, N'麻糬串團子', 35, 'KYOSHIN_04.jpg', '2024-04-15 13:40:00'),
    (28, N'柔軟蒟蒻果凍', 40, 'KYOSHIN_05.jpg', '2024-05-10 15:30:00'),
-- Insert for machineId: 29
    (29, N'醬油口味 A', 20, 'POPCORN_01.jpg', '2024-02-05 12:20:00'),
    (29, N'黑胡椒口味 A', 30, 'POPCORN_02.jpg', '2024-03-15 11:10:00'),
    (29, N'奶油口味 A', 25, 'POPCORN_03.jpg', '2024-04-25 14:45:00'),
    (29, N'醬油口味 B', 35, 'POPCORN_04.jpg', '2024-05-20 10:50:00'),
    (29, N'黑胡椒口味 B', 40, 'POPCORN_05.jpg', '2024-06-30 15:30:00'),
    (29, N'奶油口味 B', 50, 'POPCORN_06.jpg', '2024-07-25 09:10:00'),
-- Insert for machineId: 30
    (30, N'牛奶', 30, 'OSHIDORI_01.jpg', '2024-01-15 10:00:00'),
    (30, N'葡萄', 20, 'OSHIDORI_02.jpg', '2024-02-25 11:15:00'),
    (30, N'櫻桃', 25, 'OSHIDORI_03.jpg', '2024-03-10 12:30:00'),
    (30, N'西洋梨', 40, 'OSHIDORI_04.jpg', '2024-04-05 14:00:00'),
    (30, N'草莓', 35, 'OSHIDORI_05.jpg', '2024-05-20 15:45:00'),
    (30, N'咖啡', 45, 'OSHIDORI_06.jpg', '2024-06-30 16:20:00'),
-- Insert for machineId: 31
    (31, N'鮭魚飯糰', 20, N'WAITING-FOR-YOU便利商店餐_1.jpg', '2024-02-10 11:30:00'),
    (31, N'梅子飯糰', 30, N'WAITING-FOR-YOU便利商店餐_2.jpg', '2024-03-15 12:45:00'),
    (31, N'紅豆糯米飯糰', 40, N'WAITING-FOR-YOU便利商店餐_3.jpg', '2024-04-20 14:00:00'),
    (31, N'筍糯米飯糰', 35, N'WAITING-FOR-YOU便利商店餐_4.jpg', '2024-05-25 15:30:00'),
    (31, N'蛋沙拉三明治', 25, N'WAITING-FOR-YOU便利商店餐_5.jpg', '2024-06-10 10:00:00'),
    (31, N'火腿三明治', 45, N'WAITING-FOR-YOU便利商店餐_6.jpg', '2024-07-15 13:20:00'),
-- Insert for machineId: 32
    (32, N'醬汁團子', 25, 'DANGO_01.jpg', '2024-01-05 09:30:00'),
    (32, N'艾草團子', 35, 'DANGO_02.jpg', '2024-02-20 10:45:00'),
    (32, N'黃豆粉團子', 30, 'DANGO_03.jpg', '2024-03-10 12:00:00'),
    (32, N'烤團子', 20, 'DANGO_04.jpg', '2024-04-15 14:15:00'),
    (32, N'三色團子', 45, 'DANGO_05.jpg', '2024-05-30 16:00:00'),
    (32, N'海苔團子', 40, 'DANGO_06.jpg', '2024-06-25 17:30:00'),
-- Insert for machineId: 33
    (33, N'鬆餅', 25, 'waitingSnack_01.jpg', '2024-02-01 09:00:00'),
    (33, N'洋芋片', 30, 'waitingSnack_02.jpg', '2024-03-10 10:30:00'),
    (33, N'甜甜圈', 40, 'waitingSnack_03.jpg', '2024-04-15 11:45:00'),
    (33, N'軟糖', 20, 'waitingSnack_04.jpg', '2024-05-20 14:00:00'),
    (33, N'巧克力餅乾', 35, 'waitingSnack_05.jpg', '2024-06-25 16:15:00'),
-- Insert for machineId: 34
    (34, N'飯糰', 40, 'BENTO BOX 2_01.jpg', '2024-02-05 10:00:00'),
    (34, N'炸蝦', 30, 'BENTO BOX 2_02.jpg', '2024-03-10 11:30:00'),
    (34, N'水煮蛋', 25, 'BENTO BOX 2_03.jpg', '2024-04-15 12:45:00'),
    (34, N'肉丸', 35, 'BENTO BOX 2_04.jpg', '2024-05-20 14:00:00'),
    (34, N'果凍', 45, 'BENTO BOX 2_05.jpg', '2024-06-25 15:15:00'),
-- Insert for machineId: 35
	(35, N'斑比', 50, 'DisneyBambi-1.jpg', '2024-08-13 15:15:00'),
	(35, N'桑普', 50, 'DisneyBambi-2.jpg', '2024-08-13 15:15:00'),
	(35, N'花兒', 50, 'DisneyBambi-3.jpg', '2024-08-13 15:15:00'),
	(35, N'芬妮', 50, 'DisneyBambi-4.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 36
	(36, N'HelloKitty', 50, 'SANRIO-CAFE1.jpg', '2024-08-13 15:15:00'),
	(36, N'美樂蒂', 50, 'SANRIO-CAFE2.jpg', '2024-08-13 15:15:00'),
	(36, N'酷洛米', 50, 'SANRIO-CAFE3.jpg', '2024-08-13 15:15:00'),
	(36, N'大耳狗喜拿', 50, 'SANRIO-CAFE4.jpg', '2024-08-13 15:15:00'),
	(36, N'布丁狗', 50, 'SANRIO-CAFE5.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 37
	(37, N'HelloKitty', 50, 'Sanrio-characters-HelloKitty1.jpg', '2024-08-13 15:15:00'),
	(37, N'Mimmy', 50, 'Sanrio-characters-HelloKitty2.jpg', '2024-08-13 15:15:00'),
	(37, N'湯瑪士', 50, 'Sanrio-characters-HelloKitty3.jpg', '2024-08-13 15:15:00'),
	(37, N'提比', 50, 'Sanrio-characters-HelloKitty4.jpg', '2024-08-13 15:15:00'),
	(37, N'崔西', 50, 'Sanrio-characters-HelloKitty5.jpg', '2024-08-13 15:15:00'),
	(37, N'菲菲', 50, 'Sanrio-characters-HelloKitty6.jpg', '2024-08-13 15:15:00'),
	(37, N'裘蒂', 50, 'Sanrio-characters-HelloKitty7.jpg', '2024-08-13 15:15:00'),
	(37, N'喬伊與茱蒂', 50, 'Sanrio-characters-HelloKitty8.jpg', '2024-08-13 15:15:00'),
	(37, N'文太與小桃', 50, 'Sanrio-characters-HelloKitty9.jpg', '2024-08-13 15:15:00'),
	(37, N'洛蒂與羅利', 50, 'Sanrio-characters-HelloKitty10.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 38
	(38, N'大學', 50, 'MITSUBISHI-PENCIL1.jpg', '2024-08-13 15:15:00'),
	(38, N'庫爾特加', 50, 'MITSUBISHI-PENCIL2.jpg', '2024-08-13 15:15:00'),
	(38, N'波斯卡', 50, 'MITSUBISHI-PENCIL3.jpg', '2024-08-13 15:15:00'),
	(38, N'普羅布斯窗', 50, 'MITSUBISHI-PENCIL4.jpg', '2024-08-13 15:15:00'),
	(38, N'急流', 50, 'MITSUBISHI-PENCIL5.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 39
	(39, N'米奇', 50, 'DisneyFunnyTime1.jpg', '2024-08-13 15:15:00'),
	(39, N'史迪奇', 50, 'DisneyFunnyTime2.jpg', '2024-08-13 15:15:00'),
	(39, N'雪寶', 50, 'DisneyFunnyTime3.jpg', '2024-08-13 15:15:00'),
	(39, N'胡尼克', 50, 'DisneyFunnyTime4.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 40
	(40, N'GT-R-R32-黑', 50, 'SKYLINE-GT-R-R32-1.jpg', '2024-08-13 15:15:00'),
	(40, N'GT-R-R32-白', 50, 'SKYLINE-GT-R-R32-2.jpg', '2024-08-13 15:15:00'),
	(40, N'GT-R-R32-藍', 50, 'SKYLINE-GT-R-R32-3.jpg', '2024-08-13 15:15:00'),
	(40, N'GT-R-R32-紅', 50, 'SKYLINE-GT-R-R32-4.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 41
	(41, N'KPGC10', 50, 'Nissan-GT-R-Keys1.jpg', '2024-08-13 15:15:00'),
	(41, N'BNR32', 50, 'Nissan-GT-R-Keys2.jpg', '2024-08-13 15:15:00'),
	(41, N'BNR33', 50, 'Nissan-GT-R-Keys3.jpg', '2024-08-13 15:15:00'),
	(41, N'BNR34', 50, 'Nissan-GT-R-Keys4.jpg', '2024-08-13 15:15:00'),
	(41, N'R35', 50, 'Nissan-GT-R-Keys5.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 42
	(42, N'瑪麗貓', 50, 'DisneyWhite1.jpg', '2024-08-13 15:15:00'),
	(42, N'零零狗', 50, 'DisneyWhite2.jpg', '2024-08-13 15:15:00'),
	(42, N'杯麵', 50, 'DisneyWhite3.jpg', '2024-08-13 15:15:00'),
	(42, N'雪寶', 50, 'DisneyWhite4.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 43
(43, '小雞', 50, 'CORDS ８_01.jpg', '2024-08-13 15:15:00'),
(43, '斑文鳥', 50, 'CORDS ８_02.jpg', '2024-08-13 15:15:00'),
(43, '長尾山雀', 50, 'CORDS ８_03.jpg', '2024-08-13 15:15:00'),
(43, '企鵝', 50, 'CORDS ８_04.jpg', '2024-08-13 15:15:00'),
(43, '長尾鸚鵡（黃綠色）', 50, 'CORDS ８_05.jpg', '2024-08-13 15:15:00'),
(43, '情侶鸚鵡', 50, 'CORDS ８_06.jpg', '2024-08-13 15:15:00'),
(43, '斑點鸚鵡', 50, 'CORDS ８_07.jpg', '2024-08-13 15:15:00'),
(43, '灰鸚鵡', 50, 'CORDS ８_08.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 44
(44, N'灰色文鳥', 50, 'CORDS 7_01.jpg', '2024-08-13 15:15:00'),
(44, N'白色文鳥', 50, 'CORDS 7_02.jpg', '2024-08-13 15:15:00'),
(44, N'肉桂色文鳥', 50, 'CORDS 7_03.jpg', '2024-08-13 15:15:00'),
(44, N'銀色文鳥', 50, 'CORDS 7_04.jpg', '2024-08-13 15:15:00'),
(44, N'綠色虎皮鸚鵡', 50, 'CORDS 7_05.jpg', '2024-08-13 15:15:00'),
(44, N'藍色虎皮鸚鵡', 50, 'CORDS 7_06.jpg', '2024-08-13 15:15:00'),
(44, N'黃色虎皮鸚鵡', 50, 'CORDS 7_07.jpg', '2024-08-13 15:15:00'),
(44, N'黃與淡藍色虎皮鸚鵡', 50, 'CORDS 7_08.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 45
(45, N'巨嘴鳥', 50, 'CORDS 6_01.jpg', '2024-08-13 15:15:00'),
(45, N'鶯', 50, 'CORDS 6_02.jpg', '2024-08-13 15:15:00'),
(45, N'長尾山雀', 50, 'CORDS 6_03.jpg', '2024-08-13 15:15:00'),
(45, N'黑頭文鳥', 50, 'CORDS 6_04.jpg', '2024-08-13 15:15:00'),
(45, N'麻雀', 50, 'CORDS 6_05.jpg', '2024-08-13 15:15:00'),
(45, N'黃化長尾鸚鵡', 50, 'CORDS 6_06.jpg', '2024-08-13 15:15:00'),
(45, N'玄鳳鸚鵡', 50, 'CORDS 6_07.jpg', '2024-08-13 15:15:00'),
(45, N'烏鴉', 50, 'CORDS 6_08.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 46
(46, N'海鷹', 50, 'CORDS 5_01.jpg', '2024-08-13 15:15:00'),
(46, N'鴨子', 50, 'CORDS 5_02.jpg', '2024-08-13 15:15:00'),
(46, N'斑胸草雀', 50, 'CORDS 5_03.jpg', '2024-08-13 15:15:00'),
(46, N'白文鳥', 50, 'CORDS 5_04.jpg', '2024-08-13 15:15:00'),
(46, N'長尾鸚鵡（黃藍淡色）', 50, 'CORDS 5_05.jpg', '2024-08-13 15:15:00'),
(46, N'燕子', 50, 'CORDS 5_06.jpg', '2024-08-13 15:15:00'),
(46, N'白鶺鴒', 50, 'CORDS 5_07.jpg', '2024-08-13 15:15:00'),
(46, N'鴿子', 50, 'CORDS 5_08.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 47
(47, N'青蛙巧克力', 50, '01_chocolatefrog.jpg', '2024-08-13 15:15:00'),
(47, N'伯蒂·博特的媽媽豆', 50, '02_bertiebottseveryflavourbeans.jpg', '2024-08-13 15:15:00'),
(47, N'咆哮郵件', 50, '03_hoemail.jpg', '2024-08-13 15:15:00'),
(47, N'夜間騎士巴士', 50, '04_yorunokishibus.jpg', '2024-08-13 15:15:00'),
(47, N'可怕的怪物書', 50, '05_kaibutsutekinakaibutsunohon.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 48
(48, N'青蛙福晉雕像（木雕像彩色）', 50, 'aig_frog_gol_03.jpg', '2024-08-13 15:15:00'),
(48, N'青蛙雷神鵰像（木雕像色）', 50, 'aig_frog_gol_04.jpg', '2024-08-13 15:15:00'),
(48, N'青蛙福晉雕像（青銅雕像顏色）', 50, 'aig_frog_gol_05.jpg', '2024-08-13 15:15:00'),
(48, N'蛙雷神鵰像（古銅雕像色）', 50, 'aig_frog_gol_06.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 49
(49, N'蘇莫皮', 50, 'loveez_machiboke_1.jpg', '2024-08-13 15:15:00'),
(49, N'皮永奇', 50, 'loveez_machiboke_2.jpg', '2024-08-13 15:15:00'),
(49, N'尼亞波', 50, 'loveez_machiboke_3.jpg', '2024-08-13 15:15:00'),
(49, N'烏魯魯', 50, 'loveez_machiboke_4.jpg', '2024-08-13 15:15:00'),
(49, N'蘇莫皮 (zh)', 50, 'loveez_machiboke_5.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 50
(50, N'柏餅文具', 50, 'kashiwamochi.jpg', '2024-08-13 15:15:00'),
(50, N'攪打布丁', 50, 'whippedpudding.jpg', '2024-08-13 15:15:00'),
(50, N'煎餅無名', 50, 'pancake.jpg', '2024-08-13 15:15:00'),
(50, N'攪打薄荷果凍', 50, 'whippedjelly.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 51
(51, N'Anker Nano 行動電源', 50, '01_ankernanopowerbank.jpg', '2024-08-13 15:15:00'), 
(51, N'Anker 535便攜式充電站', 50, '02_anker535portablepowerstation.jpg', '2024-08-13 15:15:00'), 
(51, N'Soundcore', 50, '03_soundcore3.jpg', '2024-08-13 15:15:00'), 
(51, N'星雲膠囊3雷射', 50, '04_nebulacapsule3laser.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 52
(52, N'瑞科', 50, 'abyss_tororin_riko.jpg', '2024-08-13 15:15:00'), 
(52, N'那那奇', 50, 'abyss_tororin_nanachi.jpg', '2024-08-13 15:15:00'), 
(52, N'法普塔', 50, 'abyss_tororin_faputa.jpg', '2024-08-13 15:15:00'), 
(52, N'瑪阿桑', 50, 'abyss_tororin_maaasan.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 53
(53, N'花貓A', 50, 'chu2byou-1.jpg', '2024-08-13 15:15:00'),
(53, N'四郎貓', 50, 'chu2byou-2.jpg', '2024-08-13 15:15:00'),
(53, N'木地虎', 50, 'chu2byou-3.jpg', '2024-08-13 15:15:00'),
(53, N'灰貓', 50, 'chu2byou-4.jpg', '2024-08-13 15:15:00'),
(53, N'黑貓', 50, 'chu2byou-5.jpg', '2024-08-13 15:15:00'),
(53, N'士郎乙', 50, 'chu2byou-6.jpg', '2024-08-13 15:15:00'),
(53, N'花貓B', 50, 'chu2byou-7.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 54
(54, N'遛狗', 50, 'ironnnainu-1.jpg', '2024-08-13 15:15:00'),
(54, N'坐著的狗', 50, 'ironnnainu-2.jpg', '2024-08-13 15:15:00'),
(54, N'晚安狗', 50, 'ironnnainu-3.jpg', '2024-08-13 15:15:00'),
(54, N'早安狗', 50, 'ironnnainu-4.jpg', '2024-08-13 15:15:00'),
(54, N'睏狗', 50, 'ironnnainu-5.jpg', '2024-08-13 15:15:00'),
(54, N'毛茸茸的狗', 50, 'ironnnainu-6.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 55
(55, N'淺色紅耳龜', 50, 'kame-1.jpg', '2024-08-13 15:15:00'),
(55, N'深色紅耳龜', 50, 'kame-2.jpg', '2024-08-13 15:15:00'),
(55, N'孔雀龜', 50, 'kame-3.jpg', '2024-08-13 15:15:00'),
(55, N'佛羅裡達紅肚龜', 50, 'kame-4.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 56
(56, N'黃金倉鼠', 50, 'yubi-1.jpg', '2024-08-13 15:15:00'),
(56, N'金熊', 50, 'yubi-2.jpg', '2024-08-13 15:15:00'),
(56, N'刺蝟', 50, 'yubi-3.jpg', '2024-08-13 15:15:00'),
(56, N'肉桂刺蝟', 50, 'yubi-4.jpg', '2024-08-13 15:15:00'),
(56, N'灰蜜袋鼯', 50, 'yubi-5.jpg', '2024-08-13 15:15:00'),
(56, N'奶油蜜袋鼯', 50, 'yubi-6.jpg', '2024-08-13 15:15:00'),
-- Insert for machineId: 57
(57, N'鯨鯊', 50, 'shark-1.jpg', '2024-08-13 15:15:00'),
(57, N'大白鯊', 50, 'shark-2.jpg', '2024-08-13 15:15:00'),
(57, N'白色鱷魚', 50, 'shark-3.jpg', '2024-08-13 15:15:00'),
(57, N'鋸鯊', 50, 'shark-4.jpg', '2024-08-13 15:15:00'),
(57, N'貓鯊', 50, 'shark-5.jpg', '2024-08-13 15:15:00');










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








