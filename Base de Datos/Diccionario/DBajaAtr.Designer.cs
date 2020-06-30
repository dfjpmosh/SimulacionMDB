﻿namespace Diccionario
{
    partial class DBajaAtr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBajaAtr));
            this.cbEntSel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAtrSel = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbEntSel
            // 
            this.cbEntSel.Enabled = false;
            this.cbEntSel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEntSel.FormattingEnabled = true;
            this.cbEntSel.Location = new System.Drawing.Point(113, 7);
            this.cbEntSel.Name = "cbEntSel";
            this.cbEntSel.Size = new System.Drawing.Size(159, 27);
            this.cbEntSel.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Entidad:";
            // 
            // botonAceptar
            // 
            this.botonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botonAceptar.Image = global::Diccionario.Properties.Resources.Aceptar;
            this.botonAceptar.Location = new System.Drawing.Point(233, 79);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(50, 50);
            this.botonAceptar.TabIndex = 1;
            this.botonAceptar.UseVisualStyleBackColor = true;
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Image = global::Diccionario.Properties.Resources.Cancelar1;
            this.botonCancelar.Location = new System.Drawing.Point(1, 79);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(50, 50);
            this.botonCancelar.TabIndex = 2;
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Atributo:";
            // 
            // cbAtrSel
            // 
            this.cbAtrSel.Enabled = false;
            this.cbAtrSel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAtrSel.FormattingEnabled = true;
            this.cbAtrSel.Location = new System.Drawing.Point(113, 38);
            this.cbAtrSel.Name = "cbAtrSel";
            this.cbAtrSel.Size = new System.Drawing.Size(159, 27);
            this.cbAtrSel.TabIndex = 22;
            // 
            // DBajaAtr
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Diccionario.Properties.Resources.ibm_mobile_database;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(284, 129);
            this.Controls.Add(this.cbAtrSel);
            this.Controls.Add(this.cbEntSel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 167);
            this.MinimumSize = new System.Drawing.Size(300, 167);
            this.Name = "DBajaAtr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baja Atributo";
            this.Load += new System.EventHandler(this.DBajaAtr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbEntSel;
        public System.Windows.Forms.ComboBox cbAtrSel;
    }
}