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
(1, N'Gỏi'),(2, N'Hàu'),(3, N'Vẹm'),(4, N'Sò Điệp'),(5, N'Sò Dương'),(6, N'Sò Huyết'),
(7, N'Ốc'),(8, N'Ốc Vòi Voi'),(9, N'Nghêu'),(10, N'Nghêu Hai Cồi'),(11, N'Tôm Càng'),(12, N'Tôm Hùm'),
(13, N'Tôm Hùm Alaska'),(14, N'Tôm Tích'),(15, N'Tôm Sú'),(16, N'Tôm Mũ Ni'),(17, N'Ghẹ'),(18, N'Cua'),
(19, N'Cua Hoàng Đế'),(20, N'Cua Hai Da'),(21, N'Cá'),(22, N'Mực'),(23, N'Các Loại Cuốn'),(24, N'Lươn'),
(25, N'Xà Lách'),(26, N'Các Loại Rau'),(27, N'Súp'),(28, N'Cháo'),(29, N'Lẩu'),(30, N'Các Món Ăn Kèm'),
(31, N'Cơm'),(32, N'Mì');


create table monan
(
	mamon int primary key,
	tenmon nvarchar(50) not null,
	giatien int not null,
	dvt nvarchar(10) not null,
	manhom int,
	foreign key (manhom) references nhommon(manhom)
);
select * from monan;

insert into monan (mamon, tenmon, giatien, dvt, manhom) values
(1, N'Gỏi cá mai', 250000, N'Dĩa', 1),(2, N'Gỏi sò huyết', 285000, N'Dĩa', 1),
(3, N'Gỏi sứa tôm thịt', 260000, N'Dĩa', 1),(4, N'Gỏi lươn', 230000, N'Dĩa', 1),
(5, N'Hàu sống', 38000, N'Con', 2),(6, N'Hàu chưng tàu xì', 45000, N'Con', 2),
(7, N'Hàu nướng mọi', 40000, N'Con', 2),(8, N'Hàu chiên trứng', 45000, N'Con', 2),
(9, N'Hàu nướng mở hành', 450000, N'Con', 2),(10, N'Hàu đút lò hạnh nhân', 45000, N'Con', 2),
(11, N'Vẹm hấp kiểu Pháp', 265000, N'Dĩa', 3),(12, N'Vẹm nướng mỡ hành', 265000, N'Dĩa', 3),
(13, N'Vẹm đút lò phô mai', 265000, N'Dĩa', 3),(14, N'Vẹm xào bơ', 265000, N'Dĩa', 3),
(15, N'Sò điệp xào tỏi', 55000, N'Con', 4),(16, N'Sò điệp nướng mỡ hàng', 55000, N'Con', 4),
(17, N'Sò điệp nướng sa tế', 55000, N'Con', 4),(18, N'Sò điệp đút lò phô mai', 55000, N'Con', 4),
(19, N'Sò điệp nướng', 55000, N'Con', 4),(20, N'Sò điệp xào bơ', 55000, N'Con', 4),
(21, N'Sò dương xào bơ', 95000, N'Con', 5),(22, N'Sò dương nướng mỡ hàng', 95000, N'Con', 5),
(23, N'Sò dương đút lò phô mai', 95000, N'Con', 5),(24, N'Sò huyết nướng', 240000, N'Dĩa', 6),
(25, N'Sò huyết rang tiêu', 260000, N'Dĩa', 6),(26, N'Sò huyết rang me', 260000, N'Dĩa', 6),
(27, N'Sò huyết Tứ Xuyên', 260000, N'Dĩa', 6),(28, N'Ốc hương nướng', 570000, N'Dĩa', 7),
(29, N'Ốc nhảy nướng', 275000, N'Dĩa', 7),(30, N'Ốc móng tay xào tỏi', 225000, N'Dĩa', 7),
(31, N'Ốc móng tay xào rau muống', 225000, N'Dĩa', 7),(32, N'Ốc móng tay xào sa tế', 225000, N'Dĩa', 7),
(33, N'Ốc móng tay rang me', 225000, N'Dĩa', 7),(34, N'Ốc vòi voi ăn sống', 399000, N'100 Grams', 8),
(35, N'Ốc vòi voi nấu cháo', 399000, N'100 Grams', 8),(36, N'Tu hài hấp sả', 225000, N'Con', 8),
(37, N'Nghêu nướng bơ', 240000, N'Dĩa', 9),(38, N'Nghêu đút lò phô mai', 240000, N'Dĩa', 9),
(39, N'Nghêu hai cồi hấp sả', 59000, N'100 Grams', 10),(40, N'Nghêu hai cồi xào tỏi', 59000, N'100 Grams', 10),
(41, N'Nghêu hai cồi nướng mỡ hành', 59000, N'100 Grams', 10),(42, N'Nghêu hai cồi đút lò phô mai', 59000, N'100 Grams', 3),
(43, N'Tôm càng hấp', 179000, N'100 Grams', 11),(44, N'Tôm càng dầu giấm', 179000, N'100 Grams', 11),
(45, N'Tôm càng nướng', 179000, N'100 Grams', 11),(46, N'Tôm càng rang me', 179000, N'100 Grams', 11),
(47, N'Tôm càng đút lò phô mai', 179000, N'100 Grams', 11),(48, N'Tôm càng rang tỏi', 179000, N'100 Grams', 11),
(49, N'Tôm hùm 3 món đặc biệt', 445000, N'100 Grams', 12),(50, N'Tôm hùm sống', 415000, N'100 Grams', 12),
(51, N'Tôm hùm đút lò phô mai', 415000, N'100 Grams', 12),(52, N'Tôm hùm rang tỏi', 415000, N'100 Grams', 12),
(53, N'Tôm hùm Alaska hấp', 280000, N'100 Grams', 13),(54, N'Tôm hùm Alaska đút lò phô mai', 280000, N'100 Grams', 13),
(55, N'Tôm hùm Alaska nướng', 280000, N'100 Grams', 13),(56, N'Tôm hùm Alaska rang tỏi', 280000, N'100 Grams', 13),
(57, N'Tôm tích cháy tỏi', 315000, N'100 Grams', 14),(58, N'Tôm tích nướng', 315000, N'100 Grams', 14),
(59, N'Tôm tích rang muối', 315000, N'100 Grams', 14),(60, N'Tôm tích hấp', 315000, N'100 Grams', 14),
(61, N'Tôm sú sống', 95000, N'100 Grams', 15),(62, N'Tôm sú đốt rượu', 95000, N'100 Grams', 15),
(63, N'Tôm sú rang muối', 95000, N'100 Grams', 15),(64, N'Tôm sú hấp bia', 95000, N'100 Grams', 15),
(65, N'Tôm mũ ni hấp', 220000, N'100 Grams', 16),(66, N'Tôm mũ ni đút lò phô mai', 220000, N'100 Grams', 16),
(67, N'Tôm mũ ni nướng', 220000, N'100 Grams', 16),(68, N'Tôm mũ ni rang tỏi', 220000, N'100 Grams', 16),
(69, N'Ghẹ nướng', 165000, N'100 Grams', 17),(70, N'Ghẹ hấp', 165000, N'100 Grams', 17),
(71, N'Ghẹ rang muối', 165000, N'100 Grams', 17),(72, N'Ghẹ rang me', 165000, N'100 Grams', 17),
(73, N'Cua nướng', 95000, N'100 Grams', 18),(74, N'Cua sốt ớt Singapore', 95000, N'100 Grams', 18),
(75, N'Cua rang muối', 95000, N'100 Grams', 18),(76, N'Cua hấp bia', 95000, N'100 Grams', 18),
(77, N'Cua hoàng đế 3 món', 480000, N'100 Grams', 19),(78, N'Cua hoàng đế hấp', 480000, N'100 Grams', 19),
(79, N'Cua hoàng đế nướng', 480000, N'100 Grams', 19),(80, N'Cua hoàng đế rang muối', 480000, N'100 Grams', 19),
(81, N'Cua hai da hấp', 180000, N'100 Grams', 20),(82, N'Cua hai da nướng', 180000, N'100 Grams', 20),
(83, N'Cá trứng nướng', 20000, N'Con', 21),(84, N'Cá trứng chiên giòn', 20000, N'Con', 21),
(85, N'Cá bớp nướng', 335000, N'Dĩa', 21),(86, N'Cá mú sống nướng', 85000, N'100 Grams', 21),
(87, N'Cá mú hấp Đài Loan', 85000, N'100 Grams', 21),(88, N'Cá chình xào lăn', 130000, N'100 Grams', 21),
(89, N'Cá chình nấu măng chua', 130000, N'100 Grams', 21),(90, N'Cá mặt quỷ nướng muối ớt', 225000, N'100 Grams', 21),
(91, N'Cá mặt quỷ hấp Đài Loan', 225000, N'100 Grams', 21),(92, N'Cá mặt quỷ chưng tương', 225000, N'100 Grams', 21),
(93, N'Mực ống chiên nước mắm', 235000, N'Dĩa', 22),(94, N'Mực ống hấp', 235000, N'Dĩa', 22),
(95, N'Mực ống nướng', 235000, N'Dĩa', 22),(96, N'Mực trứng nướng', 235000, N'Dĩa', 22),
(97, N'Mực trứng hấp', 235000, N'Dĩa', 22),(98, N'Râu mực chiên giòn', 235000, N'Dĩa', 22),
(99, N'Râu mực chiên muối ớt', 225000, N'Dĩa', 22),(100, N'Chả giò tôm thịt', 235000, N'Dĩa', 23),
(101, N'Chả giò hải sản', 49000, N'Cuốn', 23),(102, N'Gỏi cuốn tôm thịt', 45000, N'Cuốn', 23),
(103, N'Lươn nướng muối ớt', 230000, N'Dĩa', 24),(104, N'Lươn um nước dừa', 230000, N'Dĩa', 24),
(105, N'Lươn xào lăn', 230000, N'Dĩa', 24),(106, N'Lươn chiên giòn', 175000, N'Dĩa', 24),
(107, N'Xà lách dầu giấm', 105000, N'Dĩa', 25),(108, N'Xà lách cá ngừ', 235000, N'Dĩa', 25),
(109, N'Xà lách cá hồi xông khói', 210000, N'Dĩa', 25),(110, N'Xà lách cá hồi Teriyaki', 270000, N'Dĩa', 25),
(111, N'Rau muống xào tỏi', 105000, N'Dĩa', 26),(112, N'Bông bí xào tỏi', 105000, N'Dĩa', 26),
(113, N'Rau luộc thập cẩm kho quẹt', 165000, N'Dĩa', 26),(114, N'Chả giò tôm thịt', 105000, N'Dĩa', 26),
(115, N'Khổ qua xào trứng', 105000, N'Dĩa', 26),(116, N'Rau lang hấp', 105000, N'Dĩa', 26),
(117, N'Súp cua bắp măng', 65000, N'Chén', 27),(118, N'Súp cua vi cá', 32000, N'Chén', 27),
(119, N'Súp rong biển hải sản', 65000, N'Chén', 27),(120, N'Súp bong bóng cá cua', 65000, N'Chén', 27),
(121, N'Cháo cá', 75000, N'Chén', 28),(122, N'Cháo tôm', 75000, N'Chén', 28),
(123, N'Cháo cua', 75000, N'Chén', 28),(124, N'Cháo lươn', 75000, N'Chén', 29),
(125, N'Cháo hải sản', 75000, N'Chén', 28),(126, N'Cháo bào ngư', 160000, N'Chén', 28),
(127, N'Lẩu canh chua truyền thống', 450000, N'Lẩu', 29),(128, N'Lẩu măng chua đầu cá hồi', 405000, N'Lẩu', 29),
(129, N'Lẩu hải sản', 540000, N'Lẩu', 29),(130, N'Lẩu Thái Lan hải sản', 540000, N'Lẩu', 29),
(131, N'Lẩu nấm hải sản', 495000, N'Lẩu', 29),(132, N'Lẩu gà lá giang', 450000, N'Lẩu', 29),
(133, N'Cơm trắng', 49000, N'Thố', 30),(134, N'Bánh mì', 49000, N'Dĩa', 30),
(135, N'Bánh mì bơ tỏi', 69000, N'Dĩa', 30),(136, N'Bánh mì đút lò phô mai', 69000, N'Dĩa', 30),
(137, N'Rau lẩu', 49000, N'Dĩa', 30),(138, N'Bún', 49000, N'Dĩa', 30),
(139, N'Cơm chiên tỏi', 145000, N'Thố', 31),(140, N'Cơm chiên cá mặn', 225000, N'Thố', 31),
(141, N'Cơm chiên cua', 225000, N'Thố', 31),(142, N'Cơm chiên tôm', 225000, N'Thố', 31),
(143, N'Cơm Dương Châu', 225000, N'Thố', 31),(144, N'Cơm tay cầm hải sản', 255000, N'Thố', 31),
(145, N'Cơm tay cầm bò', 255000, N'Thố', 31),(146, N'Cơm cháy hải sản', 275000, N'Thố', 31),
(147, N'Mì xào thập cẩm', 250000, N'Dĩa', 32),(148, N'Bún gạo xào thập cẩm', 250000, N'Dĩa', 32),
(149, N'Miến xào thịt cua', 320000, N'Thố', 32),(150, N'Miến xào cua con', 95000, N'100 Grams', 32);

--select b.manhom, b.tennhom, a.mamon, a.tenmon, a.dvt, a.giatien from monan a, nhommon b where a.manhom = b.manhom and a.tenmon like N'%c%'

--select b.manhom, b.tennhom, a.mamon, a.tenmon, a.dvt, a.giatien from monan a, nhommon b where a.manhom = b.manhom;
create table ban
(
	soban int primary key,
	trangthai bit not null
);
insert into ban(soban, trangthai) values
(1,1),(2,1),(3,1),(4,1),(5,0),(6,1),(7,1),(8,1),(9,1),
(10,1),(11,1),(12,1),(13,1),(14,1),(15,1),(16,1),(17,1),(18,1);

create table hoadon
(
	sohd int primary key,
	giovao datetime,
	giora datetime,
	manv int,
	soban int,
	foreign key (manv) references nhanvien(manv),
	foreign key (soban) references ban(soban)
);
select * from hoadon

create table chitiethoadon
(
	sohd int,
	mamon int,
	soluong int,
	foreign key (sohd) references hoadon(sohd),
	foreign key (mamon) references monan(mamon),
);
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
			where hd.sohd = cthd.sohd and m.mamon = cthd.mamon and hd.giora = hd.giovao and hd.soban = @soban --Ngày là null : chưa thanh toán
		end
		--Test thử với danh sách món ăn bàn 5
		
		execute sp_DanhSachMonAnCuaBan 3;
		
--Thanh Toán
create proc sp_ThanhToan
	(
		@sohd int,
		@giora datetime
	)
	as
		begin
			--Khai báo biến
			declare @soban int;
			--Gán giá trị
			select @soban = soban from hoadon where sohd = @sohd;
			--Cập nhật thời gian thanh toán của hoá đơn
			update hoadon set giora = @giora where sohd = @sohd;
			--Cập nhật trạng thái của bàn
			update ban set trangthai = 1 where soban = @soban;
		end
		drop proc sp_ThanhToan

create proc sp_datBan (@sohd int, @soban int, @manv int)
as
	begin
		declare @now datetime;
		set @now = getdate();
		update ban set trangthai = 0 where soban = @soban;
		insert into hoadon(sohd, giovao,giora, soban, manv) values (@sohd, @now,@now,@soban, @manv); 
	end
	drop proc sp_datBan
	select * from hoadon
	select * from chitiethoadon
	select * from ban
	select * from nhommon
delete from chitiethoadon
delete from hoadon

update ban set trangthai = 1 where soban =6

--Doanh thu theo tháng
	create proc sp_DoanhThuTheoThang
	(
		@thang int,
		@nam int
	)
	as 
		begin
			--Khai báo biến
			declare @doanhthu int
			--Tính doanh thu
			select @doanhthu = sum(m.giatien * cthd.soluong) 
			from hoadon hd, monan m, chitiethoadon cthd
			where hd.sohd = cthd.sohd and m.mamon = cthd.mamon and MONTH(hd.giora) = 11 and YEAR(hd.giora) = 2021
			--Trả về
			select @doanhthu
		end
		--Test thử tính doanh thu tháng 11 năm 2021
		execute sp_DoanhThuTheoThang 11,2021;


		delete from chitiethoadon where sohd = 15


--Doanh thu từ ngày đến ngày 
	create proc sp_DoanhThuTuNgayDenNgay 
	(
		@tungay datetime,
		@denngay datetime
	)
	as
		begin
			--Khai báo biến
			declare @doanhthu int
			--Tính doanh thu
			select @doanhthu = sum(m.giatien * cthd.soluong) 
			from hoadon hd, monan m, chitiethoadon cthd
			where hd.sohd = cthd.sohd and m.mamon = cthd.mamon and giora between @tungay and @denngay
			--Trả về
			select @doanhthu
		end
		--SELECT Day(DATEADD(month, ((YEAR(getdate()) - 1900) * 12) + MONTH(getdate()), -1))
create proc sp_DoanhThuTheoNgayTrongThang
	(
		@thang int,
		@nam int
	)
	as 
		begin
			--Khai báo biến
			declare @ngay int = 1
			declare @ngaycuoi int
			declare @doanhthu int

			SELECT @ngaycuoi = Day(DATEADD(month, ((YEAR(getdate()) - 1900) * 12) + MONTH(getdate()), -1))
			while @ngay <= @ngaycuoi
			begin
				--Tính doanh thu
				select @doanhthu = sum(m.giatien * cthd.soluong) 
				from hoadon hd, monan m, chitiethoadon cthd
				where hd.sohd = cthd.sohd and m.mamon = cthd.mamon and MONTH(hd.giora) = 11 and YEAR(hd.giora) = 2021 and Day(hd.giora) = @ngay

				SET @ngay = @ngay + 1;
			end
		end
		drop proc sp_DoanhThuTheoNgayTrongThang
		execute sp_DoanhThuTheoNgayTrongThang 11, 2021

create proc sp_TinhTienCuaHoaDon
	(
		@sohd int
	)
	as
		begin
			--Khai báo biến
			declare @doanhthu int
			--Tính doanh thu
			select @doanhthu = sum(m.giatien * cthd.soluong) 
			from hoadon hd, monan m, chitiethoadon cthd
			where hd.sohd = cthd.sohd and m.mamon = cthd.mamon and hd.sohd = @sohd
			--Trả về
			select @doanhthu
		end
		select mamon from chitiethoadon where sohd = 17
--Lấy ra số lượng bán được của từng món ăn từ ngày đến ngày
	create proc sp_ThongKeSoLuongMonAnBanDuocTuNgayDenNgay
	(@tungay datetime, @denngay datetime)
	as
		begin
			select n.manhom, n.tennhom, m.mamon, m.tenmon, m.dvt, m.giatien , x.soluong
			from monan m, nhommon n, (select c.mamon, sum(c.soluong) as 'soluong'
										from hoadon h, chitiethoadon c
										where
											h.sohd = c.sohd and
											h.giora between @tungay and @denngay and
											h.giovao != h.giora
										group by c.mamon ) as x
			where x.mamon = m.mamon and m.manhom = n.manhom
			order by x.soluong desc
		end
		drop proc sp_ThongKeSoLuongMonAnBanDuocTuNgayDenNgay
		

insert into nguyenlieu(manl, tennl,  dvt, giatien, mancc) values 
(2,N'2',N'2',100000,2)
insert into phieunhap(sopn, ngaynhap, manv) values
(2,getdate(), 1)
insert into chitietphieunhap(sopn, manl, soluong) values
(2,2,100)
insert into phieuxuat(sopx, ngayxuat, manv) values
(1,getdate(), 1)
insert into chitietphieuxuat(sopx, manl, soluong) values
(1,1,55)
--Lấy tồn kho của nguyên liệu
create proc sp_TonKhoCuaNguyenLieu
(@nguyenlieu int)
as 
	begin
		declare @soluongtrongphieunhap int;
		declare @soluongtrongphieuxuat int;
		declare @tonkho int;
		--Lấy số lượng đã nhập
		select @soluongtrongphieunhap = sum(soluong)
		from chitietphieunhap ct
		where manl = @nguyenlieu
		group by manl
		--Lấy số lượng đã xuất
		select @soluongtrongphieuxuat = sum(soluong)
		from chitietphieuxuat
		where manl = @nguyenlieu
		group by manl
		--Nếu chưa xuất thì là null -> số lượng = 0
		if(@soluongtrongphieuxuat is null)
			begin
				set @soluongtrongphieuxuat = 0
			end
		--Tồn kho là số lượng đã nhập - số lượng đã xuất
		set @tonkho = @soluongtrongphieunhap - @soluongtrongphieuxuat;
		if(@tonkho is null) 
			begin
				set @tonkho = 0
			end
		select @tonkho
	end
	drop proc sp_TonKhoCuaNguyenLieu
	execute sp_TonKhoCuaNguyenLieu 9

	select ct.sopn, nl.manl, nl.tennl, nl.dvt, ct.soluong, nl.giatien
	from chitietphieunhap ct, nguyenlieu nl
	where ct.sopn = 1 and nl.manl = ct.manl

	select * from chitietphieuxuat where sopn = 3
	delete  from ban where soban = 19
	
	select * from nguyenlieu;