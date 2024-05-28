using AggregateReader.BlueriqObjects;
using AggregateReader.Parsers;
using System.Diagnostics;
using System.Xml.Linq;
using TreeView = System.Windows.Forms.TreeView;
using AggregateReader.Helpers;
using System.Xml;

namespace AggregateReader
{
    public partial class AggregateReader : Form
    {
        public AggregateReader()
        {
            InitializeComponent();
            SetDataGridViewDefaultStyle(dgvAttributes);
            SetDataGridViewDefaultStyle(dgvRelations);
            SetDataGridViewDefaultStyle(dgvParents);
            dgvAttributes.LostFocus += (sender, e) => dgvAttributes.ClearSelection();
            dgvRelations.LostFocus += (sender, e) => dgvRelations.ClearSelection();
            dgvParents.LostFocus += (sender, e) => dgvParents.ClearSelection();

            if (!Debugger.IsAttached) txtXMLInput.Text = string.Empty;
        }
        private static void SetDataGridViewDefaultStyle(DataGridView dataGridView)
        {
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            txtXMLInput.Text = FormatXml(txtXMLInput.Text);
            PopulateTreeView(txtXMLInput.Text);
        }
        public void Clear()
        {
            ClearXML();
            ClearTreeview();
            ClearInstance();
        }
        public void ClearXML()
        {
            txtXMLInput.Text = string.Empty;
        }
        public void ClearTreeview()
        {
            treInstanceOverviewHierarchical.Nodes.Clear();
        }
        public void ClearInstance()
        {

            lblEntityValue.Text = "";
            lblIdValue.Text = "";
            lblRelationValue.Text = "";
            dgvAttributes.Rows.Clear();
            dgvRelations.Rows.Clear();
            dgvParents.Rows.Clear();
        }

        static string FormatXml(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                return doc.ToString();
            }
            catch (Exception)
            {
                // Handle and throw if fatal exception here; don't just ignore them
                return xml;
            }
        }

        void PopulateTreeView(string xml)
        {
            ClearTreeview();
            ClearInstance();
            try
            {

                if (string.IsNullOrWhiteSpace(xml)) return;

                (BlueriqAggregate aggregate, IBlueriqParser parser) = ParserFactory.Parse(xml);

                chkShowRootEntitiesOnly.Enabled = parser.CanIdentifyRootNodes;
                if (!parser.CanIdentifyRootNodes) chkShowRootEntitiesOnly.Checked = false;
                dgvParents.Columns[2].Visible = parser.CanIdentifyRootNodes;

                TreeViewBuilder.BuildTreeViewHierarchical(treInstanceOverviewHierarchical, aggregate, chkShowRootEntitiesOnly.Checked);
            }
            catch (Exception ex)
            {
                if (!IsValidXml(xml))
                {
                    MessageBox.Show("The provided XML is not valid, please provide valid XML");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public static bool IsValidXml(string xml)
        {
            try
            {
                XmlDocument xmlDoc = new();
                xmlDoc.LoadXml(xml);
                return true; // XML is valid
            }
            catch (XmlException)
            {
                return false; // XML is not valid
            }
        }

        private void TreAggregateEntities_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearInstance();

            if (e.Node == null || e.Node.Tag == null) return;

            if (e.Node.Tag.GetType() != typeof(BlueriqEntity)) return;

            if (e.Node.Tag.GetType() == typeof(BlueriqAggregate)) return;
            if (e.Node.Tag.GetType() == typeof(BlueriqAttribute)) return;

            BlueriqRelation? relation = null;
            BlueriqEntity? entity = null;
            TreeNode nodeInitial = e.Node;
            if (e.Node.Tag.GetType() == typeof(BlueriqRelation))
            {
                relation = (BlueriqRelation)e.Node.Tag;
                if (relation.Children == null || relation.Children.Count != 1) return;

                entity = relation.Children.First();
            }
            if (e.Node.Tag.GetType() == typeof(BlueriqEntity))
            {
                entity = (BlueriqEntity)e.Node.Tag;
            }

            if (entity == null) return;

            if (relation == null && e.Node.Parent.Tag != null && e.Node.Parent.Tag.GetType() == typeof(BlueriqRelation))
            {
                nodeInitial = e.Node.Parent;
            }

            string? relationPath = null;
            TreeNode nodeLoop = nodeInitial;
            while (nodeLoop != null)
            {
                if (nodeLoop.Tag != null)
                {
                    if (nodeLoop.Tag.GetType() == typeof(BlueriqRelation))
                    {
                        relationPath = string.Join(".", ((BlueriqRelation)nodeLoop.Tag).Name, relationPath);
                    }
                    if (nodeLoop.Tag.GetType() == typeof(BlueriqEntity))
                    {
                        BlueriqEntity entityLoop = (BlueriqEntity)nodeLoop.Tag;
                        if (entityLoop.ParentRelations == null || entityLoop.ParentRelations.Count == 0)
                        {
                            relationPath = entityLoop.Type + "." + relationPath;
                        }
                    }
                }
                nodeLoop = nodeLoop.Parent;
            }

            if (relationPath != null)
            {
                lblRelationValue.Text = relationPath[..^1];
            }

            lblEntityValue.Text = entity.Type;
            lblIdValue.Text = entity.Id;

            PopulateDataGridViewAttributes(dgvAttributes, entity.Attributes);
            PopulateDataGridViewRelations(dgvRelations, entity);
            PopulateDataGridViewParents(dgvParents, entity);
        }
        public static void PopulateDataGridViewAttributes(DataGridView dataGridView, List<BlueriqAttribute> attributes)
        {
            // Populate data
            foreach (var attribute in attributes)
            {
                // If attribute has multiple values, join them with new lines
                string valuesString = attribute.Values != null ? string.Join(Environment.NewLine, attribute.Values) : string.Empty;
                dataGridView.Rows.Add(attribute.Name, valuesString);
            }
            dataGridView.ClearSelection();
        }
        public static void PopulateDataGridViewRelations(DataGridView dataGridView, BlueriqEntity entity)
        {
            // Populate data
            foreach (var relation in entity.Relations)
            {
                // If attribute has multiple values, join them with new lines
                string valuesString = relation.Values != null ? string.Join(Environment.NewLine, relation.Values) : string.Empty;
                string relationType = relation.Children != null && relation.Children.Count > 0 ? relation.Children[0].Type : string.Empty;

                DataGridViewRow row = new();
                row.CreateCells(dataGridView);
                row.Cells[0].Value = relation.Name;
                row.Cells[1].Value = relationType;
                row.Cells[2].Value = valuesString;
                row.Cells[3].Value = "Select";
                row.Tag = relation;

                dataGridView.Rows.Add(row);
            }
            dataGridView.ClearSelection();
        }
        public static void PopulateDataGridViewParents(DataGridView dataGridView, BlueriqEntity entity)
        {
            if (entity.ParentRelations == null) return;

            // Populate data
            foreach (var relation in entity.ParentRelations)
            {
                DataGridViewRow row = new();
                row.CreateCells(dataGridView);
                row.Cells[0].Value = relation.ParentEntity.Type + "." + relation.Name;
                row.Cells[1].Value = relation.ParentEntity.Id;
                row.Cells[2].Value = "Select";
                row.Tag = relation;
                dataGridView.Rows.Add(row);
            }
            dataGridView.ClearSelection();
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is not DataGridView dataGridView) return;

            // Check if the click is on the button column
            if (((dataGridView.Name == "dgvRelations" && e.ColumnIndex == 3) || (dataGridView.Name == "dgvParents" && e.ColumnIndex == 2))
                && e.RowIndex >= 0)
            {
                // Retrieve the attribute object from the row's tag
                BlueriqRelation? relation = dataGridView.Rows[e.RowIndex].Tag as BlueriqRelation;

                // Handle the button click event
                SelectTreeViewNode(treInstanceOverviewHierarchical, relation);

            }
        }

        private static void SelectTreeViewNode(TreeView treeView, BlueriqRelation? relation)
        {
            // Iterate through all nodes in the TreeView
            foreach (TreeNode node in treeView.Nodes)
            {
                TreeNode? foundNode = FindNode(node, relation);
                if (foundNode != null)
                {
                    if (true || foundNode.Nodes.Count == 0)
                    {
                        treeView.SelectedNode = foundNode;
                        foundNode.EnsureVisible();
                    }
                    else
                    {
                        // TODO: select the child node in case multiple children are present
                        foreach (TreeNode childNode in foundNode.Nodes)
                        {
                            //if (childNode.Tag = relation.)
                            {

                            }
                        }
                    }
                    treeView.Focus();
                    break;
                }
            }
        }

        private static TreeNode? FindNode(TreeNode rootNode, BlueriqRelation? relation)
        {
            if (rootNode.Tag != null && rootNode.Tag.GetType() == typeof(BlueriqRelation) && rootNode.Tag == relation)
            {
                return rootNode;
            }

            foreach (TreeNode childNode in rootNode.Nodes)
            {
                TreeNode? foundNode = FindNode(childNode, relation);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }

            return null;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void ChkShowRootEntitiesOnly_CheckedChanged(object sender, EventArgs e)
        {
            BtnRead_Click(sender, e);
        }
    }
}
