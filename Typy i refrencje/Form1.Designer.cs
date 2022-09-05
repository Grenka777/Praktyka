
namespace Typy_i_refrencje
{
    partial class Referencje
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
            this.buttonLoid = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLoid
            // 
            this.buttonLoid.Location = new System.Drawing.Point(60, 24);
            this.buttonLoid.Name = "buttonLoid";
            this.buttonLoid.Size = new System.Drawing.Size(75, 23);
            this.buttonLoid.TabIndex = 0;
            this.buttonLoid.Text = "Lloyd";
            this.buttonLoid.UseVisualStyleBackColor = true;
            this.buttonLoid.Click += new System.EventHandler(this.buttonLoid_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(60, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Lucinda";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(60, 82);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Zamień";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Referencje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 140);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonLoid);
            this.Name = "Referencje";
            this.Text = "Typy i referencje";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

