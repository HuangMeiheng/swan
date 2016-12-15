﻿using System;
using System.Collections.Generic;
using Unosquare.Swan.Formatters;
using Unosquare.Swan.Reflection;
using Unosquare.Swan.Test.Mocks;

namespace Unosquare.Swan.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region basic obj

            var basicObj = new BasicJson { StringData = "string", IntData = 1, NegativeInt = -1, DecimalData = 10.33M, BoolData = true };
            var basicStr = "{\"StringData\" : \"string\", \"IntData\" : 1, \"NegativeInt\" : -1, \"DecimalData\" : 10.33, \"BoolData\" : true, \"StringNull\" : null}";

            var data = JsonFormatter.Serialize(basicObj);
            data.Info();

            if (data == basicStr) "Ok serialize".Info(); else "Error serialize".Error();

            var obj = JsonFormatter.Deserialize<BasicJson>(basicStr);

            if (obj.StringData == basicObj.StringData) "Ok string".Info(); else "Error string".Error();

            if (obj.IntData == basicObj.IntData) "Ok int".Info(); else "Error int".Error();

            if (obj.NegativeInt == basicObj.NegativeInt) "Ok neg int".Info(); else "Error neg int".Error();

            if (obj.BoolData == basicObj.BoolData) "Ok bool".Info(); else "Error bool".Error();

            if (obj.DecimalData == basicObj.DecimalData) "Ok decimal".Info(); else "Error decimal".Error();

            if (obj.StringNull == basicObj.StringNull) "Ok null".Info(); else "Error null".Error();

            #endregion

            #region basic array

            var basicArray = new[] { "One", "Two", "Three" };
            var basicAStr = "[\"One\",\"Two\",\"Three\"]";
            var dataArr = JsonFormatter.Serialize(basicArray);
            dataArr.Info();

            if (dataArr == basicAStr) "Ok serialize".Info(); else "Error serialize".Error();

            var arr = JsonFormatter.Deserialize<List<string>>(basicAStr);

            if (string.Join(",", basicArray) == string.Join(",", arr)) "Ok array".Info(); else "Error array".Error();

            #endregion

            #region basic obj with array

            var arrObj = new BasicArrayJson { Id = 1, Properties = new[] { "One", "Two", "Babu" } };

            var dataArrObj = JsonFormatter.Serialize(arrObj);
            dataArrObj.Info();

            var basicArrObj = JsonFormatter.Deserialize<BasicArrayJson>(dataArrObj);

            #endregion

            var arrayOfObj = new List<ExtendedPropertyInfo>
        {
            new ExtendedPropertyInfo<AppSettingMock>(nameof(AppSettingMock.WebServerPort)),
            new ExtendedPropertyInfo<AppSettingMock>(nameof(AppSettingMock.WebServerHostname))
        };

            var arrayOfObjData = JsonFormatter.Serialize(arrayOfObj);
            arrayOfObjData.Info();

            Console.ReadLine();
        }
    }
}