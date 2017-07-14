using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class MessageService
    {
        public static void PutErrorMessage (IDictionary<Requirement.Attributes, String> Messages, Requirement.Attributes Attribute, String Message)
        {
            if (Messages.ContainsKey(Attribute))
            {
                Messages[Attribute] = Messages[Attribute] + ", " + Message;
            }
            else
            {
                Messages.Add(Attribute, Message);
            }
        }

        public static void FillErrorMessages(IDictionary<Item.Attributes, String> Messages)
        {
            if (!Messages.ContainsKey(Item.Attributes.RequirementNumber))
                Messages.Add(Item.Attributes.RequirementNumber, String.Empty);

            if (!Messages.ContainsKey(Item.Attributes.ItemNumber))
                Messages.Add(Item.Attributes.ItemNumber, String.Empty);

            if (!Messages.ContainsKey(Item.Attributes.Description))
                Messages.Add(Item.Attributes.Description, String.Empty);
        }

        public static void FillErrorMessages(IDictionary<Requirement.Attributes, String> Messages)
        {
            if (!Messages.ContainsKey(Requirement.Attributes.RequirementNumber))
                Messages.Add(Requirement.Attributes.RequirementNumber, String.Empty);

            if (!Messages.ContainsKey(Requirement.Attributes.PurchaseOrder))
                Messages.Add(Requirement.Attributes.PurchaseOrder, String.Empty);

            if (!Messages.ContainsKey(Requirement.Attributes.PurchaseOrderExcercise))
                Messages.Add(Requirement.Attributes.PurchaseOrderExcercise, String.Empty);

            if (!Messages.ContainsKey(Requirement.Attributes.Provider))
                Messages.Add(Requirement.Attributes.Provider, String.Empty);

            if (!Messages.ContainsKey(Requirement.Attributes.CertificationDays))
                Messages.Add(Requirement.Attributes.CertificationDays, String.Empty);
        }
    }
}
