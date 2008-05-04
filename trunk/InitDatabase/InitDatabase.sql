USE [ASTDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertParameterContent]    Script Date: 04/25/2008 11:53:51 ******/
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

DELETE FROM ParameterValues WHERE (ActionName=@ActionName AND ParameterName=@ParameterName AND OSType=@OSType);

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
(@ActionName,@ParameterName,@OSType,@Value);
GO
/****** Object:  StoredProcedure [dbo].[sp_GetParameterContents]    Script Date: 04/25/2008 11:53:50 ******/
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
/****** Object:  Table [dbo].[EndStations]    Script Date: 04/25/2008 11:53:50 ******/
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
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Actions]    Script Date: 04/25/2008 11:53:50 ******/
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
/****** Object:  Table [dbo].[Parameters]    Script Date: 04/25/2008 11:53:50 ******/
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
 CONSTRAINT [ActionParameters] PRIMARY KEY CLUSTERED 
(
	[ActionName] ASC,
	[ParameterName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ActionContents]    Script Date: 04/25/2008 11:53:50 ******/
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
/****** Object:  Table [dbo].[ParameterValues]    Script Date: 04/25/2008 11:53:50 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertActionContent]    Script Date: 04/25/2008 11:53:50 ******/
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

DELETE FROM ActionContents WHERE ActionName=@ActionName;

INSERT INTO ActionContents
(ActionName,OSType,ActionContent,ValidityString)
values
(@ActionName,@OSType,@ActionContent,@ValidityString);
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActionContents]    Script Date: 04/25/2008 11:53:50 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteAction]    Script Date: 04/25/2008 11:53:50 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_insertEndStation]    Script Date: 04/25/2008 11:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--1. Insert End-Station
CREATE PROCEDURE [dbo].[sp_insertEndStation]
@ID int,
@Name text,
@IPAddress text,
@MACAddress text,
@OSType text,
@OSVersion text,
@Username text,
@Password text

AS

DELETE FROM EndStations WHERE ID=@ID;

INSERT INTO EndStations
(ID,Name,IPAddress,MACAddress,OSType,OSVersion,Username,Password)
values
(@ID,@Name,@IPAddress,@MACAddress,@OSType,@OSVersion,@Username,@Password);
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllEndStations]    Script Date: 04/25/2008 11:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--1. Getting all End-Station
CREATE PROCEDURE [dbo].[sp_GetAllEndStations]
AS
SELECT * FROM EndStations
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActionsInfo]    Script Date: 04/25/2008 11:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2. Getting actions information
CREATE PROCEDURE [dbo].[sp_GetActionsInfo]
AS
SELECT Name,Description FROM Actions
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAction]    Script Date: 04/25/2008 11:53:50 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertAction]    Script Date: 04/25/2008 11:53:50 ******/
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

DELETE FROM Actions WHERE Name=@Name;

INSERT INTO Actions
(Name,Description,Type,Timeout,CreatorName,CreationTime)
values
(@Name,@Description,@Type,@Timeout,@CreatorName,@CreationTime);
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteParameter]    Script Date: 04/25/2008 11:53:50 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetActionParameters]    Script Date: 04/25/2008 11:53:50 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertParameter]    Script Date: 04/25/2008 11:53:50 ******/
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
@ValidityExp text

AS

DELETE FROM Parameters WHERE (ActionName=@ActionName AND ParameterName=@ParameterName);

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp)
values
(@ActionName,@ParameterName,@Description,@Type,@Input,@ValidityExp);
GO
/****** Object:  ForeignKey [ContentOfAction]    Script Date: 04/25/2008 11:53:50 ******/
ALTER TABLE [dbo].[ActionContents]  WITH CHECK ADD  CONSTRAINT [ContentOfAction] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[ActionContents] CHECK CONSTRAINT [ContentOfAction]
GO
/****** Object:  ForeignKey [ParameterOfAction]    Script Date: 04/25/2008 11:53:50 ******/
ALTER TABLE [dbo].[Parameters]  WITH CHECK ADD  CONSTRAINT [ParameterOfAction] FOREIGN KEY([ActionName])
REFERENCES [dbo].[Actions] ([Name])
GO
ALTER TABLE [dbo].[Parameters] CHECK CONSTRAINT [ParameterOfAction]
GO
/****** Object:  ForeignKey [FK_ParameterValues_Parameters]    Script Date: 04/25/2008 11:53:50 ******/
ALTER TABLE [dbo].[ParameterValues]  WITH CHECK ADD  CONSTRAINT [FK_ParameterValues_Parameters] FOREIGN KEY([ActionName], [ParameterName])
REFERENCES [dbo].[Parameters] ([ActionName], [ParameterName])
GO
ALTER TABLE [dbo].[ParameterValues] CHECK CONSTRAINT [FK_ParameterValues_Parameters]
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
(ActionName,ParameterName,Description,Type,Input,ValidityExp)
values
('Test','param1','param1','Input','','');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Test','param1','WINDOWS','-p1');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp)
values
('Test','param2','param2','Option','','');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Test','param2','WINDOWS','-p2');

INSERT INTO Parameters
(ActionName,ParameterName,Description,Type,Input,ValidityExp)
values
('Test','param3','param3','Option','','');

INSERT INTO ParameterValues
(ActionName,ParameterName,OSType,Value)
values
('Test','param3','WINDOWS','-p3');

INSERT INTO EndStations
(ID,Name,IPAddress,MACAddress,OSType,OSVersion,Username,Password)
values
(0,'End-Station','1.1.1.1','','WINDOWS','','','');

