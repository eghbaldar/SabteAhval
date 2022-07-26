USE [NationalCard]
GO
/****** Object:  Table [dbo].[UserOffice]    Script Date: 04/04/2009 21:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOffice](
	[UserOfficeID] [smallint] NOT NULL,
	[UserID] [smallint] NOT NULL,
	[OfficeID] [smallint] NOT NULL,
 CONSTRAINT [PK_UserOffice] PRIMARY KEY CLUSTERED 
(
	[UserOfficeID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

USE [NationalCard]
GO
/****** Object:  StoredProcedure [dbo].[UserOffice_SP_Delete]    Script Date: 04/04/2009 21:57:29 ******/
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
/****** Object:  StoredProcedure [dbo].[UserOffice_SP_Insert]    Script Date: 04/04/2009 21:57:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[UserOffice_SP_Insert]
@UserOfficeID SmallInt Output,
	@UserID SmallInt,
	@OfficeID SmallInt
AS
INSERT INTO [UserOffice] (
[UserOfficeID],
	[UserID],
	[OfficeID])

VALUES(
@UserOfficeID,
	@UserID,
	@OfficeID)

GO
/****** Object:  StoredProcedure [dbo].[UserOffice_SP_Update]    Script Date: 04/04/2009 21:57:29 ******/
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