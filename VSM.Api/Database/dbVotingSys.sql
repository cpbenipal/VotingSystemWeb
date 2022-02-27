USE [dbVotingSys]
GO
/****** Object:  Table [dbo].[tblCandidates]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCandidates](
	[CandidateId] [int] IDENTITY(1,1) NOT NULL,
	[CandidateName] [nvarchar](200) NOT NULL,
	[AddedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_tblCandidates] PRIMARY KEY CLUSTERED 
(
	[CandidateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCandidateToCategory]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCandidateToCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CandidateId] [nchar](10) NULL,
	[CategoryId] [nchar](10) NULL,
	[AddedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_tblCandidateToCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCategories]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[AddedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_tblCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVoters]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVoters](
	[VoterId] [int] IDENTITY(1,1) NOT NULL,
	[VoterName] [nvarchar](200) NOT NULL,
	[Age] [int] NOT NULL,
	[AddedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_tblVoters] PRIMARY KEY CLUSTERED 
(
	[VoterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVoteToCandidate]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVoteToCandidate](
	[VoteId] [int] IDENTITY(1,1) NOT NULL,
	[VoterId] [int] NOT NULL,
	[CandidateId] [int] NOT NULL,
	[VoteOn] [datetime] NOT NULL,
	[AddedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_tblVoteToCandidate] PRIMARY KEY CLUSTERED 
(
	[VoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCandidates] ON 
GO
INSERT [dbo].[tblCandidates] ([CandidateId], [CandidateName], [AddedOn], [UpdatedOn]) VALUES (1, N'Michael Scott', CAST(N'2022-02-25T17:15:58.293' AS DateTime), CAST(N'2022-02-25T17:15:58.293' AS DateTime))
GO
INSERT [dbo].[tblCandidates] ([CandidateId], [CandidateName], [AddedOn], [UpdatedOn]) VALUES (2, N'Andy Bernard', CAST(N'2022-02-25T17:16:03.617' AS DateTime), CAST(N'2022-02-25T17:16:03.617' AS DateTime))
GO
INSERT [dbo].[tblCandidates] ([CandidateId], [CandidateName], [AddedOn], [UpdatedOn]) VALUES (3, N'Deangelo Vickers', CAST(N'2022-02-25T17:16:12.867' AS DateTime), CAST(N'2022-02-25T17:16:12.867' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tblCandidates] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCandidateToCategory] ON 
GO
INSERT [dbo].[tblCandidateToCategory] ([Id], [CandidateId], [CategoryId], [AddedOn], [UpdatedOn]) VALUES (1, N'1         ', N'1         ', CAST(N'2022-02-25T17:16:31.957' AS DateTime), CAST(N'2022-02-25T17:16:31.957' AS DateTime))
GO
INSERT [dbo].[tblCandidateToCategory] ([Id], [CandidateId], [CategoryId], [AddedOn], [UpdatedOn]) VALUES (2, N'2         ', N'3         ', CAST(N'2022-02-25T17:16:36.077' AS DateTime), CAST(N'2022-02-25T17:16:36.077' AS DateTime))
GO
INSERT [dbo].[tblCandidateToCategory] ([Id], [CandidateId], [CategoryId], [AddedOn], [UpdatedOn]) VALUES (3, N'3         ', N'2         ', CAST(N'2022-02-25T17:16:47.230' AS DateTime), CAST(N'2022-02-25T17:16:47.230' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tblCandidateToCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCategories] ON 
GO
INSERT [dbo].[tblCategories] ([CategoryId], [CategoryName], [AddedOn], [UpdatedOn]) VALUES (1, N'President', CAST(N'2022-02-25T17:15:18.517' AS DateTime), CAST(N'2022-02-25T17:15:18.517' AS DateTime))
GO
INSERT [dbo].[tblCategories] ([CategoryId], [CategoryName], [AddedOn], [UpdatedOn]) VALUES (2, N'Vice President', CAST(N'2022-02-25T17:15:25.070' AS DateTime), CAST(N'2022-02-25T17:15:25.070' AS DateTime))
GO
INSERT [dbo].[tblCategories] ([CategoryId], [CategoryName], [AddedOn], [UpdatedOn]) VALUES (3, N'Secretary', CAST(N'2022-02-25T17:15:28.067' AS DateTime), CAST(N'2022-02-25T17:15:28.067' AS DateTime))
GO
INSERT [dbo].[tblCategories] ([CategoryId], [CategoryName], [AddedOn], [UpdatedOn]) VALUES (9, N'Executive', CAST(N'2022-02-28T00:31:14.110' AS DateTime), CAST(N'2022-02-28T00:31:14.110' AS DateTime))
GO
INSERT [dbo].[tblCategories] ([CategoryId], [CategoryName], [AddedOn], [UpdatedOn]) VALUES (10, N'Middle Level', CAST(N'2022-02-28T00:33:24.683' AS DateTime), CAST(N'2022-02-28T00:33:24.683' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tblCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[tblVoters] ON 
GO
INSERT [dbo].[tblVoters] ([VoterId], [VoterName], [Age], [AddedOn], [UpdatedOn]) VALUES (1, N'Peter', 30, CAST(N'2022-02-25T17:18:12.947' AS DateTime), CAST(N'2022-02-28T01:50:37.570' AS DateTime))
GO
INSERT [dbo].[tblVoters] ([VoterId], [VoterName], [Age], [AddedOn], [UpdatedOn]) VALUES (2, N'Beni', 38, CAST(N'2022-02-25T17:18:19.413' AS DateTime), CAST(N'2022-02-25T17:18:19.413' AS DateTime))
GO
INSERT [dbo].[tblVoters] ([VoterId], [VoterName], [Age], [AddedOn], [UpdatedOn]) VALUES (4, N'Bubble', 30, CAST(N'2022-02-25T17:18:31.697' AS DateTime), CAST(N'2022-02-25T17:18:31.697' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tblVoters] OFF
GO
SET IDENTITY_INSERT [dbo].[tblVoteToCandidate] ON 
GO
INSERT [dbo].[tblVoteToCandidate] ([VoteId], [VoterId], [CandidateId], [VoteOn], [AddedOn], [UpdatedOn]) VALUES (2, 1, 1, CAST(N'2022-02-25T00:00:00.000' AS DateTime), CAST(N'2022-02-25T17:19:24.450' AS DateTime), CAST(N'2022-02-25T17:19:24.450' AS DateTime))
GO
INSERT [dbo].[tblVoteToCandidate] ([VoteId], [VoterId], [CandidateId], [VoteOn], [AddedOn], [UpdatedOn]) VALUES (4, 1, 2, CAST(N'2022-01-02T00:00:00.000' AS DateTime), CAST(N'2022-02-25T17:19:49.827' AS DateTime), CAST(N'2022-02-25T17:19:49.827' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tblVoteToCandidate] OFF
GO
ALTER TABLE [dbo].[tblCandidates] ADD  CONSTRAINT [DF_tblCandidates_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
ALTER TABLE [dbo].[tblCandidates] ADD  CONSTRAINT [DF_tblCandidates_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[tblCandidateToCategory] ADD  CONSTRAINT [DF_tblCandidateToCategory_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
ALTER TABLE [dbo].[tblCandidateToCategory] ADD  CONSTRAINT [DF_tblCandidateToCategory_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[tblCategories] ADD  CONSTRAINT [DF_tblCategories_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
ALTER TABLE [dbo].[tblCategories] ADD  CONSTRAINT [DF_tblCategories_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[tblVoters] ADD  CONSTRAINT [DF_tblVoters_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
ALTER TABLE [dbo].[tblVoters] ADD  CONSTRAINT [DF_tblVoters_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[tblVoteToCandidate] ADD  CONSTRAINT [DF_tblVoteToCandidate_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
ALTER TABLE [dbo].[tblVoteToCandidate] ADD  CONSTRAINT [DF_tblVoteToCandidate_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[tblCandidates]  WITH CHECK ADD  CONSTRAINT [FK_tblCandidates_tblCategories] FOREIGN KEY([CandidateId])
REFERENCES [dbo].[tblCategories] ([CategoryId])
GO
ALTER TABLE [dbo].[tblCandidates] CHECK CONSTRAINT [FK_tblCandidates_tblCategories]
GO
ALTER TABLE [dbo].[tblVoteToCandidate]  WITH CHECK ADD  CONSTRAINT [FK_tblVoteToCandidate_tblCandidates] FOREIGN KEY([CandidateId])
REFERENCES [dbo].[tblCandidates] ([CandidateId])
GO
ALTER TABLE [dbo].[tblVoteToCandidate] CHECK CONSTRAINT [FK_tblVoteToCandidate_tblCandidates]
GO
ALTER TABLE [dbo].[tblVoteToCandidate]  WITH CHECK ADD  CONSTRAINT [FK_tblVoteToCandidate_tblVoteToCandidate] FOREIGN KEY([VoteId])
REFERENCES [dbo].[tblVoters] ([VoterId])
GO
ALTER TABLE [dbo].[tblVoteToCandidate] CHECK CONSTRAINT [FK_tblVoteToCandidate_tblVoteToCandidate]
GO
/****** Object:  StoredProcedure [dbo].[spAddCandidate]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	Create Candidate
-- =============================================
CREATE PROCEDURE [dbo].[spAddCandidate] 
@CandidateName nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @Success bit = 0
	BEGIN TRY  
	 
	 
			INSERT INTO tblCandidates(CandidateName)
			VALUES (@CandidateName) 
		 
			SET @Success = 1		 
	END TRY  
	BEGIN CATCH  
	IF @@TRANCOUNT > 0  
	ROLLBACK TRAN  
		SET @Success = 0
	END CATCH  
	Select @Success 
END
GO
/****** Object:  StoredProcedure [dbo].[spAddCandidatetoCategory]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	Delete Voter
-- =============================================
CREATE PROCEDURE [dbo].[spAddCandidatetoCategory]
@CandidateId int,
@CategoryId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @Success bit = 0
	BEGIN TRY  
	BEGIN TRAN

			INSERT INTO tblCandidateToCategory(CandidateId, CategoryId)
			VALUES (@CandidateId, @CategoryId)

			SET @Success = 1
	END TRY  
	BEGIN CATCH  
	IF @@TRANCOUNT > 0  
	ROLLBACK TRAN  
		SET @Success = 0
	END CATCH  
	Select @Success 
END
GO
/****** Object:  StoredProcedure [dbo].[spAddCategory]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	Create Category
-- =============================================
CREATE PROCEDURE [dbo].[spAddCategory]  
@CategoryName nvarchar(200) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @Success bit = 0
	BEGIN TRY  
	BEGIN TRAN
		 
			INSERT INTO tblCategories(CategoryName)
			VALUES (@CategoryName) 
			COMMIT TRAN
			SET @Success = 1
		 
	END TRY  
	BEGIN CATCH  
	IF @@TRANCOUNT > 0  
	ROLLBACK TRAN  
		SET @Success = 0
	END CATCH  
	Select @Success 
END
GO
/****** Object:  StoredProcedure [dbo].[spAddVoter]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	Save Voter
-- =============================================
CREATE PROCEDURE [dbo].[spAddVoter]
@VoterName nvarchar(200) ,
@Age int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @Success varchar(100)
	BEGIN TRY  	 
		IF @Age < 18
		  SET @Success = 0
	    ELSE
		BEGIN
			INSERT INTO tblVoters(VoterName, Age)
			VALUES (@VoterName, @Age) 			
			SET @Success = 1
		END  
	END TRY  
	BEGIN CATCH  
	IF @@TRANCOUNT > 0  
	ROLLBACK TRAN  
		SET @Success = 0
	END CATCH  
	Select @Success 
END
GO
/****** Object:  StoredProcedure [dbo].[spCandidateVotes]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	 Get # of votes for a candidate
-- =============================================
CREATE PROCEDURE [dbo].[spCandidateVotes]
@CandidateId int=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 	
	 select c.CandidateId,c.CandidateName , vc.VoteId from [dbo].[tblVoteToCandidate] vc
	 inner join tblCandidates c on vc.CandidateId = c.CandidateId
	  where vc.CandidateId = @CandidateId
	
	 for json auto
END
GO
/****** Object:  StoredProcedure [dbo].[spChangeVoterAge]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	Save Voter
-- =============================================
CREATE PROCEDURE [dbo].[spChangeVoterAge]
@VoterId int,
@Age int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @Success bit = 0
	BEGIN TRY  
	 
			UPDATE tblVoters
			SET Age = @Age, UpdatedOn =GETDATE()
			Where VoterId = @VoterId
			 
			SET @Success = 1		 
	END TRY  
	BEGIN CATCH  
	IF @@TRANCOUNT > 0  
	ROLLBACK TRAN  
		SET @Success = 0
	END CATCH  
	Select @Success 
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteVoter]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	Delete Voter
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteVoter]
@VoterId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @Success bit = 0
	BEGIN TRY  
	 
			DELETE FROM tblVoters where VoterId =  @VoterId
			 
			SET @Success = 1
	END TRY  
	BEGIN CATCH  
	IF @@TRANCOUNT > 0  
	ROLLBACK TRAN  
		SET @Success = 0
	END CATCH  
	Select @Success 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCandidates]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	Get all candidates
-- =============================================
CREATE PROCEDURE [dbo].[spGetCandidates]  
@CandidateId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT C.CandidateId, C.CandidateName, 	
	(select ct.CategoryId, ct.CategoryName from [dbo].[tblCategories] ct
	inner join tblCandidateToCategory ctc on ct.CategoryId = ctc.CategoryId where ctc.CandidateId = C.CandidateId for json auto ) categories, 
	C.AddedOn, C.UpdatedOn FROM tblCandidates C where (@CandidateId = 0 or C.CandidateId = @CandidateId)
	
	for json auto
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCategories]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	Get all Categories
-- =============================================
CREATE PROCEDURE [dbo].[spGetCategories]  
@CategoryId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 	
	 select ct.CategoryId, ct.CategoryName , ct.AddedOn, ct.UpdatedOn  from [dbo].[tblCategories] ct
	  where (@CategoryId = 0 or ct.CategoryId = @CategoryId)
	
	for json auto
END
GO
/****** Object:  StoredProcedure [dbo].[spGetVoters]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	Get Voters
-- =============================================
CREATE PROCEDURE [dbo].[spGetVoters] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VoterId, VoterName, Age, Convert(varchar,AddedOn,110) AddedOn, Convert(varchar,UpdatedOn,110) UpdatedOn FROM tblVoters
	For json auto;
END
GO
/****** Object:  StoredProcedure [dbo].[spSaveVoter]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	Save Voter
-- =============================================
CREATE PROCEDURE [dbo].[spSaveVoter]
@VoterName nvarchar(200), 
@VoterId int = NULL,
@Age int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @Success bit = 0
	BEGIN TRY  
	 
		If(@VoterId > 0)
		begin
			UPDATE tblVoters
			SET VoterName = @VoterName, Age = @Age, UpdatedOn =GETDATE()
			Where VoterId = @VoterId
			  
			SET @Success = 1
		end
		else
		begin
			INSERT INTO tblVoters(VoterName, Age)
			VALUES (@VoterName, @Age) 
			SET @Success = 1
		end
	END TRY  
	BEGIN CATCH  
	IF @@TRANCOUNT > 0  
	ROLLBACK TRAN  
		SET @Success = 0
	END CATCH  
	Select @Success 
END
GO
/****** Object:  StoredProcedure [dbo].[spVoteToCandidate]    Script Date: 02-28-2022 3.01.05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Beni
-- Create date: 24-02-2022
-- Description:	Delete Voter
-- =============================================
CREATE PROCEDURE [dbo].[spVoteToCandidate] 
@VoterId  int,
@CandidateId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @Success bit = 0
	BEGIN TRY  
 

			 INSERT INTO tblVoteToCandidate(VoterId, CandidateId)
			 VALUES (@VoterId, @CandidateId)
		 
			SET @Success = 1
	END TRY  
	BEGIN CATCH  
	IF @@TRANCOUNT > 0  
	ROLLBACK TRAN  
		SET @Success = 0
	END CATCH  
	Select @Success 
END
GO
