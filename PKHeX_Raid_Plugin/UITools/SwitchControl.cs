using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PKHeX_Raid_Plugin
{
    /// <summary>
    /// A custom switch control that toggles between two states (Left/Right) with optional animation.
    /// </summary>
    public class SwitchControl : Control
    {
        /// <summary>
        /// Occurs when the switch state is toggled.
        /// </summary>
        public event EventHandler<ToggledEventArgs> Toggled;

        private bool _animationEnabled = true;

        /// <summary>
        /// Gets or sets whether the thumb animates when toggling.
        /// </summary>
        [Category("Behavior")]
        [Description("Enables or disables the thumb animation.")]
        [DefaultValue(typeof(bool), "false")]
        public bool AnimationEnabled
        {
            get => _animationEnabled;
            set => _animationEnabled = value;
        }

        /// <summary>
        /// Gets or sets the color of the switch when in the 'On' position.
        /// </summary>
        [Category("Appearance")]
        [Description("The color of the switch when in the 'On' position.")]
        [DefaultValue(typeof(Color), "MediumSeaGreen")]
        public Color OnColor { get; set; } = Color.MediumSeaGreen;



        /// <summary>
        /// Gets or sets the color of the switch when in the 'Off' position.
        /// </summary>
        [Category("Appearance")]
        [Description("The color of the switch when in the 'Off' position.")]
        [DefaultValue(typeof(Color), "LightGray")]
        public Color OffColor { get; set; } = Color.LightGray;

        /// <summary>
        /// Gets or sets the color of the thumb.
        /// </summary>
        [Category("Appearance")]
        [Description("The color of the thumb.")]
        [DefaultValue(typeof(Color), "White")]
        public Color ThumbColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the color of the thumb border.
        /// </summary>
        [Category("Appearance")]
        [Description("The color of the thum border.")]
        [DefaultValue(typeof(Color), "Gray")]
        public Color ThumbBorderColor { get; set; } = Color.Gray;

        /// <summary>
        /// Represents the state of the switch.
        /// </summary>
        public enum SwitchState
        {
            Left,
            Right
        }

        private SwitchState _state = SwitchState.Left;

        /// <summary>
        /// Gets or sets the current state of the switch.
        /// </summary>
        [Category("Behavior")]
        [Description("The current state of the switch.")]
        [TypeConverter(typeof(EnumConverter))]
        [DefaultValue(SwitchState.Left)]
        public SwitchState State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;
                    Toggled?.Invoke(this, new ToggledEventArgs(_state));
                    StartAnimation();
                }
            }
        }

        private float _thumbPosition = 0f;
        private readonly Timer _animationTimer;
        private const float AnimationStep = 0.1f;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchControl"/> class.
        /// </summary>
        public SwitchControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            TabStop = true;
            _thumbPosition = _state == SwitchState.Right ? 1f : 0f;
            _animationTimer = new Timer();
            _animationTimer.Interval = 15;
            _animationTimer.Tick += AnimateThumb;
            MinimumSize = new Size(32, 18);
            Text = "";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int minHeight = Math.Max(Height, MinimumSize.Height);
            int minWidth = Math.Max(Width, MinimumSize.Width);

            var thumbDiameter = minHeight - 6;
            int margin = 1;
            var bounds = ClientRectangle;
            var trackRect = new Rectangle(bounds.X, bounds.Height / 4, bounds.Width - margin, bounds.Height / 2);
            int trackLength = minWidth - thumbDiameter;
            int thumbX = (int)((ClientRectangle.Width - thumbDiameter - 1) * _thumbPosition);

            Color trackColor = State == SwitchState.Right ? OnColor : OffColor;
            Color thumbColor = ThumbColor;

            if (!Enabled)
            {
                trackColor = ControlPaint.Light(trackColor, 0.5f);
                thumbColor = ControlPaint.Light(thumbColor, 0.5f);
            }

            using var trackBrush = new SolidBrush(trackColor);
            using var thumbBrush = new SolidBrush(thumbColor);
            using var path = new GraphicsPath();
            path.AddArc(trackRect.Left, trackRect.Top, trackRect.Height, trackRect.Height, 90, 180);
            path.AddArc(trackRect.Right - trackRect.Height, trackRect.Top, trackRect.Height, trackRect.Height, 270, 180);
            path.CloseFigure();

            var shadowOffset = 1;
            var shadowPath = new GraphicsPath();
            shadowPath.AddArc(trackRect.Left + shadowOffset, trackRect.Top + shadowOffset, trackRect.Height, trackRect.Height, 90, 180);
            shadowPath.AddArc(trackRect.Right - trackRect.Height + shadowOffset, trackRect.Top + shadowOffset, trackRect.Height, trackRect.Height, 270, 180);
            shadowPath.CloseFigure();
            using var shadowBrush = new SolidBrush(Color.FromArgb(40, Color.Black));
            g.FillPath(shadowBrush, shadowPath);

            g.FillPath(trackBrush, path);
            g.FillEllipse(thumbBrush, new Rectangle(thumbX, 2, thumbDiameter, thumbDiameter));
            using var thumbBorderPen = new Pen(ThumbBorderColor, 1);
            g.DrawEllipse(thumbBorderPen, new Rectangle(thumbX, 2, thumbDiameter, thumbDiameter));

            if (Focused && Enabled)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, ClientRectangle);
            }
        }

        // Prevent interaction when disabled
        /// <inheritdoc/>
        protected override void OnClick(EventArgs e)
        {
            if (!Enabled)
                return;
            base.OnClick(e);
            State = State == SwitchState.Right ? SwitchState.Left : SwitchState.Right;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!Enabled)
                return;
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                State = State == SwitchState.Right ? SwitchState.Left : SwitchState.Right;
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Provides data for the <see cref="SwitchControl.Toggled"/> event.
        /// </summary>
        public class ToggledEventArgs : EventArgs
        {
            /// <summary>
            /// Gets the new state of the switch.
            /// </summary>
            public SwitchState State { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ToggledEventArgs"/> class.
            /// </summary>
            /// <param name="state">The new state.</param>
            public ToggledEventArgs(SwitchState state)
            {
                State = state;
            }

            /// <summary>
            /// Gets a value indicating whether the switch is in the right position.
            /// </summary>
            public bool IsRight => State == SwitchState.Right;
            /// <summary>
            /// Gets a value indicating whether the switch is in the left position.
            /// </summary>
            public bool IsLeft => State == SwitchState.Left;
        }

        private void AnimateThumb(object? sender, EventArgs e)
        {
            float target = State == SwitchState.Right ? 1f : 0f;

            if (Math.Abs(_thumbPosition - target) < AnimationStep)
            {
                _thumbPosition = target;
                _animationTimer.Stop();
            }
            else
            {
                _thumbPosition += (State == SwitchState.Right ? AnimationStep : -AnimationStep);
                _thumbPosition = Math.Max(0f, Math.Min(1f, _thumbPosition));
            }
            Invalidate();
        }

        private void StartAnimation()
        {
            if (AnimationEnabled)
                _animationTimer.Start();
            else
            {
                _thumbPosition = State == SwitchState.Right ? 1f : 0f;
                Invalidate();
            }
        }

        /// <inheritdoc/>
        protected override bool IsInputKey(Keys keyData) => keyData == Keys.Space || base.IsInputKey(keyData);

        /// <inheritdoc/>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        /// <inheritdoc/>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
             _animationTimer?.Dispose();

            base.Dispose(disposing);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }
    }
}
