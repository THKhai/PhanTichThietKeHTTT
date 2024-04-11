-- Quan ly tuyen dung cty ABC
drop table HoSoCaNhanUngVien;
drop table DoanhNghiep;
drop table ThongTinDangTuyen;
drop table QuangCao;
drop table TrangThai;

create table HoSoCaNhanUngVien (
    MaUngVien char(10)  primary key,
    Dat int check (Dat = 1 or Dat = 2 or Dat = 3),
    Email INT,
    GPA int,
    HopLe int not null ,check (Dat = 1 or Dat = 2 or Dat = 3),
    KyNang varchar2(100),
    DT char(10),
    TEN varchar2(100),
    ThanhVien int not null ,check (Dat = 1 or Dat = 2 or Dat = 3)
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
    primary key (MaTTDT)
);
/

create table QuangCao(
    MaSoThue char(10),
    MaTTDT char(10),
    HinhThucDangTuyen varchar2(50),
    HinhThucThanhToan varchar2(50),
    SoTien Number,
    PRIMARY key(MaSoThue,MaTTDT)
);
/

create table TrangThai(
    MaTTDT char(10),
    MaUngVien char(10),
    DiemUuTien int,
    TinhTrang int,
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
