using Atata;
using NaturesProductsUITests.Pages.Email;
using NunitVideoRecorder;
using NUnit.Framework;

namespace NaturesProductsUITests.Tests
{
    public class EmailTest : AutoTest
    {


        [Test]
        // [Video(Name = "Test", Mode = SaveMe.Always)]
        public void Email_Create()
        {
            string name, subj, from, to, cc;

            var row = Go.To<EmailEditor>().

                Name.SetRandom(out name)

                .Subject.SetRandom(out subj)

                .From.SetRandom(out from)

                .To.SetRandom(out to)

                .Cc.SetRandom(out cc)

                .Save().

                Email.Rows[x => x.Name == name].Edit()

                .Name.Should.Equal(name)

                .Subject.Should.Equal(subj)

                .From.Should.Equal(from)

                .To.Should.Equal(to)

                .Cc.Should.Equal(cc);
        }


        [Test]
        public void Email_Edit()
        {
            string name = "edit", subject, from, to, cc;

            var row = Go.To<EmailList>().

                Email.Rows[x => x.Name == name].Edit().

                Name.SetRandom(out name)

                .Subject.SetRandom(out subject)

                .From.SetRandom(out from)

                .To.SetRandom(out to)

                .Cc.SetRandom(out cc).

                Save().

                Email.Rows[x => x.Name == name].Edit()

                .Name.Should.Equal(name)

                .Subject.Should.Equal(subject).

                From.Should.Equal(from).

                To.Should.Equal(to).

                Cc.Should.Equal(cc);
        }

        [Test]
        public void Email_Delete()
        {
            string name = "delete";

            var row = Go.To<EmailList>().
                // clicking delete button for "delete" email
                Email.Rows[x => x.Name == name].Delete().OK()
                // checking that email with "delete" name doesn't exist
                .Email.Rows[x => x.Name == name].Should.Not.Exist();
        }

        [Test]
        public void Email_Validation_Required()
        {
            var row = Go.To<EmailEditor>().
                // clicking "Save" button
                Save.Click().
                // chechking that validator near "Name" field has appeared
                ValidationMessages[x => x.Name].Should.BeRequired();
        }

    }
}