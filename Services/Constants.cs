using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Constants
    {

        internal static String MaxItemDescriptionLengthParameter = "maxItemDescriptionLength";
        internal static String MinItemDescriptionLengthParameter = "minItemDescriptionLength";
        internal static String MaxUnitOfMeasurementLengthParameter = "maxUnitOfMeasurementLength";
        internal static String MinUnitOfMeasurementLengthParameter = "minUnitOfMeasurementLength";
        internal static String MaxProviderDescriptionLengthParameter = "maxProviderDescriptionLength";
        internal static String MinProviderDescriptionLengthParameter = "minProviderDescriptionLength";
        internal static String MaxSubItemDescriptionLengthParameter = "maxSubItemDescriptionLength";
        internal static String MinSubItemDescriptionLengthParameter = "minSubItemDescriptionLength";
        internal static String MaxCertificationDaysParameter = "maxCertificationDays";
        internal static String MinCertificationDaysParameter = "minCertificationDays";
        internal static String MaxPurchaseOrderExcerciseParameter = "maxPurchaseOrderExcercise";
        internal static String MinPurchaseOrderExcerciseParameter = "minPurchaseOrderExcercise";
        internal static String MaxPurchaseOrderParameter = "maxPurchaseOrder";
        internal static String MinPurchaseOrderParameter = "minPurchaseOrder";
        internal static String MaxRequirementNumberParameter = "maxRequirementNumber";
        internal static String MinRequirementNumberParameter = "minRequirementNumber";
        internal static String MaxTotalQuantityParameter = "maxTotalQuantity";
        internal static String MinTotalQuantityParameter = "minTotalQuantity";
        internal static String MaxUnitPricecParameter = "maxUnitPrice";
        internal static String MiUnitPricecParameter = "minUnitPrice";
        internal static String WarningDaysBeforeExpirationParameter = "WarningDaysBeforeExpiration";
        internal static String NumberRangeFieldErrorMessage = "numberRangeField";
        internal static String TextRangeFieldErrorMessage = "textRangeField";
        internal static String AndRangeFieldMessage = "andRangeField";
        internal static String ExistingRequirementErrorMessage = "existingRequirement";
        internal static String EmptyFieldErrorMessage = "emptyField";
        internal static String TextRangeCharsErrorMessage = "textRangeFieldChars";
        internal static String NoActionAllowedErrorMessage = "noActionAllowed";
        internal static String FirstSheetStateIdParameter = "firstSheetStateId";
        internal static String FinalSheetStateIdParameter = "finalSheetStateId";

        //Actions
        public static int CreateRequirementAction = 1;
        public static int EditRequirementAction = 2;
        public static int RemoveRequirementAction = 3;
        public static int CreateItemAction = 4;
        public static int EditItemAction = 5;
        public static int RemoveItemAction = 6;
        public static int CreateSubItemAction = 7;
        public static int EditSubItemAction = 8;
        public static int RemoveSubItemAction = 9;
        public static int EditSheetItemAction = 10;
        public static int EnterSheetAction = 11;
        public static int ApproveSheetAction = 12;
        public static int ObserveSheetAction = 13;
        public static int RejectSheetAction = 14;
        public static int AssignUsersAction = 15;

        //Estados
        public static int PartialEnteredSheetStateId = 1;
        public static int EnteredSheetStateId = 2;
        public static int ApprovedSheetStateId = 3;
        public static int ObservedSheetStateId = 4;
        public static int RejectEnterSheetStateId = 5;

        public static int AdminRoleId = 1;
        public static int BuilderRoleId = 2;
        public static int SupervisorRoleId = 3;
        public static String CurrentUserCuitKey = "a";
    }
}
