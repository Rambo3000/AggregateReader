using AggregateReader.BlueriqObjects;
using LogScraper.Extensions;

namespace AggregateReader.Parsers
{
    internal static class TreeViewAggregatePopulator
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
                    && (!relation.Children[0].OnlyOneInstanceOfThisTypeExists || relation.Name != relation.Children[0].Type)
                    ? $" ({relation.Children[0]})" : "";


                TreeNode relationNode = new($"{relation.Name}{entityType}{count}")
                {
                    Tag = relation
                };
                entityNode.Nodes.Add(relationNode);

                if (relation.Children != null && relation.Type == RelationType.NonRecursive)
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
    }
}
