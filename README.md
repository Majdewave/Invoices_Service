# Invoices

this is a script to Generate the Table in DB, sql server Management studio. 

USE [Invoices]
GO
/****** Object:  Table [dbo].[InvoicesTable]    Script Date: 1/8/2024 7:35:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoicesTable](
	[Id] [nchar](9) NOT NULL,
	[Status] [nchar](50) NULL,
	[Amount] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_InvoicesTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

