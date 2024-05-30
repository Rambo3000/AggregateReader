using AggregateReader.BlueriqObjects;
using LogScraper.Extensions;

namespace AggregateReader.Helpers
{
    internal static class TreeViewBuilder
    {
        public static void BuildTreeViewHierarchical(TreeView treeView, BlueriqAggregate aggregate, bool showOnlyRootEntities)
        {
            treeView.SuspendDrawing();

            // Create root node for the aggregate
            TreeNode rootNode = new(aggregate.Type)
            {
                Tag = aggregate
            };
            treeView.Nodes.Add(rootNode);

            // Attach the BeforeExpand event handler
            treeView.BeforeExpand += TreeView_BeforeExpand;

            // Group entities by type and optionally filter on root entries
            var groupedEntities = aggregate.Entities.Where(e => e.IsRootItem || showOnlyRootEntities == false).GroupBy(e => e.Type);

            foreach (IGrouping<string, BlueriqEntity> group in groupedEntities)
            {
                if (group.Key == null) continue;

                if (group.Count() == 1)
                {
                    // Only one instance of this type, add directly
                    BlueriqEntity entity = group.First();
                    TreeNode entityNode = CreateEntityNode(entity);
                    rootNode.Nodes.Add(entityNode);
                    AddPlaceholderNodes(entityNode, entity, treeView);
                }
                else
                {
                    // Multiple instances, create a parent node for the type
                    TreeNode typeNode = new($"{group.Key} ({group.Count()})")
                    {
                        Tag = group.Key
                    };
                    rootNode.Nodes.Add(typeNode);

                    // List to hold the entity nodes
                    List<TreeNode> entityNodes = [];

                    foreach (var entity in group)
                    {
                        TreeNode entityNode = CreateEntityNode(entity);
                        entityNodes.Add(entityNode);
                        AddPlaceholderNodes(entityNode, entity, treeView);
                    }

                    // Sort the entity nodes by their Text property
                    entityNodes = [.. entityNodes.OrderBy(n => n.Text)];

                    // Add sorted entity nodes to the type node
                    foreach (TreeNode entityNode in entityNodes)
                    {
                        typeNode.Nodes.Add(entityNode);
                    }
                }
            }

            treeView.Nodes[0].Expand();
            treeView.ResumeDrawing();
        }


        private static TreeNode CreateEntityNode(BlueriqEntity entity)
        {
            return new TreeNode(entity.ToString())
            {
                Tag = entity // Store entity object in the node's Tag property for future reference
            };
        }

        private static void TreeView_BeforeExpand(object? sender, TreeViewCancelEventArgs e)
        {
            if (e.Node == null) return;

            TreeNode currentNode = e.Node;

            // If the node has a placeholder, populate its children
            if (currentNode.Nodes.Count == 1 && currentNode.Nodes[0].Text == "Loading...")
            {
                currentNode.Nodes.Clear(); // Remove the placeholder
                if (currentNode.Tag is BlueriqRelation relation)
                {
                    if (relation.Children != null)
                    {
                        foreach (var childEntity in relation.Children)
                        {
                            TreeNode childEntityNode = CreateEntityNode(childEntity);
                            currentNode.Nodes.Add(childEntityNode);
                            AddPlaceholderNodes(childEntityNode, childEntity, currentNode.TreeView);
                        }
                    }
                }
            }
        }
        private static void AddPlaceholderNodes(TreeNode entityNode, BlueriqEntity entity, TreeView treeView)
        {
            foreach (var relation in entity.Relations)
            {
                TreeNode relationNode = new(relation.Name)
                {
                    Tag = relation,
                    NodeFont = new Font(treeView.Font, FontStyle.Italic),
                    ForeColor = Color.DimGray
                };

                // Add a placeholder node if there are children
                if (relation.Children != null && relation.Children.Count > 0)
                {
                    relationNode.Nodes.Add(new TreeNode("Loading..."));
                }

                entityNode.Nodes.Add(relationNode);
            }
        }
    }
}
