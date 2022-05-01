using System;

namespace NorthWind.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DocumentProp : Attribute
    {
        public DocumentProp(string bookMarkName)
        {
            BookMarkName = bookMarkName;
        }

        public string BookMarkName { get; set; }
    }
}