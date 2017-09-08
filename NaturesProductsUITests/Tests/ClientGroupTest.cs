using Atata;
using NaturesProductsUITests.Data;
using NUnit.Framework;
using NaturesProductsUITests.Pages.ClientGroup;

namespace NaturesProductsUITests.Tests
{
    public class ClientGroupTest : AutoTest
    {
        [Test]
        public void ClientGroup_Create()
        {
            string code,
                name,
                pageAddress,
                five9Login,
                five9Pass,
                five9Domain,
                five9ApiUrl,
                secFive9Login,
                secFive9Pass,
                secFive9Domain,
                smtpServAdress, mailbox, mailboxPass, addProp = "Additional properties are available for saved objects";
            int? smtpServPort;
            Data.CampaignData defCampaign = Data.CampaignData.delete;
            Data.SynchronizeWithFive9Data synch = SynchronizeWithFive9Data.Normal;


            var row = Go.To<ClientGroupEditor>().
                //check that "Additional properties" link exists
                Content.Should.Contain(addProp).
                //checking "Account is suspended" checkbox 
                AccountSuspended.Check().

                Code.SetRandom(out code).

                Name.SetRandom(out name).

                DefaultCampaign.Set(defCampaign).

                CustomPageAddress.SetRandom(out pageAddress).
                //checking "Individual Recordings Folder" checkbox 
                IndividualRecordingsFolder.Check().

                Five9Login.SetRandom(out five9Login).

                Five9Password.SetRandom(out five9Pass)

                .Five9Domain.SetRandom(out five9Domain)

                .Five9ApiUrl.SetRandom(out five9ApiUrl)

                .SecFive9Login.SetRandom(out secFive9Login)

                .SecFive9Password.SetRandom(out secFive9Pass)

                .SecFive9Domain.SetRandom(out secFive9Domain)

                .SynchronizeWithFive9.Set(synch)

                .SmtpServerAddress.SetRandom(out smtpServAdress).

                SmtpServerPort.SetRandom(out smtpServPort).

                SmtpRequiresSsl.Check().

                Mailbox.SetRandom(out mailbox).

                MailboxPassword.SetRandom(out mailboxPass).
                //saving the changes
                Save().
                //finding domain with "Name" == name and "Code" == code and clicking edit
                ClientGroups.Rows[x => x.Code == code && x.Name == name].Edit()
                //checking that all changes we've made have been saved correctly 

                .Code.Should.Equal(code)

                .Name.Should.Equal(name)

                .DefaultCampaign.Should.Equal(defCampaign)

                .CustomPageAddress.Should.Equal(pageAddress)

                .IndividualRecordingsFolder.Should.BeChecked()

                .Five9Login.Should.Equal(five9Login)

                .Five9Password.Should.Equal(five9Pass)

                .Five9Domain.Should.Equal(five9Domain)

                .Five9ApiUrl.Should.Equal(five9ApiUrl)

                .SecFive9Login.Should.Equal(secFive9Login)

                .SecFive9Password.Should.Equal(secFive9Pass)

                .SecFive9Domain.Should.Equal(secFive9Domain).

                SynchronizeWithFive9.Should.Equal(synch)

                .SmtpServerAddress.Should.Equal(smtpServAdress)

                .SmtpServerPort.Should.Equal(smtpServPort).

                SmtpRequiresSsl.Should.BeChecked()

                .Mailbox.Should.Equal(mailbox)

                .MailboxPassword.Should.Equal(mailboxPass);


        }


        [Test]
        public void ClientGroup_Edit()
        {
            string code = "edit", name = "edit", pageAddress,
                five9Login,
                five9Pass,
                five9Domain,
                five9ApiUrl,
                secFive9Login,
                secFive9Pass,
                secFive9Domain,
                smtpServAdress, mailbox, mailboxPass;
            int? smtpServPort;

            Data.CampaignData defCampaign2 = Data.CampaignData.edit;
            Data.SynchronizeWithFive9Data synch = SynchronizeWithFive9Data.Normal;

            //TODO: add Time Zone edit to this and create tests

            var row = Go.To<ClientGroupList>().
                //finding domain with "Name" == name and "Code" == code and clicking edit
                ClientGroups.Rows[x => x.Code == code && x.Name == name].Edit().
                //unchecking "Account is suspended" checkbox
                AccountSuspended.Uncheck().
                //checking that "Code" field is disabled
                Code.Should.BeDisabled().

                Name.SetRandom(out name).

                DefaultCampaign.Set(defCampaign2).

                CustomPageAddress.SetRandom(out pageAddress).

                IndividualRecordingsFolder.Uncheck().

                Five9Login.SetRandom(out five9Login).

                Five9Password.SetRandom(out five9Pass)

                .Five9Domain.SetRandom(out five9Domain)

                .Five9ApiUrl.SetRandom(out five9ApiUrl)

                .SecFive9Login.SetRandom(out secFive9Login)

                .SecFive9Password.SetRandom(out secFive9Pass).

                SecFive9Domain.SetRandom(out secFive9Domain).

                SynchronizeWithFive9.Set(synch)

                .SmtpServerAddress.SetRandom(out smtpServAdress).

                SmtpServerPort.SetRandom(out smtpServPort).

                SmtpRequiresSsl.Uncheck().

                Mailbox.SetRandom(out mailbox).

                MailboxPassword.SetRandom(out mailboxPass).
                //saving the changes
                Save().
                //finding needed domain and clicking edit 
                ClientGroups.Rows[x => x.Code == code && x.Name == name].Edit()

                .AccountSuspended.Should.BeUnchecked()

                .Code.Should.Equal(code).

                Code.Should.BeDisabled()

                .Name.Should.Equal(name)

                .DefaultCampaign.Should.Equal(defCampaign2)

                .CustomPageAddress.Should.Equal(pageAddress)

                .IndividualRecordingsFolder.Should.BeUnchecked()

                .Five9Login.Should.Equal(five9Login)

                .Five9Password.Should.Equal(five9Pass)

                .Five9Domain.Should.Equal(five9Domain)

                .Five9ApiUrl.Should.Equal(five9ApiUrl)

                .SecFive9Login.Should.Equal(secFive9Login)

                .SecFive9Password.Should.Equal(secFive9Pass)

                .SecFive9Domain.Should.Equal(secFive9Domain).

                SynchronizeWithFive9.Should.Equal(synch)

                .SmtpServerAddress.Should.Equal(smtpServAdress)

                .SmtpServerPort.Should.Equal(smtpServPort).

                SmtpRequiresSsl.Should.BeUnchecked()

                .Mailbox.Should.Equal(mailbox)

                .MailboxPassword.Should.Equal(mailboxPass);
        }

        [Test]
        public void ClientGroup_Delete()
        {
            string code = "delete", name = "delete";


            Go.To<ClientGroupList>().
                //clicking delete for "delete" domain
                ClientGroups.Rows[x => x.Code == code && x.Name == name].Delete().OK().
                //checking that deleted domain doesn't appear in client group grid
                ClientGroups.Rows[x => x.Code == code && x.Name == name].Should.Not.Exist();
        }

        [Test]
        public void ClientGroup_Validation_Required()
        {

            //check that validators for required fields appear
            var row =
                Go.To<ClientGroupEditor>().
                //clicking "Save" button
                Save.Click().
                //checking that validator for "Code" field has appeared
                ValidationMessages[x => x.Code].Should.BeRequired().
                    //checking that validator for "Name" field has appeared
                    ValidationMessages[x => x.Name].Should.BeRequired();
        }

    }
}