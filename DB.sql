-- Quan ly tuyen dung cty ABC

drop table QuangCao;
drop table TrangThai;
drop table HoSoCaNhanUngVien;
drop table ThongTinDangTuyen;
drop table DoanhNghiep;
create table HoSoCaNhanUngVien (
    MaUngVien char(10)  primary key,
    Email varchar2(50),
    GPA int,
    HopLe int ,check (HopLe = 1 or HopLe = 2), -- 1 l¨¤ h?p l?, 2 l¨¤ kh?ng h?p l?
    KyNang varchar2(100),
    DT char(10),
    TEN varchar2(100),
    ThanhVien int not null ,check (ThanhVien = 1 or ThanhVien = 2 ) -- 1 l¨¤ ?? ??ng k?, 2 l¨¤ ch?a ??ng k?
);
/
create table DoanhNghiep(
    MaSoThue char(10),
    DiaChi varchar2(50),
    Email varchar2(50),
    NguoiDaiDien varchar2(50),
    TenCty varchar2(50),
    primary key (MaSoThue)
);
/
create table ThongTinDangTuyen(
    MaTTDT char(10),
    SoLuong int,
    ThoiGianBatDau DATE,
    ThoiGianKetThuc DATE,
    vitri varchar2(50),
    YeuCau varchar2(50),
    HopLe int ,check (HopLe = 1 or HopLe = 2 ), -- 1 l¨¤ hop le, 2 la khong hop le
    primary key (MaTTDT)
);
/

create table QuangCao(
    MaSoThue char(10),
    MaTTDT char(10),
    HinhThucDangTuyen varchar2(50),check (HinhThucDangTuyen = 'Bao Giay' or HinhThucDangTuyen = 'Banner' or HinhThucDangTuyen = 'Mang'),
    HinhThucThanhToan varchar2(50),
    SoTien Number,
    PRIMARY key(MaSoThue,MaTTDT)
);
/

create table TrangThai(
    MaTTDT char(10),
    MaUngVien char(10),
    DiemUuTien int,
    TinhTrang int,check (TinhTrang = 1 or TinhTrang = 2 or TinhTrang = 3), -- 1 l¨¤ ?ang duy?t, 2 l¨¤ r?t, 3 l¨¤ ??u
    ThoiGInaDuyet DATE,
    primary key (MaTTDT,MaUngVien)
);
/
----------------------------constraint------------------------------
alter table TrangThai 
add foreign key (MaTTDT) references ThongTinDangTuyen(MaTTDT);
alter table TrangThai
add foreign key (MaUngVien) references HoSoCaNhanUngVien(MaUngVien);

alter table QuangCao
add foreign key (MaSoThue) references DoanhNghiep(MaSoThue);
alter table QuangCao
add foreign key (MaTTDT) references ThongTinDangTuyen(MaTTDT);
-------------------------- insert------------------------------------
/
insert into HoSoCaNhanUngVien values ('UV00000001','ABC@gmail.com',1,2,'abcxyz','098765432','Nguyen Van A', 2);
insert into HoSoCaNhanUngVien values ('UV00000002','ABD@gmail.com',2,2,'abcxyz','098765432','Nguyen Van B', 2);
insert into HoSoCaNhanUngVien values ('UV00000003','ABF@gmail.com',3,2,'abcxyz','098765432','Nguyen Van C', 2);
insert into HoSoCaNhanUngVien values ('UV00000004','ABG@gmail.com',4,1,'abcxyz','098765432','Nguyen Van D', 2);
insert into HoSoCaNhanUngVien values ('UV00000005','ABH@gmail.com',3,2,'abcxyz','098765432','Nguyen Van E', 2);
insert into HoSoCaNhanUngVien values ('UV00000006','ABL@gmail.com',2,2,'abcxyz','098765432','Nguyen Van H', 2);
insert into HoSoCaNhanUngVien values ('UV00000007','ABk@gmail.com',1,1,'abcxyz','098765432','Nguyen Van G', 2);


insert into ThongTinDangTuyen values ('DT00000001',2,NULL,NULL,'Data engineer','abcxyz',null);
insert into ThongTinDangTuyen values ('DT00000002',3,NULL,NULL,'DB','abcxyz',null);
insert into ThongTinDangTuyen values ('DT00000003',1,NULL,NULL,'DA','abcxyz',null);
insert into ThongTinDangTuyen values ('DT00000004',4,NULL,NULL,'DS','abcxyz',null);
insert into ThongTinDangTuyen values ('DT00000005',6,NULL,NULL,'Nhan Vien Co Ban','abcxyz',null);
insert into ThongTinDangTuyen values ('DT00000006',8,NULL,NULL,'Lao Cong','abcxyz',null);
insert into ThongTinDangTuyen values ('DT00000007',3,NULL,NULL,'tester','abcxyz',null);
insert into ThongTinDangTuyen values ('DT00000008',7,NULL,NULL,'automatic test','abcxyz',null);
insert into ThongTinDangTuyen values ('DT00000009',5,NULL,NULL,'Dev','abcxyz',null);

insert into doanhnghiep values ('DN12837a3d','27 pham van bach','DNABC@gamil.com','Nguyen Thi A','QWE');
insert into doanhnghiep values ('DNdx234345','27 Nguyen Tat Thanh','DNBBS@gamil.com','Nguyen Thi B','QWE');
insert into doanhnghiep values ('DN53d1c452','27 Le Duan','DNTTC@gamil.com','Nguyen Thi C','QWE');
insert into doanhnghiep values ('DN2478c234','27 An Binh','DNQAZ@gamil.com','Nguyen Thi D','QWE');
insert into doanhnghiep values ('DN235d1234','27 Nguyen Van Cu','DNERD@gamil.com','Nguyen Thi E','QWE');
insert into doanhnghiep values ('DN4523d123','27 Hung Vuong','DNABS@gamil.com','Nguyen Thi F','QWE');

insert into TrangThai values ('DT00000001','UV00000001',9,1,null);
insert into TrangThai values ('DT00000002','UV00000003',5,2,null);
insert into TrangThai values ('DT00000003','UV00000002',7,3,null);
insert into TrangThai values ('DT00000008','UV00000004',7.5,1,null);
insert into TrangThai values ('DT00000008','UV00000002',5,2,null);

insert into QuangCao values ('DN12837a3d','DT00000001','Bao Giay','Chuyen Khoan',3123000);
insert into QuangCao values ('DN12837a3d','DT00000002','Banner','Tien Mat',4123000);
insert into QuangCao values ('DN235d1234','DT00000003','Bao Giay','Chuyen Khoan',3123000);
insert into QuangCao values ('DN2478c234','DT00000004','Mang','Chuyen Khoan',3223000);
insert into QuangCao values ('DN53d1c452','DT00000005','Bao Giay','Chuyen Khoan',1323000);

create or replace view v_DNDangky
as
select tt.*
from ThongTinDangTuyen tt join QuangCao qc on tt.MaTTDT = qc.MaTTDT
where upper(qc.MaSoThue) = SYS_CONTEXT('USERENV', 'SESSION_USER');


drop user DN12837a3d;
create user DN12837a3d identified by 123;
grant connect to DN12837a3d;
grant select on v_DNDangky to DN12837a3d;
grant select on ThongTinDangTuyen to DN12837a3d;
grant insert on ThongTinDangTuyen to DN12837a3d;
grant insert on QuangCao to DN12837a3d;

select * from QuangCao
select * from ThongTinDangTuyen
connect DN12837a3d/123;
select * from sys.v_DNDangky;

select MAX(CAST(substr(MaTTDT, 3, length(MaTTDT) - 2) AS INT)) AS MaxValue
FROM ThongTinDangTuyen;


drop user NV001;
alter session set "_ORACLE_SCRIPT"=true; 
create user NV001 identified by NV001;
grant connect to NV001;
