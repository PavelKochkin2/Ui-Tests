--[TearDown]

begin
Delete from UsersAccessLog
delete from UserGroup
delete from Type where CategoryId = 25
delete from EmailDefinition
delete from Campaign
delete  from KnowledgeToCompany
delete  from KnowledgeToCampaign
delete from Knowledge
delete from [User] where Id > 1
delete from [Right] where MenuOrder > 49
delete from [Right] where MenuOrder = 0
delete from [Company] where name != 'Admin Companies'

SET NOCOUNT ON;
DECLARE @clientGroupId int;
DECLARE clientGroupCursor CURSOR FOR 
Select Id from ClientGroup where id > 1

OPEN clientGroupCursor
FETCH NEXT FROM clientGroupCursor 
INTO @clientGroupId
    WHILE @@FETCH_STATUS = 0
    BEGIN
		exec dropClientGroup @ClientGroupId
		FETCH NEXT FROM clientGroupCursor INTO @clientGroupId
	END
CLOSE clientGroupCursor;
DEALLOCATE clientGroupCursor;

end