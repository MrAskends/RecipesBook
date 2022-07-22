
namespace RecipesBook
{
    partial class FormOptions
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelNewDish = new System.Windows.Forms.Label();
            this.textBoxNewRecipe = new System.Windows.Forms.TextBox();
            this.labelNewRecipe = new System.Windows.Forms.Label();
            this.textBoxNewDish = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(34, 491);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(319, 36);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить рецепт";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelNewDish
            // 
            this.labelNewDish.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNewDish.Location = new System.Drawing.Point(125, 37);
            this.labelNewDish.Name = "labelNewDish";
            this.labelNewDish.Size = new System.Drawing.Size(133, 39);
            this.labelNewDish.TabIndex = 1;
            this.labelNewDish.Text = "Введите название нового блюда";
            this.labelNewDish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNewRecipe
            // 
            this.textBoxNewRecipe.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxNewRecipe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNewRecipe.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxNewRecipe.Location = new System.Drawing.Point(34, 153);
            this.textBoxNewRecipe.Multiline = true;
            this.textBoxNewRecipe.Name = "textBoxNewRecipe";
            this.textBoxNewRecipe.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxNewRecipe.Size = new System.Drawing.Size(319, 332);
            this.textBoxNewRecipe.TabIndex = 2;
            // 
            // labelNewRecipe
            // 
            this.labelNewRecipe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNewRecipe.Location = new System.Drawing.Point(125, 111);
            this.labelNewRecipe.Name = "labelNewRecipe";
            this.labelNewRecipe.Size = new System.Drawing.Size(133, 39);
            this.labelNewRecipe.TabIndex = 3;
            this.labelNewRecipe.Text = "Введите рецепт нового блюда";
            this.labelNewRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNewDish
            // 
            this.textBoxNewDish.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNewDish.Location = new System.Drawing.Point(34, 82);
            this.textBoxNewDish.Name = "textBoxNewDish";
            this.textBoxNewDish.Size = new System.Drawing.Size(319, 26);
            this.textBoxNewDish.TabIndex = 4;
            // 
            // buttonBack
            // 
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBack.Image = global::RecipesBook.Properties.Resources.Back;
            this.buttonBack.Location = new System.Drawing.Point(12, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(64, 64);
            this.buttonBack.TabIndex = 5;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 542);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.textBoxNewDish);
            this.Controls.Add(this.labelNewRecipe);
            this.Controls.Add(this.textBoxNewRecipe);
            this.Controls.Add(this.labelNewDish);
            this.Controls.Add(this.buttonAdd);
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipes book options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelNewDish;
        private System.Windows.Forms.TextBox textBoxNewRecipe;
        private System.Windows.Forms.Label labelNewRecipe;
        private System.Windows.Forms.TextBox textBoxNewDish;
        private System.Windows.Forms.Button buttonBack;
    }
}