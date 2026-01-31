using AggregateReader.Properties;
using System.Windows.Forms;

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
            txtXMLInput = new RichTextBox();
            button1 = new Button();
            treInstanceOverviewHierarchical = new TreeView();
            scTreeviewAndOthers = new SplitContainer();
            grpAggregateContent = new GroupBox();
            chkShowRootEntitiesOnly = new CheckBox();
            groupBox1 = new GroupBox();
            lblVersion = new Label();
            usrEntityViewer = new UsrEntityViewer();
            scMain = new SplitContainer();
            grpXML = new GroupBox();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)scTreeviewAndOthers).BeginInit();
            scTreeviewAndOthers.Panel1.SuspendLayout();
            scTreeviewAndOthers.Panel2.SuspendLayout();
            scTreeviewAndOthers.SuspendLayout();
            grpAggregateContent.SuspendLayout();
            groupBox1.SuspendLayout();
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
            txtXMLInput.Location = new Point(9, 22);
            txtXMLInput.Name = "txtXMLInput";
            txtXMLInput.Size = new Size(186, 477);
            txtXMLInput.TabIndex = 0;
            txtXMLInput.Text = resources.GetString("txtXMLInput.Text");
            txtXMLInput.WordWrap = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(114, 501);
            button1.Name = "button1";
            button1.Size = new Size(78, 23);
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
            treInstanceOverviewHierarchical.Size = new Size(386, 478);
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
            scTreeviewAndOthers.Size = new Size(776, 527);
            scTreeviewAndOthers.SplitterDistance = 395;
            scTreeviewAndOthers.TabIndex = 5;
            // 
            // grpAggregateContent
            // 
            grpAggregateContent.Controls.Add(chkShowRootEntitiesOnly);
            grpAggregateContent.Controls.Add(treInstanceOverviewHierarchical);
            grpAggregateContent.Dock = DockStyle.Fill;
            grpAggregateContent.Location = new Point(0, 0);
            grpAggregateContent.Name = "grpAggregateContent";
            grpAggregateContent.Size = new Size(395, 527);
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
            chkShowRootEntitiesOnly.Size = new Size(209, 19);
            chkShowRootEntitiesOnly.TabIndex = 4;
            chkShowRootEntitiesOnly.Text = "Only show root entities at top level";
            chkShowRootEntitiesOnly.UseVisualStyleBackColor = true;
            chkShowRootEntitiesOnly.CheckedChanged += ChkShowRootEntitiesOnly_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblVersion);
            groupBox1.Controls.Add(usrEntityViewer);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(377, 527);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Instance";
            // 
            // lblVersion
            // 
            lblVersion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVersion.BackColor = SystemColors.Control;
            lblVersion.ForeColor = Color.Silver;
            lblVersion.Location = new Point(329, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(45, 19);
            lblVersion.TabIndex = 5;
            lblVersion.Text = "v0.0.0";
            lblVersion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // usrEntityViewer
            // 
            usrEntityViewer.Dock = DockStyle.Fill;
            usrEntityViewer.Location = new Point(3, 19);
            usrEntityViewer.Name = "usrEntityViewer";
            usrEntityViewer.Size = new Size(371, 505);
            usrEntityViewer.TabIndex = 0;
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
            scMain.SplitterDistance = 198;
            scMain.TabIndex = 6;
            // 
            // grpXML
            // 
            grpXML.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpXML.Controls.Add(btnClear);
            grpXML.Controls.Add(txtXMLInput);
            grpXML.Controls.Add(button1);
            grpXML.Location = new Point(0, 0);
            grpXML.Name = "grpXML";
            grpXML.Size = new Size(198, 530);
            grpXML.TabIndex = 3;
            grpXML.TabStop = false;
            grpXML.Text = "Blueriq XML aggregate/profile export";
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClear.Location = new Point(6, 501);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(69, 23);
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
        private SplitContainer scMain;
        private GroupBox grpXML;
        private Button btnClear;
        private GroupBox grpAggregateContent;
        private GroupBox groupBox1;
        private CheckBox chkShowRootEntitiesOnly;
        private UsrEntityViewer usrEntityViewer;
        private Label lblVersion;
    }
}
