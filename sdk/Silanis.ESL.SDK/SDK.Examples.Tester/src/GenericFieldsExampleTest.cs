using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    [TestFixture()]
    public class GenericFieldsExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            GenericFieldsExample example = new GenericFieldsExample(Props.GetInstance());
            example.Run();

            DocumentPackage documentPackage = example.EslClient.GetPackage(example.PackageId);

            foreach (Signature signature in documentPackage.Documents[GenericFieldsExample.DOCUMENT_NAME].Signatures)
            {
                foreach (Field field in signature.Fields)
                {
                    // Textfield
                    if (field.Id == GenericFieldsExample.TEXTFIELD_ID)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_TEXT_FIELD, field.Style);
                        Assert.AreEqual(GenericFieldsExample.TEXTFIELD_PAGE, field.Page);
                    }
                    // Checkbox
                    if (field.Id == GenericFieldsExample.CHECKBOX_ID)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_CHECK_BOX, field.Style);
                        Assert.AreEqual(FieldBuilder.CHECKBOX_CHECKED, field.Value);
                        Assert.AreEqual(GenericFieldsExample.CHECKBOX_PAGE, field.Page);
                    }
                    // Radio Button 1
                    if (field.Id == GenericFieldsExample.RADIO_ID_1)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(GenericFieldsExample.RADIO_PAGE,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(GenericFieldsExample.RADIO_GROUP_1, field.Validator.Options[0]);
                        Assert.AreEqual("", field.Value);
                    }
                    // Radio Button 2
                    if (field.Id == GenericFieldsExample.RADIO_ID_2)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(GenericFieldsExample.RADIO_PAGE,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(GenericFieldsExample.RADIO_GROUP_1, field.Validator.Options[0]);
                        Assert.AreEqual(FieldBuilder.RADIO_SELECTED, field.Value);
                    }
                    // Radio Button 3
                    if (field.Id == GenericFieldsExample.RADIO_ID_3)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(GenericFieldsExample.RADIO_PAGE,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(GenericFieldsExample.RADIO_GROUP_2, field.Validator.Options[0]);
                        Assert.AreEqual(FieldBuilder.RADIO_SELECTED, field.Value);
                    }
                    // Radio Button 4
                    if (field.Id == GenericFieldsExample.RADIO_ID_4)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(GenericFieldsExample.RADIO_PAGE,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(GenericFieldsExample.RADIO_GROUP_2, field.Validator.Options[0]);
                        Assert.AreEqual("", field.Value);
                    }
                }
            }
        }
    }
}