USE [SnackOverflowDB]
GO
IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND  name = 'sp_update_supplier')
BEGIN
DROP PROCEDURE sp_update_supplier
Print '' print  ' *** dropping procedure sp_update_supplier'
End
GO

Print '' print  ' *** creating procedure sp_update_supplier'
GO
Create PROCEDURE sp_update_supplier
(
@old_SUPPLIER_ID[INT],
@old_USER_ID[INT],
@new_USER_ID[INT],
@old_IS_APPROVED[BIT],
@new_IS_APPROVED[BIT],
@old_APPROVED_BY[INT],
@new_APPROVED_BY[INT],
@old_FARM_NAME[NVARCHAR](300),
@new_FARM_NAME[NVARCHAR](300),
@old_FARM_ADDRESS[NVARCHAR](300),
@new_FARM_ADDRESS[NVARCHAR](300),
@old_FARM_CITY[NVARCHAR](50),
@new_FARM_CITY[NVARCHAR](50),
@old_FARM_STATE[NCHAR](50),
@new_FARM_STATE[NCHAR](50),
@old_FARM_TAX_ID[NVARCHAR](64),
@new_FARM_TAX_ID[NVARCHAR](64),
@old_ACTIVE[BIT],
@new_ACTIVE[BIT]
)
AS
BEGIN
UPDATE supplier
SET USER_ID = @new_USER_ID, IS_APPROVED = @new_IS_APPROVED, APPROVED_BY = @new_APPROVED_BY, FARM_NAME = @new_FARM_NAME, 
FARM_ADDRESS = @new_FARM_ADDRESS, FARM_CITY = @new_FARM_CITY,
FARM_STATE = @new_FARM_STATE, FARM_TAX_ID = @new_FARM_TAX_ID, ACTIVE = @new_ACTIVE
WHERE (SUPPLIER_ID = @old_SUPPLIER_ID)
AND (USER_ID = @old_USER_ID)
AND (IS_APPROVED = @old_IS_APPROVED)
AND (APPROVED_BY = @old_APPROVED_BY)
AND (FARM_NAME = @old_FARM_NAME)
AND (FARM_ADDRESS = @old_FARM_ADDRESS)
AND (FARM_CITY = @old_FARM_CITY)
AND (FARM_STATE = @old_FARM_STATE)
AND (FARM_TAX_ID = @old_FARM_TAX_ID)
AND (ACTIVE = @old_ACTIVE)
END
