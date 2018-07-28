using System;
using Xamarin.Forms;

namespace XamarinFastEntry.Behaviors
{
    public class XamarinFastEntryBehaviour : Behavior<Entry>
    {
        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(XamarinFastEntryBehaviour), defaultValue: int.MaxValue);

        public static readonly BindableProperty IsNumericProperty =
            BindableProperty.Create(nameof(IsNumeric), typeof(bool), typeof(XamarinFastEntryBehaviour), defaultValue: default(bool));

        public static readonly BindableProperty MaskProperty = BindableProperty.Create(nameof(Mask), typeof(string),
            typeof(XamarinFastEntryBehaviour), defaultValue: string.Empty);

        public static readonly BindableProperty IsAmountProperty = BindableProperty.Create(nameof(IsAmount),
            typeof(bool), typeof(XamarinFastEntryBehaviour), defaultValue: default(bool));

        public static readonly BindableProperty IsNumericWithSpaceProperty = BindableProperty.Create(nameof(IsNumericWithSpace),
            typeof(bool), typeof(XamarinFastEntryBehaviour), defaultValue: default(bool));

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        public string Mask
        {
            get => (string)GetValue(MaskProperty);
            set => SetValue(MaskProperty, value);
        }

        public bool IsNumeric
        {
            get => (bool)GetValue(IsNumericProperty);
            set => SetValue(IsNumericProperty, value);
        }

        public bool IsAmount
        {
            get => (bool)GetValue(IsAmountProperty);
            set => SetValue(IsAmountProperty, value);
        }

        public Entry AssociatedObject { get; private set; }

        public bool IsNumericWithSpace
        {
            get => (bool)GetValue(IsNumericWithSpaceProperty);
            set => SetValue(IsNumericWithSpaceProperty, value);
        }

        private readonly XamarinMaxLength _xamarinMaxLength;
        private readonly XamarinIsNumeric _xamarinIsNumeric;
        private readonly XamarinIsAmount _xamarinIsAmount;
        private readonly XamarinMask _xamarinMask;
        private readonly XamarinIsNumericWithSpace _xamarinIsNumericWithSpace;

        public XamarinFastEntryBehaviour()
        {
            _xamarinMaxLength = new XamarinMaxLength();
            _xamarinIsNumeric = new XamarinIsNumeric();
            _xamarinIsAmount = new XamarinIsAmount();
            _xamarinMask = new XamarinMask();
            _xamarinIsNumericWithSpace = new XamarinIsNumericWithSpace();
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            AssociatedObject = bindable;
            AssociatedObject.BindingContextChanged += OnBindingContextChanged;
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            AssociatedObject.BindingContextChanged -= OnBindingContextChanged;
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;
            var oldString = args.OldTextValue;
            var newString = args.NewTextValue;
            string entryText = entry.Text;

            if (MaxLength >= 0 && entryText.Length > 0)
            {
                var output = _xamarinMaxLength.ProcessLength(entryText, oldString, newString, MaxLength);
                if (output != entryText)
                {
                    entryText = output;
                    entry.Text = entryText;
                    return;
                }
            }

            if (IsNumeric && entryText.Length > 0)
            {
                var output = _xamarinIsNumeric.ProcessIsNumeric(entryText, oldString, newString);
                if (output != entryText)
                {
                    entryText = output;
                    entry.Text = entryText;
                    return;
                }
            }

            if (IsAmount && entryText.Length > 0)
            {
                var output = _xamarinIsAmount.ProcessIsAmount(entryText, oldString, newString);
                if (output != entryText)
                {
                    entryText = output;
                    entry.Text = entryText;
                    return;
                }
            }

            if (IsNumericWithSpace && entryText.Length > 0)
            {
                var output = _xamarinIsNumericWithSpace.ProcessIsNumericWithSpace(entryText, oldString, newString);
                if (output != entryText)
                {
                    entryText = output;
                    entry.Text = entryText;
                    return;
                }
            }

            if (!string.IsNullOrEmpty(Mask) && entryText.Length > 0)
            {
                var output = _xamarinMask.ProcessMask(entryText, oldString, newString, Mask);
                if (output != entryText)
                {
                    entryText = output;
                    entry.Text = entryText;
                    return;
                }
            }
            entry.Text = entryText;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}
