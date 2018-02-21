using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinFastEntrySample.FastEntry
{
    public class XamarinFastEntryBehaviour : Behavior<Entry>
    {
        public int? MaxLength { get; set; }
        public string Mask { get; set; }
        public bool? IsNumeric { get; set; }
        public bool? IsAmount { get; set; }
        public bool? IsNumericWithSpace { get; set; }

        XamarinMaxLength xamarinMaxLength;
        XamarinIsNumeric xamarinIsNumeric;
        XamarinIsAmount xamarinIsAmount;
        XamarinMask xamarinMask;
        XamarinIsNumericWithSpace _xamarinIsNumericWithSpace;

        public XamarinFastEntryBehaviour()
        {
            xamarinMaxLength = new XamarinMaxLength();
            xamarinIsNumeric = new XamarinIsNumeric();
            xamarinIsAmount = new XamarinIsAmount();
            xamarinMask = new XamarinMask();
            _xamarinIsNumericWithSpace = new XamarinIsNumericWithSpace();
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
                if (output != entryText)
                {
                    entryText = output;
                    entry.Text = entryText;
                    return;
                }
            }

            if (IsNumeric != null && IsNumeric == true && entryText.Length > 0)
            {
                var output = xamarinIsNumeric.ProcessIsNumeric(entryText, oldString, newString);
                if (output != entryText)
                {
                    entryText = output;
                    entry.Text = entryText;
                    return;
                }
            }

            if (IsAmount != null && IsAmount == true && entryText.Length > 0)
            {
                var output = xamarinIsAmount.ProcessIsAmount(entryText, oldString, newString);
                if (output != entryText)
                {
                    entryText = output;
                    entry.Text = entryText;
                    return;
                }
            }

            if (IsNumericWithSpace != null && IsNumericWithSpace == true && entryText.Length > 0)
            {
                var output = _xamarinIsNumericWithSpace.ProcessIsNumericWithSpace(entryText, oldString, newString);
                if (output != entryText)
                {
                    entryText = output;
                    entry.Text = entryText;
                    return;
                }
            }

            if (Mask != null && Mask.Length > 0 && entryText.Length > 0)
            {
                var output = xamarinMask.ProcessMask(entryText, oldString, newString, Mask);
                if (output != entryText)
                {
                    entryText = output;
                    entry.Text = entryText;
                    return;
                }
            }
            entry.Text = entryText;
        }
    }
}
