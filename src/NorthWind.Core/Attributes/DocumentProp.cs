using System;

namespace NorthWind.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DocumentProp : Attribute
    {
        public string BookMarkName { get; set; }

        public DocumentProp(string bookMarkName)
        {
            BookMarkName = bookMarkName;
        }
    }
}