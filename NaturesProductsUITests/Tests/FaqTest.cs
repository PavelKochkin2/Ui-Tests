using Atata;
using NaturesProductsUITests.Pages.FAQ;
using NUnit.Framework;

namespace NaturesProductsUITests.Tests
{
    public class FaqTest : AutoTest
    {
        [Test]
               
        public void Faq_Create()
        {
            string name , itemText, responseText;
                        
            Go.To<FaqEditor>().

                Name.SetRandom(out name).

                ItemText.SetRandom(out itemText).
                
                ResponseText.SetRandom(out responseText).
                //setting company in "Companies" list
                Companies.Set(Data.CompanyData.DeleteCompany).
                
                Save().

                Faq.Rows[x => x.Name == name].Name.Should.Equal(name);
        }

        [Test]        
        public void Faq_Edit()
        {
            string name= "edit";

            Go.To<FaqList>().
                //finding FAQ with "edit" name
            Faq.Rows[x => x.Name == name].Edit().
            
            Name.SetRandom(out name).
            
            Save().
            
            Faq.Rows[x => x.Name == name].Edit().

            Name.Should.Equal(name);
        }

        [Test]

        public void Faq_Delete()
        {
            string name = "delete";

            Go.To<FaqList>().
                //clicking delete button near "delete" FAQ
                Faq.Rows[x => x.Name == name].Delete().OK().
               
                Faq.Rows[x => x.Name == name].Should.Not.Exist();
        }

        [Test]

        public void Faq_Validation_Required()
        {
            var row = Go.To<FaqEditor>().

                Save.Click().
                //checking that validator near "Name" field has appeard
                ValidationMessages[x => x.Name].Should.BeRequired();
        }

        [Test]

        public void Faq_Validation_MinLength()
        {
            var row =
                Go.To<FaqEditor>().
                
                Name.Set("a").
                
                Save.Click().
                //checking that min length for "Name" field is 2 symbols
                ValidationMessages[x => x.Name].Should.HaveMinLength(2);
        }

        [Test]
        public void Faq_Validation_MaxLength()
        {
            string str = "K5M11f8jBqNAwU3hljQubrlrbOaSN8ulXmNJLbG5p"; //the string contains 41 symbol

            var row =
                Go.To<FaqEditor>().

                Name.Set(str).

                Save.Click().
                //checking that max length for "Name" field is 40 symbols
                ValidationMessages[x => x.Name].Should.HaveMaxLength(40);
        }

    }
}