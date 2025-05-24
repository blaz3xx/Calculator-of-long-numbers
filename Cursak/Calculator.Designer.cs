namespace Cursak
{
    partial class Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.buttonSmaller = new System.Windows.Forms.Button();
            this.buttonWindow = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.ButtonforClearHistory = new System.Windows.Forms.Button();
            this.panelForHistory = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.buttonHistory = new System.Windows.Forms.Button();
            this.secondaryDisplayLabel = new System.Windows.Forms.TextBox();
            this.textForDisplay = new System.Windows.Forms.TextBox();
            this.calculationProgressbar = new System.Windows.Forms.ProgressBar();
            this.buttonDegree = new CustomButton.MyOwnButton();
            this.Btn0 = new CustomButton.MyOwnButton();
            this.buttonFactorial = new CustomButton.MyOwnButton();
            this.buttonPlus = new CustomButton.MyOwnButton();
            this.Btn3 = new CustomButton.MyOwnButton();
            this.Btn2 = new CustomButton.MyOwnButton();
            this.Btn1 = new CustomButton.MyOwnButton();
            this.buttonMinus = new CustomButton.MyOwnButton();
            this.Btn6 = new CustomButton.MyOwnButton();
            this.Btn5 = new CustomButton.MyOwnButton();
            this.Btn4 = new CustomButton.MyOwnButton();
            this.buttonMultiply = new CustomButton.MyOwnButton();
            this.Btn9 = new CustomButton.MyOwnButton();
            this.Btn8 = new CustomButton.MyOwnButton();
            this.Btn7 = new CustomButton.MyOwnButton();
            this.buttonDivide = new CustomButton.MyOwnButton();
            this.ButtonEqual = new CustomButton.MyOwnButton();
            this.BtnCE = new CustomButton.MyOwnButton();
            this.BtnC = new CustomButton.MyOwnButton();
            this.buttonBack = new CustomButton.MyOwnButton();
            this.buttonToggleSign = new CustomButton.MyOwnButton();
            this.panelTitle.SuspendLayout();
            this.panelHistory.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.buttonSmaller);
            this.panelTitle.Controls.Add(this.buttonWindow);
            this.panelTitle.Controls.Add(this.buttonExit);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(669, 40);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textDisplay1_MouseDown);
            this.panelTitle.MouseEnter += new System.EventHandler(this.textDisplay1_MouseEnter);
            // 
            // buttonSmaller
            // 
            this.buttonSmaller.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSmaller.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSmaller.FlatAppearance.BorderSize = 0;
            this.buttonSmaller.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSmaller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSmaller.Image = ((System.Drawing.Image)(resources.GetObject("buttonSmaller.Image")));
            this.buttonSmaller.Location = new System.Drawing.Point(519, 0);
            this.buttonSmaller.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSmaller.Name = "buttonSmaller";
            this.buttonSmaller.Size = new System.Drawing.Size(50, 40);
            this.buttonSmaller.TabIndex = 4;
            this.buttonSmaller.UseVisualStyleBackColor = true;
            this.buttonSmaller.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonWindow
            // 
            this.buttonWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonWindow.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonWindow.FlatAppearance.BorderSize = 0;
            this.buttonWindow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWindow.Image = ((System.Drawing.Image)(resources.GetObject("buttonWindow.Image")));
            this.buttonWindow.Location = new System.Drawing.Point(569, 0);
            this.buttonWindow.Margin = new System.Windows.Forms.Padding(0);
            this.buttonWindow.Name = "buttonWindow";
            this.buttonWindow.Size = new System.Drawing.Size(50, 40);
            this.buttonWindow.TabIndex = 3;
            this.buttonWindow.UseVisualStyleBackColor = true;
            this.buttonWindow.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(619, 0);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(50, 40);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonWxit_Click);
            // 
            // panelHistory
            // 
            this.panelHistory.AutoScroll = true;
            this.panelHistory.Controls.Add(this.ButtonforClearHistory);
            this.panelHistory.Controls.Add(this.panelForHistory);
            this.panelHistory.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHistory.Location = new System.Drawing.Point(0, 723);
            this.panelHistory.Margin = new System.Windows.Forms.Padding(0);
            this.panelHistory.Name = "panelHistory";
            this.panelHistory.Size = new System.Drawing.Size(669, 5);
            this.panelHistory.TabIndex = 1;
            this.panelHistory.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHistory_Paint);
            // 
            // ButtonforClearHistory
            // 
            this.ButtonforClearHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonforClearHistory.FlatAppearance.BorderSize = 0;
            this.ButtonforClearHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonforClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonforClearHistory.Image = ((System.Drawing.Image)(resources.GetObject("ButtonforClearHistory.Image")));
            this.ButtonforClearHistory.Location = new System.Drawing.Point(0, -48);
            this.ButtonforClearHistory.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonforClearHistory.Name = "ButtonforClearHistory";
            this.ButtonforClearHistory.Size = new System.Drawing.Size(669, 53);
            this.ButtonforClearHistory.TabIndex = 5;
            this.ButtonforClearHistory.UseVisualStyleBackColor = true;
            this.ButtonforClearHistory.Click += new System.EventHandler(this.BtnClearHistory);
            // 
            // panelForHistory
            // 
            this.panelForHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panelForHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelForHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForHistory.ForeColor = System.Drawing.Color.Silver;
            this.panelForHistory.Location = new System.Drawing.Point(0, 0);
            this.panelForHistory.Margin = new System.Windows.Forms.Padding(0);
            this.panelForHistory.Name = "panelForHistory";
            this.panelForHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.panelForHistory.Size = new System.Drawing.Size(669, 5);
            this.panelForHistory.TabIndex = 6;
            this.panelForHistory.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonMenu);
            this.panel1.Controls.Add(this.buttonHistory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 40);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textDisplay1_MouseDown);
            this.panel1.MouseEnter += new System.EventHandler(this.textDisplay1_MouseEnter);
            // 
            // buttonMenu
            // 
            this.buttonMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonMenu.FlatAppearance.BorderSize = 0;
            this.buttonMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonMenu.Image")));
            this.buttonMenu.Location = new System.Drawing.Point(0, 0);
            this.buttonMenu.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(50, 40);
            this.buttonMenu.TabIndex = 4;
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // buttonHistory
            // 
            this.buttonHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHistory.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonHistory.FlatAppearance.BorderSize = 0;
            this.buttonHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHistory.Image = ((System.Drawing.Image)(resources.GetObject("buttonHistory.Image")));
            this.buttonHistory.Location = new System.Drawing.Point(619, 0);
            this.buttonHistory.Margin = new System.Windows.Forms.Padding(0);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(50, 40);
            this.buttonHistory.TabIndex = 2;
            this.buttonHistory.UseVisualStyleBackColor = true;
            this.buttonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // secondaryDisplayLabel
            // 
            this.secondaryDisplayLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.secondaryDisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.secondaryDisplayLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.secondaryDisplayLabel.Font = new System.Drawing.Font("Gadugi", 14F);
            this.secondaryDisplayLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.secondaryDisplayLabel.Location = new System.Drawing.Point(0, 80);
            this.secondaryDisplayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.secondaryDisplayLabel.Multiline = true;
            this.secondaryDisplayLabel.Name = "secondaryDisplayLabel";
            this.secondaryDisplayLabel.ReadOnly = true;
            this.secondaryDisplayLabel.Size = new System.Drawing.Size(669, 49);
            this.secondaryDisplayLabel.TabIndex = 3;
            this.secondaryDisplayLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.secondaryDisplayLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textDisplay1_MouseDown);
            this.secondaryDisplayLabel.MouseEnter += new System.EventHandler(this.textDisplay1_MouseEnter);
            // 
            // textForDisplay
            // 
            this.textForDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textForDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textForDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.textForDisplay.Font = new System.Drawing.Font("Gadugi", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textForDisplay.ForeColor = System.Drawing.Color.DarkGray;
            this.textForDisplay.Location = new System.Drawing.Point(0, 129);
            this.textForDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.textForDisplay.Multiline = true;
            this.textForDisplay.Name = "textForDisplay";
            this.textForDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textForDisplay.Size = new System.Drawing.Size(669, 113);
            this.textForDisplay.TabIndex = 4;
            this.textForDisplay.Text = "0";
            this.textForDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textForDisplay.UseSystemPasswordChar = true;
            this.textForDisplay.TextChanged += new System.EventHandler(this.textDisplay1_TextChanged);
            this.textForDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DisplayKeyPress);
            this.textForDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textDisplay1_MouseDown);
            this.textForDisplay.MouseEnter += new System.EventHandler(this.textDisplay1_MouseEnter);
            // 
            // calculationProgressbar
            // 
            this.calculationProgressbar.Location = new System.Drawing.Point(107, 113);
            this.calculationProgressbar.Name = "calculationProgressbar";
            this.calculationProgressbar.Size = new System.Drawing.Size(427, 129);
            this.calculationProgressbar.TabIndex = 27;
            this.calculationProgressbar.Visible = false;
            // 
            // buttonDegree
            // 
            this.buttonDegree.AllowDrop = true;
            this.buttonDegree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.buttonDegree.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.buttonDegree.BorderRadius = 20;
            this.buttonDegree.BorderSize = 765;
            this.buttonDegree.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonDegree.FlatAppearance.BorderSize = 0;
            this.buttonDegree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDegree.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.buttonDegree.ForeColor = System.Drawing.Color.White;
            this.buttonDegree.Location = new System.Drawing.Point(290, 632);
            this.buttonDegree.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDegree.Name = "buttonDegree";
            this.buttonDegree.Size = new System.Drawing.Size(120, 77);
            this.buttonDegree.TabIndex = 23;
            this.buttonDegree.Text = "^";
            this.buttonDegree.TextColor = System.Drawing.Color.White;
            this.buttonDegree.UseVisualStyleBackColor = false;
            this.buttonDegree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonMathOperations);
            // 
            // Btn0
            // 
            this.Btn0.AllowDrop = true;
            this.Btn0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn0.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn0.BorderRadius = 20;
            this.Btn0.BorderSize = 765;
            this.Btn0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn0.FlatAppearance.BorderSize = 0;
            this.Btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn0.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.Btn0.ForeColor = System.Drawing.Color.White;
            this.Btn0.Location = new System.Drawing.Point(166, 632);
            this.Btn0.Margin = new System.Windows.Forms.Padding(0);
            this.Btn0.Name = "Btn0";
            this.Btn0.Size = new System.Drawing.Size(120, 77);
            this.Btn0.TabIndex = 24;
            this.Btn0.Text = "0";
            this.Btn0.TextColor = System.Drawing.Color.White;
            this.Btn0.UseVisualStyleBackColor = false;
            this.Btn0.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // buttonFactorial
            // 
            this.buttonFactorial.AllowDrop = true;
            this.buttonFactorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.buttonFactorial.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.buttonFactorial.BorderRadius = 20;
            this.buttonFactorial.BorderSize = 765;
            this.buttonFactorial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonFactorial.FlatAppearance.BorderSize = 0;
            this.buttonFactorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFactorial.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.buttonFactorial.ForeColor = System.Drawing.Color.White;
            this.buttonFactorial.Location = new System.Drawing.Point(42, 632);
            this.buttonFactorial.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFactorial.Name = "buttonFactorial";
            this.buttonFactorial.Size = new System.Drawing.Size(120, 77);
            this.buttonFactorial.TabIndex = 25;
            this.buttonFactorial.Text = "!";
            this.buttonFactorial.TextColor = System.Drawing.Color.White;
            this.buttonFactorial.UseVisualStyleBackColor = false;
            this.buttonFactorial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonMathOperations);
            // 
            // buttonPlus
            // 
            this.buttonPlus.AllowDrop = true;
            this.buttonPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonPlus.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonPlus.BorderRadius = 20;
            this.buttonPlus.BorderSize = 765;
            this.buttonPlus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonPlus.FlatAppearance.BorderSize = 0;
            this.buttonPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlus.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlus.ForeColor = System.Drawing.Color.White;
            this.buttonPlus.Location = new System.Drawing.Point(414, 632);
            this.buttonPlus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(120, 77);
            this.buttonPlus.TabIndex = 22;
            this.buttonPlus.Text = "+";
            this.buttonPlus.TextColor = System.Drawing.Color.White;
            this.buttonPlus.UseVisualStyleBackColor = false;
            this.buttonPlus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonMathOperations);
            // 
            // Btn3
            // 
            this.Btn3.AllowDrop = true;
            this.Btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn3.BorderRadius = 20;
            this.Btn3.BorderSize = 765;
            this.Btn3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn3.FlatAppearance.BorderSize = 0;
            this.Btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn3.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.Btn3.ForeColor = System.Drawing.Color.White;
            this.Btn3.Location = new System.Drawing.Point(290, 545);
            this.Btn3.Margin = new System.Windows.Forms.Padding(0);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(120, 77);
            this.Btn3.TabIndex = 19;
            this.Btn3.Text = "3";
            this.Btn3.TextColor = System.Drawing.Color.White;
            this.Btn3.UseVisualStyleBackColor = false;
            this.Btn3.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn2
            // 
            this.Btn2.AllowDrop = true;
            this.Btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn2.BorderRadius = 20;
            this.Btn2.BorderSize = 765;
            this.Btn2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn2.FlatAppearance.BorderSize = 0;
            this.Btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn2.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.Btn2.ForeColor = System.Drawing.Color.White;
            this.Btn2.Location = new System.Drawing.Point(166, 545);
            this.Btn2.Margin = new System.Windows.Forms.Padding(0);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(120, 77);
            this.Btn2.TabIndex = 20;
            this.Btn2.Text = "2";
            this.Btn2.TextColor = System.Drawing.Color.White;
            this.Btn2.UseVisualStyleBackColor = false;
            this.Btn2.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn1
            // 
            this.Btn1.AllowDrop = true;
            this.Btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn1.BorderRadius = 20;
            this.Btn1.BorderSize = 765;
            this.Btn1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn1.FlatAppearance.BorderSize = 0;
            this.Btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn1.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.Btn1.ForeColor = System.Drawing.Color.White;
            this.Btn1.Location = new System.Drawing.Point(42, 545);
            this.Btn1.Margin = new System.Windows.Forms.Padding(0);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(120, 77);
            this.Btn1.TabIndex = 21;
            this.Btn1.Text = "1";
            this.Btn1.TextColor = System.Drawing.Color.White;
            this.Btn1.UseVisualStyleBackColor = false;
            this.Btn1.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // buttonMinus
            // 
            this.buttonMinus.AllowDrop = true;
            this.buttonMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonMinus.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonMinus.BorderRadius = 20;
            this.buttonMinus.BorderSize = 765;
            this.buttonMinus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonMinus.FlatAppearance.BorderSize = 0;
            this.buttonMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinus.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinus.ForeColor = System.Drawing.Color.White;
            this.buttonMinus.Location = new System.Drawing.Point(414, 545);
            this.buttonMinus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(120, 77);
            this.buttonMinus.TabIndex = 18;
            this.buttonMinus.Text = "-";
            this.buttonMinus.TextColor = System.Drawing.Color.White;
            this.buttonMinus.UseVisualStyleBackColor = false;
            this.buttonMinus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonMathOperations);
            // 
            // Btn6
            // 
            this.Btn6.AllowDrop = true;
            this.Btn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn6.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn6.BorderRadius = 20;
            this.Btn6.BorderSize = 765;
            this.Btn6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn6.FlatAppearance.BorderSize = 0;
            this.Btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn6.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.Btn6.ForeColor = System.Drawing.Color.White;
            this.Btn6.Location = new System.Drawing.Point(290, 457);
            this.Btn6.Margin = new System.Windows.Forms.Padding(0);
            this.Btn6.Name = "Btn6";
            this.Btn6.Size = new System.Drawing.Size(120, 77);
            this.Btn6.TabIndex = 15;
            this.Btn6.Text = "6";
            this.Btn6.TextColor = System.Drawing.Color.White;
            this.Btn6.UseVisualStyleBackColor = false;
            this.Btn6.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn5
            // 
            this.Btn5.AllowDrop = true;
            this.Btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn5.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn5.BorderRadius = 20;
            this.Btn5.BorderSize = 765;
            this.Btn5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn5.FlatAppearance.BorderSize = 0;
            this.Btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn5.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.Btn5.ForeColor = System.Drawing.Color.White;
            this.Btn5.Location = new System.Drawing.Point(166, 457);
            this.Btn5.Margin = new System.Windows.Forms.Padding(0);
            this.Btn5.Name = "Btn5";
            this.Btn5.Size = new System.Drawing.Size(120, 77);
            this.Btn5.TabIndex = 16;
            this.Btn5.Text = "5";
            this.Btn5.TextColor = System.Drawing.Color.White;
            this.Btn5.UseVisualStyleBackColor = false;
            this.Btn5.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn4
            // 
            this.Btn4.AllowDrop = true;
            this.Btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn4.BorderRadius = 20;
            this.Btn4.BorderSize = 765;
            this.Btn4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn4.FlatAppearance.BorderSize = 0;
            this.Btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn4.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.Btn4.ForeColor = System.Drawing.Color.White;
            this.Btn4.Location = new System.Drawing.Point(42, 457);
            this.Btn4.Margin = new System.Windows.Forms.Padding(0);
            this.Btn4.Name = "Btn4";
            this.Btn4.Size = new System.Drawing.Size(120, 77);
            this.Btn4.TabIndex = 17;
            this.Btn4.Text = "4";
            this.Btn4.TextColor = System.Drawing.Color.White;
            this.Btn4.UseVisualStyleBackColor = false;
            this.Btn4.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // buttonMultiply
            // 
            this.buttonMultiply.AllowDrop = true;
            this.buttonMultiply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonMultiply.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonMultiply.BorderRadius = 20;
            this.buttonMultiply.BorderSize = 765;
            this.buttonMultiply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonMultiply.FlatAppearance.BorderSize = 0;
            this.buttonMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMultiply.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMultiply.ForeColor = System.Drawing.Color.White;
            this.buttonMultiply.Location = new System.Drawing.Point(414, 457);
            this.buttonMultiply.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMultiply.Name = "buttonMultiply";
            this.buttonMultiply.Size = new System.Drawing.Size(120, 77);
            this.buttonMultiply.TabIndex = 14;
            this.buttonMultiply.Text = "×";
            this.buttonMultiply.TextColor = System.Drawing.Color.White;
            this.buttonMultiply.UseVisualStyleBackColor = false;
            this.buttonMultiply.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonMathOperations);
            // 
            // Btn9
            // 
            this.Btn9.AllowDrop = true;
            this.Btn9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn9.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn9.BorderRadius = 20;
            this.Btn9.BorderSize = 765;
            this.Btn9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn9.FlatAppearance.BorderSize = 0;
            this.Btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn9.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.Btn9.ForeColor = System.Drawing.Color.White;
            this.Btn9.Location = new System.Drawing.Point(290, 371);
            this.Btn9.Margin = new System.Windows.Forms.Padding(0);
            this.Btn9.Name = "Btn9";
            this.Btn9.Size = new System.Drawing.Size(120, 77);
            this.Btn9.TabIndex = 11;
            this.Btn9.Text = "9";
            this.Btn9.TextColor = System.Drawing.Color.White;
            this.Btn9.UseVisualStyleBackColor = false;
            this.Btn9.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn8
            // 
            this.Btn8.AllowDrop = true;
            this.Btn8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn8.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn8.BorderRadius = 20;
            this.Btn8.BorderSize = 765;
            this.Btn8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn8.FlatAppearance.BorderSize = 0;
            this.Btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn8.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.Btn8.ForeColor = System.Drawing.Color.White;
            this.Btn8.Location = new System.Drawing.Point(166, 371);
            this.Btn8.Margin = new System.Windows.Forms.Padding(0);
            this.Btn8.Name = "Btn8";
            this.Btn8.Size = new System.Drawing.Size(120, 77);
            this.Btn8.TabIndex = 12;
            this.Btn8.Text = "8";
            this.Btn8.TextColor = System.Drawing.Color.White;
            this.Btn8.UseVisualStyleBackColor = false;
            this.Btn8.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn7
            // 
            this.Btn7.AllowDrop = true;
            this.Btn7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn7.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Btn7.BorderRadius = 20;
            this.Btn7.BorderSize = 765;
            this.Btn7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Btn7.FlatAppearance.BorderSize = 0;
            this.Btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn7.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold);
            this.Btn7.ForeColor = System.Drawing.Color.White;
            this.Btn7.Location = new System.Drawing.Point(42, 371);
            this.Btn7.Margin = new System.Windows.Forms.Padding(0);
            this.Btn7.Name = "Btn7";
            this.Btn7.Size = new System.Drawing.Size(120, 77);
            this.Btn7.TabIndex = 13;
            this.Btn7.Text = "7";
            this.Btn7.TextColor = System.Drawing.Color.White;
            this.Btn7.UseVisualStyleBackColor = false;
            this.Btn7.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // buttonDivide
            // 
            this.buttonDivide.AllowDrop = true;
            this.buttonDivide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonDivide.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonDivide.BorderRadius = 20;
            this.buttonDivide.BorderSize = 765;
            this.buttonDivide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonDivide.FlatAppearance.BorderSize = 0;
            this.buttonDivide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDivide.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDivide.ForeColor = System.Drawing.Color.White;
            this.buttonDivide.Location = new System.Drawing.Point(414, 371);
            this.buttonDivide.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDivide.Name = "buttonDivide";
            this.buttonDivide.Size = new System.Drawing.Size(120, 77);
            this.buttonDivide.TabIndex = 10;
            this.buttonDivide.Text = "÷";
            this.buttonDivide.TextColor = System.Drawing.Color.White;
            this.buttonDivide.UseVisualStyleBackColor = false;
            this.buttonDivide.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonMathOperations);
            // 
            // ButtonEqual
            // 
            this.ButtonEqual.AllowDrop = true;
            this.ButtonEqual.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ButtonEqual.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.ButtonEqual.BorderRadius = 20;
            this.ButtonEqual.BorderSize = 765;
            this.ButtonEqual.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ButtonEqual.FlatAppearance.BorderSize = 0;
            this.ButtonEqual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEqual.Font = new System.Drawing.Font("Gadugi", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEqual.ForeColor = System.Drawing.Color.White;
            this.ButtonEqual.Location = new System.Drawing.Point(290, 285);
            this.ButtonEqual.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonEqual.Name = "ButtonEqual";
            this.ButtonEqual.Size = new System.Drawing.Size(120, 77);
            this.ButtonEqual.TabIndex = 9;
            this.ButtonEqual.Text = "=";
            this.ButtonEqual.TextColor = System.Drawing.Color.White;
            this.ButtonEqual.UseVisualStyleBackColor = false;
            this.ButtonEqual.Click += new System.EventHandler(this.ButtonEqual_Click);
            // 
            // BtnCE
            // 
            this.BtnCE.AllowDrop = true;
            this.BtnCE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BtnCE.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BtnCE.BorderRadius = 20;
            this.BtnCE.BorderSize = 765;
            this.BtnCE.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BtnCE.FlatAppearance.BorderSize = 0;
            this.BtnCE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCE.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCE.ForeColor = System.Drawing.Color.White;
            this.BtnCE.Location = new System.Drawing.Point(166, 285);
            this.BtnCE.Margin = new System.Windows.Forms.Padding(0);
            this.BtnCE.Name = "BtnCE";
            this.BtnCE.Size = new System.Drawing.Size(120, 77);
            this.BtnCE.TabIndex = 9;
            this.BtnCE.Text = "CE";
            this.BtnCE.TextColor = System.Drawing.Color.White;
            this.BtnCE.UseVisualStyleBackColor = false;
            this.BtnCE.Click += new System.EventHandler(this.myOwnButton9_Click);
            // 
            // BtnC
            // 
            this.BtnC.AllowDrop = true;
            this.BtnC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BtnC.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BtnC.BorderRadius = 20;
            this.BtnC.BorderSize = 765;
            this.BtnC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BtnC.FlatAppearance.BorderSize = 0;
            this.BtnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnC.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnC.ForeColor = System.Drawing.Color.White;
            this.BtnC.Location = new System.Drawing.Point(42, 285);
            this.BtnC.Margin = new System.Windows.Forms.Padding(0);
            this.BtnC.Name = "BtnC";
            this.BtnC.Size = new System.Drawing.Size(120, 77);
            this.BtnC.TabIndex = 9;
            this.BtnC.Text = "C";
            this.BtnC.TextColor = System.Drawing.Color.White;
            this.BtnC.UseVisualStyleBackColor = false;
            this.BtnC.Click += new System.EventHandler(this.myOwnButton8_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.AllowDrop = true;
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonBack.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonBack.BorderRadius = 20;
            this.buttonBack.BorderSize = 765;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Image = ((System.Drawing.Image)(resources.GetObject("buttonBack.Image")));
            this.buttonBack.Location = new System.Drawing.Point(414, 285);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(120, 77);
            this.buttonBack.TabIndex = 5;
            this.buttonBack.TextColor = System.Drawing.Color.White;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonToggleSign
            // 
            this.buttonToggleSign.AllowDrop = true;
            this.buttonToggleSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonToggleSign.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonToggleSign.BorderRadius = 20;
            this.buttonToggleSign.BorderSize = 765;
            this.buttonToggleSign.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonToggleSign.FlatAppearance.BorderSize = 0;
            this.buttonToggleSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToggleSign.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToggleSign.ForeColor = System.Drawing.Color.White;
            this.buttonToggleSign.Location = new System.Drawing.Point(540, 286);
            this.buttonToggleSign.Margin = new System.Windows.Forms.Padding(0);
            this.buttonToggleSign.Name = "buttonToggleSign";
            this.buttonToggleSign.Size = new System.Drawing.Size(120, 77);
            this.buttonToggleSign.TabIndex = 26;
            this.buttonToggleSign.Text = "+/-";
            this.buttonToggleSign.TextColor = System.Drawing.Color.White;
            this.buttonToggleSign.UseVisualStyleBackColor = false;
            this.buttonToggleSign.Click += new System.EventHandler(this.myOwnButton1_Click);
            // 
            // Calculator
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(669, 728);
            this.Controls.Add(this.calculationProgressbar);
            this.Controls.Add(this.panelHistory);
            this.Controls.Add(this.buttonDegree);
            this.Controls.Add(this.Btn0);
            this.Controls.Add(this.buttonFactorial);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.Btn3);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.Btn1);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.Btn6);
            this.Controls.Add(this.Btn5);
            this.Controls.Add(this.Btn4);
            this.Controls.Add(this.buttonMultiply);
            this.Controls.Add(this.Btn9);
            this.Controls.Add(this.Btn8);
            this.Controls.Add(this.Btn7);
            this.Controls.Add(this.buttonDivide);
            this.Controls.Add(this.ButtonEqual);
            this.Controls.Add(this.BtnCE);
            this.Controls.Add(this.BtnC);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.textForDisplay);
            this.Controls.Add(this.secondaryDisplayLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.buttonToggleSign);
            this.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Calculator_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panelTitle.ResumeLayout(false);
            this.panelHistory.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelHistory;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSmaller;
        private System.Windows.Forms.Button buttonWindow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Button buttonHistory;
        private System.Windows.Forms.TextBox secondaryDisplayLabel;
        private System.Windows.Forms.TextBox textForDisplay;
        private System.Windows.Forms.Button ButtonforClearHistory;
        private System.Windows.Forms.RichTextBox panelForHistory;
        private CustomButton.MyOwnButton buttonBack;
        private CustomButton.MyOwnButton BtnC;
        private CustomButton.MyOwnButton ButtonEqual;
        private CustomButton.MyOwnButton BtnCE;
        private CustomButton.MyOwnButton Btn9;
        private CustomButton.MyOwnButton Btn8;
        private CustomButton.MyOwnButton Btn7;
        private CustomButton.MyOwnButton buttonDivide;
        private CustomButton.MyOwnButton buttonDegree;
        private CustomButton.MyOwnButton Btn0;
        private CustomButton.MyOwnButton buttonFactorial;
        private CustomButton.MyOwnButton buttonPlus;
        private CustomButton.MyOwnButton Btn3;
        private CustomButton.MyOwnButton Btn2;
        private CustomButton.MyOwnButton Btn1;
        private CustomButton.MyOwnButton buttonMinus;
        private CustomButton.MyOwnButton Btn6;
        private CustomButton.MyOwnButton Btn5;
        private CustomButton.MyOwnButton Btn4;
        private CustomButton.MyOwnButton buttonMultiply;
        private CustomButton.MyOwnButton buttonToggleSign;
        private System.Windows.Forms.ProgressBar calculationProgressbar;
    }
}

