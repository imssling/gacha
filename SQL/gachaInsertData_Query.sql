INSERT INTO userInfo (userName, phoneNumber, email, address, gender, points)
VALUES
    ('Tzuyu', '0912345678', 'tzuyu@gmail.com', N'�Ὤ���_����292��', N'�k', 0),
    ('Mina', '0948752364', 'mina@gmail.com', N'�x�n������Ϧ��\��189��', N'�k', 0),
    ('Sana', '0974385296', 'sana@gmail.com', N'�Ÿq���M����491��', N'�k', 0),
    ('faker', '0943891253', 'faker@gmail.com', N'���L�����ڸ�83��', N'�k', 0),
    ('Nlnl', '0973168456', 'Nlnl@gmail.com', N'�Ÿq�����_��20��', N'�k', 0),
    ('Sullyon', '0911358962', 'sullyon@gmail.com', N'�������X�_�ϥ��_��311��', N'�k', 0),
    ('Bae', '0974123589', 'bae@gmail.com', N'�s�����H�q��293��', N'�k', 0),
    ('Yuna', '0985231265', 'yuna@gmail.com', N'���L���M����150��', N'�k', 0),
    ('Momo', '0978523654', 'momo@gmail.com', N'�x������Ϥ��s��255��', N'�k', 0),
    ('Johnson', '0944123669', 'johnson@gmail.com', N'���L���M����380��', N'�k', 0);
GO


-- ���J userPassword
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



-- ���J gachaTheme 
INSERT INTO gachaTheme (themeName)
VALUES
    (N'����'),
    (N'�ʺ�'),
    (N'�p��'),
    (N'�ʪ�'),
    (N'����'),
    (N'�}�h��'),
    (N'�T�R��'),
    (N'���'),
    (N'��q'),
    (N'�d��');
GO



-- ���J gachaMachine ���
INSERT INTO gachaMachine (themeId, machineName, machineDescription, machinePictureName, createTime, price,status)
VALUES
    (1, N'BASE FOOD', NULL, 'BaseFoodMiniatureMascotCharm.jpg', '2024-05-20 17:20:20', 150,N'TRUE'),
    (1, N'���]�ǥ~�P�H', NULL, 'NarabuWiener.jpg', '2024-05-21 17:20:20', 200,N'TRUE'),
    (1, N'�����ѥ]3', NULL, 'STILLWAITINGFORYOUBREAD3.jpg', '2024-05-22 17:20:20', 150,N'TRUE'),
    (1, N'������`�����g�A�����ѥ]', NULL, 'GINZA-KIMURAYA-SOHONTEN-ANPAN-MINI-CHARM.jpg', '2024-05-23 17:20:20', 150,N'TRUE'),
    (1, N'POMME ī�G��g�A�J�]���Q��', NULL, 'POMUNOKI-MINIATURE-CHARM.jpg', '2024-05-24 17:20:20', 100,N'TRUE'),
    (2, N'�N��d�z�t�C', NULL, 'ChiikawaCapchara.jpg', '2024-05-25 17:20:20', 250,N'TRUE'),
    (2, N'�����p�s�N�רt�C', NULL, 'CrayonShin-chan.jpg', '2024-05-26 17:20:20', 150,N'FALSE'),
    (2, N'���e���ܲ����t�C', NULL, 'Frieren-Beyond-Journey-End.jpg', '2024-05-27 17:20:20', 200,N'FALSE'),
    (2, N'�ڿW�ۤɯŨt�C', NULL, 'SoloLeveling.jpg', '2024-05-28 17:20:20', 200,N'FALSE'),
    (2, N'���~�q�O���q�t�C', NULL, 'MonstersInc.jpg', '2024-05-29 17:20:20', 150,N'FALSE');
GO


-- ���JgachaProduct
INSERT INTO gachaProduct (machineId, productName, stock, productPictureName, createTime)
VALUES
    (1, N'BASEFOOD�ѥ]-���J�O', 50, 'BASEFOODMiniatureMascotCharm-1.jpg', '2024-05-10 17:20:20'),
    (2, N'����~�P�HNarabuWiener', 50, 'narabundesu-wiener-1.jpg', '2024-05-11 17:20:20'),
    (3, N'�����ѥ]-�J�T���v', 50, 'STILLWAITINGFORYOUBREAD-1.jpg', '2024-05-12 17:20:20'),
    (4, N'�s�ج����ѥ]����` & �p§��', 50, 'GINZA KIMURAYA SOHONTEN ANPAN MINI CHARM-1.jpg', '2024-05-13 17:20:20'),
    (5, N'�g��J�]��', 50, 'POMUNOKI MINIATURE CHARM-1.jpg', '2024-05-14 17:20:20'),
    (6, N'�N��d�z�t�C-�N��d�z', 50, 'ChiikawaCapchara1.jpg', '2024-05-15 17:20:20'),
    (7, N'�����p�s�N�רt�C-�p�s�M��', 50, 'CrayonShin-chan1.jpg', '2024-05-16 17:20:20'),
    (8, N'���e���ܲ����t�C-�ܲ���A', 50, 'Frieren-Beyond-Journey-End-1.jpg', '2024-05-17 17:20:20'),
    (9, N'�ڿW�ۤɯŨt�C-�����tA', 50, 'SoloLeveling-1.jpg', '2024-05-18 17:20:20'),
    (10, N'���~�q�O���q�t�C-���', 50, 'MonstersInc-1.jpg', '2024-05-19 17:20:20');
GO



-- ���J bag
INSERT INTO bag (date, userId, gachaProductId, gachaStatus, isViewed )
VALUES
    ('2024-06-20 15:05:00', 1, 1,N'�w�W�[',1),
    ('2024-06-21 15:05:00', 2, 2,N'�s��o',0),
    ('2024-06-22 15:05:00', 3, 3,N'�w�W�[',1),
    ('2024-06-23 15:05:00', 4, 4,N'�s��o',0),
    ('2024-06-24 15:05:00', 5, 5,N'�w�洫',1),
    ('2024-06-25 15:05:00', 6, 6,N'�w�洫',1),
    ('2024-06-26 15:05:00', 7, 7,N'�w�W�[',1),
    ('2024-06-27 15:05:00', 8, 8,N'�w�洫',1),
    ('2024-06-28 15:05:00', 9, 9,N'�s��o',0),
    ('2024-06-29 15:05:00', 10, 10,N'�w�W�[',1);
GO



-- ���J shipping ���
INSERT INTO shipping (userId, shippingDate, shippingStatus, shippingAddress, contactPhone, shippingMethod, shippingFee)
VALUES
    (1, '2024-06-20 18:00:00', N'�ݳB�z', N'�n�뿤�M����215��', '0945963278', N'�v�t', 70),
    (2, '2024-06-21 18:00:00', N'�w�o�f', N'�W�Ӧa�}', N'����H���', N'711', 60),
    (3, '2024-06-22 18:00:00', N'�w����', N'�W�Ӧa�}', N'����H���', N'711', 60),
    (4, '2024-06-23 18:00:00', N'�w����', N'�]�߿��M����258��', '0971357412', N'�v�t', 70),
    (5, '2024-06-24 18:00:00', N'�ݳB�z', N'�W�Ӧa�}', N'����H���', N'711', 60),
    (6, '2024-06-25 18:00:00', N'�ݳB�z', N'�W�Ӧa�}', N'����H���', N'711', 60),
    (7, '2024-06-26 18:00:00', N'�ݳB�z', N'�W�Ӧa�}', N'����H���', N'711', 60),
    (8, '2024-06-27 18:00:00', N'�w�o�f', N'�������p��Ϥ��R��231��', '0934972352', N'�v�t', 70),
    (9, '2024-06-28 18:00:00', N'�w�o�f', N'�W�Ӧa�}', N'����H���', N'711', 60),
    (10, '2024-06-29 18:00:00', N'�w����', N'�W�Ӧa�}', N'����H���', N'711', 60);
GO


-- ���J shippingDetail ���
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


-- ���J trackingList ���
INSERT INTO trackingList (userId, gachaMachineId, trackingDate, noteStatus)
VALUES
    (1, 1, '2024-06-21 17:20:20', N'�ݳq��'),
    (2, 2, '2024-06-22 17:20:20', N'�ݳq��'),
    (3, 3, '2024-06-23 17:20:20', N'�L���q��'),
    (4, 4, '2024-06-24 17:20:20', N'�ݳq��'),
    (5, 5, '2024-06-25 17:20:20', N'�ݳq��'),
    (6, 6, '2024-06-26 17:20:20', N'�w�q��'),
    (7, 7, '2024-06-27 17:20:20', N'�L���q��'),
    (8, 8, '2024-06-28 17:20:20', N'�w�q��'),
    (9, 9, '2024-06-29 17:20:20', N'�w�q��'),
    (10, 10, '2024-06-30 17:20:20', N'�w�q��');
GO



-- ���Jrole���
INSERT INTO role (id, title) VALUES 
(1, '�޲z��'), (2, '�Ӯa');
go


-- ���J permission ���
INSERT INTO permission (id, permissionDesc) VALUES 
(1, N'�����޲z'), 
(2, N'�ӫ~�W�U�[�޲z');
go



-- ���J rolePermission ���
INSERT INTO rolePermission (roleId, permissionId) VALUES 
(1, 1), 
(2, 2);
go



-- ���J admin ���
INSERT INTO admin (account, roleId, email, phoneNumber, password,name) VALUES 
( 'aa', 1, 'admin001@example.com', '0912-345-678', '123',N'�p��'),
( 'manager002', 2, 'manager002@example.com', '0934-567-890', 'manager2',N'�j��'),
( 'supervisor3', 2, 'supervisor3@example.com', '0967-890-123', 'sup12345',N'�p��'),
( 'admin004', 1, 'admin004@example.com', '0956-123-456', 'admin456',N'�p��'),
( 'manager005', 2, 'manager005@example.com', '0987-654-321', 'manage5',N'�p��');
go





-- Insert data into convenienceStore Table �W�� (�Ȧs)
INSERT INTO convenienceStore (storeType, storeName, storeAddress, shippingFee)
VALUES
('722', N'����', N'�n�뿤�H��������704��', 20),
('722', N'���s', N'�]�߿��Y����������317�B319��1��', 20),
('722', N'�Q�W', N'�������p��ϰ��Q��12-26��', 20),
('722', N'�۱j', N'�������e���Ϧ۱j�G��39��', 20),
('722', N'���֤t', N'�������e���Ϧ۱j�@��149��1��2��', 20),
('FamilyFart', N'�x��', N'�n�뿤�H����������������', 20),
('FamilyFart', N'�Y���W����', N'�]�߿��Y������������������', 20),
('FamilyFart', N'���', N'�������p��ϴ䥭��������', 20),
('FamilyFart', N'�T��', N'�������e���Ϥ��ؤT����������', 20),
('FamilyFart', N'����', N'�������e���Ϥ��ؤT������������', 20);
go


-- Insert data into convenienceStoreInfo Table�W�ӸԲӸ��
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



-- ���J exchangeRecord ���
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


-- ���J uploadRecord ���
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


-- ���J gachaDetailList ���
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


-- ���J achievement ���
INSERT INTO achievement ([name], [description], achievementType, [target]) VALUES
(N'�즸�x��', N'���������x�ȡC', N'�x��', 1),
(N'�s��ñ��F�H', N'�s��ñ��7�ѡC', N'ñ��', 7),
(N'�洫�s��', N'���\�i�歺���洫�C', N'�洫', 1),
(N'��J��ߪ�', N'�֭p�֦�10�ӧ�J�C', N'��J�֦��ƶq', 10),
(N'�x�ȹF�H', N'�֭p�x�ȹF��1000���C', N'�x��', 1000),
(N'ñ�쩾�꯻��', N'�֭pñ��F��30�ѡC', N'ñ��', 30),
(N'�洫����', N'���\�i��50���洫�C', N'�洫', 50),
(N'��J���îa', N'�֭p�֦�100�ӧ�J�C', N'��J�֦��ƶq', 100),
(N'�x�Ȥj��', N'�榸�x�Ȫ��B�F��500���C', N'�x��', 500),
(N'ñ���', N'ñ��30���C', N'ñ��', 30);
go



-- ���J voucher ���
INSERT INTO voucher (voucherName, voucherCode, voucherDescription, duration) VALUES 
(N'��100�I', 'NEWUSER50', N'�f�t�����x�Ȱe�u�f', 30),
(N'8���u�f��', 'SUMMER20', N'�f�t���ʭ��x�u�f', 60),
(N'9���u�f��', 'SAVE100', N'�f�t���ʳs��ñ��e', 10),
(N'85���u�f��', 'MEMBER10', N'�f�t���ʥ洫�F�H', 90),
(N'95���u�f��', 'ANNIV25', N'�f�t���ʶg�����', 7),
(N'8���u�f��', 'WINTER15', N'�f�t���ʦ��N�j�v', 45),
(N'�����ʪ��u�f', 'FIRSTBUY', N'�f�t����2���e', 30),
(N'�ب⭿�I��!', 'XMAS30', N'�f�t���ʰʺ��D�D��', 15),
(N'85���u�f��', 'LOYALTY50', N'�f�t���ʧڬO��J�j�I��', 60),
(N'�K�B��', 'FLASHSALE', N'�f�t���ʧְ{�u�f', 3);
go



-- ���J rechargePlan ���
INSERT INTO rechargePlan (name, description, point, price, status, createdAt, updatedAt) VALUES 
(N'�����~���', N'100 �I�ơA�L���[�u�f�C', 100, 100, N'TRUE', '2024-06-20 10:00:00', '2024-06-20 10:00:00'),
(N'���|�~���', N'200 �I�ơA�L���[�u�f�C', 200, 200, N'TRUE', '2024-06-20 10:05:00', '2024-06-20 10:05:00'),
(N'���T�~���', N'500 �I�ơA�L���[�u�f�C', 500, 500, N'TRUE', '2024-06-20 10:10:00', '2024-06-20 10:10:00'),
(N'���G�~���', N'1000 �I�ơA�L���[�u�f�C', 1000, 1000, N'TRUE', '2024-06-20 10:15:00', '2024-06-20 10:15:00'),
(N'���@�~���', N'2000 �I�ơA�L���[�u�f�C', 2000, 2000, N'TRUE', '2024-06-20 10:20:00', '2024-06-20 10:20:00'),
(N'�ӦZ���', N'5000 �I�ơA�L���[�u�f�C', 5000, 5000, N'TRUE', '2024-06-20 10:25:00', '2024-06-20 10:25:00');
go



-- ���J rechargeList ���
INSERT INTO rechargeList (quantity, amount, paymentMode, rechargePlanId, userId)
VALUES
    (1, 100, N'�H�Υd', 1, 1),
    (2, 500, N'�H�Υd', 3, 2),
    (1, 300, N'�H�Υd', 2, 3),
    (1, 100, N'�H�Υd', 1, 4),
    (3, 500, N'�H�Υd', 3, 5),
    (2, 300, N'�H�Υd', 2, 6),
    (1, 100, N'�H�Υd', 1, 7),
    (1, 500, N'�H�Υd', 3, 8),
    (2, 300, N'�H�Υd', 2, 9),
    (1, 100, N'�H�Υd', 1, 10);
GO



-- ���J pointList ���
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



-- ���J announcement ���
INSERT INTO announcement (title, content, [image]) VALUES
(N'���@�q��', N'���F���ѧ�n���A�ȡA�ڭ̪��t�αN����12�I��2�I�i����@�C�Ш��̡C', 'maintenance.png'),
(N'�s�\��w�i', N'�ڭ̥��b�V�O�}�o�s�\��A�w�p�U�Ӥ���X�C�q�д��ݡI', 'features.png'),
(N'����ñ��e', N'������{�A�u�nñ��Y�i��o�u�f��A���e���L�I', 'sale.png'),
(N'�洫����', N'���ʴ����洫���Q���A�Y�i��o�K�����u�f��!�C', 'exchange_event.png'),
(N'�t�Χ�s', N'���F���ѧ�n���Τ�����A�ڭ̪��t�αN�i���s�C�д��e���n�ǳơC', 'update.png'),
(N'�Τ�䴩', N'�p�G�z�b�ϥΧڭ̪��A�ȮɹJ�������D�A���H���pô�ڭ̪��Τ�䴩�ζ��C�ڭ��H�ɦb�o�̬��z�������U�C', 'support.png'),
(N'�ڬO��J�j�I��', N'�u�n���ʴ������ֿn��o50����J�A�Y�i����K�B��!', 'upgrade.png'),
(N'�s�|��§�J', N'�s�|�����U�C�Ѥ��x�ȥ��N���B�I�ơA�Y�i�B�~��o�K���u�f��A�֨ӥ[�J�a�I', 'new_member.png'),
(N'�ʺ��D�D��', N'�ʺ��D�D�t�C��J�������K����!', 'animeDay.png'),
(N'�w��ĵ�i', N'���F�z���㸹�w���A�Ф��n���S�z���ӤH�H���C', 'security.png');
go



-- ���J activityType ���
INSERT INTO activityType ([name]) VALUES
(N'�x��'),
(N'ñ��'),
(N'���N'),
(N'�洫'),
(N'�D�D��'),
(N'��J�֦��ƶq');
go



-- ���J activity ���
INSERT INTO [activity] (title, [description], activityTypeId, activityStart, activityEnd) VALUES
(N'�x�Ȱe�u�f', N'�@���x�Ⱥ�1000�I�Y�e100�I', 1, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'���x�u�f', N'�s��b��C�Ѥ��x����o8���u�f��', 1, '2024-12-01 00:00:00', '2024-12-31 23:59:59'),
(N'�s��ñ��e', N'�s��Q�ѵn�J�e9���u�f��', 2, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'�洫�F�H', N'�洫�Q����o85���u�f��', 4, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'�g�����', N'����n�J�e95���u�f��', 2, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'���N�j�v', N'�Q�Ѥ���o���Ӧ��N�i�H����8���u�f��', 3, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'2���e', N'���ʴ������x����o�⭿�I��!', 1, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'�ʺ��D�D��', N'�u�n�ŦX�ʺ��D�D��J�һ��I�Ƨ�85��', 5, '2024-07-01 00:00:00', '2024-07-31 23:59:59'),
(N'�ڬO��J�j�I��', N'�������u�n�I�]���֦�50����J�Y�i�K�B�O', 6, '2024-07-01 00:00:00', '2024-07-31 23:59:59');
go



-- ���J activityLinkVoucher ���
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



-- ���J userVoucher ���
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




-- ���J userAchievement ���
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



-- ���J achievementProgress ���
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



-- ���J checkIn ���
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
