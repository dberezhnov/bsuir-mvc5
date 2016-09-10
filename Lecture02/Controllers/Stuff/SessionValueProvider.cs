using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers.Stuff
{
    public class SessionValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix) => HttpContext.Current.Session[prefix] != null;

        public ValueProviderResult GetValue(string key) => new ValueProviderResult(
            HttpContext.Current.Session[key],
            HttpContext.Current.Session[key].ToString(),
            System.Globalization.CultureInfo.CurrentCulture
        );
    }

    public class SessionValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext) =>
            new SessionValueProvider();
    }
}