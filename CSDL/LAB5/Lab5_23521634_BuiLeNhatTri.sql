--11
GO
CREATE TRIGGER trg_ins_hd ON HOADON
FOR INSERT 
AS
BEGIN
	IF EXISTS (SELECT *
				FROM  INSERTED I, KHACHHANG KH
				WHERE I.MAKH = KH.MAKH
				AND NGHD>NGDK )
		BEGIN
			RAISERROR('LOI',16,1);
			ROLLBACK TRANSACTION
		END 
	ELSE
		PRINT 'THEM MOI THANH CONG';
END

--12
GO
CREATE TRIGGER CAU12_QLBH ON HOADON
FOR INSERT
AS 
BEGIN
	IF EXISTS (SELECT * 
				FROM INSERTED I, NHANVIEN NV
				WHERE I.MANV = NV.MANV AND NGHD < NV.NGVL)
		BEGIN
			RAISERROR('LOI',16,1);
			ROLLBACK TRANSACTION
		END
	ELSE
		PRINT 'THEM MOI THANH CONG';
END

--13
GO
CREATE TRIGGER CAU13_QLBH ON CTHD
FOR INSERT,UPDATE,DELETE
AS 
BEGIN
	UPDATE HOADON
		SET TRIGIA = (
			SELECT SUM(SL * GIA)
			FROM CTHD
			WHERE HOADON.SOHD = CTHD.SOHD
		)
	WHERE SOHD IN (
		SELECT DISTINCT SOHD
		FROM INSERTED
		UNION
		SELECT DISTINCT SOHD
		FROM DELETED
);
END

--14
GO
CREATE TRIGGER CAU14_QLBH ON HOADON
FOR INSERT,DELETE,UPDATE
AS 
BEGIN
	UPDATE KHACHHANG
	SET DOANHSO = (SELECT SUM(HD.TRIGIA) 
				FROM HOADON HD 
				WHERE HD.MAKH =KHACHHANG.MAKH)
END

--9
GO
CREATE TRIGGER CAU9_QLGV ON LOP
FOR INSERT, UPDATE
AS
BEGIN
	IF EXISTS(SELECT * FROM INSERTED I, HOCVIEN HV
				WHERE I.TRGLOP = HV.MAHV AND HV.MALOP <> I.MALOP)
			BEGIN 
				RAISERROR('LOI',16,1);
				ROLLBACK TRANSACTION
			END
	ELSE
		PRINT 'THEM MOI THANH CONG';
END

--10
GO
CREATE TRIGGER CAU10_QLGV ON GIAOVIEN
FOR UPDATE
AS
BEGIN
	IF(SELECT COUNT(*)
	FROM inserted I , KHOA K
	WHERE K.TRGKHOA=I.MAGV AND I.MAKHOA=K.MAKHOA)=0
	BEGIN
		RAISERROR ('LOI:', 16, 1)
		ROLLBACK TRANSACTION
	END
	ELSE
		BEGIN
		PRINT'THANH CONG'
	END 
END
--- X�a GIAOVIEN
GO
CREATE TRIGGER CAU10_QLGV_2 ON GIAOVIEN
FOR DELETE
AS
BEGIN
	DECLARE @MAGV CHAR(4), @TRGKHOA CHAR(4), @MAKHOA VARCHAR(4)
	SELECT @MAGV = MAGV, @MAKHOA=MAKHOA
	FROM DELETED
	SELECT @TRGKHOA=TRGKHOA
	FROM KHOA
	WHERE MAKHOA=@MAKHOA
	IF(@MAGV = @TRGKHOA)
	BEGIN 
		PRINT ' KHONG DUOC XOA'
		ROLLBACK TRANSACTION
	END
	ELSE
	BEGIN
		PRINT 'XOA THANH CONG!'
	END
END

--15
GO
CREATE TRIGGER CAU15_QLGV ON KETQUATHI
FOR INSERT 
AS
BEGIN
	IF EXISTS (SELECT * FROM INSERTED I,GIANGDAY GD, HOCVIEN HV
				WHERE I.MAHV=HV.MAHV AND GD.MALOP=HV.MALOP AND I.MAMH=GD.MAMH AND I.NGTHI<GD.DENNGAY)
		BEGIN
			RAISERROR ('LOI:', 16, 1)
        ROLLBACK TRANSACTION
		END
	ELSE
		PRINT 'THEM MOI TRUONG KHOA THANH CONG!'
END

--16
GO
CREATE TRIGGER CAU16_QLGV ON GIANGDAY
FOR INSERT, UPDATE
AS
BEGIN
	IF EXISTS (
        SELECT I.MALOP, I.HOCKY, I.NAM
        FROM INSERTED I
        GROUP BY I.MALOP, I.HOCKY, I.NAM
        HAVING (
            SELECT COUNT(*)
            FROM GIANGDAY GD
            WHERE GD.MALOP = I.MALOP AND GD.HOCKY = I.HOCKY AND GD.NAM = I.NAM
        ) + COUNT(*) > 3
    )
		BEGIN
			RAISERROR('LOI: QUA 3 MON HOC!',16,1)
			ROLLBACK TRANSACTION
		END
	ELSE
		PRINT 'THEM THANH CONG!'
END

--17
GO
CREATE TRIGGER CAU17_QLGV ON HOCVIEN
FOR INSERT,DELETE
AS 
BEGIN
	UPDATE LOP 
	SET SISO=( SELECT COUNT(*)
				FROM HOCVIEN HV
				WHERE HV.MALOP=LOP.MALOP)
	WHERE LOP.MALOP IN (
	SELECT MALOP FROM INSERTED
        UNION
	SELECT MALOP FROM DELETED
	)
END

--18
GO
CREATE TRIGGER CAU18_QLGV ON DIEUKIEN
FOR INSERT
AS
BEGIN
	IF EXISTS (SELECT *
				FROM INSERTED I
				WHERE I.MAMH = I.MAMH_TRUOC)
			BEGIN
				RAISERROR('LOI: QUA 3 MON HOC!',16,1)
				ROLLBACK TRANSACTION
			END
	ELSE
		IF EXISTS(SELECT *
					FROM INSERTED I, DIEUKIEN DK
					WHERE I.MAMH = DK.MAMH_TRUOC AND I.MAMH_TRUOC=DK.MAMH)
			BEGIN
				RAISERROR('LOI: QUA 3 MON HOC!',16,1)
				ROLLBACK TRANSACTION
			END
	ELSE
		PRINT 'THEM THANH CONG!'
END

--19
GO
CREATE TRIGGER CAU19_QLGV ON GIAOVIEN
FOR INSERT, UPDATE
AS
BEGIN
	IF EXISTS(SELECT * FROM INSERTED I, GIAOVIEN GV
			WHERE I.HOCVI=GV.HOCVI AND I.HOCHAM=GV.HOCHAM AND I.HESO=GV.HESO AND I.MUCLUONG<> GV.MUCLUONG)
			BEGIN
				RAISERROR('LOI: QUA 3 MON HOC!',16,1)
				ROLLBACK TRANSACTION
			END
	ELSE
		PRINT 'THEM THANH CONG!'
END

--20
GO
CREATE TRIGGER CAU20_QLGV ON KETQUATHI
FOR INSERT
AS 
BEGIN
	IF EXISTS ( SELECT * FROM KETQUATHI KQ, INSERTED I
				WHERE I.LANTHI = KQ.LANTHI + 1 AND KQ.DIEM>=5 AND KQ.MAMH=I.MAMH AND KQ.MAHV = I.MAHV)
			BEGIN
				RAISERROR('LOI: QUA 3 MON HOC!',16,1)
				ROLLBACK TRANSACTION
			END
	ELSE 
		PRINT 'THEM THANH CONG!'
END


--21
GO
CREATE TRIGGER CAU21_QLGV ON KETQUATHI
FOR INSERT, UPDATE
AS
BEGIN
	IF EXISTS (SELECT * FROM INSERTED I, KETQUATHI KQ
				WHERE KQ.MAMH=I.MAMH AND KQ.MAHV = I.MAHV AND I.LANTHI>KQ.LANTHI AND I.NGTHI>KQ.NGTHI)
			BEGIN
				RAISERROR('LOI: QUA 3 MON HOC!',16,1)
				ROLLBACK TRANSACTION
			END
	ELSE 
		PRINT 'THEM THANH CONG!'
END


--22
GO
CREATE TRIGGER CAU22_QLGV ON GIANGDAY
AFTER INSERT, UPDATE
AS
BEGIN
	IF EXISTS(
		SELECT * 
		FROM INSERTED I, GIANGDAY gd, DIEUKIEN dk
		WHERE I.MAMH=dk.MAMH_TRUOC AND gd.MAMH=dk.MAMH 
		AND gd.DENNGAY>=I.TUNGAY
	)
	BEGIN
		RAISERROR('LOI:',16,1);
		ROLLBACK TRANSACTION
	END
END

--23
GO
CREATE TRIGGER CAU23_QLGV ON GIANGDAY
FOR INSERT, UPDATE
AS
BEGIN
	IF EXISTS (SELECT * FROM INSERTED I, GIAOVIEN GV, MONHOC MH
				WHERE I.MAMH=MH.MAMH AND GV.MAGV = I.MAGV AND GV.MAKHOA<>MH.MAKHOA)
			BEGIN
				RAISERROR('LOI: QUA 3 MON HOC!',16,1)
				ROLLBACK TRANSACTION
			END
	ELSE 
		PRINT 'THEM THANH CONG!'
END


