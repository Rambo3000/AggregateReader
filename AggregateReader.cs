using AggregateReader.BlueriqObjects;
using AggregateReader.BlueriqXml;
using LogScraper.Extensions;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using TreeView = System.Windows.Forms.TreeView;

namespace AggregateReader
{
    public partial class AggregateReader : Form
    {
        public AggregateReader()
        {
            InitializeComponent();
            dgvAttributes.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvAttributes.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvRelations.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvRelations.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvParents.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvParents.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAttributes.LostFocus += (sender, e) => dgvAttributes.ClearSelection();
            dgvRelations.LostFocus += (sender, e) => dgvRelations.ClearSelection();
            dgvParents.LostFocus += (sender, e) => dgvParents.ClearSelection();

            if (!Debugger.IsAttached) txtXMLInput.Text = string.Empty;
        }

        private void Button1_Click(object sender, EventArgs e)
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
            treInstanceOverviewAlphabetically.Nodes.Clear();
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

                if (string.IsNullOrWhiteSpace(txtXMLInput.Text)) return;

                BlueriqXmlAggregate? xmlAggregate;
                using TextReader reader = new StringReader(xml);
                XmlSerializer serializer = new(typeof(BlueriqXmlAggregate));
                xmlAggregate = serializer.Deserialize(reader) as BlueriqXmlAggregate;
                
                if (xmlAggregate == null) return;
                
                BlueriqAggregate aggregate = BlueriqXmlAggregateParser.ParseXmlToAggregate(xmlAggregate);
                PopulateRelationChildren(aggregate);

                BuildTreeViewHierarchical(treInstanceOverviewHierarchical, aggregate);
                BuildTreeViewAlphabetically(treInstanceOverviewAlphabetically, aggregate);
            }
            catch (Exception)
            {
                // Handle and throw if fatal exception here; don't just ignore them
            }
        }

        public static void PopulateRelationChildren(BlueriqAggregate aggregate)
        {
            foreach (var entity in aggregate.Entities)
            {
                foreach (var relation in entity.Relations)
                {
                    // Check if relation has values
                    if (relation.Values != null && relation.Values.Count != 0)
                    {
                        relation.ParentEntity = entity;

                        // Find matching entities based on relation values
                        relation.Children = aggregate.Entities.Where(e => relation.Values.Contains(e.Id)).ToList();
                        foreach (var childEntity in relation.Children)
                        {
                            childEntity.ParentRelations ??= [];
                            childEntity.ParentRelations.Add(relation);
                        }
                    }
                }
            }
        }
        public static void BuildTreeViewHierarchical(TreeView treeView, BlueriqAggregate aggregate)
        {
            treeView.SuspendDrawing();

            // Create root node for the aggregate
            TreeNode rootNode = new(aggregate.Type)
            {
                Tag = aggregate
            };
            treeView.Nodes.Add(rootNode);

            // Populate tree recursively
            foreach (var entity in aggregate.Entities)
            {
                //Only show root items to simplify the view
                if (entity.ParentRelations != null && entity.ParentRelations.Count > 0) continue;

                TreeNode entityNode = CreateEntityNode(entity);
                entityNode.Tag = entity;
                rootNode.Nodes.Add(entityNode);
                PopulateEntityNode(entityNode, entity);
            }

            treeView.Nodes[0].Expand();
            treeView.ResumeDrawing();
        }
        public static void BuildTreeViewAlphabetically(TreeView treeView, BlueriqAggregate aggregate)
        {
            treeView.SuspendDrawing();

            List<IGrouping<string, BlueriqEntity>> groupedEntities = aggregate.Entities.GroupBy(e => e.Type).ToList();

            TreeNode rootNode = new(aggregate.Type);
            treeView.Nodes.Add(rootNode);

            foreach (IGrouping<string, BlueriqEntity> group in groupedEntities)
            {
                TreeNodeCollection treeNodes = rootNode.Nodes;

                if (group.Count() > 1)
                {
                    TreeNode treeNode = new TreeNode($"{group.Key} ({group.Count()})");
                    treeNodes.Add(treeNode);
                    treeNodes = treeNode.Nodes;
                }
                
                foreach (BlueriqEntity entity in group)
                {
                    treeNodes.Add(CreateEntityNode(entity));
                }
            }

            treeView.Nodes[0].Expand();
            treeView.ResumeDrawing();
        }

        private static TreeNode CreateEntityNode(BlueriqEntity entity)
        {
            TreeNode entityNode = new(entity.ToString())
            {
                Tag = entity // Store entity object in the node's Tag property for future reference
            };
            return entityNode;
        }

        private static void PopulateEntityNode(TreeNode entityNode, BlueriqEntity entity)
        {
            foreach (var relation in entity.Relations)
            {
                if (relation.Children == null || relation.Children.Count == 0)
                {
                    TreeNode newNode = new($"{relation.Name} (entiteit niet gevonden!)")
                    {
                        Tag = relation
                    };
                    entityNode.Nodes.Add(newNode);
                    continue;
                }

                string count = relation.Children.Count == 1 ? "" : $" ({relation.Children.Count})";
                string entityType = 
                    relation.Children.Count == 1 
                    && ( !relation.Children[0].OnlyOneInstanceOfThisTypeExists || relation.Name != relation.Children[0].Type )
                    ? $" ({relation.Children[0]})" : "";

                //TreeNode relationNode = new($"{relation.Name} [{relation.Children[0].Type}]")
                TreeNode relationNode = new($"{relation.Name}{entityType}{count}")
                {
                    Tag = relation
                };
                entityNode.Nodes.Add(relationNode);

                if (relation.Children != null)
                {
                    if (relation.Children.Count == 1)
                    {
                        PopulateEntityNode(relationNode, relation.Children[0]);
                    }
                    else
                    {
                        foreach (var childEntity in relation.Children)
                        {
                            TreeNode childEntityNode = CreateEntityNode(childEntity);
                            relationNode.Nodes.Add(childEntityNode);
                            PopulateEntityNode(childEntityNode, childEntity);
                        }
                    }
                }
            }
        }

        public static string GenerateTable(List<BlueriqAttribute> attributes)
        {
            if (attributes.Count == 0) return "";

            StringBuilder tableBuilder = new();

            // Calculate the maximum length of attribute names and values
            int maxNameLength = attributes.Max(attr => attr.Name.Length);
            int maxValuesLength = attributes.Max(attr => attr.Values != null ? attr.Values.Max(val => val.Length) : 0);

            // Add rows for each attribute
            foreach (var attribute in attributes)
            {
                // If attribute has multiple values, join them with new lines
                string valuesString = attribute.Values != null ? string.Join("\n", attribute.Values) : string.Empty;
                tableBuilder.AppendLine($"{PadRightAndTruncate(attribute.Name, maxNameLength)} {PadRightAndTruncate(valuesString, maxValuesLength)}");
            }

            return tableBuilder.ToString();
        }

        private static string PadRightAndTruncate(string value, int length)
        {
            if (value.Length <= length)
            {
                return value.PadRight(length);
            }
            else
            {
                return value[..length];
            }
        }

        private void TreAggregateEntities_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearInstance();

            if (e.Node == null || e.Node.Tag == null) return;

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

        private void SelectTreeViewNode(TreeView treeView, BlueriqRelation? relation)
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
                    tabInstanceOverview.SelectedIndex = 1;
                    break;
                }
            }
        }

        private static TreeNode? FindNode(TreeNode rootNode, BlueriqRelation? relation)
        {
            if (rootNode.Tag.GetType() == typeof(BlueriqRelation) && rootNode.Tag == relation)
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

        private void AggregateReader_Load(object sender, EventArgs e)
        {

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
