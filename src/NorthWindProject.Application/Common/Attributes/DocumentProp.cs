using System;

namespace NorthWindProject.Application.Common.Attributes
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