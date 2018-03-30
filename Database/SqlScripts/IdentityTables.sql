IF OBJECT_ID('tblUserClaim', 'U') IS NOT NULL
    DROP TABLE tblUserClaim;

IF OBJECT_ID('tblUserLogin', 'U') IS NOT NULL
    DROP TABLE tblUserLogin;

IF OBJECT_ID('tblUserRole', 'U') IS NOT NULL
	DROP TABLE tblUserRole;

IF OBJECT_ID('tblRole', 'U') IS NOT NULL
	DROP TABLE tblRole;

IF OBJECT_ID('tblUser', 'U') IS NOT NULL
	DROP TABLE tblUser;


-- tblUser
CREATE TABLE [dbo].[tblUser](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.tblUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

-- tblRole
CREATE TABLE [dbo].[tblRole](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.tblRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- tblUserRole
CREATE TABLE [dbo].[tblUserRole](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.tblUserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblUserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblUserRole_dbo.tblRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[tblRole] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblUserRole] CHECK CONSTRAINT [FK_dbo.tblUserRole_dbo.tblRole_RoleId]
GO

ALTER TABLE [dbo].[tblUserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblUserRole_dbo.tblUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblUser] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblUserRole] CHECK CONSTRAINT [FK_dbo.tblUserRole_dbo.tblUser_UserId]
GO

-- tblUserLogin
CREATE TABLE [dbo].[tblUserLogin](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.tblUserLogin] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblUserLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblUserLogin_dbo.tblUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblUser] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblUserLogin] CHECK CONSTRAINT [FK_dbo.tblUserLogin_dbo.tblUser_UserId]
GO

-- tblUserClaim

CREATE TABLE [dbo].[tblUserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tblUserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblUserClaim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblUserClaim_dbo.tblUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblUser] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblUserClaim] CHECK CONSTRAINT [FK_dbo.tblUserClaim_dbo.tblUser_UserId]
GO

