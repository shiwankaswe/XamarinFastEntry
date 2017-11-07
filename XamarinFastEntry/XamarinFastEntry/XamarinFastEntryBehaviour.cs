using System;
using Xamarin.Forms;

namespace XamarinFastEntry
{
    public class XamarinFastEntryBehaviour : Behavior<Entry>
    {
        public int? MaxLength { get; set; }
        public string Mask { get; set; }
        public bool? IsNumeric { get; set; }
        public bool? IsAmount { get; set; }

        XamarinMaxLength xamarinMaxLength;
        XamarinIsNumeric xamarinIsNumeric;
        XamarinIsAmount xamarinIsAmount;
        XamarinMask xamarinMask;

        public XamarinFastEntryBehaviour()
        {
            xamarinMaxLength = new XamarinMaxLength();
            xamarinIsNumeric = new XamarinIsNumeric();
            xamarinIsAmount = new XamarinIsAmount();
            xamarinMask = new XamarinMask();
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;
            var oldString = args.OldTextValue;
            var newString = args.NewTextValue;
            string entryText = entry.Text;

            if (MaxLength != null && MaxLength >= 0 && entryText.Length > 0)
            {
                var output = xamarinMaxLength.ProcessLength(entryText, oldString, newString, MaxLength);
                entryText = output;
            }

            if (IsNumeric != null && IsNumeric == true && entryText.Length > 0)
            {
                var output = xamarinIsNumeric.ProcessIsNumeric(entryText, oldString, newString);
                entryText = output;
            }

            if (IsAmount != null && IsAmount == true && entryText.Length > 0)
            {
                var output = xamarinIsAmount.ProcessIsAmount(entryText, oldString, newString);
                entryText = output;
            }

            if (Mask != null && Mask.Length > 0 && entryText.Length > 0)
            {
                var output = xamarinMask.ProcessMask(entryText, oldString, newString, Mask);
                entryText = output;

            }

            entry.Text = entryText;

        }
    }
}
