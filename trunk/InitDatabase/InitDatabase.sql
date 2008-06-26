USE [ASTDB]
GO
/****** Object:  Table [dbo].[TSCs]    Script Date: 06/26/2008 18:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TSCs](
	[Name] [varchar](20) NOT NULL,
	[Description] [text] NULL,
	[CreatorName] [varchar](20) NULL,
	[CreationTime] [datetime] NULL,
 CONSTRAINT [PK_TSCs] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TPs]    Script Date: 06/26/2008 18:42:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TPs](
	[Name] [varchar](20) NOT NULL,
	[Description] [text] NULL,
	[CreatorName] [varchar](20) NULL,
	[CreationTime] [datetime] NULL,
 CONSTRAINT [PK_TPs] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_GetParameterContents]    Script Date: 06/26/2008 18:41:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--6. Getting parameter values
CREATE PROCEDURE [dbo].[sp_GetParameterContents]
@ActionName varchar(20),
@ParameterName varchar(20)
AS
SELECT * FROM ParameterValues WHERE (ActionName=@ActionName AND ParameterName=@ParameterName);
GO
/****** Object:  Table [dbo].[EndStations]    Script Date: 06/26/2008 18:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EndStations](
	[ID] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[IPAddress] [varchar](15) NOT NULL,
	[MACAddress] [varchar](20) NULL,
	[OSTYpe] [varchar](20) NOT NULL,
	[OSVersion] [varchar](20) NULL,
	[Username] [varchar](20) NULL,
	[Password] [varchar](20) NULL,
	[IsDefault] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Actions]    Script Date: 06/26/2008 18:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Actions](
	[Name] [varchar](20) NOT NULL,
	[Description] [text] NULL,
	[Type] [varchar](20) NOT NULL,
	[Timeout] [int] NULL,
	[CreatorName] [varchar](20) NOT NULL,
	[CreationTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EndStationsInTSC]    Script Date: 06/26/2008 18:42:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EndStationsInTSC](
	[ID] [int] NOT NULL,
	[TSCName] [varchar](20) NOT NULL,
	[ActionName] [varchar](20) NOT NULL,
	[ExecutionOrder] [int] NOT NULL,
 CONSTRAINT [PK_EndStationsInTSC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[TSCName] ASC,
	[ActionName] ASC,
	[ExecutionOrder] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ActionsInTSC]    Script Date: 06/26/2008 18:42:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ActionsInTSC](
	[TSCName] [varchar](20) NOT NULL,
	[ActionName] [varchar](20) NOT NULL,
	[ExecutionOrder] [int] NOT NULL,
	[Delay] [int] NULL,
 CONSTRAINT [PK_ActionsInTSC] PRIMARY KEY CLUSTERED 
(
	[TSCName] ASC,
	[ActionName] ASC,
	[ExecutionOrder] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TSCsInTP]    Script Date: 06/26/2008 18:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TSCsInTP](
	[TPName] [varchar](20) NOT NULL,
	[TSCName] [varchar](20) NOT NULL,
	[ExecutionOrder] [int] NOT NULL,
 CONSTRAINT [PK_TSCsInTP] PRIMARY KEY CLUSTERED 
(
	[TPName] ASC,
	[TSCName] ASC,
	[ExecutionOrder] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ParametersInTSC]    Script Date: 06/26/2008 18:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ParametersInTSC](
	[TSCName] [varchar](20) NOT NULL,
	[ActionName] [varchar](20) NOT NULL,
	[ExecutionOrder] [int] NOT NULL,
	[ParameterName] [varchar](20) NOT NULL,
	[Input] [text] NULL,
 CONSTRAINT [PK_ParametersInTSC] PRIMARY KEY CLUSTERED 
(
	[TSCName] ASC,
	[ActionName] ASC,
	[ExecutionOrder] ASC,
	[ParameterName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ParameterValues]    Script Date: 06/26/2008 18:42:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ParameterValues](
	[ActionName] [varchar](20) NOT NULL,
	[ParameterName] [varchar](20) NOT NULL,
	[OSType] [varchar](20) NOT NULL,
	[Value] [varchar](20) NULL,
 CONSTRAINT [PK_ParameterValues] PRIMARY KEY CLUSTERED 
(
	[ActionName] ASC,
	[ParameterName] ASC,
	[OSType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Parameters]    Script Date: 06/26/2008 18:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parameters](
	[ActionName] [varchar](20) NOT NULL,
	[ParameterName] [varchar](20) NOT NULL,
	[Description] [text] NULL,
	[Type] [varchar](20) NOT NULL,
	[Input] [text] NULL,
	[ValidityExp] [text] NULL,
	[IsDefault] [bit] NULL,
 CONSTRAINT [ActionParameters] PRIMARY KEY CLUSTERED 
(
	[ActionName] ASC,
	[ParameterName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ActionContents]    Script Date: 06/26/2008 18:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ActionContents](
	[ActionName] [varchar](20) NOT NULL,
	[OSType] [varchar](20) NOT NULL,
	[ActionContent] [text] NOT NULL,
	[ValidityString] [text] NULL,
 CONSTRAINT [ContetnsOfAction] PRIMARY KEY CLUSTERED 
(
	[ActionName] ASC,
	[OSType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRecentTSCs]    Script Date: 06/26/2008 18:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Getting action
CREATE PROCEDURE [dbo].[sp_GetRecentTSCs]
AS
SELECT Name, Description, CreationTime
FROM TSCs
ORDER BY CreationTime DESC;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTSC]    Script Date: 06/26/2008 18:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Getting action
CREATE PROCEDURE [dbo].[sp_GetTSC]
@Name varchar(20) 
AS
SELECT * FROM TSCs WHERE Name=@Name;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTSC]    Script Date: 06/26/2008 18:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Insert Action
CREATE PROCEDURE [dbo].[sp_UpdateTSC]
@Name varchar(20),
@Description text,
@CreatorName varchar(20),
@CreationTime datetime

AS

UPDATE TSCs
SET Description=@Description,
	CreatorName=@CreatorName,
	CreationTime=@CreationTime
WHERE
Name=@Name;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertTSC]    Script Date: 06/26/2008 18:42:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Insert Action
CREATE PROCEDURE [dbo].[sp_InsertTSC]
@Name varchar(20),
@Description text,
@CreatorName varchar(20),
@CreationTime datetime

AS

INSERT INTO TSCs
(Name, Description, CreatorName, CreationTime)
values
(@Name, @Description, @CreatorName, @CreationTime)
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTSC]    Script Date: 06/26/2008 18:41:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Delete Action
CREATE PROCEDURE [dbo].[sp_DeleteTSC]
@TSCName varchar(20)
AS
DELETE FROM ParametersInTSC WHERE TSCName=@TSCName;
DELETE FROM ActionsInTSC WHERE TSCName=@TSCName;
DELETE FROM EndStationsInTSC WHERE TSCName=@TSCName;
DELETE FROM TSCs WHERE Name=@TSCName;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTSCsInfo]    Script Date: 06/26/2008 18:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Getting actions information
CREATE PROCEDURE [dbo].[sp_GetTSCsInfo]
AS
SELECT Name,Description FROM TSCs
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTPsInfo]    Script Date: 06/26/2008 18:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Getting actions information
CREATE PROCEDURE [dbo].[sp_GetTPsInfo]
AS
SELECT Name,Description FROM TPs
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTP]    Script Date: 06/26/2008 18:41:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Delete Action
CREATE PROCEDURE [dbo].[sp_DeleteTP]
@TPName varchar(20)
AS
DELETE FROM TSCsInTP WHERE TPName=@TPName;
DELETE FROM TPs WHERE Name=@TPName;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertTP]    Script Date: 06/26/2008 18:42:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Insert Action
CREATE PROCEDURE [dbo].[sp_InsertTP]
@Name varchar(20),
@Description text,
@CreatorName varchar(20),
@CreationTime datetime

AS

INSERT INTO TPs
(Name, Description, CreatorName, CreationTime)
values
(@Name, @Description, @CreatorName, @CreationTime)
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTP]    Script Date: 06/26/2008 18:42:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Insert Action
CREATE PROCEDURE [dbo].[sp_UpdateTP]
@Name varchar(20),
@Description text,
@CreatorName varchar(20),
@CreationTime datetime

AS

UPDATE TPs
SET Description = @Description,
	CreatorName = @CreatorName,
	CreationTime = @CreationTime
WHERE Name=@Name;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRecentTPs]    Script Date: 06/26/2008 18:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Getting action
CREATE PROCEDURE [dbo].[sp_GetRecentTPs]
AS
SELECT Name, Description, CreationTime
FROM TPs
ORDER BY CreationTime DESC;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTP]    Script Date: 06/26/2008 18:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Getting action
CREATE PROCEDURE [dbo].[sp_GetTP]
@Name varchar(20) 
AS
SELECT * FROM TPs WHERE Name=@Name;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertEndStationToTSC]    Script Date: 06/26/2008 18:42:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Insert Action Content
CREATE PROCEDURE [dbo].[sp_InsertEndStationToTSC]
@TSCName varchar(20),
@ActionName varchar(20),
@ExecutionOrder int,
@ID int


AS



INSERT INTO EndStationsInTSC
(ID,TSCName,ActionName,ExecutionOrder)
values
(@ID,@TSCName,@ActionName,@ExecutionOrder)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEndStationsInTSC]    Script Date: 06/26/2008 18:41:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--4. Getting action content
CREATE PROCEDURE [dbo].[sp_GetEndStationsInTSC]
@TSCName varchar(20),
@ActionName varchar(20),
@ExecutionOrder int

AS
SELECT * FROM EndStationsInTSC WHERE TSCName=@TSCName AND ActionName=@ActionName AND ExecutionOrder=@ExecutionOrder;
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTSCContent]    Script Date: 06/26/2008 18:41:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Delete Action
CREATE PROCEDURE [dbo].[sp_DeleteTSCContent]
@TSCName varchar(20)
AS
DELETE FROM ParametersInTSC WHERE TSCName=@TSCName;
DELETE FROM ActionsInTSC WHERE TSCName=@TSCName;
DELETE FROM EndStationsInTSC WHERE TSCName=@TSCName;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertActionToTSC]    Script Date: 06/26/2008 18:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Insert Action Content
CREATE PROCEDURE [dbo].[sp_InsertActionToTSC]
@TSCName varchar(20),
@ActionName varchar(20),
@ExecutionOrder int,
@Delay int


AS



INSERT INTO ActionsInTSC
(TSCName,ActionName,ExecutionOrder,Delay)
values
(@TSCName,@ActionName,@ExecutionOrder,@Delay)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActionsInTSC]    Script Date: 06/26/2008 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--4. Getting action content
CREATE PROCEDURE [dbo].[sp_GetActionsInTSC]
@Name varchar(20) 
AS
SELECT * FROM ActionsInTSC WHERE TSCName=@Name ORDER BY ExecutionOrder ASC;
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteParameter]    Script Date: 06/26/2008 18:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--1. Delete Parameter
CREATE PROCEDURE [dbo].[sp_DeleteParameter]
@ActionName varchar(20),
@ParameterName varchar(20)
AS
DELETE FROM ParameterValues WHERE (ActionName=@ActionName AND ParameterName=@ParameterName);
DELETE FROM Parameters WHERE (ActionName=@ActionName AND ParameterName=@ParameterName);
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActionParameters]    Script Date: 06/26/2008 18:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--5. Getting all parameters of actions
CREATE PROCEDURE [dbo].[sp_GetActionParameters]
@Name varchar(20) 
AS
SELECT * FROM Parameters WHERE ActionName=@Name;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertParameter]    Script Date: 06/26/2008 18:42:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--4. Insert Parameter
CREATE PROCEDURE [dbo].[sp_InsertParameter]
@ActionName varchar(20),
@ParameterName varchar(20),
@Description text,
@Type varchar(20),
@Input text,
@ValidityExp text,
@IsDefault bit

AS


INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp,IsDefault)
values
(@ActionName,@ParameterName,@Description,@Type,@Input,@ValidityExp,@IsDefault)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetParameter]    Script Date: 06/26/2008 18:41:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--5. Getting all parameters of actions
CREATE PROCEDURE [dbo].[sp_GetParameter]
@ActionName varchar(20),
@ParameterName varchar(20)
AS
SELECT * FROM Parameters WHERE ActionName=@ActionName AND ParameterName=@ParameterName;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateParameter]    Script Date: 06/26/2008 18:42:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--4. Insert Parameter
CREATE PROCEDURE [dbo].[sp_UpdateParameter]
@ActionName varchar(20),
@ParameterName varchar(20),
@Description text,
@Type varchar(20),
@Input text,
@ValidityExp text,
@IsDefault bit

AS

UPDATE Parameters
SET Description=@Description,
	Type=@Type,
	Input=@Input,
	ValidityExp=@ValidityExp,
	IsDefault=@IsDefault
WHERE (ActionName=@ActionName AND ParameterName=@ParameterName)
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteAction]    Script Date: 06/26/2008 18:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Delete Action
CREATE PROCEDURE [dbo].[sp_DeleteAction]
@ActionName varchar(20)
AS
DELETE FROM ParameterValues WHERE ActionName=@ActionName;
DELETE FROM Parameters WHERE ActionName=@ActionName;
DELETE FROM ActionContents WHERE ActionName=@ActionName;
DELETE FROM Actions WHERE Name=@ActionName;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertActionContent]    Script Date: 06/26/2008 18:42:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Insert Action Content
CREATE PROCEDURE [dbo].[sp_InsertActionContent]
@ActionName varchar(20),
@OSType varchar(20),
@ActionContent text,
@ValidityString text

AS


IF (0 < (SELECT COUNT(*) FROM ActionContents WHERE ActionName=@ActionName AND OSType=@OSType))
	BEGIN
	UPDATE ActionContents
	SET ActionContent=@ActionContent,
		ValidityString=@ValidityString
	WHERE ActionName=@ActionName AND OSType=@OSType
	END
ELSE
	BEGIN
	INSERT INTO ActionContents
	(ActionName, OSType, ActionContent, ValidityString)
	values
	(@ActionName, @OSType, @ActionContent, @ValidityString)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActionContents]    Script Date: 06/26/2008 18:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--4. Getting action content
CREATE PROCEDURE [dbo].[sp_GetActionContents]
@Name varchar(20) 
AS
SELECT * FROM ActionContents WHERE ActionName=@Name;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertParameterContent]    Script Date: 06/26/2008 18:42:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--5. Insert Parameter Value
CREATE PROCEDURE [dbo].[sp_InsertParameterContent]
@ActionName varchar(20),
@ParameterName varchar(20),
@OSType varchar(20),
@Value varchar(20)

AS


IF (0 < (SELECT COUNT(*) FROM ParameterValues WHERE (ActionName=@ActionName AND OSType=@OSType AND ParameterName=@ParameterName)))
	BEGIN
	UPDATE ParameterValues
	SET Value=@Value
	WHERE (ActionName=@ActionName AND OSType=@OSType AND ParameterName=@ParameterName)
	END
ELSE
	BEGIN
	INSERT INTO ParameterValues
	(ActionName,ParameterName,OSType,Value)
	values
	(@ActionName,@ParameterName,@OSType,@Value)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetParametersInTSC]    Script Date: 06/26/2008 18:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--4. Getting action content
CREATE PROCEDURE [dbo].[sp_GetParametersInTSC]
@TSCName varchar(20),
@ActionName varchar(20),
@ExecutionOrder int

AS
SELECT * FROM ParametersInTSC WHERE TSCName=@TSCName AND ActionName=@ActionName AND ExecutionOrder=@ExecutionOrder;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertParameterToTSC]    Script Date: 06/26/2008 18:42:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Insert Action Content
CREATE PROCEDURE [dbo].[sp_InsertParameterToTSC]
@TSCName varchar(20),
@ActionName varchar(20),
@ExecutionOrder int,
@ParameterName varchar(20),
@Input text


AS



INSERT INTO ParametersInTSC
(TSCName,ActionName,ExecutionOrder,ParameterName,Input)
values
(@TSCName,@ActionName,@ExecutionOrder,@ParameterName,@Input)
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTPContent]    Script Date: 06/26/2008 18:41:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Delete Action
CREATE PROCEDURE [dbo].[sp_DeleteTPContent]
@TPName varchar(20)
AS
DELETE FROM TSCsInTP WHERE TPName=@TPName;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertTSCToTP]    Script Date: 06/26/2008 18:42:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Insert Action Content
CREATE PROCEDURE [dbo].[sp_InsertTSCToTP]
@TPName varchar(20),
@TSCName varchar(20),
@ExecutionOrder int


AS



INSERT INTO TSCsInTP
(TPName,TSCName,ExecutionOrder)
values
(@TPName,@TSCName,@ExecutionOrder)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTSCsInTP]    Script Date: 06/26/2008 18:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--4. Getting action content
CREATE PROCEDURE [dbo].[sp_GetTSCsInTP]
@TPName varchar(20) 
AS
SELECT * FROM TSCsInTP WHERE TPName=@TPName ORDER BY ExecutionOrder ASC;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEndStation]    Script Date: 06/26/2008 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Getting action
CREATE PROCEDURE [dbo].[sp_GetEndStation]
@ID int 
AS
SELECT * FROM EndStations WHERE ID=@ID;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateEndStation]    Script Date: 06/26/2008 18:42:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--1. Insert End-Station
CREATE PROCEDURE [dbo].[sp_UpdateEndStation]
@ID int,
@Name text,
@IPAddress text,
@MACAddress text,
@OSType text,
@OSVersion text,
@Username text,
@Password text,
@IsDefault bit

AS

UPDATE EndStations
SET Name=@Name,
	IPAddress=@IPAddress,
	MACAddress=@MACAddress,
	OSType=@OSType,
	OSVersion=@OSVersion,
	Username=@Username,
	Password=@Password,
	IsDefault=@IsDefault
WHERE ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertEndStation]    Script Date: 06/26/2008 18:42:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--1. Insert End-Station
CREATE PROCEDURE [dbo].[sp_InsertEndStation]
@ID int,
@Name text,
@IPAddress text,
@MACAddress text,
@OSType text,
@OSVersion text,
@Username text,
@Password text,
@IsDefault bit

AS

INSERT INTO EndStations
(ID,Name,IPAddress,MACAddress,OSType,OSVersion,Username,Password,IsDefault)
values
(@ID,@Name,@IPAddress,@MACAddress,@OSType,@OSVersion,@Username,@Password,@IsDefault)
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteEndStation]    Script Date: 06/26/2008 18:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Delete Action
CREATE PROCEDURE [dbo].[sp_DeleteEndStation]
@ID int
AS
DELETE FROM EndStations WHERE ID=@ID
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllEndStations]    Script Date: 06/26/2008 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--1. Getting all End-Station
CREATE PROCEDURE [dbo].[sp_GetAllEndStations]
AS
SELECT * FROM EndStations
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActionsInfo]    Script Date: 06/26/2008 18:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Getting actions information
CREATE PROCEDURE [dbo].[sp_GetActionsInfo]
AS
SELECT Name,Description FROM Actions
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAction]    Script Date: 06/26/2008 18:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Getting action
CREATE PROCEDURE [dbo].[sp_GetAction]
@Name varchar(20) 
AS
SELECT * FROM Actions WHERE Name=@Name;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAction]    Script Date: 06/26/2008 18:42:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Insert Action
CREATE PROCEDURE [dbo].[sp_InsertAction]
@Name varchar(20),
@Description text,
@Type varchar(20),
@Timeout int,
@CreatorName varchar(20),
@CreationTime datetime

AS

INSERT INTO Actions
(Name, Description, Type, Timeout, CreatorName, CreationTime)
values
(@Name, @Description, @Type, @Timeout, @CreatorName, @CreationTime)
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAction]    Script Date: 06/26/2008 18:42:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Insert Action
CREATE PROCEDURE [dbo].[sp_UpdateAction]
@Name varchar(20),
@Description text,
@Type varchar(20),
@Timeout int,
@CreatorName varchar(20),
@CreationTime datetime

AS

UPDATE Actions
SET Description=@Description,
	Type=@Type,
	Timeout=@Timeout,
	CreatorName=@CreatorName,
	CreationTime=@CreationTime
WHERE
Name=@Name;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRecentActions]    Script Date: 06/26/2008 18:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Getting action
CREATE PROCEDURE [dbo].[sp_GetRecentActions]
AS
SELECT Name, Description, CreationTime
FROM Actions
ORDER BY CreationTime DESC;
GO
/****** Object:  ForeignKey [ContentOfAction]    Script Date: 06/26/2008 18:42:12 ******/
ALTER TABLE [dbo].[ActionContents]  WITH CHECK ADD  CONSTRAINT [ContentOfAction] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[ActionContents] CHECK CONSTRAINT [ContentOfAction]
GO
/****** Object:  ForeignKey [FK_ActionsInTSC_ActionsInTSC]    Script Date: 06/26/2008 18:42:16 ******/
ALTER TABLE [dbo].[ActionsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ActionsInTSC_ActionsInTSC] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[ActionsInTSC] CHECK CONSTRAINT [FK_ActionsInTSC_ActionsInTSC]
GO
/****** Object:  ForeignKey [FK_ActionsInTSC_TSCs]    Script Date: 06/26/2008 18:42:16 ******/
ALTER TABLE [dbo].[ActionsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ActionsInTSC_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[ActionsInTSC] CHECK CONSTRAINT [FK_ActionsInTSC_TSCs]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSC_Actions]    Script Date: 06/26/2008 18:42:22 ******/
ALTER TABLE [dbo].[EndStationsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_EndStationsInTSC_Actions] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[EndStationsInTSC] CHECK CONSTRAINT [FK_EndStationsInTSC_Actions]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSC_EndStations]    Script Date: 06/26/2008 18:42:22 ******/
ALTER TABLE [dbo].[EndStationsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_EndStationsInTSC_EndStations] FOREIGN KEY([ID])
REFERENCES [dbo].[EndStations] ([ID])
GO
ALTER TABLE [dbo].[EndStationsInTSC] CHECK CONSTRAINT [FK_EndStationsInTSC_EndStations]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSC_TSCs]    Script Date: 06/26/2008 18:42:22 ******/
ALTER TABLE [dbo].[EndStationsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_EndStationsInTSC_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[EndStationsInTSC] CHECK CONSTRAINT [FK_EndStationsInTSC_TSCs]
GO
/****** Object:  ForeignKey [ParameterOfAction]    Script Date: 06/26/2008 18:42:25 ******/
ALTER TABLE [dbo].[Parameters]  WITH CHECK ADD  CONSTRAINT [ParameterOfAction] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[Parameters] CHECK CONSTRAINT [ParameterOfAction]
GO
/****** Object:  ForeignKey [FK_ParametersInTSC_Parameters]    Script Date: 06/26/2008 18:42:27 ******/
ALTER TABLE [dbo].[ParametersInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ParametersInTSC_Parameters] FOREIGN KEY([ActionName], [ParameterName])
REFERENCES [dbo].[Parameters] ([ActionName], [ParameterName])
GO
ALTER TABLE [dbo].[ParametersInTSC] CHECK CONSTRAINT [FK_ParametersInTSC_Parameters]
GO
/****** Object:  ForeignKey [FK_ParametersInTSC_TSCs]    Script Date: 06/26/2008 18:42:27 ******/
ALTER TABLE [dbo].[ParametersInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ParametersInTSC_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[ParametersInTSC] CHECK CONSTRAINT [FK_ParametersInTSC_TSCs]
GO
/****** Object:  ForeignKey [FK_ParameterValues_Parameters]    Script Date: 06/26/2008 18:42:30 ******/
ALTER TABLE [dbo].[ParameterValues]  WITH CHECK ADD  CONSTRAINT [FK_ParameterValues_Parameters] FOREIGN KEY([ActionName], [ParameterName])
REFERENCES [dbo].[Parameters] ([ActionName], [ParameterName])
GO
ALTER TABLE [dbo].[ParameterValues] CHECK CONSTRAINT [FK_ParameterValues_Parameters]
GO
/****** Object:  ForeignKey [FK_TSCsInTP_TPs]    Script Date: 06/26/2008 18:42:34 ******/
ALTER TABLE [dbo].[TSCsInTP]  WITH CHECK ADD  CONSTRAINT [FK_TSCsInTP_TPs] FOREIGN KEY([TPName])
REFERENCES [dbo].[TPs] ([Name])
GO
ALTER TABLE [dbo].[TSCsInTP] CHECK CONSTRAINT [FK_TSCsInTP_TPs]
GO
/****** Object:  ForeignKey [FK_TSCsInTP_TSCs]    Script Date: 06/26/2008 18:42:34 ******/
ALTER TABLE [dbo].[TSCsInTP]  WITH CHECK ADD  CONSTRAINT [FK_TSCsInTP_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[TSCsInTP] CHECK CONSTRAINT [FK_TSCsInTP_TSCs]
GO


--/////////////////////////////////////////
--// Basic Actions
--/////////////////////////////////////////

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime)
values
('Notepad','Opens notepad on the remote end-station.','COMMAND_LINE',10,'System','01/01/08');

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('Notepad','WINDOWS','notepad.exe','');

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime)
values
('Test','This is a test command.','COMMAND_LINE',10,'System','01/01/08');

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('Test','WINDOWS','test','');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp,IsDefault)
values
('Test','param1','param1','Input','','','False');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Test','param1','WINDOWS','-p1');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Test','param2','param2','Option','','','False');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Test','param2','WINDOWS','-p2');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Test','param3','param3','Option','','','False');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Test','param3','WINDOWS','-p3');

INSERT INTO EndStations
(ID,Name,IPAddress,MACAddress,OSType,OSVersion,Username,Password,IsDefault)
values
(0,'End-Station','1.1.1.1','','WINDOWS','','','','False');