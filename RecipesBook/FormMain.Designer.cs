
namespace RecipesBook
{
    partial class FormMain
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
            this.comboBoxDishes = new System.Windows.Forms.ComboBox();
            this.textBoxRecipe = new System.Windows.Forms.TextBox();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.labelSelectDish = new System.Windows.Forms.Label();
            this.labelRecipeDish = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxDishes
            // 
            this.comboBoxDishes.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxDishes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDishes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxDishes.FormattingEnabled = true;
            this.comboBoxDishes.Location = new System.Drawing.Point(90, 34);
            this.comboBoxDishes.Name = "comboBoxDishes";
            this.comboBoxDishes.Size = new System.Drawing.Size(167, 27);
            this.comboBoxDishes.TabIndex = 0;
            this.comboBoxDishes.SelectedIndexChanged += new System.EventHandler(this.comboBoxDishes_SelectedIndexChanged);
            // 
            // textBoxRecipe
            // 
            this.textBoxRecipe.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxRecipe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRecipe.Location = new System.Drawing.Point(12, 104);
            this.textBoxRecipe.Multiline = true;
            this.textBoxRecipe.Name = "textBoxRecipe";
            this.textBoxRecipe.ReadOnly = true;
            this.textBoxRecipe.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxRecipe.Size = new System.Drawing.Size(319, 334);
            this.textBoxRecipe.TabIndex = 1;
            // 
            // buttonOptions
            // 
            this.buttonOptions.FlatAppearance.BorderSize = 0;
            this.buttonOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOptions.Image = global::RecipesBook.Properties.Resources.Settings;
            this.buttonOptions.Location = new System.Drawing.Point(12, 12);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(64, 64);
            this.buttonOptions.TabIndex = 2;
            this.buttonOptions.UseVisualStyleBackColor = true;
            this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // labelSelectDish
            // 
            this.labelSelectDish.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSelectDish.Location = new System.Drawing.Point(111, 8);
            this.labelSelectDish.Name = "labelSelectDish";
            this.labelSelectDish.Size = new System.Drawing.Size(123, 23);
            this.labelSelectDish.TabIndex = 3;
            this.labelSelectDish.Text = "Выберите блюдо";
            this.labelSelectDish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRecipeDish
            // 
            this.labelRecipeDish.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRecipeDish.Location = new System.Drawing.Point(111, 82);
            this.labelRecipeDish.Name = "labelRecipeDish";
            this.labelRecipeDish.Size = new System.Drawing.Size(123, 19);
            this.labelRecipeDish.TabIndex = 4;
            this.labelRecipeDish.Text = "Рецепт блюда";
            this.labelRecipeDish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 450);
            this.Controls.Add(this.labelRecipeDish);
            this.Controls.Add(this.labelSelectDish);
            this.Controls.Add(this.buttonOptions);
            this.Controls.Add(this.textBoxRecipe);
            this.Controls.Add(this.comboBoxDishes);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipes book";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.VisibleChanged += new System.EventHandler(this.FormMain_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDishes;
        private System.Windows.Forms.TextBox textBoxRecipe;
        private System.Windows.Forms.Button buttonOptions;
        private System.Windows.Forms.Label labelSelectDish;
        private System.Windows.Forms.Label labelRecipeDish;
    }
}

