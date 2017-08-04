using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Constants
{
    public class Constants
    {
        public static int AdminRoleId = 1;
        public static int BuilderRoleId = 2;
        public static int SupervisorRoleId = 3;
        public static String CurrentUserCuitKey = "a";

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
    }
}