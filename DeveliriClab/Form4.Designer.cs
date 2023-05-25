namespace DeveliriClab
{
    partial class Form4
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.С3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deliteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optinalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.C,
            this.C2,
            this.Column2,
            this.С3,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(28, 44);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(441, 376);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "delivery number";
            this.Column1.Name = "Column1";
            // 
            // C
            // 
            this.C.HeaderText = "id_user";
            this.C.Name = "C";
            // 
            // C2
            // 
            this.C2.HeaderText = "id_company";
            this.C2.Name = "C2";
            this.C2.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "delivery date";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // С3
            // 
            this.С3.HeaderText = "id_cargo";
            this.С3.Name = "С3";
            this.С3.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "status";
            this.Column3.Name = "Column3";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(194, 428);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(234, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "delivery information";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(69, 428);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(97, 26);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.добавитьToolStripMenuItem.Text = "Add";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deliteToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(105, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // deliteToolStripMenuItem
            // 
            this.deliteToolStripMenuItem.Name = "deliteToolStripMenuItem";
            this.deliteToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.deliteToolStripMenuItem.Text = "Delite";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Black;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optinalToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(496, 24);
            this.menuStrip2.TabIndex = 7;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.BackColor = System.Drawing.Color.Black;
            this.addToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Control;
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // deliteToolStripMenuItem1
            // 
            this.deliteToolStripMenuItem1.BackColor = System.Drawing.Color.Black;
            this.deliteToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Control;
            this.deliteToolStripMenuItem1.Name = "deliteToolStripMenuItem1";
            this.deliteToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.deliteToolStripMenuItem1.Text = "Delite";
            this.deliteToolStripMenuItem1.Click += new System.EventHandler(this.deliteToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.editToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // infoUserToolStripMenuItem
            // 
            this.infoUserToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.infoUserToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.infoUserToolStripMenuItem.Name = "infoUserToolStripMenuItem";
            this.infoUserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.infoUserToolStripMenuItem.Text = "Info user";
            this.infoUserToolStripMenuItem.Click += new System.EventHandler(this.infoUserToolStripMenuItem_Click);
            // 
            // optinalToolStripMenuItem
            // 
            this.optinalToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.optinalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.deliteToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.infoUserToolStripMenuItem});
            this.optinalToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.optinalToolStripMenuItem.Name = "optinalToolStripMenuItem";
            this.optinalToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optinalToolStripMenuItem.Text = "Options";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(496, 469);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Button button2;
        private Button button1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem deliteToolStripMenuItem;
        private MenuStrip menuStrip2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn C;
        private DataGridViewTextBoxColumn C2;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn С3;
        private DataGridViewTextBoxColumn Column3;
        private ToolStripMenuItem optinalToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem1;
        private ToolStripMenuItem deliteToolStripMenuItem1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem infoUserToolStripMenuItem;
    }
}