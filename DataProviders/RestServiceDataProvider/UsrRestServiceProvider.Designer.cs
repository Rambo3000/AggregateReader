using AggregateReader.Properties;

namespace AggregateReader
{
    partial class UsrRestServiceProvider
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnGetFromUrl = new Button();
            urlSelector = new ComboBox();
            txtId = new TextBox();
            label1 = new Label();
            lblId = new Label();
            btnEdit = new Button();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // btnGetFromUrl
            // 
            btnGetFromUrl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGetFromUrl.Location = new Point(118, 60);
            btnGetFromUrl.Name = "btnGetFromUrl";
            btnGetFromUrl.Size = new Size(82, 30);
            btnGetFromUrl.TabIndex = 0;
            btnGetFromUrl.Text = "Download";
            btnGetFromUrl.UseVisualStyleBackColor = true;
            btnGetFromUrl.Click += BtnGetFromUrl_Click;
            // 
            // urlSelector
            // 
            urlSelector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            urlSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            urlSelector.FormattingEnabled = true;
            urlSelector.Location = new Point(52, 3);
            urlSelector.Name = "urlSelector";
            urlSelector.Size = new Size(148, 23);
            urlSelector.TabIndex = 1;
            urlSelector.SelectedIndexChanged += UrlSelector_SelectedIndexChanged;
            // 
            // txtId
            // 
            txtId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtId.Location = new Point(88, 32);
            txtId.Name = "txtId";
            txtId.Size = new Size(112, 23);
            txtId.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 6);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 3;
            label1.Text = "Source";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(0, 35);
            lblId.Name = "lblId";
            lblId.Size = new Size(17, 15);
            lblId.TabIndex = 4;
            lblId.Text = "Id";
            // 
            // btnEdit
            // 
            btnEdit.BackgroundImageLayout = ImageLayout.Center;
            btnEdit.Image = Resources.cog;
            btnEdit.Location = new Point(0, 66);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(24, 24);
            btnEdit.TabIndex = 5;
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += BtnEdit_Click;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 0;
            toolTip1.ReshowDelay = 100;
            // 
            // UsrRestServiceProvider
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnEdit);
            Controls.Add(lblId);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(urlSelector);
            Controls.Add(btnGetFromUrl);
            Name = "UsrRestServiceProvider";
            Size = new Size(200, 90);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGetFromUrl;
        private ComboBox urlSelector;
        private TextBox txtId;
        private Label label1;
        private Label lblId;
        private Button btnEdit;
        private ToolTip toolTip1;
    }
}
