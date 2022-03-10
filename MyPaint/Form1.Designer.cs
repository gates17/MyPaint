namespace MyPaint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelDrawing = new System.Windows.Forms.Panel();
            this.buttonLine = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonPen = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonBlack = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelDrawing
            // 
            this.panelDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDrawing.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDrawing.BackColor = System.Drawing.SystemColors.Window;
            this.panelDrawing.Location = new System.Drawing.Point(102, 46);
            this.panelDrawing.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panelDrawing.MinimumSize = new System.Drawing.Size(100, 100);
            this.panelDrawing.Name = "panelDrawing";
            this.panelDrawing.Size = new System.Drawing.Size(691, 397);
            this.panelDrawing.TabIndex = 0;
            this.panelDrawing.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDrawing_Paint);
            this.panelDrawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDrawing_MouseDown);
            this.panelDrawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDrawing_MouseMove);
            this.panelDrawing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelDrawing_MouseUp);
            // 
            // buttonLine
            // 
            this.buttonLine.Location = new System.Drawing.Point(102, 1);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(94, 39);
            this.buttonLine.TabIndex = 1;
            this.buttonLine.Text = "Line";
            this.buttonLine.UseVisualStyleBackColor = true;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.Location = new System.Drawing.Point(202, 1);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(94, 39);
            this.buttonCircle.TabIndex = 2;
            this.buttonCircle.Text = "Circle";
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Location = new System.Drawing.Point(302, 1);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(94, 39);
            this.buttonRectangle.TabIndex = 3;
            this.buttonRectangle.Text = "Rectangle";
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // buttonPen
            // 
            this.buttonPen.Location = new System.Drawing.Point(402, 1);
            this.buttonPen.Name = "buttonPen";
            this.buttonPen.Size = new System.Drawing.Size(94, 39);
            this.buttonPen.TabIndex = 4;
            this.buttonPen.Text = "Pen";
            this.buttonPen.UseVisualStyleBackColor = true;
            this.buttonPen.Click += new System.EventHandler(this.buttonPen_Click);
            // 
            // buttonRed
            // 
            this.buttonRed.Location = new System.Drawing.Point(2, 46);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(94, 39);
            this.buttonRed.TabIndex = 5;
            this.buttonRed.Text = "Red";
            this.buttonRed.UseVisualStyleBackColor = true;
            this.buttonRed.Click += new System.EventHandler(this.buttonRed_Click);
            // 
            // buttonBlack
            // 
            this.buttonBlack.Location = new System.Drawing.Point(2, 91);
            this.buttonBlack.Name = "buttonBlack";
            this.buttonBlack.Size = new System.Drawing.Size(94, 39);
            this.buttonBlack.TabIndex = 6;
            this.buttonBlack.Text = "Black";
            this.buttonBlack.UseVisualStyleBackColor = true;
            this.buttonBlack.Click += new System.EventHandler(this.buttonBlack_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(2, 1);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(94, 39);
            this.undoButton.TabIndex = 7;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(2, 284);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(94, 39);
            this.loadButton.TabIndex = 8;
            this.loadButton.Text = "Abrir";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(2, 329);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 39);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Gravar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(2, 374);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(94, 64);
            this.saveAsButton.TabIndex = 10;
            this.saveAsButton.Text = "Gravar Como";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.buttonBlack);
            this.Controls.Add(this.buttonRed);
            this.Controls.Add(this.buttonPen);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.buttonLine);
            this.Controls.Add(this.panelDrawing);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelDrawing;
        private Button buttonLine;
        private Button buttonCircle;
        private Button buttonRectangle;
        private Button buttonPen;
        private Button buttonRed;
        private Button buttonBlack;
        private Button undoButton;
        private Button loadButton;
        private Button saveButton;
        private Button saveAsButton;
    }
}