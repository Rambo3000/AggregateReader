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
            txtXMLInput.Text = XmlHelper.PrettyPrint(txtXMLInput.Text);
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

            txtEntityTypeValue.Text = "";
            txtInstanceIdValue.Text = "";
            txtRelationValue.Text = "";
            dgvAttributes.Rows.Clear();
            dgvRelations.Rows.Clear();
            dgvParents.Rows.Clear();
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
                if (!XmlHelper.IsValidXml(xml))
                {
                    MessageBox.Show("The provided XML is not valid, please provide valid XML");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TreAggregateEntities_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearInstance();

            if (e.Node == null || e.Node.Tag == null) return;

            TreeNode nodeInitial = e.Node;

            if (nodeInitial.Tag.GetType() != typeof(BlueriqEntity)) return;

            BlueriqEntity? entity = (BlueriqEntity)nodeInitial.Tag; ;

            if (entity == null) return;


            txtRelationValue.Text = GetRelationPath(nodeInitial);
            txtEntityTypeValue.Text = entity.Type;
            txtInstanceIdValue.Text = entity.Id;

            PopulateDataGridViewAttributes(dgvAttributes, entity.Attributes);
            PopulateDataGridViewRelations(dgvRelations, entity);
            PopulateDataGridViewParents(dgvParents, entity);
        }

        private static string GetRelationPath(TreeNode nodeInitial)
        {

            if (nodeInitial.Parent.Tag != null && nodeInitial.Parent.Tag.GetType() == typeof(BlueriqRelation))
            {
                nodeInitial = nodeInitial.Parent;
            }

            string relationPath = string.Empty;
            TreeNode? nodeLoop = nodeInitial;
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
                        if (nodeLoop.Parent != null && nodeLoop.Parent.Tag != null && nodeLoop.Parent.Tag.GetType() == typeof(BlueriqAggregate))
                        {
                            relationPath = entityLoop.Type + "." + relationPath;
                        }
                    }
                    // In case the root items are grouped we can identify that by the string and get the entity by getting the first child
                    if (nodeLoop.Tag.GetType() == typeof(string) && nodeLoop.Nodes.Count > 0 && nodeLoop.Nodes[0].Tag.GetType() == typeof(BlueriqEntity))
                    {
                        BlueriqEntity entityLoop = (BlueriqEntity)nodeLoop.Nodes[0].Tag;
                        if (nodeLoop.Parent != null && nodeLoop.Parent.Tag != null && nodeLoop.Parent.Tag.GetType() == typeof(BlueriqAggregate))
                        {
                            relationPath = entityLoop.Type + "." + relationPath;
                        }
                    }
                }
                nodeLoop = nodeLoop.Parent;
            }

            if (!string.IsNullOrWhiteSpace(relationPath))
            {
                relationPath = relationPath[..^1];
            }

            return relationPath;
        }

        public void PopulateDataGridViewAttributes(DataGridView dataGridView, List<BlueriqAttribute> attributes)
        {
            // Populate data
            foreach (var attribute in attributes)
            {
                if (attribute.Values == null || attribute.Values.Count == 0 && chkOnlyShowAttributesHavingAValue.Checked) continue;

                // If attribute has multiple values, join them with new lines
                string valuesString = attribute.Values != null ? string.Join(Environment.NewLine, attribute.Values) : string.Empty;
                string derivationDescription = attribute.DerivationType switch
                {
                    DerivationType.UserSet => "User set",
                    DerivationType.DerivedUnknown => "Unknown",
                    DerivationType.DerivedSystem => "System",
                    DerivationType.DerivedDefaultValue => "Default",
                    null => string.Empty,
                    _ => string.Empty,
                };
                dataGridView.Rows.Add(attribute.Name, valuesString, derivationDescription);
            }
            dataGridView.ClearSelection();
            dataGridView.Tag = attributes;
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

        private void ChkOnlyShowAttributesHavingAValue_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvAttributes.Tag == null) return;

            dgvAttributes.Rows.Clear();
            PopulateDataGridViewAttributes(dgvAttributes, (List<BlueriqAttribute>)dgvAttributes.Tag);
        }
    }
}
