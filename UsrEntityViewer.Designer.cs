using System.Windows.Forms;

namespace AggregateReader
{
    partial class UsrEntityViewer
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
            lblEntity = new Label();
            lblId = new Label();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            Goto = new DataGridViewButtonColumn();
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
            SuspendLayout();
            // 
            // txtInstanceIdValue
            // 
            txtInstanceIdValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInstanceIdValue.BorderStyle = BorderStyle.None;
            txtInstanceIdValue.Location = new Point(75, 30);
            txtInstanceIdValue.Name = "txtInstanceIdValue";
            txtInstanceIdValue.ReadOnly = true;
            txtInstanceIdValue.Size = new Size(348, 16);
            txtInstanceIdValue.TabIndex = 14;
            // 
            // txtEntityTypeValue
            // 
            txtEntityTypeValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEntityTypeValue.BorderStyle = BorderStyle.None;
            txtEntityTypeValue.Location = new Point(75, 14);
            txtEntityTypeValue.Name = "txtEntityTypeValue";
            txtEntityTypeValue.ReadOnly = true;
            txtEntityTypeValue.Size = new Size(348, 16);
            txtEntityTypeValue.TabIndex = 13;
            // 
            // txtRelationValue
            // 
            txtRelationValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRelationValue.BorderStyle = BorderStyle.None;
            txtRelationValue.Location = new Point(75, 0);
            txtRelationValue.Name = "txtRelationValue";
            txtRelationValue.ReadOnly = true;
            txtRelationValue.Size = new Size(348, 16);
            txtRelationValue.TabIndex = 12;
            // 
            // lblRelation
            // 
            lblRelation.AutoSize = true;
            lblRelation.Location = new Point(0, 0);
            lblRelation.Name = "lblRelation";
            lblRelation.Size = new Size(31, 15);
            lblRelation.TabIndex = 9;
            lblRelation.Text = "Path";
            // 
            // scAttributesAndOthers
            // 
            scAttributesAndOthers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scAttributesAndOthers.Location = new Point(0, 48);
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
            scAttributesAndOthers.Size = new Size(423, 435);
            scAttributesAndOthers.SplitterDistance = 239;
            scAttributesAndOthers.TabIndex = 11;
            // 
            // chkOnlyShowAttributesHavingAValue
            // 
            chkOnlyShowAttributesHavingAValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkOnlyShowAttributesHavingAValue.AutoSize = true;
            chkOnlyShowAttributesHavingAValue.Location = new Point(3, 218);
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
            dgvAttributes.Size = new Size(423, 212);
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
            scRelationsAndParents.Size = new Size(423, 192);
            scRelationsAndParents.SplitterDistance = 89;
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
            dgvRelations.Size = new Size(423, 89);
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
            Goto2.Width = 50;
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
            dgvParents.Size = new Size(423, 99);
            dgvParents.TabIndex = 13;
            dgvParents.CellContentClick += DataGridView_CellContentClick;
            // 
            // lblEntity
            // 
            lblEntity.AutoSize = true;
            lblEntity.Location = new Point(0, 15);
            lblEntity.Name = "lblEntity";
            lblEntity.Size = new Size(63, 15);
            lblEntity.TabIndex = 5;
            lblEntity.Text = "Entity type";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(0, 30);
            lblId.Name = "lblId";
            lblId.Size = new Size(61, 15);
            lblId.TabIndex = 7;
            lblId.Text = "InstanceId";
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
            Goto.Width = 50;
            // 
            // UsrEntityViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtInstanceIdValue);
            Controls.Add(txtEntityTypeValue);
            Controls.Add(lblRelation);
            Controls.Add(txtRelationValue);
            Controls.Add(lblId);
            Controls.Add(lblEntity);
            Controls.Add(scAttributesAndOthers);
            Name = "UsrEntityViewer";
            Size = new Size(423, 486);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblId;
        private Label lblEntity;
        private Label lblRelation;
        private DataGridView dgvAttributes;
        private SplitContainer scAttributesAndOthers;
        private DataGridView dgvRelations;
        private DataGridView dgvParents;
        private SplitContainer scRelationsAndParents;
        private TextBox txtRelationValue;
        private TextBox txtInstanceIdValue;
        private TextBox txtEntityTypeValue;
        private DataGridViewTextBoxColumn Attribute;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn Derivation;
        private CheckBox chkOnlyShowAttributesHavingAValue;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewButtonColumn Goto2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewButtonColumn Goto;
    }
}
