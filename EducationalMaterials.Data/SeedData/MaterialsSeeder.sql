USE [Materials]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [Name], [Description]) VALUES (1, N'Fullstack Developer', N'Great video tutorials in Polish')
INSERT [dbo].[Authors] ([Id], [Name], [Description]) VALUES (2, N'Tim Corey', N'Detailed video tutorials in English')
INSERT [dbo].[Authors] ([Id], [Name], [Description]) VALUES (3, N'Gang of Four', N'Gamma Erich, Helm Richard, Johnson Ralph, Vlissides John')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[MaterialTypes] ON 

INSERT [dbo].[MaterialTypes] ([Id], [Name], [Definition]) VALUES (1, N'Video tutorial', N'Video material with step-by-step instructions on a specific topic.')
INSERT [dbo].[MaterialTypes] ([Id], [Name], [Definition]) VALUES (2, N'Book', N'Paper book describing a topic in great detail.')
INSERT [dbo].[MaterialTypes] ([Id], [Name], [Definition]) VALUES (3, N'Internet article', N'Gives an overview of a specific topic.')
INSERT [dbo].[MaterialTypes] ([Id], [Name], [Definition]) VALUES (4, N'Sample code', N'Heavily commented source code for analysis.')
SET IDENTITY_INSERT [dbo].[MaterialTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Materials] ON 

INSERT [dbo].[Materials] ([Id], [AuthorId], [Title], [Description], [Location], [TypeId], [Published]) VALUES (3, 2, N'Intro to WebAPI - One of the most powerful project types in C#', N'Learn about a project type that allows C# to communicate with almost any programming language.', N'https://youtu.be/vN9NRqv7xmY', 1, CAST(N'2017-12-06T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [AuthorId], [Title], [Description], [Location], [TypeId], [Published]) VALUES (4, 1, N'ASP.NET Core Web API - Logowanie (Autentykacja) użytkowników', N'Overview of user authentication in a .NET API', N'https://youtu.be/exKLvxaPI6Y', 1, CAST(N'2021-06-24T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [AuthorId], [Title], [Description], [Location], [TypeId], [Published]) VALUES (5, 3, N'Design Patterns: Elements of Reusable Object-Oriented Software', N'Capturing a wealth of experience about the design of object-oriented software, four top-notch designers present a catalog of simple and succinct solutions', N'Main CodeCool library', 2, CAST(N'1994-10-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [AuthorId], [Title], [Description], [Location], [TypeId], [Published]) VALUES (6, 2, N'Creating a WebAPI with Authentication - A TimCo Retail Manager Video
', N'In this video, we set up a C# WebAPI project with authentication. We then walk through the settings, configure our first user, and test out the authentication and authorization process.', N'https://youtu.be/_LdiqQ13NBo', 1, CAST(N'2019-01-21T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Materials] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [MaterialId], [ReviewText], [Rating]) VALUES (1, 3, N'Awesome video with detailed, clear explanations', 9)
INSERT [dbo].[Reviews] ([Id], [MaterialId], [ReviewText], [Rating]) VALUES (2, 3, N'Great explanations, but a bit too detailed', 8)
INSERT [dbo].[Reviews] ([Id], [MaterialId], [ReviewText], [Rating]) VALUES (3, 5, N'A brick, didn''t manage to get through it', 2)
INSERT [dbo].[Reviews] ([Id], [MaterialId], [ReviewText], [Rating]) VALUES (4, 4, N'Great if you want to learn about authentication, but you''re out of luck if you don''t know Polish', 7)
INSERT [dbo].[Reviews] ([Id], [MaterialId], [ReviewText], [Rating]) VALUES (5, 6, N'Very in-depth, liked it', 6)
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Login], [PasswordHash], [RoleId]) VALUES (1, N'admin', N'AQAAAAEAACcQAAAAEATOmAFgY4A62PA8T3Wi+rHWwvX5QfYA9NWGv6/SSHKst8+y7uOy4arth+aqxlgvew==', 1)
INSERT [dbo].[Users] ([Id], [Login], [PasswordHash], [RoleId]) VALUES (2, N'user', N'AQAAAAEAACcQAAAAENXP3yCUvLtEm2WcD4uyrmPKws+ZL8gE+Ggthyq5yXwHHxcBH75m4LLJJ1gzyG59wA==', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
