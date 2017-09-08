// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserTest.cs" company="Authority Software">
//  Authority Software 
// </copyright>
// <summary>
//   Defines the CampaignData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NaturesProductsUITests.Tests
{
    using Atata;

    using NaturesProductsUITests.Pages;
    using NaturesProductsUITests.Pages.User;

    using NUnit.Framework;

    public class UserTest : AutoTest
    {
        [Test]
        public void User_Create()
        {
            string login, firstname, lastname, email, county, city, addr, addr2;
            int? zip;
            //string phone = "+375(29)303-82-28";

            Data.CampaignData camp = Data.CampaignData.edit;
            Data.StateData state = Data.StateData.ALASKA;



            var row = Go.To<UserEditor>().

                Login.SetRandom(out login).

                Password.Set("123").

                PasswordConfirm.Set("123").

                FirstName.SetRandom(out firstname).

                LastName.SetRandom(out lastname).

                Email.SetRandom(out email).

                Campaigns.Set(camp).

                Zip.SetRandom(out zip)                

                .Address.SetRandom(out addr)

                .Address2.SetRandom(out addr2)

                .States.Set(state).
                
                County.SetRandom(out county).
                
                City.SetRandom(out city).

                Save().
                
                User.Rows[x => x.Login == login && x.FirstName == firstname && x.LastName == lastname];
            
            row.Edit()

                .Login.Should.Equal(login)

                .FirstName.Should.Equal(firstname)

                .LastName.Should.Equal(lastname)

                .Email.Should.Equal(email)

                .Campaigns.Should.Equal(camp)    
                  // We check that default country is USA          
                .Countries.Should.Equal(Data.CountryData.UnitedStatesofAmerica) 

                .Zip.Should.Equal(zip)

                .States.Should.Equal(state).

                County.Should.Equal(county)

                .City.Should.Equal(city)

                .Address.Should.Equal(addr)

                .Address2.Should.Equal(addr2)
                //check that default value for "Filter" is default
                .Filter.Should.Equal(Data.FilterData.Default).
                
                Save();
            //we check that values in User list comply with user's values
                  row.Login.Should.Equal(login);
                  row.FirstName.Should.Equal(firstname);
                  row.LastName.Should.Equal(lastname);


        }

        [Test]
        public void User_Edit()
        {
            string login = "edit", firstname, lastname, email, city, county, addr, addr2;
            int? zip = 96701;
            Data.ClientGroupData cg = Data.ClientGroupData.Admin;
            Data.CompanyData comp = Data.CompanyData.DeleteCompany;
            Data.CampaignData camp = Data.CampaignData.edit;
            Data.CountryData country = Data.CountryData.Spain;
            Data.StateData state = Data.StateData.HAWAII;
            Data.FilterData filter = Data.FilterData.Agent;
            
            
            //TODO: add phone field data check
            //TODO: add TimeZone set
            var row = Go.To<UserList>().

              User.Rows[x => x.Login == login].Edit().
              //check that "Login" value can't be changed after creating a user 
                Login.Should.BeDisabled().

                Login.Should.Equal(login).

                Password.Set("321").
                PasswordConfirm.Set("321").

                FirstName.SetRandom(out firstname).

                LastName.SetRandom(out lastname).

                Email.SetRandom(out email).
                
                ClientGroup.Set(cg).
                
                Companies.Set(comp).
                
                Campaigns.Set(camp).
                
                Countries.Set(country).
                
                Zip.Set(zip).

                Address.SetRandom(out addr).
                
                Address2.SetRandom(out addr2).
                //check that default value for "Filter" is default
                Filter.Should.Equal(Data.FilterData.Default).

                Filter.Set(filter).
                
                County.SetRandom(out county).

                City.SetRandom(out city).

                Save().

                User.Rows[x => x.Login == login && x.FirstName == firstname && x.LastName == lastname].Edit().

                FirstName.Should.Equal(firstname).

                LastName.Should.Equal(lastname).

                City.Should.Equal(city).

                Email.Should.Equal(email).
                
                ClientGroup.Should.Equal(cg).
                
                Companies.Should.Equal(comp).
                
                Campaigns.Should.Equal(camp).
                
                Countries.Should.Equal(country).

                Zip.Should.Equal(zip).
                
                States.Should.Equal(state).
                
                County.Should.Equal(county).
                
                City.Should.Equal(city).
                
                Address.Should.Equal(addr).
                
                Address2.Should.Equal(addr2).

                Filter.Should.Equal(filter);

        }


        [Test]
        public void User_Delete()
        {
            string login = "delete";


            var row = Go.To<UserList>().

                User.Rows[x => x.Login == login].Delete().OK()

                .User.Rows[x => x.Login == login].Should.Not.Exist();
        }

        [Test]
        public void User_Validation_Required()
        {
            var row = Go.To<UserEditor>().Save.Click().
                //check that validators for required fields appear
                ValidationMessages[x => x.Login].Should.BeRequired().
                ValidationMessages[x => x.Password].Should.BeRequired().
                ValidationMessages[x => x.FirstName].Should.BeRequired().
                ValidationMessages[x => x.LastName].Should.BeRequired().
                ValidationMessages[x => x.Email].Should.BeRequired();
        }

        [Test]
        public void User_Able_Login()
        {            
            Go.To<LoginPage>().Content.Should.Contain("Welcome to Authority CRM!");
        }

        public override void LogIn()
        {
            Go.To<LoginPage>().
               UserName.Set("support").
               Password.Set("123").
               LogIn.ClickAndGo();
        }

        public override void LogOut()
        {
            Go.To<WelcomePage>().
                Kolya.Logout.ClickAndGo();
        }
    }
}