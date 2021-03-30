-- Creating Database

-- DROP DATABASE QLCuaHangDienThoaiDb
CREATE DATABASE QLCuaHangDienThoaiDb
GO
USE QLCuaHangDienThoaiDb
GO


--Creating tables

CREATE TABLE TaiKhoan(
	TenTaiKhoan varchar(50) PRIMARY KEY,
	MatKhau varchar(50),
	HoTen nvarchar(50),
	GioiTinh bit,
	SoDienThoai varchar(15),
	Email varchar(50),
	DiaChi nvarchar(255),
	IsAdmin bit
)
GO

CREATE TABLE LoaiDienThoai (
	Id int PRIMARY KEY identity(1, 1),
	Ten nvarchar(100),
	MoTa nvarchar(200)
)
GO

CREATE TABLE DienThoai(
	Id int PRIMARY KEY identity(1, 1),
	Ten nvarchar(100),
	MoTa nvarchar(1000),
	SoLuong int check(SoLuong > 0),
	UrlHinhAnh varchar(200),
	Gia int,
	IdLoaiDienThoai int REFERENCES LoaiDienThoai(Id)
)
GO


CREATE TABLE GioHang(
	Id int PRIMARY KEY identity(1, 1),
	TaiKhoan varchar(50) REFERENCES TaiKhoan(TenTaiKhoan),
	IdDienThoai int REFERENCES DienThoai(Id),
	DaDatHang bit default 0,
	NgayThem date,
)
GO

CREATE TABLE DatHang(
	Id int PRIMARY KEY identity(1, 1),
	TaiKhoan varchar(50) REFERENCES TaiKhoan(TenTaiKhoan),
	IdDienThoai int REFERENCES DienThoai(Id),
	TrangThai int check(TrangThai >= 1 and TrangThai <= 3), --['Chưa thanh toán', 'Đã thanh toán', 'Đã huỷ']
	NgayTao date,
	TongTien int
)
GO


-- Creating triggers
Create trigger deleteTaiKhoan on TaiKhoan instead of delete
as
begin
	declare @TaiKhoan varchar(50)
	select @TaiKhoan=TenTaiKhoan from deleted


	Delete from HoaDon where TaiKhoan=@TaiKhoan
	Delete from GioHang where TaiKhoan=@TaiKhoan
	Delete from TaiKhoan where TenTaiKhoan=@TaiKhoan
end
GO

Create trigger deleteLoaiDienThoai on LoaiDienThoai instead of delete
as
begin
	declare @IdLoaiDienThoai int
	select @IdLoaiDienThoai=Id from deleted


	Delete from DienThoai where IdLoaiDienThoai=@IdLoaiDienThoai
	Delete from LoaiDienThoai where Id=@IdLoaiDienThoai
end
GO

Create trigger deleteDienThoai on DienThoai instead of delete
as
begin
	declare @IdDienThoai int
	select @IdDienThoai=Id from deleted


	Delete from GioHang where IdDienThoai=@IdDienThoai
	Delete from DatHang where IdDienThoai=@IdDienThoai
	Delete from DienThoai where Id=@IdDienThoai
end
GO

Create trigger insertDatHang on DatHang for insert
as
begin
	declare @IdDienThoai int
	select @IdDienThoai=IdDienThoai from inserted

	Delete from GioHang where IdDienThoai=@IdDienThoai
end
GO



-- Creating procedures
Create proc spDangNhap @tenTK varchar(50), @matKhau varchar(50)
as
begin
	select * from TaiKhoan where TenTaiKhoan=@tenTK and MatKhau=@matKhau 
end
GO


--Inserting default data
Insert into TaiKhoan values
('Lanh', '123456', N'Tẩn Thị Lan Anh', 0, '012345678', 'lanh@gmail.com', N'Đường Z 115, Quyết Thắng, Thành phố Thái Nguyên, Thái Nguyên', 1),
('admin', '123456', N'Admin', 1, '0123455678', 'admin@gmail.com', N'Ngõ 1 Phạm Văn Đồng', 1),
('User', '123456', N'Khách Hàng 1', 0, '012345678', 'user@gmail.com', N'Ngõ 1 Phạm Văn Đồng', 0)
GO

Insert into LoaiDienThoai values
('IPhone', N'iPhone là mẫu smartphone của hãng điện tử Mỹ Apple Inc. Phiên bản iPhone đầu tiên ra mắt ngày 09 tháng 01 năm 2007 và lên kệ bán vào ngày 29 tháng 6 năm 2007.'),
('SamSung', N'Samsung đang kinh doanh các dòng điện thoại như: Galaxy A, Galaxy J, Galaxy C và mới đây là là Galaxy M. Tuy nhiên, nổi bật nhất vẫn là các sản phẩm cao cấp Galaxy Galaxy S10.'),
('OPPO', N'Sản phẩm đầu tiên đánh dấu sự xuất hiện của OPPO tại thị trường Việt Nam là chiếc smartphone OPPO Find 5, xuất hiện vào cuối năm 2012 với mức giá khoảng 10 triệu đồng.')
GO

Insert into DienThoai values
('IPhone 12', N'iPhone là mẫu smartphone của hãng điện tử Mỹ Apple Inc', 100, 'Images/iphone12.jpg', 25000000, 1),
('SamSung S10', N'Samsung đang kinh doanh các dòng điện thoại như: Galaxy A.', 70, 'Images/iphone12.jpg', 11000000, 2),
('OPPO A5s', N'Sản phẩm đầu tiên đánh dấu sự xuất.', 50, 'Images/iphone12.jpg', 5000000, 3)
GO
