using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFastEntrySample.FastEntry
{
    public class XamarinIsNumericWithSpace
    {
        public string ProcessIsNumericWithSpace(string entryText, string oldString, string newString)
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

                    double Num;
                    bool isNum = double.TryParse(hil, out Num);
                    if (!isNum && hil != " ")
                    {
                        entryText = entryText.Remove(entryText.Length - 1); // remove last char
                        output = entryText;
                    }
                    else if (hil == " ")
                    {
                        if (oldString.Contains(" "))
                        {
                            entryText = entryText.Remove(entryText.Length - 1); // remove last char
                            output = entryText;
                        }
                    }
                }
                else
                {
                    string hil = entryText.Substring(entryText.Length - 1, 1);
                    double Num;
                    bool isNum = double.TryParse(hil, out Num);
                    if (!isNum && hil != " ")
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
