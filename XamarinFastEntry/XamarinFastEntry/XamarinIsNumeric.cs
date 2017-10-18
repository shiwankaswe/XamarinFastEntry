using System;
namespace XamarinFastEntry
{
    public class XamarinIsNumeric
    {
        public string ProcessIsNumeric(string entryText, string oldString, string newString)
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
                    if (!isNum)
                    {
                        entryText = entryText.Remove(entryText.Length - 1); // remove last char
                        output = entryText;
                    }
                }else
                {
                    string hil = entryText;
                    double Num;
                    bool isNum = double.TryParse(hil, out Num);
                    if (!isNum)
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
