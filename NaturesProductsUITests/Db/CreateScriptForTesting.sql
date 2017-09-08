
begin
--Create Enum Campaign Types
if not exists(select * from [dbo].[Type] where Name = 'ACQN')insert into Type (Name, CategoryId,[Description], ClientGroupId) values ('ACQN' , 25 , 'Description', 0)
if not exists(select * from [dbo].[Type] where Name = 'Reliant')insert into Type (Name, CategoryId,[Description], ClientGroupId) values ('Reliant' , 25 , 'Description', 0)

-----------------------------------------------------------
--Create test User Groups
if not exists(select * from [dbo].[UserGroup] where Name = 'edit')insert into UserGroup (Name, ClientGroupId) values ('edit', 0)
if not exists(select * from [dbo].[UserGroup] where Name = 'delete')insert into UserGroup (Name, ClientGroupId) values ('delete', 1)
-----------------------------------------------------------
--Create test Emails
insert into EmailDefinition (Name, EmailSubject, DefaultTo, DefaultFrom, DefaultCc) values ('edit' , 'editedit' , 'editedit', 'editedit' , 'editedit')
if not exists(select * from [dbo].[EmailDefinition] where Name = 'delete')insert into EmailDefinition (Name) values ('delete')
-----------------------------------------------------------
--Create test Campaigns

if not exists (select * from [dbo].[Campaign] where Name ='delete')
insert into Campaign (Name, CampaignTypeId, ClientId) values ('delete', (SELECT Id FROM [dbo].[Type] WHERE Name = 'ACQN'), (select Id from [dbo].[Company] where Name = 'Admin Companies'))

if not exists (select * from [dbo].[Campaign] where Name ='share')
insert into Campaign (Name, CampaignTypeId, ClientId) values ('share', (SELECT Id FROM [dbo].[Type] WHERE Name = 'ACQN'), (select Id from [dbo].[Company] where Name = 'Admin Companies'))

if not exists (select * from [dbo].[Campaign] where Name ='edit')
insert into Campaign (Name, CampaignTypeId, ClientId, SeatsAllocated,CampaignToShareSeatId, StartDate, EndDate, ProjectedEndDate,Inactive,UseAlternativeLanguage,AgencyId,InfomercialTypeId,
Five9List) 
values ('edit', (SELECT Id FROM [dbo].[Type] WHERE Name = 'ACQN'), (select Id from [dbo].[Company] where Name = 'DeleteCompany'), 10 , (select id from Campaign where Name = 'share'),
'2017-07-17 00:00:00.000', '2017-12-20 00:00:00.000', '2019-01-25 12:12:12.000', 1,1, (select Id from [dbo].[Company] where Name = 'DeleteCompany'), (select id from Type where Name = 'Long Form'),
'test')

-----------------------------------------------------------
--Create test Campaign Types
if not exists (select * from Type where Name = 'edit')insert into Type (Name, CategoryId,[Description], ClientGroupId) values ('edit' , 25 , 'Description', 0)
if not exists (select * from Type where Name = 'delete')insert into Type (Name, CategoryId,[Description], ClientGroupId) values ('delete' , 25 , 'Description', 0)
-----------------------------------------------------------
--Create test FAQs
if not exists (select * from Knowledge where Name = 'edit' )insert into Knowledge (Name) values ('edit')
if not exists (select * from Knowledge where Name = 'delete')insert into Knowledge (Name) values ('delete')
-----------------------------------------------------------
--Create test Client Groups
if not exists (select * from ClientGroup where Name = 'edit') insert into ClientGroup (Suspended ,Name, Code, DefaultCampaignId, CustomPageAddress,IndividualRecordingsFolder, Five9Login, Five9Password,Five9Domain, Five9ApiUrl, SecondaryFive9Login, SecondaryFive9Password
,SecondaryFive9Domain, EmailServerAddress , EmailServerPort , EmailServerLogin, EmailServerPassword, EmailServerUseSsl) values (1,'edit', 'edit' , (select id from Campaign where name = 'delete'), 'test.authority.com'
, 1, 'Five9Login', 'Five9Password' , 'Five9Domain' , 'test.authority.com' , 'SecondaryFive9Login' , 'SecondaryFive9Password','SecondaryFive9Domain' , 'EmailServerAddress' , 25 , 'EmailServerLogin' , 
'EmailServerPassword', 1)
if not exists (select * from ClientGroup where Name = 'delete')insert into ClientGroup (Name, Code) values ('delete', 'delete')
----------------------------------------------------------
--Create test Users

DECLARE @UserId uniqueidentifier;
begin 
if not exists(select * from [User] where Email = 'mail@mail.com')
insert into [User]  (FirstName, LastName,Email, [Login], [Password], CompanyId, ClientGroupId ) values ('Pavel' , 'Kochkin' , 'mail@mail.com' , 'edit' , 123, (select id from Company where Name = 'Admin Companies'), (SELECT Id FROM [dbo].[ClientGroup] WHERE Name = 'Guest'))
exec dbo.CreateMembershipUser 'npmc' , 'edit' , '123' , 'mail@mail.com' , '', '', @UserId  OUT;
if not exists(select * from [User] where Email = 'mails@mail.com')
insert into [User]  (FirstName, LastName,Email, [Login], [Password], CompanyId, ClientGroupId) values ('Andrey' , 'Misnik' , 'mails@mail.com' , 'delete' , 123, (select id from Company where Name = 'Admin Companies'), (SELECT Id FROM [dbo].[ClientGroup] WHERE Name = 'Admin'))
exec dbo.CreateMembershipUser 'npmc' , 'delete' , '123' , 'mails@mail.com' , '', '', @UserId  OUT;
if not exists(select * from [User] where Email = 'maills@mail.com')
insert into [User]  (FirstName, LastName,Email, [Login], [Password], CompanyId, ClientGroupId) values ('Kolya' , 'Palyda' , 'maills@mail.com' , 'support' , 123, (select id from Company where Name = 'Admin Companies'), (SELECT Id FROM [dbo].[ClientGroup] WHERE Name = 'Admin'))
exec dbo.CreateMembershipUser 'npmc' , 'support' , '123' , 'maills@mail.com' , '', '', @UserId  OUT;
end

------------------------------
--Company creating
if not exists (select * from Company where Name = 'DeleteCompany')insert into Company (Name, ParentId, CompanyTypeId, Relationship,CountryId, ClientGroupId) values ('DeleteCompany', (select id from Company where Name = 'Admin Companies'), 32, 0  , 840 , 0)
if not exists (select * from Company where Name = 'ExistingCompany')insert into Company (Name, ParentId, CompanyTypeId, Relationship,CountryId, ClientGroupId) values ('ExistingCompany', (select id from Company where Name = 'Admin Companies'), 32, 0  , 840 , 0)
------------------------------
--Rights creating
insert into [Right] (Code, Name, [Description] , ClientGroupId) values ('edit', 'edit', 'edit' , 0)
insert into [Right] (Code, Name, [Description]) values ('delete', 'delete', 'delete')
end