--- Bai 1
-- 19
SELECT COUNT(*) SLHD
FROM HOADON
WHERE MAKH NOT IN(
	SELECT MAKH FROM KHACHHANG 
	WHERE KHACHHANG.MAKH = HOADON.MAKH
)
--20
select count(distinct CTHD.MASP) SLSP
from CTHD,HOADON hd
where hd.SOHD=CTHD.SOHD and year(NGHD)=2006
--21
select Max(TRIGIA), Min(TRIGIA) from HOADON
--22
select AVG(TRIGIA) from HOADON where year(NGHD)=2006
--23
select sum(TRIGIA) from HOADON where year(NGHD)=2006
--24 
select SOHD from HOADON where year(NGHD)=2006
and TRIGIA= (
	select Max(TRIGIA) from HOADON
)
--25
select kh.HOTEN 
from HOADON hd, KHACHHANG kh
where hd.MAKH=kh.MAKH and year(hd.NGHD)=2006 
AND hd.TRIGIA=(
	select MAX(TRIGIA) from HOADON
)
--26
select top 3 MAKH,HOTEN from KHACHHANG order by DOANHSO DESC
--27
select MASP, TENSP  from SANPHAM 
where GIA in (
	select distinct top 3 GIA from SANPHAM order by GIA DESC
	)
--28
select MASP, TENSP  from SANPHAM 
where NUOCSX='Thai Lan' and GIA in (
	select distinct top 3 GIA from SANPHAM order by GIA DESC
	)
--29
select MASP, TENSP  from SANPHAM 
where NUOCSX='Trung Quoc'  and GIA in (
	select distinct top 3 GIA from SANPHAM 
	where NUOCSX='Trung Quoc' 
	order by GIA DESC
)
--30
select top 3 MAKH,HOTEN, RANK() over (order by DOANHSO desc) XEPHANG from KHACHHANG
--- Bai 3
--31
select count(MASP) SLSP from SANPHAM where NUOCSX='Trung Quoc'
--32
select NUOCSX, count(MASP) SLSP from SANPHAM
group by NUOCSX
--33
select NUOCSX, max(GIA) Max, min(GIA) Min, avg(GIA) Avg  from SANPHAM
group by NUOCSX
--34
select NGHD, sum(TRIGIA) DOANHTHU from HOADON
group by NGHD
--35
select CTHD.MASP, sum(CTHD.SL) SL
from CTHD, HOADON hd
where CTHD.SOHD=hd.SOHD and month(hd.NGHD)=10 and year(hd.NGHD)=2006
group by CTHD.MASP
--36
select month(NGHD) Thang, sum(TRIGIA) DoanhThu from HOADON
where year(NGHD)=2006
group by month(NGHD)
--37
SELECT SOHD FROM CTHD
GROUP BY SOHD 
HAVING COUNT(DISTINCT MASP) >= 4
--38
select SOHD from CTHD,SANPHAM sp
where CTHD.MASP=sp.MASP and sp.NUOCSX='Viet Nam'
group by SOHD
having count (distinct CTHD.MASP)=3
--39
select MAKH, HOTEN
from KHACHHANG
where MAKH in (
	select top 1 MAKH from HOADON 
	group by MAKH
	order by (count(SOHD)) desc
)
--40
select distinct month(NGHD) 'Thang'
from HOADON
where year(NGHD)=2006	
and month(NGHD) in(
	select  top 1 month(NGHD) from HOADON
	group by month(NGHD)
	order by (sum(TRIGIA)) desc
)
--41
select MASP,TENSP from SANPHAM
where MASP in (
	select top 1 CTHD.MASP
	from CTHD, HOADON hd
	where CTHD.SOHD=hd.SOHD and year(hd.NGHD)=2006
	group by CTHD.MASP
	order by (sum(CTHD.SL)) ASC
)
--42
SELECT NUOCSX MASP, TENSP
FROM SANPHAM S
WHERE GIA = (
    SELECT MAX(GIA)
    FROM SANPHAM
    WHERE NUOCSX = S.NUOCSX
);
--43
SELECT NUOCSX FROM SANPHAM 
GROUP BY NUOCSX
HAVING COUNT(DISTINCT GIA) >= 3
--44
select MAKH, HOTEN
from KHACHHANG
where MAKH in (
	select top 1 MAKH from HOADON 
	where MAKH in (
		select top 10 MAKH from KHACHHANG
		order by DOANHSO desc
	)
	group by MAKH
	order by (count(SOHD)) desc
)

--- Bai 2
--19
select MAKHOA, TENKHOA from KHOA
where NGTLAP = (
	select min(NGTLAP) from KHOA
)
--20
select count(*) from GIAOVIEN where HOCHAM in ('GS' ,'PGS')
--21
select MAKHOA,HOCVI, count(MAGV) SLGV 
from GIAOVIEN 
group by MAKHOA,HOCVI
--22
SELECT MAMH, KQUA, COUNT(MAHV) SL
FROM KETQUATHI A
WHERE NOT EXISTS (
	SELECT*
	FROM KETQUATHI B 
	WHERE A.MAHV = B.MAHV AND A.MAMH = B.MAMH AND A.LANTHI < B.LANTHI
)
GROUP BY MAMH, KQUA
--23
select MAGV, HOTEN from GIAOVIEN
where MAGV in (
	select MAGV 
	from LOP,GIANGDAY gd
	where LOP.MAGVCN=gd.MAGV
)

--24
select HO+' '+TEN HOTEN from HOCVIEN,LOP 
where HOCVIEN.MAHV=LOP.TRGLOP and LOP.SISO in (
	select max(SISO) from LOP
)
--25
select HO +' '+ TEN from HOCVIEN
where MAHV in (
	select MAHV from KETQUATHI A
	where MAHV in (select TRGLOP from LOP) 
	and not exists ( select* from KETQUATHI B
					where A.MAHV=B.MAHV and A.MAMH=B.MAMH and A.LANTHI<B.LANTHI
	) and KQUA='Khong dat'
	group by MAHV
	having count(MAHV)>=3
) 
--26
select MAHV, HO,TEN from HOCVIEN 
where MAHV in (
	select top 1 with ties MAHV from KETQUATHI
	where DIEM in (9,10)
	group by MAHV
	order by count(MAMH) desc
)
--27
select MALOP,MAHV, HO,TEN from HOCVIEN A
where MAHV in (
	select top 1 with ties B.MAHV from KETQUATHI, HOCVIEN B
	where DIEM in (9,10) and KETQUATHI.MAHV=B.MAHV and B.MALOP=A.MALOP
	group by B.MAHV
	order by count(MAMH) desc
)
group by MALOP,MAHV, HO,TEN
--28
select HOCKY,NAM,MAGV, count(MAMH) SLMH, count (MALOP) SLL 
from GIANGDAY
group by HOCKY,NAM,MAGV
--29
select HOCKY,NAM, gv.MAGV,gv.HOTEN from GIAOVIEN gv,GIANGDAY gd
where gv.MAGV=gd.MAGV and gv.MAGV in (
	select top 1 with ties  MAGV from GIANGDAY gd2
	where gd2.HOCKY=gd.HOCKY and gd2.NAM=gd.NAM
	group by MAGV
	order by count(*) desc
)
group by HOCKY,NAM,gv.MAGV,gv.HOTEN
--30
select MAMH, TENMH from MONHOC
where MAMH in (
	select top 1 with ties MAMH from KETQUATHI
	where LANTHI=1 and KQUA='Khong dat'
	group by MAMH
	order by count (MAHV) desc
)
--31
select MAHV,HO,TEN from HOCVIEN
where MAHV in (
	select MAHV from KETQUATHI A
	where not exists(
		select* from KETQUATHI B
		where A.MAHV=B.MAHV and LANTHI=1 and B.KQUA='Khong dat'
	)
)
--32
select MAHV,HO,TEN from HOCVIEN
where MAHV in (
	select MAHV from KETQUATHI A
	where not exists(
		select* from KETQUATHI B
		where A.MAHV=B.MAHV and B.KQUA='Khong dat' 
		and LANTHI=(select max(LANTHI) from KETQUATHI C 
		where B.MAMH=C.MAMH and B.MAHV=C.MAHV
		)
	)
)
--33
select hv.MAHV,hv.HO,hv.TEN from HOCVIEN hv,KETQUATHI kqt
where hv.MAHV=kqt.MAHV and hv.MAHV in (
	select MAHV from KETQUATHI A
	where not exists(
		select* from KETQUATHI B
		where A.MAHV=B.MAHV and LANTHI=1 and B.KQUA='Khong dat'
	)
)
group by hv.MAHV,hv.HO,hv.TEN
having count(MAMH) = (
	select count(MAMH) from MONHOC
)
--34
select hv.MAHV,hv.HO,hv.TEN from HOCVIEN hv,KETQUATHI kqt
where hv.MAHV=kqt.MAHV and hv.MAHV in (
	select MAHV from KETQUATHI A
	where not exists(
		select* from KETQUATHI B
		where A.MAHV=B.MAHV and B.KQUA='Khong dat' 
		and LANTHI=(select max(LANTHI) from KETQUATHI C 
		where B.MAMH=C.MAMH and B.MAHV=C.MAHV
		)
	)
)
group by hv.MAHV,hv.HO,hv.TEN
having count(MAMH) = (
	select count(MAMH) from MONHOC
)

--35
SELECT A.MAHV, HO + ' ' + TEN HOTEN FROM (
	SELECT B.MAMH, MAHV, DIEM, DIEMMAX
	FROM KETQUATHI B INNER JOIN (
		SELECT MAMH, MAX(DIEM) DIEMMAX FROM KETQUATHI
		GROUP BY MAMH
	) C 
	ON B.MAMH = C.MAMH
	WHERE NOT EXISTS (
		SELECT 1 FROM KETQUATHI D 
		WHERE B.MAHV = D.MAHV AND B.MAMH = D.MAMH AND B.LANTHI < D.LANTHI
	) AND DIEM = DIEMMAX
) A INNER JOIN HOCVIEN HV
ON A.MAHV = HV.MAHV