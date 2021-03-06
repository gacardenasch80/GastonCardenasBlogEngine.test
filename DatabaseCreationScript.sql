USE [master]
GO
/****** Object:  Database [ZemogaBlogEngine]    Script Date: 12/01/2021 20:00:46 ******/
CREATE DATABASE [ZemogaBlogEngine] 
GO
USE [ZemogaBlogEngine]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 12/01/2021 20:00:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[ApprovalDate] [datetime] NULL,
	[ApproverName] [varchar](100) NULL,
	[AuthorName] [varchar](100) NOT NULL,
	[CreationtDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[PostStatusId] [int] NULL,
	[Text] [varchar](4000) NOT NULL,
	[Title] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostComment]    Script Date: 12/01/2021 20:00:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostComment](
	[PostCommentId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorEmail] [varchar](100) NULL,
	[AuthorName] [varchar](100) NOT NULL,
	[CreationtDate] [datetime] NULL,
	[PostId] [int] NULL,
	[Comment] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_PostComment] PRIMARY KEY CLUSTERED 
(
	[PostCommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostStatus]    Script Date: 12/01/2021 20:00:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostStatus](
	[PostStatusId] [int] NOT NULL,
	[Name] [varchar](100) NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ZemogaBlogEngine] SET  READ_WRITE 
GO
/*insertion of default Post statuses*/
USE [ZemogaBlogEngine]
GO
insert into PostStatus values(0,'Draft')
insert into PostStatus values(1,'Pending Publish Approval')
insert into PostStatus values(2,'Published')

/*Application Login and user creation*/
USE [master]
GO

CREATE LOGIN [ZemogaUsr] WITH PASSWORD='Zemog@!P@ssword', DEFAULT_DATABASE=[ZemogaBlogEngine], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE [master]
GO
ALTER LOGIN [ZemogaUsr] WITH PASSWORD=N'Zemog@!P@ssword'
GO
USE [ZemogaBlogEngine]
GO
CREATE USER [ZemogaUsr] FOR LOGIN [ZemogaUsr]
GO
USE [ZemogaBlogEngine]
GO
ALTER USER [ZemogaUsr] WITH DEFAULT_SCHEMA=[dbo]
GO
USE [ZemogaBlogEngine]
GO
ALTER ROLE [db_owner] ADD MEMBER [ZemogaUsr]
GO

/*End of script*/
