using System;
using System.DHTML;

namespace ClientLibrary
{
    public delegate bool AttributeComparer(string a, string b);

    public static class Utils
    {
        public static Array GetElementsByAttribute(DOMElement parent, string tagName, string attributeName, string attributeValue, AttributeComparer comparer)
        {
            Array result = new Array();
            int currentResultIndex = 0;
            if (parent == null)
                parent = Document.DocumentElement;
            if (tagName == null)
                tagName = "*";
            DOMElementCollection startElements = parent.GetElementsByTagName(tagName);
            for (int i = 0; i < startElements.Length; i++)
            {
                DOMElement current = startElements[i];
                object attribute = current.GetAttribute(attributeName);
                if (attribute != null)
                {
                    bool attributesEqual = false;
                    if (comparer != null)
                    {
                        attributesEqual = comparer(attribute.ToString(), attributeValue);
                    }
                    else
                    {
                        attributesEqual = (attribute.ToString() == attributeValue);
                    }

                    if (attributesEqual)
                    {
                        result[currentResultIndex] = current;
                        currentResultIndex++;
                    }
                }
            }
            return result;
        }
    }
}
