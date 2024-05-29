﻿using System.Windows.Forms;

namespace AggregateReader
{
    partial class AggregateReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AggregateReader));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            txtXMLInput = new RichTextBox();
            button1 = new Button();
            treInstanceOverviewHierarchical = new TreeView();
            scTreeviewAndOthers = new SplitContainer();
            grpAggregateContent = new GroupBox();
            chkShowRootEntitiesOnly = new CheckBox();
            groupBox1 = new GroupBox();
            txtInstanceIdValue = new TextBox();
            txtEntityTypeValue = new TextBox();
            txtRelationValue = new TextBox();
            lblRelation = new Label();
            scAttributesAndOthers = new SplitContainer();
            chkOnlyShowAttributesHavingAValue = new CheckBox();
            dgvAttributes = new DataGridView();
            Attribute = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            Derivation = new DataGridViewTextBoxColumn();
            scRelationsAndParents = new SplitContainer();
            dgvRelations = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            Goto2 = new DataGridViewButtonColumn();
            dgvParents = new DataGridView();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            Goto = new DataGridViewButtonColumn();
            lblEntity = new Label();
            lblId = new Label();
            scMain = new SplitContainer();
            grpXML = new GroupBox();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)scTreeviewAndOthers).BeginInit();
            scTreeviewAndOthers.Panel1.SuspendLayout();
            scTreeviewAndOthers.Panel2.SuspendLayout();
            scTreeviewAndOthers.SuspendLayout();
            grpAggregateContent.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scAttributesAndOthers).BeginInit();
            scAttributesAndOthers.Panel1.SuspendLayout();
            scAttributesAndOthers.Panel2.SuspendLayout();
            scAttributesAndOthers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttributes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scRelationsAndParents).BeginInit();
            scRelationsAndParents.Panel1.SuspendLayout();
            scRelationsAndParents.Panel2.SuspendLayout();
            scRelationsAndParents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRelations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvParents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
            scMain.Panel1.SuspendLayout();
            scMain.Panel2.SuspendLayout();
            scMain.SuspendLayout();
            grpXML.SuspendLayout();
            SuspendLayout();
            // 
            // txtXMLInput
            // 
            txtXMLInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtXMLInput.BorderStyle = BorderStyle.None;
            txtXMLInput.Location = new Point(6, 47);
            txtXMLInput.Name = "txtXMLInput";
            txtXMLInput.Size = new Size(182, 474);
            txtXMLInput.TabIndex = 0;
            txtXMLInput.Text = resources.GetString("txtXMLInput.Text");
            txtXMLInput.WordWrap = false;
            // 
            // button1
            // 
            button1.Location = new Point(9, 18);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Read";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnRead_Click;
            // 
            // treInstanceOverviewHierarchical
            // 
            treInstanceOverviewHierarchical.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treInstanceOverviewHierarchical.BorderStyle = BorderStyle.None;
            treInstanceOverviewHierarchical.Location = new Point(3, 18);
            treInstanceOverviewHierarchical.Name = "treInstanceOverviewHierarchical";
            treInstanceOverviewHierarchical.Size = new Size(391, 478);
            treInstanceOverviewHierarchical.TabIndex = 3;
            treInstanceOverviewHierarchical.AfterSelect += TreAggregateEntities_AfterSelect;
            // 
            // scTreeviewAndOthers
            // 
            scTreeviewAndOthers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scTreeviewAndOthers.Location = new Point(0, 3);
            scTreeviewAndOthers.Name = "scTreeviewAndOthers";
            // 
            // scTreeviewAndOthers.Panel1
            // 
            scTreeviewAndOthers.Panel1.Controls.Add(grpAggregateContent);
            // 
            // scTreeviewAndOthers.Panel2
            // 
            scTreeviewAndOthers.Panel2.Controls.Add(groupBox1);
            scTreeviewAndOthers.Size = new Size(783, 527);
            scTreeviewAndOthers.SplitterDistance = 400;
            scTreeviewAndOthers.TabIndex = 5;
            // 
            // grpAggregateContent
            // 
            grpAggregateContent.Controls.Add(chkShowRootEntitiesOnly);
            grpAggregateContent.Controls.Add(treInstanceOverviewHierarchical);
            grpAggregateContent.Dock = DockStyle.Fill;
            grpAggregateContent.Location = new Point(0, 0);
            grpAggregateContent.Name = "grpAggregateContent";
            grpAggregateContent.Size = new Size(400, 527);
            grpAggregateContent.TabIndex = 4;
            grpAggregateContent.TabStop = false;
            grpAggregateContent.Text = "Instance overview";
            // 
            // chkShowRootEntitiesOnly
            // 
            chkShowRootEntitiesOnly.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkShowRootEntitiesOnly.AutoSize = true;
            chkShowRootEntitiesOnly.Location = new Point(6, 502);
            chkShowRootEntitiesOnly.Name = "chkShowRootEntitiesOnly";
            chkShowRootEntitiesOnly.Size = new Size(208, 19);
            chkShowRootEntitiesOnly.TabIndex = 4;
            chkShowRootEntitiesOnly.Text = "Show root entities only at top level";
            chkShowRootEntitiesOnly.UseVisualStyleBackColor = true;
            chkShowRootEntitiesOnly.CheckedChanged += ChkShowRootEntitiesOnly_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtInstanceIdValue);
            groupBox1.Controls.Add(txtEntityTypeValue);
            groupBox1.Controls.Add(txtRelationValue);
            groupBox1.Controls.Add(lblRelation);
            groupBox1.Controls.Add(scAttributesAndOthers);
            groupBox1.Controls.Add(lblEntity);
            groupBox1.Controls.Add(lblId);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(379, 527);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Instance";
            // 
            // txtInstanceIdValue
            // 
            txtInstanceIdValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInstanceIdValue.BorderStyle = BorderStyle.None;
            txtInstanceIdValue.Location = new Point(81, 49);
            txtInstanceIdValue.Name = "txtInstanceIdValue";
            txtInstanceIdValue.ReadOnly = true;
            txtInstanceIdValue.Size = new Size(298, 16);
            txtInstanceIdValue.TabIndex = 14;
            // 
            // txtEntityTypeValue
            // 
            txtEntityTypeValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEntityTypeValue.BorderStyle = BorderStyle.None;
            txtEntityTypeValue.Location = new Point(81, 33);
            txtEntityTypeValue.Name = "txtEntityTypeValue";
            txtEntityTypeValue.ReadOnly = true;
            txtEntityTypeValue.Size = new Size(298, 16);
            txtEntityTypeValue.TabIndex = 13;
            // 
            // txtRelationValue
            // 
            txtRelationValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRelationValue.BorderStyle = BorderStyle.None;
            txtRelationValue.Location = new Point(81, 18);
            txtRelationValue.Name = "txtRelationValue";
            txtRelationValue.ReadOnly = true;
            txtRelationValue.Size = new Size(298, 16);
            txtRelationValue.TabIndex = 12;
            // 
            // lblRelation
            // 
            lblRelation.AutoSize = true;
            lblRelation.Location = new Point(6, 19);
            lblRelation.Name = "lblRelation";
            lblRelation.Size = new Size(31, 15);
            lblRelation.TabIndex = 9;
            lblRelation.Text = "Path";
            // 
            // scAttributesAndOthers
            // 
            scAttributesAndOthers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scAttributesAndOthers.Location = new Point(6, 67);
            scAttributesAndOthers.Name = "scAttributesAndOthers";
            scAttributesAndOthers.Orientation = Orientation.Horizontal;
            // 
            // scAttributesAndOthers.Panel1
            // 
            scAttributesAndOthers.Panel1.Controls.Add(chkOnlyShowAttributesHavingAValue);
            scAttributesAndOthers.Panel1.Controls.Add(dgvAttributes);
            // 
            // scAttributesAndOthers.Panel2
            // 
            scAttributesAndOthers.Panel2.Controls.Add(scRelationsAndParents);
            scAttributesAndOthers.Size = new Size(367, 454);
            scAttributesAndOthers.SplitterDistance = 225;
            scAttributesAndOthers.TabIndex = 11;
            // 
            // chkOnlyShowAttributesHavingAValue
            // 
            chkOnlyShowAttributesHavingAValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkOnlyShowAttributesHavingAValue.AutoSize = true;
            chkOnlyShowAttributesHavingAValue.Location = new Point(3, 204);
            chkOnlyShowAttributesHavingAValue.Name = "chkOnlyShowAttributesHavingAValue";
            chkOnlyShowAttributesHavingAValue.Size = new Size(214, 19);
            chkOnlyShowAttributesHavingAValue.TabIndex = 12;
            chkOnlyShowAttributesHavingAValue.Text = "Only show attributes having a value";
            chkOnlyShowAttributesHavingAValue.UseVisualStyleBackColor = true;
            chkOnlyShowAttributesHavingAValue.CheckedChanged += ChkOnlyShowAttributesHavingAValue_CheckedChanged;
            // 
            // dgvAttributes
            // 
            dgvAttributes.AllowUserToAddRows = false;
            dgvAttributes.AllowUserToDeleteRows = false;
            dgvAttributes.AllowUserToOrderColumns = true;
            dgvAttributes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 250);
            dgvAttributes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAttributes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAttributes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttributes.BackgroundColor = SystemColors.Window;
            dgvAttributes.BorderStyle = BorderStyle.None;
            dgvAttributes.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAttributes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAttributes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAttributes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttributes.Columns.AddRange(new DataGridViewColumn[] { Attribute, Value, Derivation });
            dgvAttributes.GridColor = SystemColors.Window;
            dgvAttributes.Location = new Point(0, 0);
            dgvAttributes.Name = "dgvAttributes";
            dgvAttributes.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAttributes.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvAttributes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvAttributes.RowTemplate.Height = 20;
            dgvAttributes.Size = new Size(367, 198);
            dgvAttributes.TabIndex = 11;
            // 
            // Attribute
            // 
            Attribute.FillWeight = 111.928932F;
            Attribute.HeaderText = "Attribute";
            Attribute.Name = "Attribute";
            Attribute.ReadOnly = true;
            // 
            // Value
            // 
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            Value.DefaultCellStyle = dataGridViewCellStyle3;
            Value.FillWeight = 111.928932F;
            Value.HeaderText = "Value";
            Value.Name = "Value";
            Value.ReadOnly = true;
            // 
            // Derivation
            // 
            Derivation.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Derivation.FillWeight = 76.1421356F;
            Derivation.HeaderText = "Derivation";
            Derivation.Name = "Derivation";
            Derivation.ReadOnly = true;
            Derivation.Width = 70;
            // 
            // scRelationsAndParents
            // 
            scRelationsAndParents.Dock = DockStyle.Fill;
            scRelationsAndParents.Location = new Point(0, 0);
            scRelationsAndParents.Name = "scRelationsAndParents";
            scRelationsAndParents.Orientation = Orientation.Horizontal;
            // 
            // scRelationsAndParents.Panel1
            // 
            scRelationsAndParents.Panel1.Controls.Add(dgvRelations);
            // 
            // scRelationsAndParents.Panel2
            // 
            scRelationsAndParents.Panel2.Controls.Add(dgvParents);
            scRelationsAndParents.Size = new Size(367, 225);
            scRelationsAndParents.SplitterDistance = 106;
            scRelationsAndParents.TabIndex = 0;
            // 
            // dgvRelations
            // 
            dgvRelations.AllowUserToAddRows = false;
            dgvRelations.AllowUserToDeleteRows = false;
            dgvRelations.AllowUserToOrderColumns = true;
            dgvRelations.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(250, 250, 250);
            dgvRelations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvRelations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRelations.BackgroundColor = SystemColors.Window;
            dgvRelations.BorderStyle = BorderStyle.None;
            dgvRelations.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvRelations.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvRelations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvRelations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRelations.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, Id, Goto2 });
            dgvRelations.Dock = DockStyle.Fill;
            dgvRelations.GridColor = SystemColors.Window;
            dgvRelations.Location = new Point(0, 0);
            dgvRelations.Name = "dgvRelations";
            dgvRelations.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRelations.RowHeadersVisible = false;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvRelations.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvRelations.RowTemplate.Height = 20;
            dgvRelations.Size = new Size(367, 106);
            dgvRelations.TabIndex = 12;
            dgvRelations.CellContentClick += DataGridView_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Relation";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewTextBoxColumn2.HeaderText = "Type";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Id
            // 
            Id.HeaderText = "InstanceId";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Goto2
            // 
            Goto2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Goto2.HeaderText = "";
            Goto2.Name = "Goto2";
            Goto2.ReadOnly = true;
            Goto2.Resizable = DataGridViewTriState.False;
            Goto2.SortMode = DataGridViewColumnSortMode.Automatic;
            Goto2.Width = 67;
            // 
            // dgvParents
            // 
            dgvParents.AllowUserToAddRows = false;
            dgvParents.AllowUserToDeleteRows = false;
            dgvParents.AllowUserToOrderColumns = true;
            dgvParents.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(250, 250, 250);
            dgvParents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            dgvParents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParents.BackgroundColor = SystemColors.Window;
            dgvParents.BorderStyle = BorderStyle.None;
            dgvParents.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvParents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Control;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvParents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvParents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParents.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn5, Goto });
            dgvParents.Dock = DockStyle.Fill;
            dgvParents.GridColor = SystemColors.Window;
            dgvParents.Location = new Point(0, 0);
            dgvParents.Name = "dgvParents";
            dgvParents.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvParents.RowHeadersVisible = false;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgvParents.RowsDefaultCellStyle = dataGridViewCellStyle11;
            dgvParents.RowTemplate.Height = 20;
            dgvParents.Size = new Size(367, 115);
            dgvParents.TabIndex = 13;
            dgvParents.CellContentClick += DataGridView_CellContentClick;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Parent relation";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "ParentId";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // Goto
            // 
            Goto.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Goto.HeaderText = "";
            Goto.Name = "Goto";
            Goto.Resizable = DataGridViewTriState.False;
            Goto.Width = 67;
            // 
            // lblEntity
            // 
            lblEntity.AutoSize = true;
            lblEntity.Location = new Point(6, 34);
            lblEntity.Name = "lblEntity";
            lblEntity.Size = new Size(63, 15);
            lblEntity.TabIndex = 5;
            lblEntity.Text = "Entity type";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(6, 49);
            lblId.Name = "lblId";
            lblId.Size = new Size(61, 15);
            lblId.TabIndex = 7;
            lblId.Text = "InstanceId";
            // 
            // scMain
            // 
            scMain.Dock = DockStyle.Fill;
            scMain.Location = new Point(0, 0);
            scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            scMain.Panel1.Controls.Add(grpXML);
            // 
            // scMain.Panel2
            // 
            scMain.Panel2.Controls.Add(scTreeviewAndOthers);
            scMain.Size = new Size(981, 530);
            scMain.SplitterDistance = 194;
            scMain.TabIndex = 6;
            // 
            // grpXML
            // 
            grpXML.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpXML.Controls.Add(btnClear);
            grpXML.Controls.Add(txtXMLInput);
            grpXML.Controls.Add(button1);
            grpXML.Location = new Point(0, 3);
            grpXML.Name = "grpXML";
            grpXML.Size = new Size(194, 527);
            grpXML.TabIndex = 3;
            grpXML.TabStop = false;
            grpXML.Text = "Blueriq XML aggregate";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(90, 18);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // AggregateReader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 530);
            Controls.Add(scMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AggregateReader";
            Text = "Aggregate reader";
            scTreeviewAndOthers.Panel1.ResumeLayout(false);
            scTreeviewAndOthers.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scTreeviewAndOthers).EndInit();
            scTreeviewAndOthers.ResumeLayout(false);
            grpAggregateContent.ResumeLayout(false);
            grpAggregateContent.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            scAttributesAndOthers.Panel1.ResumeLayout(false);
            scAttributesAndOthers.Panel1.PerformLayout();
            scAttributesAndOthers.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scAttributesAndOthers).EndInit();
            scAttributesAndOthers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttributes).EndInit();
            scRelationsAndParents.Panel1.ResumeLayout(false);
            scRelationsAndParents.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scRelationsAndParents).EndInit();
            scRelationsAndParents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRelations).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvParents).EndInit();
            scMain.Panel1.ResumeLayout(false);
            scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
            scMain.ResumeLayout(false);
            grpXML.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox txtXMLInput;
        private Button button1;
        private TreeView treInstanceOverviewHierarchical;
        private SplitContainer scTreeviewAndOthers;
        private Label lblId;
        private Label lblEntity;
        private Label lblRelation;
        private DataGridView dgvAttributes;
        private SplitContainer scAttributesAndOthers;
        private DataGridView dgvRelations;
        private DataGridView dgvParents;
        private SplitContainer scRelationsAndParents;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewButtonColumn Goto2;
        private SplitContainer scMain;
        private GroupBox grpXML;
        private Button btnClear;
        private GroupBox grpAggregateContent;
        private GroupBox groupBox1;
        private CheckBox chkShowRootEntitiesOnly;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewButtonColumn Goto;
        private TextBox txtRelationValue;
        private TextBox txtInstanceIdValue;
        private TextBox txtEntityTypeValue;
        private DataGridViewTextBoxColumn Attribute;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn Derivation;
        private CheckBox chkOnlyShowAttributesHavingAValue;
    }
}
