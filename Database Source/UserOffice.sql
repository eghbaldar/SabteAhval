USE [NationalCard]
GO
/****** Object:  StoredProcedure [dbo].[UserOffice_SP_Delete]    Script Date: 04/05/2009 21:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[UserOffice_SP_Delete]
	@UserOfficeID SmallInt
AS
DELETE FROM [UserOffice]
WHERE [UserOfficeID] = @UserOfficeID
GO
/****** Object:  StoredProcedure [dbo].[UserOffice_SP_Insert]    Script Date: 04/05/2009 21:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[UserOffice_SP_Insert]
	@UserOfficeID SmallInt Output,
	@UserID SmallInt,
	@OfficeID SmallInt
AS
SET @UserOfficeID = ISNULL((SELECT MAX(UserOfficeID) FROM [UserOffice]),0) + 1
INSERT INTO [UserOffice] (
[UserOfficeID],
	[UserID],
	[OfficeID])

VALUES(
@UserOfficeID,
	@UserID,
	@OfficeID)


GO
/****** Object:  StoredProcedure [dbo].[UserOffice_SP_Update]    Script Date: 04/05/2009 21:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[UserOffice_SP_Update]
	@UserOfficeID SmallInt,
	@UserID SmallInt,
	@OfficeID SmallInt
AS
UPDATE [UserOffice] SET 
	[UserID] = @UserID,
	[OfficeID] = @OfficeID
WHERE [UserOfficeID] = @UserOfficeID