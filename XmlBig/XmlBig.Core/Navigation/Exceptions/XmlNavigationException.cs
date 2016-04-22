using System;

namespace XmlBig.Core.Navigation.Exceptions
{

    public class XmlNavigationException : Exception
    {
        #region .ctor

        public XmlNavigationException(string errorDescription) : base(errorDescription)
        {
        }

        #endregion
    }
}
