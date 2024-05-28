using AggregateReader.BlueriqObjects;
using LogScraper.Extensions;

namespace AggregateReader.Helpers
{
    internal static class TreeViewBuilder
    {
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
                    TreeNode treeNode = new($"{group.Key} ({group.Count()})");
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
        public static void BuildTreeViewHierarchical(TreeView treeView, BlueriqAggregate aggregate, bool showOnlyRootEntities)
        {
            treeView.SuspendDrawing();

            // Create root node for the aggregate
            TreeNode rootNode = new TreeNode(aggregate.Type)
            {
                Tag = aggregate
            };
            treeView.Nodes.Add(rootNode);

            // Attach the BeforeExpand event handler
            treeView.BeforeExpand += TreeView_BeforeExpand;

            // Group entities by type
            var groupedEntities = aggregate.Entities.Where(e => e.IsRootItem || showOnlyRootEntities == false).GroupBy(e => e.Type);

            foreach (var group in groupedEntities)
            {
                if (group.Key == null) continue;

                if (group.Count() == 1 && group.First().OnlyOneInstanceOfThisTypeExists)
                {
                    // Only one instance of this type, add directly
                    var entity = group.First();
                    TreeNode entityNode = CreateEntityNode(entity);
                    rootNode.Nodes.Add(entityNode);
                    AddPlaceholderNodes(entityNode, entity);
                }
                else
                {
                    // Multiple instances, create a parent node for the type
                    TreeNode typeNode = new($"{group.Key} ({group.Count()})")
                    {
                        Tag = group.Key
                    };
                    rootNode.Nodes.Add(typeNode);

                    foreach (var entity in group)
                    {
                        TreeNode entityNode = CreateEntityNode(entity);
                        typeNode.Nodes.Add(entityNode);
                        AddPlaceholderNodes(entityNode, entity);
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

        private static void AddPlaceholderNodes(TreeNode entityNode, BlueriqEntity entity)
        {
            foreach (var relation in entity.Relations)
            {
                TreeNode relationNode = new TreeNode(relation.Name)
                {
                    Tag = relation
                };

                // Add a placeholder node if there are children
                if (relation.Children != null && relation.Children.Count > 0)
                {
                    relationNode.Nodes.Add(new TreeNode("Loading..."));
                }

                entityNode.Nodes.Add(relationNode);
            }
        }
        private static void TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode currentNode = e.Node;

            // If the node has a placeholder, populate its children
            if (currentNode.Nodes.Count == 1 && currentNode.Nodes[0].Text == "Loading...")
            {
                currentNode.Nodes.Clear(); // Remove the placeholder

                if (currentNode.Tag is BlueriqEntity entity)
                {
                    PopulateEntityNode(currentNode, entity);
                }
                else if (currentNode.Tag is BlueriqRelation relation)
                {
                    foreach (var childEntity in relation.Children)
                    {
                        TreeNode childEntityNode = CreateEntityNode(childEntity);
                        currentNode.Nodes.Add(childEntityNode);
                        AddPlaceholderNodes(childEntityNode, childEntity);
                    }
                }
            }
        }

        private static void PopulateEntityNode(TreeNode entityNode, BlueriqEntity entity)
        {
            foreach (var relation in entity.Relations)
            {
                if (relation.Children == null || relation.Children.Count == 0)
                {
                    TreeNode newNode = new TreeNode($"{relation.Name} (entiteit niet gevonden!)")
                    {
                        Tag = relation
                    };
                    entityNode.Nodes.Add(newNode);
                    continue;
                }

                string count = relation.Children.Count == 1 ? "" : $" ({relation.Children.Count})";
                string entityType =
                    relation.Children.Count == 1
                    && (!relation.Children[0].OnlyOneInstanceOfThisTypeExists || relation.Name != relation.Children[0].Type)
                    ? $" ({relation.Children[0]})" : "";

                TreeNode relationNode = new TreeNode($"{relation.Name}{entityType}{count}")
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
                            AddPlaceholderNodes(childEntityNode, childEntity);
                        }
                    }
                }
            }
        }
    }
}
