namespace XamarinFastEntry.Behaviors
{
    public class XamarinIsNumericWithSpace
    {
        public string ProcessIsNumericWithSpace(string entryText, string oldString, string newString)
        {
            string output = entryText;

            if (oldString == null) return output;

            if (newString.Length > oldString.Length)
            {
                string hil = "";
                if (oldString.Length > 0)
                    hil = entryText.Remove(0, entryText.Length - 1);
                else
                    hil = newString;

                bool isNum = double.TryParse(hil, out _);
                if (!isNum && hil != " ")
                {
                    entryText = entryText.Remove(entryText.Length - 1); // remove last char
                    output = entryText;
                }
                else switch (hil)
                {
                    case " " when !oldString.Contains(" "):
                        return output;
                    case " ":
                        entryText = entryText.Remove(entryText.Length - 1); // remove last char
                        output = entryText;
                        break;
                }
            }
            else
            {
                string hil = entryText.Substring(entryText.Length - 1, 1);

                bool isNum = double.TryParse(hil, out _);
                if (isNum || hil == " ") return output;

                entryText = entryText.Remove(entryText.Length - 1); // remove last char
                output = entryText;
            }


            return output;
        }
    }
}
