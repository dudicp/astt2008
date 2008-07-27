USE [ASTDB]
GO
/****** Object:  Table [dbo].[Actions]    Script Date: 07/27/2008 14:35:06 ******/
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
	[StopIfFails] [bit] NULL,
	[Duration] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TSCs]    Script Date: 07/27/2008 14:35:06 ******/
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
/****** Object:  Table [dbo].[TPs]    Script Date: 07/27/2008 14:35:06 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetParameterContents]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  Table [dbo].[EndStations]    Script Date: 07/27/2008 14:35:06 ******/
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
/****** Object:  Table [dbo].[EndStationsInTSC]    Script Date: 07/27/2008 14:35:06 ******/
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
/****** Object:  Table [dbo].[Parameters]    Script Date: 07/27/2008 14:35:06 ******/
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
/****** Object:  Table [dbo].[ActionContents]    Script Date: 07/27/2008 14:35:06 ******/
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
/****** Object:  Table [dbo].[ActionsInTSC]    Script Date: 07/27/2008 14:35:06 ******/
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
/****** Object:  Table [dbo].[ParametersInTSC]    Script Date: 07/27/2008 14:35:06 ******/
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
/****** Object:  Table [dbo].[TSCsInTP]    Script Date: 07/27/2008 14:35:06 ******/
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
/****** Object:  Table [dbo].[EndStationsInTSCRoot]    Script Date: 07/27/2008 14:35:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EndStationsInTSCRoot](
	[EndStationID] [int] NOT NULL,
	[TSCName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_EndStationsInTSCRoot] PRIMARY KEY CLUSTERED 
(
	[EndStationID] ASC,
	[TSCName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ParameterValues]    Script Date: 07/27/2008 14:35:06 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetActionsInfo]    Script Date: 07/27/2008 14:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Getting actions information
CREATE PROCEDURE [dbo].[sp_GetActionsInfo]
AS
SELECT Name,Description FROM Actions
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAction]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertAction]    Script Date: 07/27/2008 14:35:07 ******/
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
@CreationTime datetime,
@StopIfFails bit,
@Duration int

AS

INSERT INTO Actions
(Name, Description, Type, Timeout, CreatorName, CreationTime, StopIfFails, Duration)
values
(@Name, @Description, @Type, @Timeout, @CreatorName, @CreationTime, @StopIfFails, @Duration)
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAction]    Script Date: 07/27/2008 14:35:07 ******/
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
@CreationTime datetime,
@StopIfFails bit,
@Duration int

AS

UPDATE Actions
SET Description=@Description,
	Type=@Type,
	Timeout=@Timeout,
	CreatorName=@CreatorName,
	CreationTime=@CreationTime,
	StopIfFails=@StopIfFails,
	Duration=@Duration
WHERE
Name=@Name;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRecentActions]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteAction]    Script Date: 07/27/2008 14:35:06 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteTSC]    Script Date: 07/27/2008 14:35:07 ******/
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
DELETE FROM EndStationsInTSCRoot WHERE TSCName=@TSCName;
DELETE FROM TSCs WHERE Name=@TSCName;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTSCsInfo]    Script Date: 07/27/2008 14:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Getting actions information
CREATE PROCEDURE [dbo].[sp_GetTSCsInfo]
AS
SELECT Name,Description FROM TSCs
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRecentTSCs]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetTSC]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UpdateTSC]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertTSC]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteTPContent]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertTSCToTP]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetTSCsInTP]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteTP]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteTSCContent]    Script Date: 07/27/2008 14:35:07 ******/
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
DELETE FROM EndStationsInTSCRoot WHERE TSCName=@TSCName;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetParametersInTSC]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertParameterToTSC]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertParameterContent]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteParameter]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertEndStationToTSC]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetEndStationsInTSC]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertActionToTSC]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetActionsInTSC]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetActionParameters]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertParameter]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetParameter]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UpdateParameter]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertActionContent]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetActionContents]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetEndStationsInTSCRoot]    Script Date: 07/27/2008 14:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--4. Getting action content
CREATE PROCEDURE [dbo].[sp_GetEndStationsInTSCRoot]
@TSCName varchar(20)

AS
SELECT * FROM EndStationsInTSCRoot WHERE TSCName=@TSCName;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertEndStationToTSCRoot]    Script Date: 07/27/2008 14:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Insert Action Content
CREATE PROCEDURE [dbo].[sp_InsertEndStationToTSCRoot]
@TSCName varchar(20),
@EndStationID int


AS



INSERT INTO EndStationsInTSCRoot
(EndStationID,TSCName)
values
(@EndStationID,@TSCName)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTPsInfo]    Script Date: 07/27/2008 14:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Getting actions information
CREATE PROCEDURE [dbo].[sp_GetTPsInfo]
AS
SELECT Name,Description FROM TPs
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertTP]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UpdateTP]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetRecentTPs]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetTP]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetEndStation]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UpdateEndStation]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertEndStation]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteEndStation]    Script Date: 07/27/2008 14:35:07 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetAllEndStations]    Script Date: 07/27/2008 14:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--1. Getting all End-Station
CREATE PROCEDURE [dbo].[sp_GetAllEndStations]
AS
SELECT * FROM EndStations
GO
/****** Object:  ForeignKey [ContentOfAction]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[ActionContents]  WITH CHECK ADD  CONSTRAINT [ContentOfAction] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[ActionContents] CHECK CONSTRAINT [ContentOfAction]
GO
/****** Object:  ForeignKey [FK_ActionsInTSC_ActionsInTSC]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[ActionsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ActionsInTSC_ActionsInTSC] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[ActionsInTSC] CHECK CONSTRAINT [FK_ActionsInTSC_ActionsInTSC]
GO
/****** Object:  ForeignKey [FK_ActionsInTSC_TSCs]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[ActionsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ActionsInTSC_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[ActionsInTSC] CHECK CONSTRAINT [FK_ActionsInTSC_TSCs]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSC_Actions]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[EndStationsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_EndStationsInTSC_Actions] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[EndStationsInTSC] CHECK CONSTRAINT [FK_EndStationsInTSC_Actions]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSC_EndStations]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[EndStationsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_EndStationsInTSC_EndStations] FOREIGN KEY([ID])
REFERENCES [dbo].[EndStations] ([ID])
GO
ALTER TABLE [dbo].[EndStationsInTSC] CHECK CONSTRAINT [FK_EndStationsInTSC_EndStations]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSC_TSCs]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[EndStationsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_EndStationsInTSC_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[EndStationsInTSC] CHECK CONSTRAINT [FK_EndStationsInTSC_TSCs]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSCRoot_EndStations]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[EndStationsInTSCRoot]  WITH NOCHECK ADD  CONSTRAINT [FK_EndStationsInTSCRoot_EndStations] FOREIGN KEY([EndStationID])
REFERENCES [dbo].[EndStations] ([ID])
GO
ALTER TABLE [dbo].[EndStationsInTSCRoot] CHECK CONSTRAINT [FK_EndStationsInTSCRoot_EndStations]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSCRoot_TSCs]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[EndStationsInTSCRoot]  WITH CHECK ADD  CONSTRAINT [FK_EndStationsInTSCRoot_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[EndStationsInTSCRoot] CHECK CONSTRAINT [FK_EndStationsInTSCRoot_TSCs]
GO
/****** Object:  ForeignKey [ParameterOfAction]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[Parameters]  WITH CHECK ADD  CONSTRAINT [ParameterOfAction] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[Parameters] CHECK CONSTRAINT [ParameterOfAction]
GO
/****** Object:  ForeignKey [FK_ParametersInTSC_Parameters]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[ParametersInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ParametersInTSC_Parameters] FOREIGN KEY([ActionName], [ParameterName])
REFERENCES [dbo].[Parameters] ([ActionName], [ParameterName])
GO
ALTER TABLE [dbo].[ParametersInTSC] CHECK CONSTRAINT [FK_ParametersInTSC_Parameters]
GO
/****** Object:  ForeignKey [FK_ParametersInTSC_TSCs]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[ParametersInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ParametersInTSC_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[ParametersInTSC] CHECK CONSTRAINT [FK_ParametersInTSC_TSCs]
GO
/****** Object:  ForeignKey [FK_ParameterValues_Parameters]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[ParameterValues]  WITH CHECK ADD  CONSTRAINT [FK_ParameterValues_Parameters] FOREIGN KEY([ActionName], [ParameterName])
REFERENCES [dbo].[Parameters] ([ActionName], [ParameterName])
GO
ALTER TABLE [dbo].[ParameterValues] CHECK CONSTRAINT [FK_ParameterValues_Parameters]
GO
/****** Object:  ForeignKey [FK_TSCsInTP_TPs]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[TSCsInTP]  WITH CHECK ADD  CONSTRAINT [FK_TSCsInTP_TPs] FOREIGN KEY([TPName])
REFERENCES [dbo].[TPs] ([Name])
GO
ALTER TABLE [dbo].[TSCsInTP] CHECK CONSTRAINT [FK_TSCsInTP_TPs]
GO
/****** Object:  ForeignKey [FK_TSCsInTP_TSCs]    Script Date: 07/27/2008 14:35:06 ******/
ALTER TABLE [dbo].[TSCsInTP]  WITH CHECK ADD  CONSTRAINT [FK_TSCsInTP_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[TSCsInTP] CHECK CONSTRAINT [FK_TSCsInTP_TSCs]
GO

--/////////////////////////////////////////
--// Basic Actions
--/////////////////////////////////////////

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,StopIfFails, Duration)
values
('Notepad','Opens notepad on the remote end-station.','COMMAND_LINE',10,'System','01/01/08',0, 0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('Notepad','WINDOWS','-i notepad.exe','');

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,StopIfFails, Duration)
values
('Test','This is a test command.','COMMAND_LINE',10,'System','01/01/08',0, 0);

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

-- 1. Shutdown CLI

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,StopIfFails, Duration)
values
('Shutdown','This action turn off the remote end-station.','COMMAND_LINE',20,'System','01/01/08',0, 0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('Shutdown','WINDOWS','shutdown','');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Shutdown','ShutdownOPT','Shutdown the computer.','Option','','','True');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Shutdown','ShutdownOPT','WINDOWS','/s');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Shutdown','ForceOPT','Force running applications to close without forewarning users.','Option','','','True');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Shutdown','ForceOPT','WINDOWS','/f');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Shutdown','NoWarning','Turn off the local computer with no time-out or warning.','Option','','','False');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Shutdown','NoWarning','WINDOWS','/p');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Shutdown','Timeout','Set the time-out period before shutdown to xxx seconds.The valid range is 0-600, with a default of 30.Using this parameter implies using ForceOPT parameter.','Both','30','','False');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Shutdown','Timeout','WINDOWS','/t');

-- 2. Restart CLI

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,StopIfFails, Duration)
values
('Restart','This action restart the remote end-station.','COMMAND_LINE',20,'System','01/01/08',0, 0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('Restart','WINDOWS','shutdown','');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Restart','RestartOPT','Shutdown and restart the computer.','Option','','','True');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Restart','RestartOPT','WINDOWS','/r');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Restart','ForceOPT','Force running applications to close without forewarning users.','Option','','','True');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Restart','ForceOPT','WINDOWS','/f');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Restart','Timeout','Set the time-out period before shutdown to xxx seconds.The valid range is 0-600, with a default of 30.Using this parameter implies using ForceOPT parameter.','Both','30','','False');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Restart','Timeout','WINDOWS','/t');

-- 3. Hibernate CLI

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,StopIfFails, Duration)
values
('Hibernate','This action hibernate the remote end-station.','COMMAND_LINE',20,'System','01/01/08',0, 0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('Hibernate','WINDOWS','shutdown','');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Hibernate','HibernateOPT','Hibernate the local computer.','Option','','','True');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Hibernate','HibernateOPT','WINDOWS','/h');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Hibernate','ForceOPT','Force running applications to close without forewarning users.','Option','','','True');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Hibernate','ForceOPT','WINDOWS','/f');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Hibernate','Timeout','Set the time-out period before shutdown to xxx seconds.The valid range is 0-600, with a default of 30.Using this parameter implies using ForceOPT parameter.','Both','30','','False');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Hibernate','Timeout','WINDOWS','/t');

-- 4 Logoff CLI

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,StopIfFails, Duration)
values
('Logoff','This action logoff the current user on the remote end-station.','COMMAND_LINE',20,'System','01/01/08',0, 0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('Logoff','WINDOWS','shutdown','');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Logoff','LogoffOPT','Logoff the current user on the remote end-station.','Option','','','True');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Logoff','LogoffOPT','WINDOWS','/l');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Logoff','ForceOPT','Force running applications to close without forewarning users.','Option','','','True');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Logoff','ForceOPT','WINDOWS','/f');

-- 5 Change IP Address

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,StopIfFails, Duration)
values
('ChangeIPAddress','This action change the IP address of the remote end-station.','SCRIPT',20,'System','01/01/08',0,0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('ChangeIPAddress','WINDOWS','../Scripts/ChangeIPAddress.vbs','');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('ChangeIPAddress','NewIP','The new wanted IP address','Input','192.168.2.8','','True');