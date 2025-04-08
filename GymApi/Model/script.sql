USE [GYM_DB]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 04-04-2025 10:21:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Age] [int] NOT NULL,
	[Gender] [nvarchar](10) NULL,
	[MobileNo] [nvarchar](15) NULL,
	[Address] [nvarchar](255) NULL,
	[Weight] [float] NOT NULL,
	[Height] [float] NOT NULL,
	[Role] [nvarchar](50) NULL,
	[Branch] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[Password] [nvarchar](100) NULL,
	[IsDefaultPassword] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO




-- Trigger to auto-update ModifiedDate
CREATE TRIGGER trg_UpdateModifiedDate
ON Users
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Users
    SET ModifiedDate = GETDATE()
    FROM Users u
    INNER JOIN inserted i ON u.Id = i.Id;
END;


CREATE TABLE UserPlans (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    [Plan] NVARCHAR(100) NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    CreatedBy NVARCHAR(100) NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    ModifiedBy NVARCHAR(100) NULL,
    ModifiedDate DATETIME NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);

CREATE TABLE UserWeightLogs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    InWeight FLOAT NOT NULL,
    OutWeight FLOAT NOT NULL,
    Date DATE NOT NULL,
    CreatedBy NVARCHAR(100) NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    ModifiedBy NVARCHAR(100) NULL,
    ModifiedDate DATETIME NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);
