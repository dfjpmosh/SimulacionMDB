namespace Diccionario
{
    partial class FormSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSQL));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mImportar = new System.Windows.Forms.ToolStripMenuItem();
            this.dAbrir = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bImportar = new System.Windows.Forms.Button();
            this.tcImpCompleta = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bAbrirBD = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.tbTDestino = new System.Windows.Forms.TextBox();
            this.tbConsulta = new System.Windows.Forms.TextBox();
            this.bImportarC = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvInnerJoin = new System.Windows.Forms.DataGridView();
            this.tbInnerJoin = new System.Windows.Forms.TextBox();
            this.bInnerJoin = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvCrossJoin = new System.Windows.Forms.DataGridView();
            this.tbCrossJoin = new System.Windows.Forms.TextBox();
            this.bCrossJoin = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvLeftJoin = new System.Windows.Forms.DataGridView();
            this.tbLeftJoin = new System.Windows.Forms.TextBox();
            this.bLeftJoin = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tcImpCompleta.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInnerJoin)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrossJoin)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeftJoin)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.RoyalBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mImportar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(740, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mImportar
            // 
            this.mImportar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mImportar.Name = "mImportar";
            this.mImportar.Size = new System.Drawing.Size(124, 23);
            this.mImportar.Text = "Importar Datos";
            this.mImportar.Click += new System.EventHandler(this.mImportar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "BD Destino";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "BD Origen";
            // 
            // bImportar
            // 
            this.bImportar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bImportar.Location = new System.Drawing.Point(638, 39);
            this.bImportar.Name = "bImportar";
            this.bImportar.Size = new System.Drawing.Size(88, 27);
            this.bImportar.TabIndex = 3;
            this.bImportar.Text = "Importar";
            this.bImportar.UseVisualStyleBackColor = true;
            this.bImportar.Click += new System.EventHandler(this.bImportar_Click);
            // 
            // tcImpCompleta
            // 
            this.tcImpCompleta.Controls.Add(this.tabPage1);
            this.tcImpCompleta.Controls.Add(this.tabPage2);
            this.tcImpCompleta.Controls.Add(this.tabPage3);
            this.tcImpCompleta.Controls.Add(this.tabPage4);
            this.tcImpCompleta.Controls.Add(this.tabPage5);
            this.tcImpCompleta.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcImpCompleta.Location = new System.Drawing.Point(0, -1);
            this.tcImpCompleta.Name = "tcImpCompleta";
            this.tcImpCompleta.SelectedIndex = 0;
            this.tcImpCompleta.Size = new System.Drawing.Size(740, 281);
            this.tcImpCompleta.TabIndex = 4;
            this.tcImpCompleta.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcImpCompleta_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::Diccionario.Properties.Resources.ibm_mobile_database;
            this.tabPage1.Controls.Add(this.bImportar);
            this.tabPage1.Controls.Add(this.bAbrirBD);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(732, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Imp. X Tablas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bAbrirBD
            // 
            this.bAbrirBD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAbrirBD.Location = new System.Drawing.Point(638, 6);
            this.bAbrirBD.Name = "bAbrirBD";
            this.bAbrirBD.Size = new System.Drawing.Size(88, 27);
            this.bAbrirBD.TabIndex = 5;
            this.bAbrirBD.Text = "Abrir BD";
            this.bAbrirBD.UseVisualStyleBackColor = true;
            this.bAbrirBD.Click += new System.EventHandler(this.mImportar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(146, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "BD Origen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "BD Destino";
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::Diccionario.Properties.Resources.ibm_mobile_database;
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.tbTDestino);
            this.tabPage2.Controls.Add(this.tbConsulta);
            this.tabPage2.Controls.Add(this.bImportarC);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(732, 249);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Imp. X Consulta";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(92, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(318, 14);
            this.label14.TabIndex = 23;
            this.label14.Text = "SELECT * FROM BDORIGEN.TABLA WHERE CAMPO = DATO";
            // 
            // tbTDestino
            // 
            this.tbTDestino.Location = new System.Drawing.Point(4, 53);
            this.tbTDestino.Name = "tbTDestino";
            this.tbTDestino.Size = new System.Drawing.Size(224, 26);
            this.tbTDestino.TabIndex = 18;
            this.tbTDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbConsulta
            // 
            this.tbConsulta.Location = new System.Drawing.Point(4, 117);
            this.tbConsulta.Name = "tbConsulta";
            this.tbConsulta.Size = new System.Drawing.Size(477, 26);
            this.tbConsulta.TabIndex = 17;
            this.tbConsulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bImportarC
            // 
            this.bImportarC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bImportarC.Location = new System.Drawing.Point(641, 3);
            this.bImportarC.Name = "bImportarC";
            this.bImportarC.Size = new System.Drawing.Size(88, 27);
            this.bImportarC.TabIndex = 7;
            this.bImportarC.Text = "Importar";
            this.bImportarC.UseVisualStyleBackColor = true;
            this.bImportarC.Click += new System.EventHandler(this.bImportarC_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "BD Origen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "BD Destino";
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = global::Diccionario.Properties.Resources.ibm_mobile_database;
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.dgvInnerJoin);
            this.tabPage3.Controls.Add(this.tbInnerJoin);
            this.tabPage3.Controls.Add(this.bInnerJoin);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(732, 249);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "C. Inner Join";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(212, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(377, 14);
            this.label8.TabIndex = 22;
            this.label8.Text = "SELECT * FROM BD.tabla1 INNER JOIN BD.tabla2 ON tabla1.col = tabla2.col";
            // 
            // dgvInnerJoin
            // 
            this.dgvInnerJoin.AllowUserToAddRows = false;
            this.dgvInnerJoin.AllowUserToDeleteRows = false;
            this.dgvInnerJoin.BackgroundColor = System.Drawing.Color.White;
            this.dgvInnerJoin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInnerJoin.Location = new System.Drawing.Point(10, 77);
            this.dgvInnerJoin.Name = "dgvInnerJoin";
            this.dgvInnerJoin.ReadOnly = true;
            this.dgvInnerJoin.Size = new System.Drawing.Size(716, 166);
            this.dgvInnerJoin.TabIndex = 21;
            // 
            // tbInnerJoin
            // 
            this.tbInnerJoin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnerJoin.Location = new System.Drawing.Point(10, 45);
            this.tbInnerJoin.Name = "tbInnerJoin";
            this.tbInnerJoin.Size = new System.Drawing.Size(716, 22);
            this.tbInnerJoin.TabIndex = 20;
            this.tbInnerJoin.Text = "SELECT * FROM BD.tabla1 INNER JOIN BD.tabla2 ON tabla1.col = tabla2.col";
            this.tbInnerJoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bInnerJoin
            // 
            this.bInnerJoin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bInnerJoin.Location = new System.Drawing.Point(641, 3);
            this.bInnerJoin.Name = "bInnerJoin";
            this.bInnerJoin.Size = new System.Drawing.Size(88, 27);
            this.bInnerJoin.TabIndex = 18;
            this.bInnerJoin.Text = "Aceptar";
            this.bInnerJoin.UseVisualStyleBackColor = true;
            this.bInnerJoin.Click += new System.EventHandler(this.bInnerJoin_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 19);
            this.label7.TabIndex = 19;
            this.label7.Text = "Consulta Inner Join";
            // 
            // tabPage4
            // 
            this.tabPage4.BackgroundImage = global::Diccionario.Properties.Resources.ibm_mobile_database;
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.dgvCrossJoin);
            this.tabPage4.Controls.Add(this.tbCrossJoin);
            this.tabPage4.Controls.Add(this.bCrossJoin);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(732, 249);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "C. Cross Join";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(209, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(381, 14);
            this.label9.TabIndex = 27;
            this.label9.Text = "SELECT * FROM BD.Tabla1 CROSS JOIN BD.Tabla2 ON tabla1.col = tabla2.col";
            // 
            // dgvCrossJoin
            // 
            this.dgvCrossJoin.AllowUserToAddRows = false;
            this.dgvCrossJoin.AllowUserToDeleteRows = false;
            this.dgvCrossJoin.BackgroundColor = System.Drawing.Color.White;
            this.dgvCrossJoin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCrossJoin.Location = new System.Drawing.Point(7, 78);
            this.dgvCrossJoin.Name = "dgvCrossJoin";
            this.dgvCrossJoin.ReadOnly = true;
            this.dgvCrossJoin.Size = new System.Drawing.Size(716, 166);
            this.dgvCrossJoin.TabIndex = 26;
            // 
            // tbCrossJoin
            // 
            this.tbCrossJoin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCrossJoin.Location = new System.Drawing.Point(7, 46);
            this.tbCrossJoin.Name = "tbCrossJoin";
            this.tbCrossJoin.Size = new System.Drawing.Size(716, 22);
            this.tbCrossJoin.TabIndex = 25;
            this.tbCrossJoin.Text = "SELECT * FROM BD.Tabla1 CROSS JOIN BD.Tabla2 ON tabla1.col = tabla2.col";
            this.tbCrossJoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bCrossJoin
            // 
            this.bCrossJoin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCrossJoin.Location = new System.Drawing.Point(638, 4);
            this.bCrossJoin.Name = "bCrossJoin";
            this.bCrossJoin.Size = new System.Drawing.Size(88, 27);
            this.bCrossJoin.TabIndex = 23;
            this.bCrossJoin.Text = "Aceptar";
            this.bCrossJoin.UseVisualStyleBackColor = true;
            this.bCrossJoin.Click += new System.EventHandler(this.bCrossJoin_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 19);
            this.label10.TabIndex = 24;
            this.label10.Text = "Consulta Cross Join";
            // 
            // tabPage5
            // 
            this.tabPage5.BackgroundImage = global::Diccionario.Properties.Resources.ibm_mobile_database;
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.dgvLeftJoin);
            this.tabPage5.Controls.Add(this.tbLeftJoin);
            this.tabPage5.Controls.Add(this.bLeftJoin);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Location = new System.Drawing.Point(4, 28);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(732, 249);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "C. Left Join";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(209, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(377, 14);
            this.label11.TabIndex = 32;
            this.label11.Text = "SELECT * FROM BD.Tabla1 LEFT JOIN BD.Tabla2 ON tabla1.col = tabla2.col";
            // 
            // dgvLeftJoin
            // 
            this.dgvLeftJoin.AllowUserToAddRows = false;
            this.dgvLeftJoin.AllowUserToDeleteRows = false;
            this.dgvLeftJoin.BackgroundColor = System.Drawing.Color.White;
            this.dgvLeftJoin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeftJoin.Location = new System.Drawing.Point(7, 78);
            this.dgvLeftJoin.Name = "dgvLeftJoin";
            this.dgvLeftJoin.ReadOnly = true;
            this.dgvLeftJoin.Size = new System.Drawing.Size(716, 166);
            this.dgvLeftJoin.TabIndex = 31;
            // 
            // tbLeftJoin
            // 
            this.tbLeftJoin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLeftJoin.Location = new System.Drawing.Point(7, 46);
            this.tbLeftJoin.Name = "tbLeftJoin";
            this.tbLeftJoin.Size = new System.Drawing.Size(716, 22);
            this.tbLeftJoin.TabIndex = 30;
            this.tbLeftJoin.Text = "SELECT * FROM BD.Tabla1 LEFT JOIN BD.Tabla2 ON tabla1.col = tabla2.col";
            this.tbLeftJoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bLeftJoin
            // 
            this.bLeftJoin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLeftJoin.Location = new System.Drawing.Point(638, 4);
            this.bLeftJoin.Name = "bLeftJoin";
            this.bLeftJoin.Size = new System.Drawing.Size(88, 27);
            this.bLeftJoin.TabIndex = 28;
            this.bLeftJoin.Text = "Aceptar";
            this.bLeftJoin.UseVisualStyleBackColor = true;
            this.bLeftJoin.Click += new System.EventHandler(this.bLeftJoin_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 19);
            this.label12.TabIndex = 29;
            this.label12.Text = "Consulta Left Join";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(100, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 14);
            this.label13.TabIndex = 24;
            this.label13.Text = "BDDESTINO.TABLA";
            // 
            // FormSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Diccionario.Properties.Resources.ibm_mobile_database;
            this.ClientSize = new System.Drawing.Size(740, 282);
            this.Controls.Add(this.tcImpCompleta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSQL_FormClosing);
            this.Load += new System.EventHandler(this.FormSQL_Load);
            this.ClientSizeChanged += new System.EventHandler(this.FormSQL_ClientSizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tcImpCompleta.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInnerJoin)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrossJoin)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeftJoin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mImportar;
        private System.Windows.Forms.OpenFileDialog dAbrir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bImportar;
        private System.Windows.Forms.TabControl tcImpCompleta;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bAbrirBD;
        private System.Windows.Forms.Button bImportarC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbConsulta;
        private System.Windows.Forms.TextBox tbTDestino;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvInnerJoin;
        private System.Windows.Forms.TextBox tbInnerJoin;
        private System.Windows.Forms.Button bInnerJoin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvCrossJoin;
        private System.Windows.Forms.TextBox tbCrossJoin;
        private System.Windows.Forms.Button bCrossJoin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvLeftJoin;
        private System.Windows.Forms.TextBox tbLeftJoin;
        private System.Windows.Forms.Button bLeftJoin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}