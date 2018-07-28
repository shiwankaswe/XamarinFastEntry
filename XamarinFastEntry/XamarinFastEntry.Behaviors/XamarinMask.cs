namespace XamarinFastEntry.Behaviors
{
    public class XamarinMask
    {
        public string ProcessMask(string entryText, string oldString, string newString, string mask)
        {
            string output = entryText;

            if (oldString == null) return output;
            if (!returnCheck(oldString, mask)) return output;
            if (newString.Length <= oldString.Length) return output;

            if (mask.Length >= newString.Length)
            {
                var ln = entryText.Length - 1;
                var st = mask.Substring(ln, 1);
                string newstr;

                if (oldString.Length > 0)
                    newstr = newString.Substring(newString.Length - 1);
                else
                    newstr = newString;

                if (output.Length > 1)
                    output = output.Remove(output.Length - 1, 1);
                else
                    output = "";

                if (st == "#")
                {
                    output = output + newstr;
                }
                else
                {
                    foreach (var s in mask.Substring(ln))
                    {
                        if (s == '#')
                        {
                            output = output + newstr;
                            break;
                        }

                        output = output + s;
                    }
                }
            }
            else
            {
                output = oldString;
            }

            return output;
        }


        private bool returnCheck(string oldValue, string mask)
        {

            int i = 0;
            if (mask.Length < oldValue.Length)
            {
                return false;
            }

            foreach (var s in mask.Substring(0, oldValue.Length))
            {
                if (s.ToString() != "#" && s.ToString() != oldValue.Substring(i, 1))
                {
                    return false;
                }
                i++;
            }
            return true;
        }

    }
}
