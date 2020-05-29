namespace VVPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControlMain = new OpenTK.GLControl();
            this.nUDHorizontal = new System.Windows.Forms.NumericUpDown();
            this.nUDVertical = new System.Windows.Forms.NumericUpDown();
            this.chkInvertMouseWheel = new System.Windows.Forms.CheckBox();
            this.grpMouseWheelSensitivity = new System.Windows.Forms.GroupBox();
            this.rbHighSensitivityWheel = new System.Windows.Forms.RadioButton();
            this.rbLowSensitivityWheel = new System.Windows.Forms.RadioButton();
            this.rbMediumSensitivityWheel = new System.Windows.Forms.RadioButton();
            this.chkInvertMouse = new System.Windows.Forms.CheckBox();
            this.grpMouseOptions = new System.Windows.Forms.GroupBox();
            this.rbHighSensitivity = new System.Windows.Forms.RadioButton();
            this.rbMediumSensitivity = new System.Windows.Forms.RadioButton();
            this.rbLowSensitivity = new System.Windows.Forms.RadioButton();
            this.btnResetView = new System.Windows.Forms.Button();
            this.lblHorizontal = new System.Windows.Forms.Label();
            this.lblVertical = new System.Windows.Forms.Label();
            this.grpAutoRotate = new System.Windows.Forms.GroupBox();
            this.rbARHighSpeed = new System.Windows.Forms.RadioButton();
            this.chkAutoRotate = new System.Windows.Forms.CheckBox();
            this.rbARLowSpeed = new System.Windows.Forms.RadioButton();
            this.rbARMediumSpeed = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVertical)).BeginInit();
            this.grpMouseWheelSensitivity.SuspendLayout();
            this.grpMouseOptions.SuspendLayout();
            this.grpAutoRotate.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControlMain
            // 
            this.glControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControlMain.BackColor = System.Drawing.Color.Black;
            this.glControlMain.Location = new System.Drawing.Point(12, 12);
            this.glControlMain.Name = "glControlMain";
            this.glControlMain.Size = new System.Drawing.Size(705, 448);
            this.glControlMain.TabIndex = 1;
            this.glControlMain.VSync = false;
            // 
            // nUDHorizontal
            // 
            this.nUDHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nUDHorizontal.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDHorizontal.Location = new System.Drawing.Point(788, 420);
            this.nUDHorizontal.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nUDHorizontal.Name = "nUDHorizontal";
            this.nUDHorizontal.Size = new System.Drawing.Size(76, 20);
            this.nUDHorizontal.TabIndex = 2;
            // 
            // nUDVertical
            // 
            this.nUDVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nUDVertical.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDVertical.Location = new System.Drawing.Point(788, 446);
            this.nUDVertical.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nUDVertical.Name = "nUDVertical";
            this.nUDVertical.Size = new System.Drawing.Size(76, 20);
            this.nUDVertical.TabIndex = 2;
            // 
            // chkInvertMouseWheel
            // 
            this.chkInvertMouseWheel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInvertMouseWheel.AutoSize = true;
            this.chkInvertMouseWheel.Location = new System.Drawing.Point(6, 19);
            this.chkInvertMouseWheel.Name = "chkInvertMouseWheel";
            this.chkInvertMouseWheel.Size = new System.Drawing.Size(122, 17);
            this.chkInvertMouseWheel.TabIndex = 3;
            this.chkInvertMouseWheel.Text = "Invert Mouse Wheel";
            this.chkInvertMouseWheel.UseVisualStyleBackColor = true;
            // 
            // grpMouseWheelSensitivity
            // 
            this.grpMouseWheelSensitivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMouseWheelSensitivity.Controls.Add(this.rbHighSensitivityWheel);
            this.grpMouseWheelSensitivity.Controls.Add(this.chkInvertMouseWheel);
            this.grpMouseWheelSensitivity.Controls.Add(this.rbLowSensitivityWheel);
            this.grpMouseWheelSensitivity.Controls.Add(this.rbMediumSensitivityWheel);
            this.grpMouseWheelSensitivity.Location = new System.Drawing.Point(723, 138);
            this.grpMouseWheelSensitivity.Name = "grpMouseWheelSensitivity";
            this.grpMouseWheelSensitivity.Size = new System.Drawing.Size(141, 120);
            this.grpMouseWheelSensitivity.TabIndex = 4;
            this.grpMouseWheelSensitivity.TabStop = false;
            this.grpMouseWheelSensitivity.Text = "Mouse Wheel Options";
            // 
            // rbHighSensitivityWheel
            // 
            this.rbHighSensitivityWheel.AutoSize = true;
            this.rbHighSensitivityWheel.Location = new System.Drawing.Point(6, 88);
            this.rbHighSensitivityWheel.Name = "rbHighSensitivityWheel";
            this.rbHighSensitivityWheel.Size = new System.Drawing.Size(97, 17);
            this.rbHighSensitivityWheel.TabIndex = 0;
            this.rbHighSensitivityWheel.TabStop = true;
            this.rbHighSensitivityWheel.Text = "High Sensitivity";
            this.rbHighSensitivityWheel.UseVisualStyleBackColor = true;
            // 
            // rbLowSensitivityWheel
            // 
            this.rbLowSensitivityWheel.AutoSize = true;
            this.rbLowSensitivityWheel.Location = new System.Drawing.Point(6, 42);
            this.rbLowSensitivityWheel.Name = "rbLowSensitivityWheel";
            this.rbLowSensitivityWheel.Size = new System.Drawing.Size(95, 17);
            this.rbLowSensitivityWheel.TabIndex = 0;
            this.rbLowSensitivityWheel.TabStop = true;
            this.rbLowSensitivityWheel.Text = "Low Sensitivity";
            this.rbLowSensitivityWheel.UseVisualStyleBackColor = true;
            // 
            // rbMediumSensitivityWheel
            // 
            this.rbMediumSensitivityWheel.AutoSize = true;
            this.rbMediumSensitivityWheel.Location = new System.Drawing.Point(6, 65);
            this.rbMediumSensitivityWheel.Name = "rbMediumSensitivityWheel";
            this.rbMediumSensitivityWheel.Size = new System.Drawing.Size(112, 17);
            this.rbMediumSensitivityWheel.TabIndex = 0;
            this.rbMediumSensitivityWheel.TabStop = true;
            this.rbMediumSensitivityWheel.Text = "Medium Sensitivity";
            this.rbMediumSensitivityWheel.UseVisualStyleBackColor = true;
            // 
            // chkInvertMouse
            // 
            this.chkInvertMouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInvertMouse.AutoSize = true;
            this.chkInvertMouse.Location = new System.Drawing.Point(6, 19);
            this.chkInvertMouse.Name = "chkInvertMouse";
            this.chkInvertMouse.Size = new System.Drawing.Size(88, 17);
            this.chkInvertMouse.TabIndex = 3;
            this.chkInvertMouse.Text = "Invert Mouse";
            this.chkInvertMouse.UseVisualStyleBackColor = true;
            // 
            // grpMouseOptions
            // 
            this.grpMouseOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMouseOptions.Controls.Add(this.rbHighSensitivity);
            this.grpMouseOptions.Controls.Add(this.rbMediumSensitivity);
            this.grpMouseOptions.Controls.Add(this.chkInvertMouse);
            this.grpMouseOptions.Controls.Add(this.rbLowSensitivity);
            this.grpMouseOptions.Location = new System.Drawing.Point(723, 12);
            this.grpMouseOptions.Name = "grpMouseOptions";
            this.grpMouseOptions.Size = new System.Drawing.Size(141, 120);
            this.grpMouseOptions.TabIndex = 4;
            this.grpMouseOptions.TabStop = false;
            this.grpMouseOptions.Text = "Mouse Options";
            // 
            // rbHighSensitivity
            // 
            this.rbHighSensitivity.AutoSize = true;
            this.rbHighSensitivity.Location = new System.Drawing.Point(6, 88);
            this.rbHighSensitivity.Name = "rbHighSensitivity";
            this.rbHighSensitivity.Size = new System.Drawing.Size(97, 17);
            this.rbHighSensitivity.TabIndex = 0;
            this.rbHighSensitivity.TabStop = true;
            this.rbHighSensitivity.Text = "High Sensitivity";
            this.rbHighSensitivity.UseVisualStyleBackColor = true;
            // 
            // rbMediumSensitivity
            // 
            this.rbMediumSensitivity.AutoSize = true;
            this.rbMediumSensitivity.Location = new System.Drawing.Point(6, 65);
            this.rbMediumSensitivity.Name = "rbMediumSensitivity";
            this.rbMediumSensitivity.Size = new System.Drawing.Size(112, 17);
            this.rbMediumSensitivity.TabIndex = 0;
            this.rbMediumSensitivity.TabStop = true;
            this.rbMediumSensitivity.Text = "Medium Sensitivity";
            this.rbMediumSensitivity.UseVisualStyleBackColor = true;
            // 
            // rbLowSensitivity
            // 
            this.rbLowSensitivity.AutoSize = true;
            this.rbLowSensitivity.Location = new System.Drawing.Point(6, 42);
            this.rbLowSensitivity.Name = "rbLowSensitivity";
            this.rbLowSensitivity.Size = new System.Drawing.Size(95, 17);
            this.rbLowSensitivity.TabIndex = 0;
            this.rbLowSensitivity.TabStop = true;
            this.rbLowSensitivity.Text = "Low Sensitivity";
            this.rbLowSensitivity.UseVisualStyleBackColor = true;
            // 
            // btnResetView
            // 
            this.btnResetView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetView.Location = new System.Drawing.Point(723, 391);
            this.btnResetView.Name = "btnResetView";
            this.btnResetView.Size = new System.Drawing.Size(141, 23);
            this.btnResetView.TabIndex = 5;
            this.btnResetView.Text = "ResetView";
            this.btnResetView.UseVisualStyleBackColor = true;
            // 
            // lblHorizontal
            // 
            this.lblHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorizontal.Location = new System.Drawing.Point(723, 448);
            this.lblHorizontal.Name = "lblHorizontal";
            this.lblHorizontal.Size = new System.Drawing.Size(59, 13);
            this.lblHorizontal.TabIndex = 6;
            this.lblHorizontal.Text = "Horizontal:";
            this.lblHorizontal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVertical
            // 
            this.lblVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVertical.Location = new System.Drawing.Point(726, 422);
            this.lblVertical.Name = "lblVertical";
            this.lblVertical.Size = new System.Drawing.Size(56, 13);
            this.lblVertical.TabIndex = 6;
            this.lblVertical.Text = "Vertical:";
            this.lblVertical.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpAutoRotate
            // 
            this.grpAutoRotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAutoRotate.Controls.Add(this.rbARHighSpeed);
            this.grpAutoRotate.Controls.Add(this.chkAutoRotate);
            this.grpAutoRotate.Controls.Add(this.rbARLowSpeed);
            this.grpAutoRotate.Controls.Add(this.rbARMediumSpeed);
            this.grpAutoRotate.Location = new System.Drawing.Point(724, 265);
            this.grpAutoRotate.Name = "grpAutoRotate";
            this.grpAutoRotate.Size = new System.Drawing.Size(140, 120);
            this.grpAutoRotate.TabIndex = 7;
            this.grpAutoRotate.TabStop = false;
            this.grpAutoRotate.Text = "Auto Rotate";
            // 
            // rbARHighSpeed
            // 
            this.rbARHighSpeed.AutoSize = true;
            this.rbARHighSpeed.Location = new System.Drawing.Point(5, 92);
            this.rbARHighSpeed.Name = "rbARHighSpeed";
            this.rbARHighSpeed.Size = new System.Drawing.Size(81, 17);
            this.rbARHighSpeed.TabIndex = 0;
            this.rbARHighSpeed.TabStop = true;
            this.rbARHighSpeed.Text = "High Speed";
            this.rbARHighSpeed.UseVisualStyleBackColor = true;
            // 
            // chkAutoRotate
            // 
            this.chkAutoRotate.Location = new System.Drawing.Point(7, 20);
            this.chkAutoRotate.Name = "chkAutoRotate";
            this.chkAutoRotate.Size = new System.Drawing.Size(127, 20);
            this.chkAutoRotate.TabIndex = 0;
            this.chkAutoRotate.Text = "Auto Rotate";
            this.chkAutoRotate.UseVisualStyleBackColor = true;
            // 
            // rbARLowSpeed
            // 
            this.rbARLowSpeed.AutoSize = true;
            this.rbARLowSpeed.Location = new System.Drawing.Point(5, 46);
            this.rbARLowSpeed.Name = "rbARLowSpeed";
            this.rbARLowSpeed.Size = new System.Drawing.Size(79, 17);
            this.rbARLowSpeed.TabIndex = 0;
            this.rbARLowSpeed.TabStop = true;
            this.rbARLowSpeed.Text = "Low Speed";
            this.rbARLowSpeed.UseVisualStyleBackColor = true;
            // 
            // rbARMediumSpeed
            // 
            this.rbARMediumSpeed.AutoSize = true;
            this.rbARMediumSpeed.Location = new System.Drawing.Point(5, 69);
            this.rbARMediumSpeed.Name = "rbARMediumSpeed";
            this.rbARMediumSpeed.Size = new System.Drawing.Size(96, 17);
            this.rbARMediumSpeed.TabIndex = 0;
            this.rbARMediumSpeed.TabStop = true;
            this.rbARMediumSpeed.Text = "Medium Speed";
            this.rbARMediumSpeed.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 472);
            this.Controls.Add(this.grpAutoRotate);
            this.Controls.Add(this.lblVertical);
            this.Controls.Add(this.lblHorizontal);
            this.Controls.Add(this.btnResetView);
            this.Controls.Add(this.grpMouseOptions);
            this.Controls.Add(this.grpMouseWheelSensitivity);
            this.Controls.Add(this.nUDVertical);
            this.Controls.Add(this.nUDHorizontal);
            this.Controls.Add(this.glControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(892, 511);
            this.Name = "MainForm";
            this.Text = "Volumetric Video Player";
            ((System.ComponentModel.ISupportInitialize)(this.nUDHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDVertical)).EndInit();
            this.grpMouseWheelSensitivity.ResumeLayout(false);
            this.grpMouseWheelSensitivity.PerformLayout();
            this.grpMouseOptions.ResumeLayout(false);
            this.grpMouseOptions.PerformLayout();
            this.grpAutoRotate.ResumeLayout(false);
            this.grpAutoRotate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private OpenTK.GLControl glControlMain;
        private System.Windows.Forms.NumericUpDown nUDHorizontal;
        private System.Windows.Forms.NumericUpDown nUDVertical;
        private System.Windows.Forms.CheckBox chkInvertMouseWheel;
        private System.Windows.Forms.GroupBox grpMouseWheelSensitivity;
        private System.Windows.Forms.RadioButton rbHighSensitivityWheel;
        private System.Windows.Forms.RadioButton rbMediumSensitivityWheel;
        private System.Windows.Forms.RadioButton rbLowSensitivityWheel;
        private System.Windows.Forms.CheckBox chkInvertMouse;
        private System.Windows.Forms.GroupBox grpMouseOptions;
        private System.Windows.Forms.RadioButton rbHighSensitivity;
        private System.Windows.Forms.RadioButton rbMediumSensitivity;
        private System.Windows.Forms.RadioButton rbLowSensitivity;
        private System.Windows.Forms.Button btnResetView;
        private System.Windows.Forms.Label lblHorizontal;
        private System.Windows.Forms.Label lblVertical;
        private System.Windows.Forms.GroupBox grpAutoRotate;
        private System.Windows.Forms.RadioButton rbARHighSpeed;
        private System.Windows.Forms.CheckBox chkAutoRotate;
        private System.Windows.Forms.RadioButton rbARLowSpeed;
        private System.Windows.Forms.RadioButton rbARMediumSpeed;
    }
}

