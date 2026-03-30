using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace PKHeX_Raid_Plugin
{
    public class ValidIPChangedEventArgs : EventArgs
    {
        public bool IsValid { get; }
        public string ValidatedText { get; }
        public IPAddress? ParsedAddress { get; }

        public ValidIPChangedEventArgs(bool isValid, string validatedText, IPAddress? parsedAddress)
        {
            IsValid = isValid;
            ValidatedText = validatedText;
            ParsedAddress = parsedAddress;
        }
    }
    /// <summary>
    /// A TextBox for IPv4 input with live validation, and visual feedback for invalid entries.
    /// </summary>
    public class IPTextBox : TextBox
    {

        /// <summary>
        /// Occurs when the validity of the IP address changes.
        /// </summary>
        /// <remarks>This event is raised whenever the state of the IP address validity is updated. 
        /// Subscribers can use this event to respond to changes in the validity of the IP address.
        /// </remarks>       
        public event EventHandler<ValidIPChangedEventArgs> ValidIPChanged;

        private bool _isValid;
        /// <summary>
        /// Gets whether the current text is a valid IPv4 address.
        /// </summary>
        [Browsable(false)]
        public bool IsValid
        {
            get => _isValid;
            private set
            {
                if (_isValid != value)
                {
                    _isValid = value;
                }
            }
        }

        private Color _validationBackColor = Color.MistyRose;
        /// <summary>
        /// The background color used when the IP address is invalid.
        /// </summary>
        [Category("Behavior")]
        [Description("The background color used when the IP address is invalid.")]
        [DefaultValue(typeof(Color), "MistyRose")]
        public Color ValidationBackColor
        {
            get => _validationBackColor;
            set => _validationBackColor = value;
        }

        public IPTextBox()
        {
            BackColor = SystemColors.Window;
            MaxLength = 15;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            var result = TryParseIP(this.Text);
            this.BackColor = result.IsValid ? SystemColors.Window : _validationBackColor;

            if (result.IsValid)
                OnValidIPChanged(new ValidIPChangedEventArgs(true, result.TrimmedText, result.ParsedAddress));   

            base.OnTextChanged(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // Allow control keys (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                base.OnKeyPress(e);
                return;
            }

            // Allow digits and dot (for IP address)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            base.OnKeyPress(e);
        }

        private static (bool IsValid, string TrimmedText, IPAddress? ParsedAddress) TryParseIP(string input)
        {
            string trimmed = input?.Trim() ?? string.Empty;

            if (trimmed.Length <7 || trimmed.Length > 15)
                return (false, trimmed, null);

            if (IPAddress.TryParse(trimmed, out var address) &&
                address.AddressFamily == AddressFamily.InterNetwork)
            {
                return (true, trimmed, address);
            }

            return (false, trimmed, null);
        }

        protected virtual void OnValidIPChanged(ValidIPChangedEventArgs e)
        {
            ValidIPChanged?.Invoke(this, e);
        }
    }
}
