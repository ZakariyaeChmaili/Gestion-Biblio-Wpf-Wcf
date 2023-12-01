using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for ITestService
/// </summary>
/// 
[ServiceContract]
public interface ITestService
{
     string test();
}