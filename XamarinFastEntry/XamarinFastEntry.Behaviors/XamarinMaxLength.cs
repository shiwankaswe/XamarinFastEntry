using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFastEntrySample.FastEntry
{
    public class XamarinMaxLength
    {
        public string ProcessLength(string entryText, string oldString, string newString, int? maxLength)
        {
            string output = entryText;

            if (oldString != null)
            {
                if (newString.Length > oldString.Length)
                {
                    string hil = "";
                    if (oldString.Length > 0)
                        hil = entryText.Remove(0, entryText.Length - 1);
                    else
                        hil = newString;

                    // if Entry text is longer then valid length
                    if (entryText.Length > maxLength)
                    {
                        entryText = entryText.Remove(entryText.Length - 1); // remove last char

                        output = entryText;
                    }
                }
            }

            return output;
        }
    }
}
