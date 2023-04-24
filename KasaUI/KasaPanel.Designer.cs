namespace KasaUI
{
    partial class KasaPanel
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
            this.ProductsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.KoszykLabel = new System.Windows.Forms.Label();
            this.KoszykListBox = new System.Windows.Forms.ListBox();
            this.PlusCartButton = new System.Windows.Forms.Button();
            this.MinusCartButton = new System.Windows.Forms.Button();
            this.DeleteCartButton = new System.Windows.Forms.Button();
            this.CompleteCartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProductsPanel
            // 
            this.ProductsPanel.AutoScroll = true;
            this.ProductsPanel.Location = new System.Drawing.Point(0, 0);
            this.ProductsPanel.Name = "ProductsPanel";
            this.ProductsPanel.Size = new System.Drawing.Size(854, 665);
            this.ProductsPanel.TabIndex = 0;
            // 
            // KoszykLabel
            // 
            this.KoszykLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KoszykLabel.Location = new System.Drawing.Point(864, 9);
            this.KoszykLabel.Name = "KoszykLabel";
            this.KoszykLabel.Size = new System.Drawing.Size(330, 54);
            this.KoszykLabel.TabIndex = 1;
            this.KoszykLabel.Text = "KOSZYK";
            this.KoszykLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KoszykListBox
            // 
            this.KoszykListBox.ColumnWidth = 450;
            this.KoszykListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KoszykListBox.ItemHeight = 24;
            this.KoszykListBox.Items.AddRange(new object[] {
            "Tu pojawią się twoje produkty..."});
            this.KoszykListBox.Location = new System.Drawing.Point(869, 70);
            this.KoszykListBox.Name = "KoszykListBox";
            this.KoszykListBox.Size = new System.Drawing.Size(324, 412);
            this.KoszykListBox.TabIndex = 2;
            // 
            // PlusCartButton
            // 
            this.PlusCartButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.PlusCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlusCartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PlusCartButton.Location = new System.Drawing.Point(869, 520);
            this.PlusCartButton.Name = "PlusCartButton";
            this.PlusCartButton.Size = new System.Drawing.Size(75, 57);
            this.PlusCartButton.TabIndex = 3;
            this.PlusCartButton.Text = "+";
            this.PlusCartButton.UseVisualStyleBackColor = false;
            this.PlusCartButton.Click += new System.EventHandler(this.PlusCartButton_Click);
            // 
            // MinusCartButton
            // 
            this.MinusCartButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MinusCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MinusCartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MinusCartButton.Location = new System.Drawing.Point(963, 520);
            this.MinusCartButton.Name = "MinusCartButton";
            this.MinusCartButton.Size = new System.Drawing.Size(75, 57);
            this.MinusCartButton.TabIndex = 4;
            this.MinusCartButton.Text = "-";
            this.MinusCartButton.UseVisualStyleBackColor = false;
            this.MinusCartButton.Click += new System.EventHandler(this.MinusCartButton_Click);
            // 
            // DeleteCartButton
            // 
            this.DeleteCartButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.DeleteCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteCartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DeleteCartButton.Location = new System.Drawing.Point(1058, 520);
            this.DeleteCartButton.Name = "DeleteCartButton";
            this.DeleteCartButton.Size = new System.Drawing.Size(135, 57);
            this.DeleteCartButton.TabIndex = 5;
            this.DeleteCartButton.Text = "Usuń";
            this.DeleteCartButton.UseVisualStyleBackColor = false;
            this.DeleteCartButton.Click += new System.EventHandler(this.DeleteCartButton_Click);
            // 
            // CompleteCartButton
            // 
            this.CompleteCartButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CompleteCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CompleteCartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CompleteCartButton.Location = new System.Drawing.Point(869, 588);
            this.CompleteCartButton.Name = "CompleteCartButton";
            this.CompleteCartButton.Size = new System.Drawing.Size(324, 57);
            this.CompleteCartButton.TabIndex = 6;
            this.CompleteCartButton.Text = "Potwierdź";
            this.CompleteCartButton.UseVisualStyleBackColor = false;
            this.CompleteCartButton.Click += new System.EventHandler(this.CompleteCartButton_Click);
            // 
            // KasaPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1207, 665);
            this.Controls.Add(this.CompleteCartButton);
            this.Controls.Add(this.DeleteCartButton);
            this.Controls.Add(this.MinusCartButton);
            this.Controls.Add(this.PlusCartButton);
            this.Controls.Add(this.KoszykListBox);
            this.Controls.Add(this.KoszykLabel);
            this.Controls.Add(this.ProductsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KasaPanel";
            this.Text = "Kasa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ProductsPanel;
        private System.Windows.Forms.Label KoszykLabel;
        private System.Windows.Forms.ListBox KoszykListBox;
        private System.Windows.Forms.Button PlusCartButton;
        private System.Windows.Forms.Button MinusCartButton;
        private System.Windows.Forms.Button DeleteCartButton;
        private System.Windows.Forms.Button CompleteCartButton;
    }
}

