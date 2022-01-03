USE [Partner_Managment]
GO

/****** Object:  StoredProcedure [dbo].[PartnerAddOrEdit]    Script Date: 3.1.2022. 22:46:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PartnerAddOrEdit]
@FirstName nvarchar(max),
@LastName nvarchar(max),
@Address nvarchar(max),
@PartnerNumber nvarchar(20),
@CroatianPIN nvarchar(20),
@PartnerTypeId int,
@CreateByUser nvarchar(max),
@IsForeign bit,
@ExternalCode nchar(20),
@Gender char(1)
AS

		INSERT INTO Partners(FirstName,LastName,Address,PartnerNumber,CroatianPIN,PartnerTypeId,CreatedAtUtc,CreateByUser,IsForeign,ExternalCode,Gender)
		VALUES (@FirstName,@LastName,@Address,@PartnerNumber,@CroatianPIN,@PartnerTypeId,GETDATE(),@CreateByUser,@IsForeign,@ExternalCode,@Gender)
GO

------------
USE [Partner_Managment]
GO

/****** Object:  StoredProcedure [dbo].[PartnerDeleteByID]    Script Date: 3.1.2022. 22:47:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PartnerDeleteByID]
@PartnerId int
As
	DELETE FROM Partners
	WHERE PartnerId = @PartnerId
GO


-----------------

USE [Partner_Managment]
GO

/****** Object:  StoredProcedure [dbo].[PartnerViewAll]    Script Date: 3.1.2022. 22:47:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PartnerViewAll]
As
	select PartnerId, rtrim(FirstName) + ' ' + RTRIM(LastName) FullName, PartnerNumber, CroatianPIN, PartnerTypeId, CreatedAtUtc, IsForeign, Gender
	FROM Partners
	order by CreatedAtUtc desc
GO


---------------------------

USE [Partner_Managment]
GO

/****** Object:  StoredProcedure [dbo].[PartnerViewById]    Script Date: 3.1.2022. 22:48:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PartnerViewById]
@PartnerId int
As
	select rtrim(FirstName) + ' ' + RTRIM(LastName) FullName, * 
	FROM Partners
	WHERE PartnerId = @PartnerId
GO




