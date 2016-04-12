using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BusinessLogic.Layer.ManagerObjects;
using BusinessLogic.Layer.BusinessObjects;

namespace BusinessLogic.Layer.Base
{
    public class UnitTestbase
    {
        protected IManagerFactory managerFactory = new ManagerFactory();
    }
}