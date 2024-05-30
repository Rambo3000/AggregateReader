using AggregateReader.BlueriqObjects;
using AggregateReader.Parsers;
using System.Diagnostics;
using TreeView = System.Windows.Forms.TreeView;
using AggregateReader.Helpers;
using System.Windows.Forms;

namespace AggregateReader
{
    public partial class AggregateReader : Form
    {
        public AggregateReader()
        {
            InitializeComponent();
            usrEntityViewer.NavigateToRelationEvent += UsrEntityViewer_NavigateToRelationEvent;

            string version = Application.ProductVersion;
            const string versionSeperator = "+";
            if (version.Contains(versionSeperator))
            {
                version = version[..version.IndexOf(versionSeperator)];
            }

            lblVersion.Text = "v" + version;

            if (!Debugger.IsAttached) txtXMLInput.Text = string.Empty;
        }

        private void UsrEntityViewer_NavigateToRelationEvent(object sender, BlueriqRelation relation, BlueriqEntity? entity)
        {
            SelectTreeViewNode(treInstanceOverviewHierarchical, relation, entity);
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
            usrEntityViewer.Clear();
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

                usrEntityViewer.CanNavigateToParentRelations = parser.CanIdentifyRootNodes;

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

            if (e?.Node?.Tag is not BlueriqEntity entity) return;

            usrEntityViewer.UpdateEntity(entity, GetRelationPath(e.Node));
        }

        private static string GetRelationPath(TreeNode nodeInitial)
        {

            if (nodeInitial.Parent.Tag?.GetType() == typeof(BlueriqRelation))
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

        private static void SelectTreeViewNode(TreeView treeView, BlueriqRelation relation, BlueriqEntity? entity)
        {
            // Iterate through all nodes in the TreeView
            foreach (TreeNode node in treeView.Nodes)
            {
                TreeNode? foundNode = FindNode(node, relation);
                if (foundNode != null)
                {
                    if (entity == null)
                    {
                        //Select the relation and open it
                        treeView.SelectedNode = foundNode;
                        foundNode.EnsureVisible();
                        if (foundNode.Nodes.Count > 0)
                        {
                            foundNode.Nodes[0].EnsureVisible();
                        }
                    }
                    else
                    {
                        //Select the entity
                        if (foundNode.Nodes.Count > 0)
                        {
                            //Make sure the nodes are loaded and their tags are set
                            foundNode.Nodes[0].EnsureVisible();
                            Application.DoEvents();

                            foreach (TreeNode childNode in foundNode.Nodes)
                            {
                                if (childNode.Tag is BlueriqEntity entityChildNode && entityChildNode == entity)
                                {
                                    treeView.SelectedNode = childNode;
                                }
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
