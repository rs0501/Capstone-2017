﻿using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    interface IEmployeeManager
    {
        Employee RetrieveEmployeeByUserName(string userName);
    }
}
