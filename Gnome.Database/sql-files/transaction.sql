﻿CREATE TABLE [transaction]
(
	[id] uniqueidentifier not null primary key,
	[account_id] int not null,
	[date] datetime not null,
	[amount] decimal(18,2) not null,
	[type] nvarchar(40) not null,
	[data] nvarchar(max) not null,
	foreign key ([account_id]) references fio_account(id)
)
