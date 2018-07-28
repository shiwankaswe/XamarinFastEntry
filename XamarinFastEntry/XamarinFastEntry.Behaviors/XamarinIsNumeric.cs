namespace XamarinFastEntry.Behaviors
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
                    string hil;
                    if (oldString.Length > 0)
                        hil = entryText.Remove(0, entryText.Length - 1);
                    else
                        hil = newString;

                    bool isNum = double.TryParse(hil, out _);
                    if (isNum) return output;
                    entryText = entryText.Remove(entryText.Length - 1); // remove last char
                    output = entryText;
                }
                else
                {
                    string hil = entryText;

                    bool isNum = double.TryParse(hil, out _);
                    if (isNum) return output;
                    entryText = entryText.Remove(entryText.Length - 1); // remove last char
                    output = entryText;
                }
            }
            else
            {
                string hil = entryText;
                bool isNum = double.TryParse(hil, out _);

                if (isNum) return output;
                entryText = entryText.Remove(entryText.Length - 1); // remove last char
                output = entryText;
            }


            return output;
        }
    }
}
