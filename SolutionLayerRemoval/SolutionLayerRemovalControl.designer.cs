namespace SolutionLayerRemoval
{
    partial class SolutionLayerRemovalControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionLayerRemovalControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadSolutions = new System.Windows.Forms.ToolStripButton();
            this.tsbLoadUnmanagedComponents = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRemoveActiveCustomizations = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelOperation = new System.Windows.Forms.ToolStripButton();
            this.lboxSolutions = new System.Windows.Forms.ListBox();
            this.dataGridLayers = new System.Windows.Forms.DataGridView();
            this.ComponentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colComponentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComponentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPublisherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchSolution = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSeparator1,
            this.tsbLoadSolutions,
            this.tsbLoadUnmanagedComponents,
            this.toolStripSeparator1,
            this.tsbtnRemoveActiveCustomizations,
            this.tsbCancelOperation});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1187, 39);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbLoadSolutions
            // 
            this.tsbLoadSolutions.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadSolutions.Image")));
            this.tsbLoadSolutions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbLoadSolutions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLoadSolutions.Name = "tsbLoadSolutions";
            this.tsbLoadSolutions.Size = new System.Drawing.Size(121, 36);
            this.tsbLoadSolutions.Text = "Load Solutions";
            this.tsbLoadSolutions.Click += new System.EventHandler(this.btnLoadSolutions_Click);
            // 
            // tsbLoadUnmanagedComponents
            // 
            this.tsbLoadUnmanagedComponents.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadUnmanagedComponents.Image")));
            this.tsbLoadUnmanagedComponents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbLoadUnmanagedComponents.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLoadUnmanagedComponents.Name = "tsbLoadUnmanagedComponents";
            this.tsbLoadUnmanagedComponents.Size = new System.Drawing.Size(209, 36);
            this.tsbLoadUnmanagedComponents.Text = "Load Unmanaged Components";
            this.tsbLoadUnmanagedComponents.Click += new System.EventHandler(this.tsbtnLoadUmanagedComponents_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnRemoveActiveCustomizations
            // 
            this.tsbtnRemoveActiveCustomizations.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRemoveActiveCustomizations.Image")));
            this.tsbtnRemoveActiveCustomizations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemoveActiveCustomizations.Name = "tsbtnRemoveActiveCustomizations";
            this.tsbtnRemoveActiveCustomizations.Size = new System.Drawing.Size(199, 36);
            this.tsbtnRemoveActiveCustomizations.Text = "Remove Active Customizations";
            this.tsbtnRemoveActiveCustomizations.Click += new System.EventHandler(this.tsbtnRemoveActiveCustomizations_Click);
            // 
            // tsbCancelOperation
            // 
            this.tsbCancelOperation.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelOperation.Image")));
            this.tsbCancelOperation.Name = "tsbCancelOperation";
            this.tsbCancelOperation.Size = new System.Drawing.Size(127, 36);
            this.tsbCancelOperation.Text = "Cancel Operation";
            this.tsbCancelOperation.ToolTipText = "Cancel Operation";
            this.tsbCancelOperation.Click += new System.EventHandler(this.tsbCancelOperation_Click);
            // 
            // lboxSolutions
            // 
            this.lboxSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lboxSolutions.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lboxSolutions.FormattingEnabled = true;
            this.lboxSolutions.HorizontalScrollbar = true;
            this.lboxSolutions.ItemHeight = 16;
            this.lboxSolutions.Location = new System.Drawing.Point(0, 23);
            this.lboxSolutions.Name = "lboxSolutions";
            this.lboxSolutions.Size = new System.Drawing.Size(318, 557);
            this.lboxSolutions.Sorted = true;
            this.lboxSolutions.TabIndex = 5;
            this.lboxSolutions.DoubleClick += new System.EventHandler(this.lboxSolutions_DoubleClick);
            // 
            // dataGridLayers
            // 
            this.dataGridLayers.AllowUserToAddRows = false;
            this.dataGridLayers.AllowUserToDeleteRows = false;
            this.dataGridLayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridLayers.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridLayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridLayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComponentId,
            this.Selected,
            this.colComponentName,
            this.colComponentType,
            this.colEntityName,
            this.colOrder,
            this.colPublisherName});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridLayers.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLayers.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridLayers.Location = new System.Drawing.Point(0, 0);
            this.dataGridLayers.Name = "dataGridLayers";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridLayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridLayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridLayers.Size = new System.Drawing.Size(865, 580);
            this.dataGridLayers.TabIndex = 9;
            this.dataGridLayers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridLayers_CellClick);
            // 
            // ComponentId
            // 
            this.ComponentId.HeaderText = "";
            this.ComponentId.Name = "ComponentId";
            this.ComponentId.Visible = false;
            // 
            // Selected
            // 
            this.Selected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Selected.FillWeight = 5F;
            this.Selected.HeaderText = "";
            this.Selected.Name = "Selected";
            this.Selected.Width = 40;
            // 
            // colComponentName
            // 
            this.colComponentName.FillWeight = 15.62737F;
            this.colComponentName.HeaderText = "Component Name";
            this.colComponentName.Name = "colComponentName";
            this.colComponentName.ReadOnly = true;
            // 
            // colComponentType
            // 
            this.colComponentType.FillWeight = 15.62737F;
            this.colComponentType.HeaderText = "Component Type";
            this.colComponentType.Name = "colComponentType";
            // 
            // colEntityName
            // 
            this.colEntityName.FillWeight = 25F;
            this.colEntityName.HeaderText = "Entity Name";
            this.colEntityName.Name = "colEntityName";
            this.colEntityName.ReadOnly = true;
            // 
            // colOrder
            // 
            this.colOrder.FillWeight = 10F;
            this.colOrder.HeaderText = "Order";
            this.colOrder.Name = "colOrder";
            this.colOrder.ReadOnly = true;
            // 
            // colPublisherName
            // 
            this.colPublisherName.FillWeight = 26.181F;
            this.colPublisherName.HeaderText = "Publisher Name";
            this.colPublisherName.Name = "colPublisherName";
            this.colPublisherName.ReadOnly = true;
            // 
            // txtSearchSolution
            // 
            this.txtSearchSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchSolution.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtSearchSolution.Location = new System.Drawing.Point(0, 0);
            this.txtSearchSolution.Name = "txtSearchSolution";
            this.txtSearchSolution.Size = new System.Drawing.Size(318, 23);
            this.txtSearchSolution.TabIndex = 12;
            this.txtSearchSolution.Text = "Search here...";
            this.txtSearchSolution.TextChanged += new System.EventHandler(this.txtSearchSolution_TextChanged);
            this.txtSearchSolution.Enter += new System.EventHandler(this.txtSearchSolution_Enter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lboxSolutions);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearchSolution);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridLayers);
            this.splitContainer1.Size = new System.Drawing.Size(1187, 580);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 13;
            // 
            // SolutionLayerRemovalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "SolutionLayerRemovalControl";
            this.Size = new System.Drawing.Size(1187, 619);
            this.Load += new System.EventHandler(this.SolutionLayerRemovalControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLayers)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbCancelOperation;
        private System.Windows.Forms.ToolStripButton tsbLoadUnmanagedComponents;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnRemoveActiveCustomizations;
        private System.Windows.Forms.ListBox lboxSolutions;
        private System.Windows.Forms.DataGridView dataGridLayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComponentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComponentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPublisherName;
        private System.Windows.Forms.ToolStripButton tsbLoadSolutions;
        private System.Windows.Forms.TextBox txtSearchSolution;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
