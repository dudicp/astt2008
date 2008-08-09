USE [ASTDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetParameterContents]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetEndStation]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UpdateEndStation]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertEndStation]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteEndStation]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetAllEndStations]    Script Date: 08/08/2008 17:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--1. Getting all End-Station
CREATE PROCEDURE [dbo].[sp_GetAllEndStations]
AS
SELECT * FROM EndStations
GO
/****** Object:  Table [dbo].[EndStations]    Script Date: 08/08/2008 17:56:26 ******/
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
	[Username] [varchar](50) NULL,
	[Password] [varchar](20) NULL,
	[IsDefault] [bit] NULL,
 CONSTRAINT [PK__EndStations__03317E3D] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Actions]    Script Date: 08/08/2008 17:56:26 ******/
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
	[Duration] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TSCs]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  Table [dbo].[TPs]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  Table [dbo].[ParametersInTSC]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  Table [dbo].[ParameterValues]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  Table [dbo].[EndStationsInTSC]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  Table [dbo].[EndStationsInTSCRoot]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  Table [dbo].[Parameters]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  Table [dbo].[ActionContents]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  Table [dbo].[ActionsInTSC]    Script Date: 08/08/2008 17:56:26 ******/
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
	[StopIfFails] [bit] NULL,
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
/****** Object:  Table [dbo].[TSCsInTP]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteTSC]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteTSCContent]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertEndStationToTSC]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetEndStationsInTSC]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteParameter]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetActionParameters]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertParameter]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetParameter]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UpdateParameter]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteAction]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertActionContent]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetActionContents]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertActionToTSC]    Script Date: 08/08/2008 17:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3. Insert Action Content
CREATE PROCEDURE [dbo].[sp_InsertActionToTSC]
@TSCName varchar(20),
@ActionName varchar(20),
@ExecutionOrder int,
@Delay int,
@StopIfFails bit


AS



INSERT INTO ActionsInTSC
(TSCName,ActionName,ExecutionOrder,Delay,StopIfFails)
values
(@TSCName,@ActionName,@ExecutionOrder,@Delay,@StopIfFails)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActionsInTSC]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetParametersInTSC]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertParameterToTSC]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteTPContent]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertTSCToTP]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetTSCsInTP]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteTP]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetEndStationsInTSCRoot]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertEndStationToTSCRoot]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertParameterContent]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetActionsInfo]    Script Date: 08/08/2008 17:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Getting actions information
CREATE PROCEDURE [dbo].[sp_GetActionsInfo]
AS
SELECT Name,Description FROM Actions
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAction]    Script Date: 08/08/2008 17:56:26 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertAction]    Script Date: 08/08/2008 17:56:27 ******/
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
@Duration int

AS

INSERT INTO Actions
(Name, Description, Type, Timeout, CreatorName, CreationTime, Duration)
values
(@Name, @Description, @Type, @Timeout, @CreatorName, @CreationTime, @Duration)
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAction]    Script Date: 08/08/2008 17:56:27 ******/
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
@Duration int

AS

UPDATE Actions
SET Description=@Description,
	Type=@Type,
	Timeout=@Timeout,
	CreatorName=@CreatorName,
	CreationTime=@CreationTime,
	Duration=@Duration
WHERE
Name=@Name;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRecentActions]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetAdditionalActionsInfo]    Script Date: 08/08/2008 17:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Getting actions information
CREATE PROCEDURE [dbo].[sp_GetAdditionalActionsInfo]
AS
SELECT Name,Description
FROM Actions
WHERE CreatorName != 'System'
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTSCsInfo]    Script Date: 08/08/2008 17:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Getting actions information
CREATE PROCEDURE [dbo].[sp_GetTSCsInfo]
AS
SELECT Name,Description FROM TSCs
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRecentTSCs]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetTSC]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UpdateTSC]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertTSC]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetTPsInfo]    Script Date: 08/08/2008 17:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Getting actions information
CREATE PROCEDURE [dbo].[sp_GetTPsInfo]
AS
SELECT Name,Description FROM TPs
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertTP]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UpdateTP]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetRecentTPs]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetTP]    Script Date: 08/08/2008 17:56:27 ******/
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
/****** Object:  ForeignKey [ContentOfAction]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[ActionContents]  WITH CHECK ADD  CONSTRAINT [ContentOfAction] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[ActionContents] CHECK CONSTRAINT [ContentOfAction]
GO
/****** Object:  ForeignKey [FK_ActionsInTSC_ActionsInTSC]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[ActionsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ActionsInTSC_ActionsInTSC] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[ActionsInTSC] CHECK CONSTRAINT [FK_ActionsInTSC_ActionsInTSC]
GO
/****** Object:  ForeignKey [FK_ActionsInTSC_TSCs]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[ActionsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ActionsInTSC_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[ActionsInTSC] CHECK CONSTRAINT [FK_ActionsInTSC_TSCs]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSC_Actions]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[EndStationsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_EndStationsInTSC_Actions] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[EndStationsInTSC] CHECK CONSTRAINT [FK_EndStationsInTSC_Actions]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSC_EndStations]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[EndStationsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_EndStationsInTSC_EndStations] FOREIGN KEY([ID])
REFERENCES [dbo].[EndStations] ([ID])
GO
ALTER TABLE [dbo].[EndStationsInTSC] CHECK CONSTRAINT [FK_EndStationsInTSC_EndStations]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSC_TSCs]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[EndStationsInTSC]  WITH CHECK ADD  CONSTRAINT [FK_EndStationsInTSC_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[EndStationsInTSC] CHECK CONSTRAINT [FK_EndStationsInTSC_TSCs]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSCRoot_EndStations]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[EndStationsInTSCRoot]  WITH NOCHECK ADD  CONSTRAINT [FK_EndStationsInTSCRoot_EndStations] FOREIGN KEY([EndStationID])
REFERENCES [dbo].[EndStations] ([ID])
GO
ALTER TABLE [dbo].[EndStationsInTSCRoot] CHECK CONSTRAINT [FK_EndStationsInTSCRoot_EndStations]
GO
/****** Object:  ForeignKey [FK_EndStationsInTSCRoot_TSCs]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[EndStationsInTSCRoot]  WITH CHECK ADD  CONSTRAINT [FK_EndStationsInTSCRoot_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[EndStationsInTSCRoot] CHECK CONSTRAINT [FK_EndStationsInTSCRoot_TSCs]
GO
/****** Object:  ForeignKey [ParameterOfAction]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[Parameters]  WITH CHECK ADD  CONSTRAINT [ParameterOfAction] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[Parameters] CHECK CONSTRAINT [ParameterOfAction]
GO
/****** Object:  ForeignKey [FK_ParametersInTSC_Parameters]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[ParametersInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ParametersInTSC_Parameters] FOREIGN KEY([ActionName], [ParameterName])
REFERENCES [dbo].[Parameters] ([ActionName], [ParameterName])
GO
ALTER TABLE [dbo].[ParametersInTSC] CHECK CONSTRAINT [FK_ParametersInTSC_Parameters]
GO
/****** Object:  ForeignKey [FK_ParametersInTSC_TSCs]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[ParametersInTSC]  WITH CHECK ADD  CONSTRAINT [FK_ParametersInTSC_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[ParametersInTSC] CHECK CONSTRAINT [FK_ParametersInTSC_TSCs]
GO
/****** Object:  ForeignKey [FK_ParameterValues_Parameters]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[ParameterValues]  WITH CHECK ADD  CONSTRAINT [FK_ParameterValues_Parameters] FOREIGN KEY([ActionName], [ParameterName])
REFERENCES [dbo].[Parameters] ([ActionName], [ParameterName])
GO
ALTER TABLE [dbo].[ParameterValues] CHECK CONSTRAINT [FK_ParameterValues_Parameters]
GO
/****** Object:  ForeignKey [FK_TSCsInTP_TPs]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[TSCsInTP]  WITH CHECK ADD  CONSTRAINT [FK_TSCsInTP_TPs] FOREIGN KEY([TPName])
REFERENCES [dbo].[TPs] ([Name])
GO
ALTER TABLE [dbo].[TSCsInTP] CHECK CONSTRAINT [FK_TSCsInTP_TPs]
GO
/****** Object:  ForeignKey [FK_TSCsInTP_TSCs]    Script Date: 08/08/2008 17:56:26 ******/
ALTER TABLE [dbo].[TSCsInTP]  WITH CHECK ADD  CONSTRAINT [FK_TSCsInTP_TSCs] FOREIGN KEY([TSCName])
REFERENCES [dbo].[TSCs] ([Name])
GO
ALTER TABLE [dbo].[TSCsInTP] CHECK CONSTRAINT [FK_TSCsInTP_TSCs]
GO


------------------------------ End-Stations ------------------------------

INSERT INTO EndStations
(ID,Name,IPAddress,MACAddress,OSType,OSVersion,Username,Password,IsDefault)
values
(0,'Localhost','127.0.0.1','','WINDOWS','','','','False');


------------------------------ Basic Actions ------------------------------

-- 1. Change IP

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,Duration)
values
('ChangeIP','Changes the IP address of an end-station to an IP address specified by the user.','SCRIPT',10,'System','01/01/08',0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('ChangeIP','WINDOWS','Scripts\ChangeIP.vbs','');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('ChangeIP','NewIP','The new wanted IP address.','Input','','','True');


-- 2. Dynamic Change IP

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,Duration)
values
('DynamicChangeIP','Changes the IP address of an end-station dynamically.','BATCH_FILE',10,'System','01/01/08',0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('DynamicChangeIP','WINDOWS','Scripts\DynamicChangeIP.exe','');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('DynamicChangeIP','SharedFolderPath','The path of the shared folder to write the new IP address.','Input','','','True');


-- 3. Logoff

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,Duration)
values
('Logoff','Logoff the current user on the remote end-station.','COMMAND_LINE',10,'System','01/01/08',0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('Logoff','WINDOWS','shutdown -l','');


-- 4. Ping

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,Duration)
values
('Ping','Tests a network connection - if successful, ping returns the ip address.','COMMAND_LINE',10,'System','01/01/08',0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('Ping','WINDOWS','ping','Reply from');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','BufferSize','Send buffer size.','Both','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','Destination','The name of the remote host.','Input','','','True');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','ExecuteUntilKill','Ping the destination host until interrupted.','Option','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','LooseSourceRoute','Loose source route along host_list.','Both','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','RecordRoute','Record route for count hops.','Both','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','RequestsNumber','Number of echo requests to send.','Both','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','ResolveAddresses','Resolve addresses to hostnames.','Option','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','SetDontFragment','Set Dont Fragment flag in packet.','Option','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','StrictSourceRoute','Strict source route along host_list.','Both','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','Timeout','Timeout in milliseconds to wait for each reply.','Both','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','Timestamp','Timestamp for count hops.','Both','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','TimeToLive','Time to live.','Both','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Ping','TypeOfService','Type of service.','Both','','','False');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','BufferSize','WINDOWS','-l');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','ExecuteUntilKill','WINDOWS','-t');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','LooseSourceRoute','WINDOWS','-j');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','RecordRoute','WINDOWS','-r');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','RequestsNumber','WINDOWS','-n');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','ResolveAddresses','WINDOWS','-a');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','SetDontFragment','WINDOWS','-f');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','StrictSourceRoute','WINDOWS','-k');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','Timeout','WINDOWS','-w');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','Timestamp','WINDOWS','-s');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','TimeToLive','WINDOWS','-i');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Ping','TypeOfService','WINDOWS','-v');


-- 5. Reset

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,Duration)
values
('Reset','Restarts the computer.','COMMAND_LINE',10,'System','01/01/08',0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('Reset','WINDOWS','shutdown -r','');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Reset','ForceOPT','Force running applications to close. This will not prompt for File-Save in any open applications and will result a loss of all unsaved data.','Option','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Reset','Message','An optional shutdown message (maximum of 127 chars).','Both','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Reset','Timeout','Time until system reset in seconds. The valid range is 0-600 seconds (default is 30 seconds).','Both','30','','False');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Reset','ForceOPT','WINDOWS','-f');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Reset','Message','WINDOWS','-c');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Reset','Timeout','WINDOWS','-t');


-- 6. Shutdown

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime,Duration)
values
('Shutdown','Shutdown the computer.','COMMAND_LINE',10,'System','01/01/08',0);

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
('Shutdown','WINDOWS','shutdown -s','');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Shutdown','ForceOPT','Force running applications to close. This will not prompt for File-Save in any open applications and will result a loss of all unsaved data.','Option','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Shutdown','Message','An optional shutdown message (maximum of 127 chars).','Both','','','False');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp, IsDefault)
values
('Shutdown','Timeout','Time until system shutdown in seconds. The valid range is 0-600 seconds (default is 30 seconds).','Both','30','','False');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Shutdown','ForceOPT','WINDOWS','-f');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Shutdown','Message','WINDOWS','-c');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Shutdown','Timeout','WINDOWS','-t');