using Atata;
using NUnit.Framework;
using NaturesProductsUITests.Pages.UserGroup;


namespace NaturesProductsUITests.Tests
{
    public class UserGroupTest : AutoTest
    {
        
        [Test]
        public void UserGroup_Create()
        {

            string name, desc;


            var row = Go.To<UserGroupEditor>().

                Name.SetRandom(out name).

                Description.SetRandom(out desc).

                Save().
                
                UserGroups.Rows[x => x.Name == name && x.Description == desc];

            row.Description.Should.Equal(desc);

            row.Name.Should.Equal(name);

        }

        [Test]        
        public void UserGroup_Edit()
        {
            string name = "edit", desc;

            var row = Go.To<UserGroupList>().

               UserGroups.Rows[x => x.Name == name].Edit().

                Name.SetRandom(out name).

                Description.SetRandom(out desc).

                Save().
                
                UserGroups.Rows[x => x.Name == name && x.Description == desc].Edit().

                Name.Should.Equal(name).

                Description.Should.Equal(desc);
        }

        [Test]
        public void UserGroup_Delete()
        {
            string name = "delete";

            var row = Go.To<UserGroupList>().

              UserGroups.Rows[x => x.Name == name].Delete().OK().

                UserGroups.Rows[x => x.Name == name ].Should.Not.Exist();
        }
    }
}