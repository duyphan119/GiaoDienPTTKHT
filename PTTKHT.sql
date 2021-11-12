create database btl_pttkht;
use btl_pttkht;

create table nhanvien
(
	manv int primary key,
	tennv nvarchar(50) not null,
	gioitinh nvarchar(5) not null ,
	sdt varchar(11) not null,
	chucvu nvarchar(30) not null,
	matkhau varchar(20) not null,
	quyen varchar(10) not null default 'admin',
	ngaysinh datetime not null
);

insert into nhanvien(manv, tennv, ngaysinh, gioitinh, sdt, chucvu, matkhau, quyen) values
(1, N'Phan Khánh Duy','1989-01-01', N'Nam', '0375593241', N'Giám Đốc', '123456', 'admin'),
(2, N'Nguyễn Hữu An','1989-02-01', N'Nam', '0375593242', N'Bếp Trưởng', '123456', 'admin'),
(3, N'Phạm Minh Hiếu','1989-03-01', N'Nam', '0375593243', N'Thủ Kho', '123456', 'admin'),
(4, N'Trần Mặc Khải','1989-04-01', N'Nam', '0375593244', N'Kế Toán Trưởng', '123456', 'admin'),
(5, N'Trần Tấn Nhựt','1989-05-01', N'Nam', '0375593245', N'Nhân Viên Kế Toán', '123456', 'admin'),
(6, N'Nguyễn Văn Bê','1999-02-01', N'Nam', '0375593246', N'Bảo Vệ', '123456', 'user'),
(7, N'Nguyễn Văn Xê','1999-03-01', N'Nam', '0375593247', N'Lao Công', '123456', 'user'),
(8, N'Trần Văn An','1999-04-01', N'Nam', '0375593248', N'Nhân Viên Chạy Bàn', '123456', 'user'),
(9, N'Trần Văn Bê','1999-01-01', N'Nam', '0375593249', N'Lễ Tân', '123456', 'user'),
(10, N'Trần Văn Xê','1999-11-01', N'Nam', '0372592249', N'Nhân Viên Phục Vụ', '123456', 'user'),
(11, N'Trần Văn Đê','1999-07-01', N'Nam', '0375592249', N'Nhân Viên Phục Vụ', '123456', 'user'),
(12, N'Trần Văn Gờ','1999-01-06', N'Nam', '0375591249', N'Nhân Viên Đầu Bếp', '123456', 'user');
select * from nhanvien;

create table nhommon
(
	manhom int primary key,
	tennhom nvarchar(50) not null
);
insert into nhommon(manhom, tennhom) values
(1, N'Nhóm 1'),
(2, N'Nhóm 2'),
(3, N'Nhóm 3'),
(4, N'Nhóm 4'),
(5, N'Nhóm 5');
create table monan
(
	mamon int primary key,
	tenmon nvarchar(50) not null,
	giatien int not null,
	dvt nvarchar(10) not null,
	manhom int,
	foreign key (manhom) references nhommon(manhom)
);
insert into monan (mamon, tenmon, giatien, dvt, manhom) values
(1, N'Món 1', 300000, N'Dĩa', 1),
(2, N'Món 2', 330000, N'Dĩa', 1),
(3, N'Món 3', 400000, N'Dĩa', 2),
(4, N'Món 4', 320000, N'Dĩa', 2),
(5, N'Món 5', 330000, N'Dĩa', 2),
(6, N'Món 6', 200000, N'Dĩa', 3),
(7, N'Món 7', 170000, N'Dĩa', 3),
(8, N'Món 8', 240000, N'Dĩa', 3),
(9, N'Món 9', 550000, N'Dĩa', 4),
(10, N'Món 10', 450000, N'Dĩa', 4),
(11, N'Món 11', 330000, N'Dĩa', 5),
(12, N'Món 12', 300000, N'Dĩa', 5);
create table ban
(
	soban int primary key,
	trangthai bit not null
);
insert into ban(soban, trangthai) values
(1,1),(2,1),(3,1),(4,1),(5,0),(6,1),(7,1),(8,1),(9,1),
(10,1),(11,0),(12,1),(13,1),(14,0),(15,1),(16,1),(17,0),(18,1);

create table hoadon
(
	sohd int primary key,
	ngayhd datetime,
	manv int,
	soban int,
	foreign key (manv) references nhanvien(manv),
	foreign key (soban) references ban(soban)
);
insert into hoadon(sohd, ngayhd, manv, soban) values
(1, '2021/11/11 10:20:10', 3, 1),(2, '2021/11/11 10:40:10', 3, 2),
(3, '2021/11/11 16:20:10', 3, 4),(4, '2021/11/11 16:50:10', 3, 12),
(5, '2021/11/11 21:20:10', 3, 5),(6, '2021/11/11 20:20:10', 3, 3),
(7, '2021/11/12 09:20:10', 4, 7),(8, '2021/11/12 10:30:10', 4, 10),
(9, '2021/11/12 18:20:10', 4, 8),(10, '2021/11/12 19:20:10', 4, 1),
(11, '2021/11/12 20:20:10', 4, 9),(12, '2021/11/12 21:20:10', 4, 11),
(13, null, 5, 11);
update hoadon set ngayhd = GETDATE() where ngayhd = null and soban = 11

create table chitiethoadon
(
	sohd int,
	mamon int,
	soluong int,
	foreign key (sohd) references hoadon(sohd),
	foreign key (mamon) references monan(mamon),
);
insert into chitiethoadon (sohd, mamon, soluong) values
(1, 1, 2),
(2, 2, 2),
(3, 3, 2),
(3, 4, 1),
(4, 5, 2),
(5, 1, 3),
(6, 6, 2),
(7, 8, 3),
(8, 9, 1),
(8, 10, 2),
(9, 12, 2),
(10, 7, 2),
(10, 12, 1),
(11, 6, 2),
(12, 4, 2),
(13, 3, 2),
(13, 8, 2);
create table nhacungcap
(
	mancc int primary key,
	tenncc nvarchar(100) not null,
	diachi nvarchar(100) not null,
	sdt varchar(11) not null
);
create table nguyenlieu
(
	manl int primary key,
	tennl nvarchar(50) not null,
	giatien int not null,
	dvt nvarchar(10) not null,
	mancc int,
	foreign key (mancc) references nhacungcap(mancc)
);
create table phieunhap
(
	sopn int primary key,
	ngaynhap datetime not null,
	manv int,
	foreign key (manv) references nhanvien(manv)
);
create table chitietphieunhap
(
	sopn int,
	manl int,
	soluong int,
	foreign key (sopn) references phieunhap(sopn),
	foreign key (manl) references nguyenlieu(manl)
);

create table phieuxuat
(
	sopx int primary key,
	ngayxuat datetime not null,
	manv int,
	foreign key (manv) references nhanvien(manv)
);
create table chitietphieuxuat
(
	sopx int,
	manl int,
	soluong int,
	foreign key (sopx) references phieuxuat(sopx),
	foreign key (manl) references nguyenlieu(manl)
);
--Danh sách món ăn của bàn
create proc sp_DanhSachMonAnCuaBan
	(
		@soban int
	)
	as
		begin
			--Lấy ra danh sách món ăn
			select hd.sohd, m.mamon, m.tenmon, cthd.soluong , m.dvt, m.giatien, (cthd.soluong * m.giatien) as 'thanhtien'
			from hoadon hd, monan m, chitiethoadon cthd
			where hd.sohd = cthd.sohd and m.mamon = cthd.mamon and hd.ngayhd is null and hd.soban = @soban --Ngày là null : chưa thanh toán
		end
		--Test thử với danh sách món ăn bàn 5
		
		execute sp_DanhSachMonAnCuaBan 11;
		
--Thanh Toán
create proc sp_ThanhToan
	(
		@sohd int
	)
	as
		begin
			--Khai báo biến
			declare @soban int;
			--Gán giá trị
			select @soban = soban from hoadon where sohd = @sohd;
			--Cập nhật thời gian thanh toán của hoá đơn
			update hoadon set ngayhd = null where sohd = @sohd;
			--Cập nhật trạng thái của bàn
			update ban set trangthai = 1 where soban = @soban;
		end









