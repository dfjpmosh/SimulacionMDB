namespace Diccionario
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.mPrincipal = new System.Windows.Forms.MenuStrip();
            this.mEstructura = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mMantemiento = new System.Windows.Forms.ToolStripMenuItem();
            this.mSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.bSQL = new System.Windows.Forms.Button();
            this.bMatenimiento = new System.Windows.Forms.Button();
            this.bEstructura = new System.Windows.Forms.Button();
            this.mPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mPrincipal
            // 
            this.mPrincipal.BackColor = System.Drawing.Color.RoyalBlue;
            this.mPrincipal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mEstructura,
            this.mMantemiento,
            this.mSQL});
            this.mPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mPrincipal.Name = "mPrincipal";
            this.mPrincipal.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.mPrincipal.Size = new System.Drawing.Size(424, 29);
            this.mPrincipal.TabIndex = 0;
            this.mPrincipal.Text = "menuStrip1";
            // 
            // mEstructura
            // 
            this.mEstructura.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripSeparator2});
            this.mEstructura.Name = "mEstructura";
            this.mEstructura.Size = new System.Drawing.Size(91, 23);
            this.mEstructura.Text = "&Estructura";
            this.mEstructura.Click += new System.EventHandler(this.mEstructura_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(57, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(57, 6);
            // 
            // mMantemiento
            // 
            this.mMantemiento.Name = "mMantemiento";
            this.mMantemiento.Size = new System.Drawing.Size(123, 23);
            this.mMantemiento.Text = "&Mantenimiento";
            this.mMantemiento.Click += new System.EventHandler(this.mMantemiento_Click);
            // 
            // mSQL
            // 
            this.mSQL.Name = "mSQL";
            this.mSQL.Size = new System.Drawing.Size(60, 23);
            this.mSQL.Text = "&S.Q.L";
            // 
            // bSQL
            // 
            this.bSQL.BackColor = System.Drawing.Color.White;
            this.bSQL.Image = ((System.Drawing.Image)(resources.GetObject("bSQL.Image")));
            this.bSQL.Location = new System.Drawing.Point(282, 40);
            this.bSQL.Margin = new System.Windows.Forms.Padding(4);
            this.bSQL.Name = "bSQL";
            this.bSQL.Size = new System.Drawing.Size(132, 122);
            this.bSQL.TabIndex = 3;
            this.bSQL.UseVisualStyleBackColor = false;
            this.bSQL.Click += new System.EventHandler(this.bSQL_Click);
            // 
            // bMatenimiento
            // 
            this.bMatenimiento.BackColor = System.Drawing.Color.White;
            this.bMatenimiento.Image = ((System.Drawing.Image)(resources.GetObject("bMatenimiento.Image")));
            this.bMatenimiento.Location = new System.Drawing.Point(146, 40);
            this.bMatenimiento.Margin = new System.Windows.Forms.Padding(4);
            this.bMatenimiento.Name = "bMatenimiento";
            this.bMatenimiento.Size = new System.Drawing.Size(132, 122);
            this.bMatenimiento.TabIndex = 2;
            this.bMatenimiento.UseVisualStyleBackColor = false;
            this.bMatenimiento.Click += new System.EventHandler(this.mMantemiento_Click);
            // 
            // bEstructura
            // 
            this.bEstructura.BackColor = System.Drawing.Color.White;
            this.bEstructura.Image = ((System.Drawing.Image)(resources.GetObject("bEstructura.Image")));
            this.bEstructura.Location = new System.Drawing.Point(10, 40);
            this.bEstructura.Margin = new System.Windows.Forms.Padding(4);
            this.bEstructura.Name = "bEstructura";
            this.bEstructura.Size = new System.Drawing.Size(132, 122);
            this.bEstructura.TabIndex = 1;
            this.bEstructura.UseVisualStyleBackColor = false;
            this.bEstructura.Click += new System.EventHandler(this.mEstructura_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Diccionario.Properties.Resources.ibm_mobile_database;
            this.ClientSize = new System.Drawing.Size(424, 170);
            this.Controls.Add(this.bSQL);
            this.Controls.Add(this.bMatenimiento);
            this.Controls.Add(this.bEstructura);
            this.Controls.Add(this.mPrincipal);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 208);
            this.MinimumSize = new System.Drawing.Size(440, 208);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manejador de Base de Datos";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.mPrincipal.ResumeLayout(false);
            this.mPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mEstructura;
        private System.Windows.Forms.ToolStripMenuItem mMantemiento;
        private System.Windows.Forms.ToolStripMenuItem mSQL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button bEstructura;
        private System.Windows.Forms.Button bMatenimiento;
        private System.Windows.Forms.Button bSQL;
    }
}