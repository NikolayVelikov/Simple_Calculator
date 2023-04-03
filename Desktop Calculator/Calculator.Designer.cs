namespace Desktop_Calculator
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            submit = new Button();
            label1 = new Label();
            label2 = new Label();
            reset = new Button();
            Information = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(10, 104);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(366, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(10, 165);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(127, 23);
            textBox2.TabIndex = 1;
            // 
            // submit
            // 
            submit.Location = new Point(10, 224);
            submit.Name = "submit";
            submit.Size = new Size(75, 23);
            submit.TabIndex = 2;
            submit.Text = "Submit";
            submit.UseVisualStyleBackColor = true;
            submit.Click += submit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 86);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 3;
            label1.Text = "Input";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 147);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Result";
            // 
            // reset
            // 
            reset.Location = new Point(117, 224);
            reset.Name = "reset";
            reset.Size = new Size(75, 23);
            reset.TabIndex = 5;
            reset.Text = "Reset";
            reset.UseVisualStyleBackColor = true;
            reset.Click += reset_Click;
            // 
            // Information
            // 
            Information.AutoSize = true;
            Information.Location = new Point(10, 9);
            Information.Name = "Information";
            Information.Size = new Size(346, 15);
            Information.TabIndex = 6;
            Information.Text = "You can use the following mathematilac arguments: +, -, *, /, (, )";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 37);
            label3.Name = "label3";
            label3.Size = new Size(190, 15);
            label3.TabIndex = 7;
            label3.Text = "Every open bracket must be closed";
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 267);
            Controls.Add(label3);
            Controls.Add(Information);
            Controls.Add(reset);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(submit);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Calculator";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button submit;
        private Button reset;
        private Label Information;
        private Label label3;
    }
}