﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ISheetStateService
    {
        SheetState GetSheetStateByRequirementNumberAndSheetNumber(int RequirementNumber, int SheetNumber);
        IEnumerable<SheetState> GetSheetStates();
        SheetState GetSheetStateById(int SheetStateId);
    }
}
