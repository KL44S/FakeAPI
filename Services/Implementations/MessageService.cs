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
        public static void PutErrorMessage (IDictionary<Attributes.Requirement, String> Messages, Attributes.Requirement Attribute, String Message)
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

        public static void FillErrorMessages(IDictionary<Attributes.SubItem, String> Messages)
        {
            if (!Messages.ContainsKey(Attributes.SubItem.Description))
                Messages.Add(Attributes.SubItem.Description, String.Empty);

            if (!Messages.ContainsKey(Attributes.SubItem.TotalQuantity))
                Messages.Add(Attributes.SubItem.TotalQuantity, String.Empty);

            if (!Messages.ContainsKey(Attributes.SubItem.UnitOfMeasurement))
                Messages.Add(Attributes.SubItem.UnitOfMeasurement, String.Empty);

            if (!Messages.ContainsKey(Attributes.SubItem.UnitPrice))
                Messages.Add(Attributes.SubItem.UnitPrice, String.Empty);
        }

        public static void FillErrorMessages(IDictionary<Attributes.Item, String> Messages)
        {
            if (!Messages.ContainsKey(Attributes.Item.RequirementNumber))
                Messages.Add(Attributes.Item.RequirementNumber, String.Empty);

            if (!Messages.ContainsKey(Attributes.Item.ItemNumber))
                Messages.Add(Attributes.Item.ItemNumber, String.Empty);

            if (!Messages.ContainsKey(Attributes.Item.Description))
                Messages.Add(Attributes.Item.Description, String.Empty);
        }

        public static void FillErrorMessages(IDictionary<Attributes.SheetItem, String> Messages)
        {
            if (!Messages.ContainsKey(Attributes.SheetItem.PartialQuantity))
                Messages.Add(Attributes.SheetItem.PartialQuantity, String.Empty);

            if (!Messages.ContainsKey(Attributes.SheetItem.PercentQuantity))
                Messages.Add(Attributes.SheetItem.PercentQuantity, String.Empty);
        }

        public static void FillErrorMessages(IDictionary<Attributes.Requirement, String> Messages)
        {
            if (!Messages.ContainsKey(Attributes.Requirement.RequirementNumber))
                Messages.Add(Attributes.Requirement.RequirementNumber, String.Empty);

            if (!Messages.ContainsKey(Attributes.Requirement.PurchaseOrder))
                Messages.Add(Attributes.Requirement.PurchaseOrder, String.Empty);

            if (!Messages.ContainsKey(Attributes.Requirement.PurchaseOrderExcercise))
                Messages.Add(Attributes.Requirement.PurchaseOrderExcercise, String.Empty);

            if (!Messages.ContainsKey(Attributes.Requirement.Provider))
                Messages.Add(Attributes.Requirement.Provider, String.Empty);

            if (!Messages.ContainsKey(Attributes.Requirement.CertificationDays))
                Messages.Add(Attributes.Requirement.CertificationDays, String.Empty);
        }
    }
}
