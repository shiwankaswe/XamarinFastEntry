namespace XamarinFastEntry.Behaviors
{
    public class XamarinMaxLength
    {
        public string ProcessLength(string entryText, string oldString, string newString, int? maxLength)
        {
            string output = entryText;

            if (oldString == null) return output;
            if (newString.Length <= oldString.Length) return output;

            string hil = "";
            if (oldString.Length > 0)
                hil = entryText.Remove(0, entryText.Length - 1);
            else
                hil = newString;

            // if Entry text is longer than valid length
            if (!(entryText.Length > maxLength)) return output;

            entryText = entryText.Remove(entryText.Length - 1); // remove last char

            output = entryText;

            return output;
        }
    }
}
