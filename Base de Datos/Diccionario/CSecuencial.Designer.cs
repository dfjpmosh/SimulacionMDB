namespace Diccionario
{
    partial class CSecuencial
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSecuencial));
            this.dgvES = new System.Windows.Forms.DataGridView();
            this.EntidadS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDS = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mAbrirConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mNRespaldo = new System.Windows.Forms.ToolStripMenuItem();
            this.dAbrirCrear = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bGuardar = new System.Windows.Forms.ToolStripButton();
            this.bBajaDato = new System.Windows.Forms.ToolStripButton();
            this.bModificaDato = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.lF = new System.Windows.Forms.ToolStripLabel();
            this.lFecha = new System.Windows.Forms.ToolStripLabel();
            this.lHora = new System.Windows.Forms.ToolStripLabel();
            this.Espacio = new System.Windows.Forms.ToolStripLabel();
            this.lUs = new System.Windows.Forms.ToolStripLabel();
            this.lUsuario = new System.Windows.Forms.ToolStripLabel();
            this.dgvDato = new System.Windows.Forms.DataGridView();
            this.bBuscar = new System.Windows.Forms.Button();
            this.tbClave = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDato)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvES
            // 
            this.dgvES.AllowUserToAddRows = false;
            this.dgvES.AllowUserToDeleteRows = false;
            this.dgvES.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvES.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvES.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntidadS});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvES.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvES.Location = new System.Drawing.Point(12, 186);
            this.dgvES.MultiSelect = false;
            this.dgvES.Name = "dgvES";
            this.dgvES.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvES.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvES.RowHeadersVisible = false;
            this.dgvES.Size = new System.Drawing.Size(144, 242);
            this.dgvES.TabIndex = 4;
            this.dgvES.SelectionChanged += new System.EventHandler(this.dgvES_SelectionChanged);
            // 
            // EntidadS
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntidadS.DefaultCellStyle = dataGridViewCellStyle2;
            this.EntidadS.HeaderText = "Entidad";
            this.EntidadS.MinimumWidth = 100;
            this.EntidadS.Name = "EntidadS";
            this.EntidadS.ReadOnly = true;
            this.EntidadS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EntidadS.Width = 130;
            // 
            // dgvDS
            // 
            this.dgvDS.AllowUserToAddRows = false;
            this.dgvDS.AllowUserToDeleteRows = false;
            this.dgvDS.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDS.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDS.Location = new System.Drawing.Point(184, 186);
            this.dgvDS.MultiSelect = false;
            this.dgvDS.Name = "dgvDS";
            this.dgvDS.ReadOnly = true;
            this.dgvDS.Size = new System.Drawing.Size(545, 242);
            this.dgvDS.TabIndex = 5;
            this.dgvDS.SelectionChanged += new System.EventHandler(this.dgvDS_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Entidades";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.RoyalBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(740, 27);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mNuevo,
            this.toolStripSeparator1,
            this.mAbrir});
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(73, 23);
            this.toolStripMenuItem4.Text = "&Archivo";
            // 
            // mNuevo
            // 
            this.mNuevo.Name = "mNuevo";
            this.mNuevo.Size = new System.Drawing.Size(122, 24);
            this.mNuevo.Text = "Nuevo";
            this.mNuevo.Click += new System.EventHandler(this.mCrear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.RoyalBlue;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // mAbrir
            // 
            this.mAbrir.Name = "mAbrir";
            this.mAbrir.Size = new System.Drawing.Size(122, 24);
            this.mAbrir.Text = "Abrir";
            this.mAbrir.Click += new System.EventHandler(this.mAbrir_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAbrirConsultas});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(87, 23);
            this.toolStripMenuItem1.Text = "&Consultas";
            // 
            // mAbrirConsultas
            // 
            this.mAbrirConsultas.Name = "mAbrirConsultas";
            this.mAbrirConsultas.Size = new System.Drawing.Size(113, 24);
            this.mAbrirConsultas.Text = "Abrir";
            this.mAbrirConsultas.Click += new System.EventHandler(this.mAbrirConsultas_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mNRespaldo});
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(91, 23);
            this.toolStripMenuItem2.Text = "&Respaldos";
            // 
            // mNRespaldo
            // 
            this.mNRespaldo.Enabled = false;
            this.mNRespaldo.Name = "mNRespaldo";
            this.mNRespaldo.Size = new System.Drawing.Size(189, 24);
            this.mNRespaldo.Text = "Nuevo Respaldo";
            this.mNRespaldo.Click += new System.EventHandler(this.mNRespaldo_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bGuardar,
            this.bBajaDato,
            this.bModificaDato});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(740, 87);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bGuardar
            // 
            this.bGuardar.AutoSize = false;
            this.bGuardar.BackColor = System.Drawing.Color.Transparent;
            this.bGuardar.Checked = true;
            this.bGuardar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bGuardar.Image = global::Diccionario.Properties.Resources.AltaAtributo;
            this.bGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bGuardar.Name = "bGuardar";
            this.bGuardar.Size = new System.Drawing.Size(76, 84);
            this.bGuardar.Click += new System.EventHandler(this.bGuardar_Click);
            // 
            // bBajaDato
            // 
            this.bBajaDato.Checked = true;
            this.bBajaDato.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bBajaDato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bBajaDato.Image = global::Diccionario.Properties.Resources.BajaAtributo;
            this.bBajaDato.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bBajaDato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bBajaDato.Name = "bBajaDato";
            this.bBajaDato.Size = new System.Drawing.Size(76, 84);
            this.bBajaDato.Text = "toolStripButton1";
            this.bBajaDato.Click += new System.EventHandler(this.bBajaDato_Click);
            // 
            // bModificaDato
            // 
            this.bModificaDato.Checked = true;
            this.bModificaDato.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bModificaDato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bModificaDato.Image = global::Diccionario.Properties.Resources.ModificarAtributo;
            this.bModificaDato.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bModificaDato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bModificaDato.Name = "bModificaDato";
            this.bModificaDato.Size = new System.Drawing.Size(74, 84);
            this.bModificaDato.Text = "toolStripButton1";
            this.bModificaDato.Click += new System.EventHandler(this.bModificaDato_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lF,
            this.lFecha,
            this.lHora,
            this.Espacio,
            this.lUs,
            this.lUsuario});
            this.toolStrip2.Location = new System.Drawing.Point(0, 114);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(740, 25);
            this.toolStrip2.TabIndex = 19;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // lF
            // 
            this.lF.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lF.Name = "lF";
            this.lF.Size = new System.Drawing.Size(60, 22);
            this.lF.Text = "Fecha:  ";
            // 
            // lFecha
            // 
            this.lFecha.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lFecha.Name = "lFecha";
            this.lFecha.Size = new System.Drawing.Size(0, 22);
            // 
            // lHora
            // 
            this.lHora.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lHora.Name = "lHora";
            this.lHora.Size = new System.Drawing.Size(0, 22);
            // 
            // Espacio
            // 
            this.Espacio.Name = "Espacio";
            this.Espacio.Size = new System.Drawing.Size(106, 22);
            this.Espacio.Text = "                                 ";
            // 
            // lUs
            // 
            this.lUs.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lUs.Name = "lUs";
            this.lUs.Size = new System.Drawing.Size(72, 22);
            this.lUs.Text = "Usuario:  ";
            // 
            // lUsuario
            // 
            this.lUsuario.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lUsuario.Name = "lUsuario";
            this.lUsuario.Size = new System.Drawing.Size(0, 22);
            // 
            // dgvDato
            // 
            this.dgvDato.AllowUserToAddRows = false;
            this.dgvDato.AllowUserToDeleteRows = false;
            this.dgvDato.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDato.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDato.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDato.Location = new System.Drawing.Point(183, 186);
            this.dgvDato.MultiSelect = false;
            this.dgvDato.Name = "dgvDato";
            this.dgvDato.ReadOnly = true;
            this.dgvDato.Size = new System.Drawing.Size(545, 103);
            this.dgvDato.TabIndex = 20;
            this.dgvDato.Visible = false;
            // 
            // bBuscar
            // 
            this.bBuscar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscar.Location = new System.Drawing.Point(638, 59);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(75, 28);
            this.bBuscar.TabIndex = 21;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = true;
            this.bBuscar.Visible = false;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // tbClave
            // 
            this.tbClave.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClave.Location = new System.Drawing.Point(532, 59);
            this.tbClave.Name = "tbClave";
            this.tbClave.Size = new System.Drawing.Size(100, 25);
            this.tbClave.TabIndex = 22;
            this.tbClave.Visible = false;
            this.tbClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbClave_KeyPress);
            // 
            // CSecuencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Diccionario.Properties.Resources.ibm_mobile_database;
            this.ClientSize = new System.Drawing.Size(740, 440);
            this.Controls.Add(this.tbClave);
            this.Controls.Add(this.bBuscar);
            this.Controls.Add(this.dgvDato);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDS);
            this.Controls.Add(this.dgvES);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(756, 478);
            this.MinimumSize = new System.Drawing.Size(756, 478);
            this.Name = "CSecuencial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base de Datos";
            this.Load += new System.EventHandler(this.CSecuencial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvES;
        private System.Windows.Forms.DataGridView dgvDS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog dAbrirCrear;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bGuardar;
        private System.Windows.Forms.ToolStripButton bBajaDato;
        private System.Windows.Forms.ToolStripButton bModificaDato;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel lHora;
        private System.Windows.Forms.ToolStripLabel lFecha;
        private System.Windows.Forms.ToolStripLabel lF;
        private System.Windows.Forms.ToolStripLabel Espacio;
        private System.Windows.Forms.ToolStripLabel lUs;
        private System.Windows.Forms.ToolStripLabel lUsuario;
        private System.Windows.Forms.DataGridView dgvDato;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.TextBox tbClave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mAbrir;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mAbrirConsultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntidadS;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mNRespaldo;
    }
}