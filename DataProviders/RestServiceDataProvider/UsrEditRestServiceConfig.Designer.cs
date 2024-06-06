using AggregateReader.Properties;

namespace AggregateReader.DataProviders.RestServiceDataProvider
{
    partial class UsrEditRestServiceConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrEditRestServiceConfig));
            lstNames = new ListBox();
            BtnAdd = new Button();
            btnRemove = new Button();
            btnCancel = new Button();
            btnOK = new Button();
            txtName = new TextBox();
            txtRequestUrl = new TextBox();
            txtIdDescription = new TextBox();
            txtResponseJsonPath = new TextBox();
            cboRequestMethod = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtRequestBody = new RichTextBox();
            label5 = new Label();
            label6 = new Label();
            toolTip = new ToolTip(components);
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            panel1 = new Panel();
            label7 = new Label();
            btnUp = new Button();
            btnDown = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lstNames
            // 
            lstNames.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lstNames.FormattingEnabled = true;
            lstNames.IntegralHeight = false;
            lstNames.ItemHeight = 15;
            lstNames.Location = new Point(12, 12);
            lstNames.Name = "lstNames";
            lstNames.Size = new Size(166, 189);
            lstNames.TabIndex = 0;
            lstNames.SelectedIndexChanged += LstNames_SelectedIndexChanged_1;
            // 
            // BtnAdd
            // 
            BtnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnAdd.Location = new Point(64, 207);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(49, 23);
            BtnAdd.TabIndex = 1;
            BtnAdd.Text = "Add";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemove.Enabled = false;
            btnRemove.Location = new Point(119, 207);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(59, 23);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += BtnRemove_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(501, 280);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.Location = new Point(582, 280);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 4;
            btnOK.Text = "Ok";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += BtnOK_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(136, 0);
            txtName.MaxLength = 50;
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 23);
            txtName.TabIndex = 5;
            txtName.TextChanged += UpdateAfterNewInput;
            // 
            // txtRequestUrl
            // 
            txtRequestUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRequestUrl.Location = new Point(136, 29);
            txtRequestUrl.Name = "txtRequestUrl";
            txtRequestUrl.Size = new Size(320, 23);
            txtRequestUrl.TabIndex = 6;
            txtRequestUrl.TextChanged += UpdateAfterNewInput;
            // 
            // txtIdDescription
            // 
            txtIdDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtIdDescription.Location = new Point(136, 197);
            txtIdDescription.MaxLength = 25;
            txtIdDescription.Name = "txtIdDescription";
            txtIdDescription.Size = new Size(247, 23);
            txtIdDescription.TabIndex = 7;
            txtIdDescription.TextChanged += UpdateAfterNewInput;
            // 
            // txtResponseJsonPath
            // 
            txtResponseJsonPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtResponseJsonPath.Location = new Point(136, 168);
            txtResponseJsonPath.Name = "txtResponseJsonPath";
            txtResponseJsonPath.Size = new Size(319, 23);
            txtResponseJsonPath.TabIndex = 8;
            txtResponseJsonPath.TextChanged += UpdateAfterNewInput;
            // 
            // cboRequestMethod
            // 
            cboRequestMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRequestMethod.FormattingEnabled = true;
            cboRequestMethod.Items.AddRange(new object[] { "GET", "POST" });
            cboRequestMethod.Location = new Point(136, 58);
            cboRequestMethod.Name = "cboRequestMethod";
            cboRequestMethod.Size = new Size(82, 23);
            cboRequestMethod.TabIndex = 11;
            cboRequestMethod.SelectedIndexChanged += CboRequestMethod_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 12;
            label1.Text = "Source name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 29);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 13;
            label2.Text = "Request url";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 90);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 14;
            label3.Text = "Request body";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 61);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 15;
            label4.Text = "Request method";
            // 
            // txtRequestBody
            // 
            txtRequestBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtRequestBody.Location = new Point(136, 87);
            txtRequestBody.Name = "txtRequestBody";
            txtRequestBody.Size = new Size(320, 75);
            txtRequestBody.TabIndex = 16;
            txtRequestBody.Text = "";
            txtRequestBody.TextChanged += UpdateAfterNewInput;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(3, 171);
            label5.Name = "label5";
            label5.Size = new Size(115, 15);
            label5.TabIndex = 17;
            label5.Text = "Response JSON path";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(3, 200);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 18;
            label6.Text = "Id description";
            // 
            // toolTip
            // 
            toolTip.AutomaticDelay = 100;
            toolTip.AutoPopDelay = 10000;
            toolTip.InitialDelay = 100;
            toolTip.ReshowDelay = 20;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = Resources.help;
            pictureBox1.Location = new Point(461, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 16);
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            toolTip.SetToolTip(pictureBox1, "Provide the full URL at which the profile export can be found. Insert a specific Id using [[Id]].");
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.Image = Resources.help;
            pictureBox2.Location = new Point(461, 89);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(16, 16);
            pictureBox2.TabIndex = 24;
            pictureBox2.TabStop = false;
            toolTip.SetToolTip(pictureBox2, "Provide the request body in case of a POST. Optionally insert a specific Id using [[Id]].");
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox3.Image = Resources.help;
            pictureBox3.Location = new Point(461, 173);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(16, 16);
            pictureBox3.TabIndex = 25;
            pictureBox3.TabStop = false;
            toolTip.SetToolTip(pictureBox3, "Provide the JSON path of the response message to the base64 encoded profile export");
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox4.Image = Resources.help;
            pictureBox4.Location = new Point(461, 202);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(16, 16);
            pictureBox4.TabIndex = 26;
            pictureBox4.TabStop = false;
            toolTip.SetToolTip(pictureBox4, "Provide a description to the Id which you can insert at either the request url or body. This description is shown in the interface");
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(txtRequestUrl);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtIdDescription);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtResponseJsonPath);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cboRequestMethod);
            panel1.Controls.Add(txtRequestBody);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Enabled = false;
            panel1.Location = new Point(184, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(481, 220);
            panel1.TabIndex = 27;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.BackColor = SystemColors.Control;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.ForeColor = Color.FromArgb(64, 64, 64);
            label7.Location = new Point(12, 236);
            label7.Name = "label7";
            label7.Size = new Size(653, 34);
            label7.TabIndex = 29;
            label7.Text = resources.GetString("label7.Text");
            // 
            // btnUp
            // 
            btnUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUp.Enabled = false;
            btnUp.Image = Resources.up;
            btnUp.Location = new Point(12, 207);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(22, 23);
            btnUp.TabIndex = 30;
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += BtnUp_Click;
            // 
            // btnDown
            // 
            btnDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDown.Enabled = false;
            btnDown.Image = Resources.down;
            btnDown.Location = new Point(36, 207);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(22, 23);
            btnDown.TabIndex = 31;
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += BtnDown_Click;
            // 
            // UsrEditRestServiceConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 315);
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            Controls.Add(label7);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Controls.Add(btnRemove);
            Controls.Add(BtnAdd);
            Controls.Add(lstNames);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(685, 350);
            Name = "UsrEditRestServiceConfig";
            Text = "Configure REST API Endpoints";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstNames;
        private Button BtnAdd;
        private Button btnRemove;
        private Button btnCancel;
        private Button btnOK;
        private TextBox txtName;
        private TextBox txtRequestUrl;
        private TextBox txtIdDescription;
        private TextBox txtResponseJsonPath;
        private ComboBox cboRequestMethod;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RichTextBox txtRequestBody;
        private Label label5;
        private Label label6;
        private ToolTip toolTip;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Panel panel1;
        private Label label7;
        private Button btnUp;
        private Button btnDown;
    }
}
