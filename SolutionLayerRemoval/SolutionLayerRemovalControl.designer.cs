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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadSolutions = new System.Windows.Forms.ToolStripButton();
            this.tsbLoadUnmanagedComponents = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRemoveActiveCustomizations = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelOperation = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lboxSolutions = new System.Windows.Forms.ListBox();
            this.dataGridLayers = new System.Windows.Forms.DataGridView();
            this.ComponentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colComponentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComponentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPublisherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLayers)).BeginInit();
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
            this.tsbLoadSolutions.Image = global::SolutionLayerRemoval.Properties.Resources.loader;
            this.tsbLoadSolutions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbLoadSolutions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLoadSolutions.Name = "tsbLoadSolutions";
            this.tsbLoadSolutions.Size = new System.Drawing.Size(121, 36);
            this.tsbLoadSolutions.Text = "Load Solutions";
            this.tsbLoadSolutions.Click += new System.EventHandler(this.btnLoadSolutions_Click);
            // 
            // tsbLoadUnmanagedComponents
            // 
            this.tsbLoadUnmanagedComponents.Image = global::SolutionLayerRemoval.Properties.Resources.loader;
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
            this.tsbtnRemoveActiveCustomizations.Image = global::SolutionLayerRemoval.Properties.Resources.erase;
            this.tsbtnRemoveActiveCustomizations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemoveActiveCustomizations.Name = "tsbtnRemoveActiveCustomizations";
            this.tsbtnRemoveActiveCustomizations.Size = new System.Drawing.Size(199, 36);
            this.tsbtnRemoveActiveCustomizations.Text = "Remove Active Customizations";
            this.tsbtnRemoveActiveCustomizations.Click += new System.EventHandler(this.tsbtnRemoveActiveCustomizations_Click);
            // 
            // tsbCancelOperation
            // 
            this.tsbCancelOperation.Image = global::SolutionLayerRemoval.Properties.Resources.power_button;
            this.tsbCancelOperation.Name = "tsbCancelOperation";
            this.tsbCancelOperation.Size = new System.Drawing.Size(127, 36);
            this.tsbCancelOperation.Text = "Cancel Operation";
            this.tsbCancelOperation.ToolTipText = "Cancel Operation";
            this.tsbCancelOperation.Click += new System.EventHandler(this.tsbCancelOperation_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(253, 39);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 580);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // lboxSolutions
            // 
            this.lboxSolutions.Dock = System.Windows.Forms.DockStyle.Left;
            this.lboxSolutions.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lboxSolutions.FormattingEnabled = true;
            this.lboxSolutions.HorizontalScrollbar = true;
            this.lboxSolutions.ItemHeight = 16;
            this.lboxSolutions.Location = new System.Drawing.Point(0, 39);
            this.lboxSolutions.Name = "lboxSolutions";
            this.lboxSolutions.Size = new System.Drawing.Size(253, 580);
            this.lboxSolutions.Sorted = true;
            this.lboxSolutions.TabIndex = 5;
            // 
            // dataGridLayers
            // 
            this.dataGridLayers.AllowUserToAddRows = false;
            this.dataGridLayers.AllowUserToDeleteRows = false;
            this.dataGridLayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridLayers.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridLayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridLayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComponentId,
            this.Selected,
            this.colComponentName,
            this.colComponentType,
            this.colEntityName,
            this.colOrder,
            this.colPublisherName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridLayers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLayers.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridLayers.Location = new System.Drawing.Point(256, 39);
            this.dataGridLayers.MultiSelect = false;
            this.dataGridLayers.Name = "dataGridLayers";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridLayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridLayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridLayers.Size = new System.Drawing.Size(931, 580);
            this.dataGridLayers.TabIndex = 9;
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
            // SolutionLayerRemovalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridLayers);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lboxSolutions);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "SolutionLayerRemovalControl";
            this.Size = new System.Drawing.Size(1187, 619);
            this.Load += new System.EventHandler(this.SolutionLayerRemovalControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbCancelOperation;
        private System.Windows.Forms.ToolStripButton tsbLoadUnmanagedComponents;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.Splitter splitter1;
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
    }
}
