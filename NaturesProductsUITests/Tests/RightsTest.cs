using Atata;
using  NaturesProductsUITests.Pages.Rights;
using NUnit.Framework;


namespace NaturesProductsUITests.Tests
{

    public class RightsTest : AutoTest
    {
        [Test]
        //[Parallelizable(ParallelScope.Self)]
        public void Right_Create()
        {
            
            //TODO: change cg varuable to "Admin" when the bug is fixed

            string code, name, desc;
            Data.ClientGroupData cg = Data.ClientGroupData.Guest;
            
            var row = Go.To<RightEditor>().

                Code.SetRandom(out code).

                Name.SetRandom(out name).
                
                Description.SetRandom(out desc).

                ClientGroup.Set(cg).
                
                Save();

            Show_All_Enties();

            row.Rights.Rows[x => x.Code == code && x.Name == name].Edit()

                .Code.Should.Equal(code).

                Name.Should.Equal(name).

                Description.Should.Equal(desc).

                ClientGroup.Should.Equal(cg);
        }

        [Test]
        public void Right_Edit()
        {
            Data.ClientGroupData cg = Data.ClientGroupData.Guest;
            string name = "edit";
            string code, desc;
            var row = Go.To<RightList>();

            Show_All_Enties();  
                      
            row.Rights.Rows[x => x.Name == name].Edit()
                
                .Code.SetRandom(out code)
                
                .Name.SetRandom(out name).
                
                Description.SetRandom(out desc).

                ClientGroup.Set(cg).

                Save().

                Rights.Rows[x => x.Code == code && x.Name == name].Edit()

                .Code.Should.Equal(code).
                
                Name.Should.Equal(name).
                
                Description.Should.Equal(desc).
                
                ClientGroup.Should.Equal(cg);            
        }

        [Test]
        //[Parallelizable]
        public void Right_Delete()
        {
            string name = "delete";

            var row = Go.To<RightList>();

            Show_All_Enties();

            row.Rights.Rows[x => x.Name == name].Delete.Click().OK();

            row.Rights.Rows[x => x.Name == name].Should.Not.Exist();

        }


        [Test]
        [Ignore("")]
        public void Right_Validation_Required()
        {
            var row = Go.To<RightEditor>().Save.Click().
                //checking that validator near "Code" field has appeared
                ValidationMessages[x => x.Code].Should.MustFill().
                //checking that validator near "Name" field has appeared
                ValidationMessages[x => x.Name].Should.MustFill();
        }

        //Method allows to display all rows in a grid 
       public void Show_All_Enties()
        {
            string x = "All";

            var row = Go.To<RightList>().ShowEntries.Set(x);            
        }

    }
}