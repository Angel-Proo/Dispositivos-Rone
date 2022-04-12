namespace Rone_2._0.Presentacion
{
    partial class Monitoreo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.iconButtonLog = new FontAwesome.Sharp.IconButton();
            this.iconButtonReporte = new FontAwesome.Sharp.IconButton();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panel1.Controls.Add(this.iconCurrentChildForm);
            this.panel1.Controls.Add(this.labelTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 70);
            this.panel1.TabIndex = 0;
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 70;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(303, 0);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(70, 70);
            this.iconCurrentChildForm.TabIndex = 3;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Helvetica Condensed", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitulo.Location = new System.Drawing.Point(389, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(171, 46);
            this.labelTitulo.TabIndex = 2;
            this.labelTitulo.Text = "Monitoreo";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panelMenu.Controls.Add(this.iconButtonLog);
            this.panelMenu.Controls.Add(this.iconButtonReporte);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 70);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(150, 380);
            this.panelMenu.TabIndex = 1;
            // 
            // iconButtonLog
            // 
            this.iconButtonLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButtonLog.FlatAppearance.BorderSize = 0;
            this.iconButtonLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonLog.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.iconButtonLog.IconChar = FontAwesome.Sharp.IconChar.Tasks;
            this.iconButtonLog.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconButtonLog.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonLog.Location = new System.Drawing.Point(0, 90);
            this.iconButtonLog.Name = "iconButtonLog";
            this.iconButtonLog.Size = new System.Drawing.Size(150, 90);
            this.iconButtonLog.TabIndex = 1;
            this.iconButtonLog.Text = "Event Log";
            this.iconButtonLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonLog.UseVisualStyleBackColor = false;
            this.iconButtonLog.Click += new System.EventHandler(this.iconButtonLog_Click);
            // 
            // iconButtonReporte
            // 
            this.iconButtonReporte.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButtonReporte.FlatAppearance.BorderSize = 0;
            this.iconButtonReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButtonReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonReporte.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.iconButtonReporte.IconChar = FontAwesome.Sharp.IconChar.File;
            this.iconButtonReporte.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconButtonReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonReporte.Location = new System.Drawing.Point(0, 0);
            this.iconButtonReporte.Name = "iconButtonReporte";
            this.iconButtonReporte.Size = new System.Drawing.Size(150, 90);
            this.iconButtonReporte.TabIndex = 0;
            this.iconButtonReporte.Text = "Reporte";
            this.iconButtonReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButtonReporte.UseVisualStyleBackColor = false;
            this.iconButtonReporte.Click += new System.EventHandler(this.iconButtonReporte_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point(150, 70);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(650, 380);
            this.panelInfo.TabIndex = 2;
            // 
            // Monitoreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Monitoreo";
            this.Text = "Monitoreo";
            this.Load += new System.EventHandler(this.Monitoreo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton iconButtonReporte;
        private FontAwesome.Sharp.IconButton iconButtonLog;
        private System.Windows.Forms.Panel panelInfo;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label labelTitulo;
    }
}