CREATE DATABASE QL_BANVE
GO

USE QL_BANVE
GO

----------------------------------- TẠO BẢNG QUYỀN TRUY CẬP
CREATE TABLE QUYENTC
(
	MAQUYEN INT NOT NULL IDENTITY(1, 1),
	TENQUYEN NVARCHAR(20),
	CONSTRAINT PK_QUYENTC PRIMARY KEY (MAQUYEN)
);

----------------------------------- TẠO BẢNG NHÂN VIÊN BÁN VÉ
CREATE TABLE NVBANVE
(
	MANV INT NOT NULL IDENTITY(1, 1),
	TENDN VARCHAR(20),
	MATKHAU VARCHAR(20),
	TENNV NVARCHAR(50),
	NGAYSINH DATE,
	GIOITINH NVARCHAR(5),
	DIACHI NVARCHAR(50),
	CMND VARCHAR(12),
	SDT VARCHAR(10),
	EMAIL VARCHAR(30),
	MAQUYEN INT,
	CONSTRAINT PK_NVBANVE PRIMARY KEY (MANV)
);

----------------------------------- TẠO BẢNG KHÁCH HÀNG
CREATE TABLE KHACHHANG
(
	MAKH INT NOT NULL IDENTITY(1, 1),
	TENDN VARCHAR(20),
	MATKHAU VARCHAR(20),
	TENKH NVARCHAR(50),
	NGAYSINH DATE,
	GIOITINH NVARCHAR(5),
	DIACHI NVARCHAR(50),
	SDT VARCHAR(10),
	EMAIL VARCHAR(30),
	CMND VARCHAR(12),
	CONSTRAINT PK_KHACHHANG PRIMARY KEY (MAKH)
);


----------------------------------- TẠO BẢNG XE
CREATE TABLE XE
(
	MAXE INT NOT NULL IDENTITY(1, 1),
	TENXE NVARCHAR(50),
	CONSTRAINT PK_XE PRIMARY KEY (MAXE)
);

----------------------------------- TẠO BẢNG XE
CREATE TABLE CTXE
(
	MAXE INT,
	MALOAIXE INT,
	BENSOXE VARCHAR(15),
	SOGHE INT,
	CONSTRAINT PK_CTXE PRIMARY KEY (MAXE, MALOAIXE, BENSOXE)
);

----------------------------------- TẠO BẢNG LOẠI XE
CREATE TABLE LOAIXE
(
	MALOAIXE INT NOT NULL IDENTITY(1, 1),
	TENLOAIXE NVARCHAR(50),
	CONSTRAINT PK_LOAIXE PRIMARY KEY (MALOAIXE)
);

----------------------------------- TẠO BẢNG VÉ XE
CREATE TABLE VEXE
(
	MAVE INT NOT NULL IDENTITY(1, 1),
	TENVE NVARCHAR(50),
	MANV INT,
	MACHUYENXE INT,
	CONSTRAINT PK_VEXE PRIMARY KEY (MAVE)
);

----------------------------------- TẠO BẢNG CHI TIẾT VÉ XE
CREATE TABLE CHITIETVEXE
(
	MACTVX INT NOT NULL IDENTITY(1, 1),
	MAVE INT,
	MAKH INT,
	VITRIGHE INT,
	GHICHU NVARCHAR(50),
	CONSTRAINT PK_CHITIETVEXE PRIMARY KEY (MACTVX)
);

----------------------------------- TẠO BẢNG TUYẾN XE
CREATE TABLE TUYENXE
(
	MATUYEN INT NOT NULL IDENTITY(1, 1),
	TENTUYEN NVARCHAR(50),
	DIEMXUATPHAT NVARCHAR(50),
	DIEMDEN NVARCHAR(50),
	BANGGIA DECIMAL(18, 0),
	MAXE INT,
	CONSTRAINT PK_TUYENXE PRIMARY KEY (MATUYEN)
);

----------------------------------- TẠO BẢNG TÀI XẾ
CREATE TABLE TAIXE
(
	MATAIXE INT NOT NULL IDENTITY(1, 1),
	TENTAIXE NVARCHAR(50),
	NGAYSINH DATE,
	GIOITINH NVARCHAR(5),
	DIACHI NVARCHAR(50),
	CMND VARCHAR(12),
	SDT VARCHAR(10),
	EMAIL VARCHAR(30),
	CONSTRAINT PK_TAIXE PRIMARY KEY (MATAIXE)
);

----------------------------------- TẠO BẢNG CHUYẾN XE
CREATE TABLE CHUYENXE
(
	MACHUYENXE INT NOT NULL IDENTITY(1, 1),
	MATUYEN INT,
	GIOXUATPHAT VARCHAR(20),
	GIODEN VARCHAR(20),
	GHETRONG INT,
	MATAIXE INT,
	CONSTRAINT PK_CHUYENXE PRIMARY KEY (MACHUYENXE)
);


----------
----------------------------------- TẠO RÀNG BUỘC KHÓA NGOẠI

-------------------------- KHÓA NGOẠI NHÂN VIÊN BÁN VÉ
ALTER TABLE NVBANVE
ADD CONSTRAINT FK_NVBANVE_QUYENTC FOREIGN KEY (MAQUYEN) REFERENCES QUYENTC(MAQUYEN)

-------------------------- KHÓA NGOẠI CHI TIẾT XE
ALTER TABLE CTXE
ADD CONSTRAINT FK_CTXE_LOAIXE FOREIGN KEY (MALOAIXE) REFERENCES LOAIXE(MALOAIXE)

ALTER TABLE CTXE
ADD CONSTRAINT FK_CTXE_XE FOREIGN KEY (MAXE) REFERENCES XE(MAXE)

-------------------------- KHÓA NGOẠI VÉ XE
ALTER TABLE VEXE
ADD CONSTRAINT FK_VEXE_NVBANVE FOREIGN KEY (MANV) REFERENCES NVBANVE(MANV)

ALTER TABLE VEXE
ADD CONSTRAINT FK_VEXE_CHUYENXE FOREIGN KEY (MACHUYENXE) REFERENCES CHUYENXE(MACHUYENXE)

-------------------------- KHÓA NGOẠI CHI TIẾT VÉ XE
ALTER TABLE CHITIETVEXE
ADD CONSTRAINT FK_CHITIETVEXE_VEXE FOREIGN KEY (MAVE) REFERENCES VEXE(MAVE)

ALTER TABLE CHITIETVEXE
ADD CONSTRAINT FK_CHITIETVEXE_KHACHHANG FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH)

-------------------------- KHÓA NGOẠI CHUYẾN XE
ALTER TABLE CHUYENXE
ADD CONSTRAINT FK_CHUYENXE_TUYENXE FOREIGN KEY (MATUYEN) REFERENCES TUYENXE(MATUYEN)

ALTER TABLE CHUYENXE
ADD CONSTRAINT FK_CHUYENXE_TAIXE FOREIGN KEY (MATAIXE) REFERENCES TAIXE(MATAIXE)

-------------------------- KHÓA NGOẠI TUYẾN XE
ALTER TABLE TUYENXE
ADD CONSTRAINT FK_TUYENXE_XE FOREIGN KEY (MAXE) REFERENCES XE(MAXE)

----------
----------------------------------- THÊM DỮ LIỆU VÀO CÁC BẢNG

-------------------------- THÊM DỮ LIỆU VÀO BẢNG QUYỀN TRUY CẬP
INSERT INTO QUYENTC(TENQUYEN)
VALUES 
(N'Admin'),
(N'Nhân viên bán vé');

-------------------------- THÊM DỮ LIỆU VÀO BẢNG NHÂN VIÊN BÁN VÉ
SET DATEFORMAT DMY
INSERT INTO NVBANVE(TENDN, MATKHAU, TENNV, NGAYSINH, GIOITINH, DIACHI, CMND, SDT, EMAIL, MAQUYEN)
VALUES
('2001200771', '123', N'Phạm Trần Tấn Đạt', '22/09/2002', N'Nam', N'Kiên Giang', '0123456789', '0123456789', 'tandat123@gmail.com', 2),
('2001200775', '123', N'Nguyễn Minh Khoa', '07/05/2002', N'Nam', N'Kiên Giang', '0123789456', '0123789456', 'minhkhoa123@gmail.com', 2),
('2001200516', '123', N'Lê Tiến Hưng', '24/10/2002', N'Nam', N'Kiên Giang', '0789123456', '0789123456', 'tienhung123@gmail.com', 2),
('2001202037', '123', N'Hoàng Lê Quốc Đạt', '13/02/2002', N'Nam', N'Kiên Giang', '0456789123', '0456789123', 'quocdat123@gmail.com', 2),
('2001202044', '123', N'Huỳnh Phan Thành Đạt', '19/08/2002', N'Nam', N'Kiên Giang', '0456123789', '0456123789', 'thanhdat123@gmail.com', 2),
('2001200288', '123', N'Lê Sĩ Hoàng', '26/11/2002', N'Nam', N'Kiên Giang', '0789456123', '0789456123', 'sihoang123@gmail.com', 2);

-------------------------- THÊM DỮ LIỆU VÀO BẢNG KHÁCH HÀNG
INSERT INTO KHACHHANG(TENDN, MATKHAU, TENKH, NGAYSINH, GIOITINH, DIACHI, CMND, SDT, EMAIL)
VALUES
('tdat123', '123', N'Phạm Trần Tấn Đạt', '22/09/2002', N'Nam', N'Kiên Giang', '0123456789', '0123456789', 'tandat123@gmail.com'),
('khoa123', '123', N'Nguyễn Minh Khoa', '07/05/2002', N'Nam', N'Kiên Giang', '0123789456', '0123789456', 'minhkhoa123@gmail.com'),
('hung123', '123', N'Lê Tiến Hưng', '24/10/2002', N'Nam', N'Kiên Giang', '0789123456', '0789123456', 'tienhung123@gmail.com'),
('qdat123', '123', N'Hoàng Lê Quốc Đạt', '13/02/2002', N'Nam', N'Kiên Giang', '0456789123', '0456789123', 'quocdat123@gmail.com'),
('thdat123', '123', N'Huỳnh Phan Thành Đạt', '19/08/2002', N'Nam', N'Kiên Giang', '0456123789', '0456123789', 'thanhdat123@gmail.com'),
('hoang123', '123', N'Lê Sĩ Hoàng', '26/11/2002', N'Nam', N'Kiên Giang', '0789456123', '0789456123', 'sihoang123@gmail.com');

-------------------------- THÊM DỮ LIỆU VÀO BẢNG LOẠI XE
INSERT INTO LOAIXE(TENLOAIXE)
VALUES
(N'Xe giường nằm'),
(N'Xe ghế ngồi');

-------------------------- THÊM DỮ LIỆU VÀO BẢNG XE
INSERT INTO XE(TENXE)
VALUES
(N'Phương Trang'),
(N'Tuấn Nga'),
(N'Mai Linh'),
(N'Thành Bưởi'),
(N'Kumho Samco'),
(N'Khải Nam'),
(N'Như Ngọc');

-------------------------- THÊM DỮ LIỆU VÀO BẢNG XE
INSERT INTO CTXE(MAXE, MALOAIXE, BENSOXE, SOGHE)
VALUES
(1, 1,'51B-164.05', 36),
(1, 1,'51B-292.96', 36),
(1, 1,'51B-298.81', 36),
(2, 2,'51B-137.37', 18),
(2, 1,'51B-122.99', 36);

-------------------------- THÊM DỮ LIỆU VÀO BẢNG TUYẾN XE
INSERT INTO TUYENXE(TENTUYEN, DIEMXUATPHAT, DIEMDEN, BANGGIA, MAXE)
VALUES
(N'bx.Miền Tây - bx.Rạch Sỏi', N'bx.Miền Tây', N'bx.Rạch Sỏi', 220000, 1),
(N'bx.Hà Tiên - bx.Miền Tây',  N'bx.Hà Tiên', N'bx.Miền Tây', 220000, 2),
(N'bx.Miền Tây - Long An',  N'bx.Miền Tây', N'Long An', 180000, 6),
(N'Cần Thơ - bx.Miền Tây',  N'Cần Thơ', N'bx.Miền Tây', 180000, 2),
(N'bx.Miền Tây - Trà Vinh',  N'bx.Miền Tây', N'Trà Vinh', 220000, 7),
(N'bx.Miền Tây - Vĩnh Long',  N'bx.Miền Tây', N'Vĩnh Long', 180000, 5),
(N'bx.Miền Tây - Đồng Tháp',  N'bx.Miền Tây', N'Đồng Tháp', 220000, 3),
(N'bx.Miền Tây - Sóc Trăng',  N'bx.Miền Tây', N'Sóc Trăng', 180000, 6),
(N'Hậu Giang - bx.Miền Tây',  N'Hậu Giang', N'bx.Miền Tây', 200000, 1),
(N'Bạc Liêu - bx.Miền Tây',  N'Bạc Liêu', N'bx.Miền Tây', 200000, 3),
(N'bx.Miền Tây - An Giang',  N'bx.Miền Tây', N'An Giang', 180000, 4),
(N'bx.Hà Tiên - bx.Miền Tây',  N'bx.Hà Tiên', N'bx.Miền Tây', 220000, 7),
(N'bx.Rạch Sỏi - bx.Miền Tây',  N'bx.Rạch Sỏi', N'bx.Miền Tây', 220000, 3),
(N'An Giang - bx.Miền Tây',  N'An Giang', N'bx.Miền Tây', 180000, 4),
(N'bx.Hà Tiên - bx.Miền Tây',  N'bx.Hà Tiên', N'bx.Miền Tây', 200000, 5),
(N'Sa Đéc - bx.Hà Tiên',  N'Sa Đéc', N'bx.Hà Tiên', 200000, 7),
(N'bx.Miền Tây - An Giang',  N'bx.Miền Tây', N'An Giang', 220000, 5),
(N'bx.Hà Tiên - Cần Thơ',  N'bx.Hà Tiên', N'Cần Thơ', 180000, 6),
(N'Vĩnh Long - Cần Thơ',  N'Vĩnh Long', N'Cần Thơ', 220000, 4),
(N'bx.Miền Tây - Sa Đéc',  N'bx.Miền Tây', N'Sa Đéc', 180000, 4);


-------------------------- THÊM DỮ LIỆU VÀO BẢNG TÀI XẾ
INSERT INTO TAIXE(TENTAIXE,NGAYSINH, GIOITINH, DIACHI, CMND, SDT, EMAIL)
VALUES
(N'Nguyễn Văn An', '31/01/1987', N'Nam', N'Kiên Giang', '0123456789', '0123456789', 'an123@gmail.com'),
(N'Huỳnh Gia Khương', '31/01/1987', N'Nam', N'Kiên Giang', '0123456789', '0123456789', 'khuong123@gmail.com'),
(N'Trần Quốc Quy', '31/01/1987', N'Nam', N'Kiên Giang', '0123456789', '0123456789', 'quy123@gmail.com'),
(N'Lê Quang Vinh', '31/01/1987', N'Nam', N'Kiên Giang', '0123456789', '0123456789', 'vinh123@gmail.com');

-------------------------- THÊM DỮ LIỆU VÀO BẢNG CHUYẾN XE
INSERT INTO CHUYENXE(MATUYEN, GIOXUATPHAT, GIODEN, GHETRONG, MATAIXE)
VALUES
(1, '20:00', '04:00', 36, 1),
(3, '22:00', '03:00', 36, 3),
(2, '22:00', '03:00', 36, 4),
(5, '20:00', '04:00', 36, 2),
(4, '24:00', '03:30', 36, 1);

INSERT INTO CHUYENXE(MATUYEN, GIOXUATPHAT, GIODEN, GHETRONG, MATAIXE)
VALUES
(10, '21:00', '3:00', 36, 1),
(7, '16:00', '21:00', 36, 3),
(9, '20:00', '04:00', 36, 4),
(6, '22:00', '03:00', 36, 2),
(8, '21:00', '3:00', 36, 1);
INSERT INTO CHUYENXE(MATUYEN, GIOXUATPHAT, GIODEN, GHETRONG, MATAIXE)
VALUES
(13, '22:00', '03:00', 36, 1),
(15, '21:00', '3:00', 36, 3),
(11, '11:00', '15:00', 36, 4),
(12, '20:00', '04:00', 36, 2),
(14, '21:00', '3:00', 36, 1);
INSERT INTO CHUYENXE(MATUYEN, GIOXUATPHAT, GIODEN, GHETRONG, MATAIXE)
VALUES
(17, '20:00', '04:00', 36, 1),
(16, '23:00', '3:00', 36, 3),
(20, '23:00', '03:00', 36, 4),
(18, '16:00', '09:40', 36, 2),
(19, '22:00', '08:30', 36, 1);

select TENTUYEN, TENXE, DIEMXUATPHAT, DIEMDEN, GIOXUATPHAT, BANGGIA 
from TUYENXE
join CHUYENXE 
on TUYENXE.MATUYEN = CHUYENXE.MATUYEN
join XE
on TUYENXE.MAXE = XE.MAXE 
order by TENXE DESC

select * from tuyenxe

select distinct GIOXUATPHAT, MACHUYENXE from CHUYENXE order by GIOXUATPHAT ASC