using AggregateReader.BlueriqObjects;
using AggregateReader.Parsers;
using System.Diagnostics;
using System.Xml.Linq;
using TreeView = System.Windows.Forms.TreeView;
using AggregateReader.Helpers;
using System.Xml;

namespace AggregateReader
{
    public partial class UsrEntityViewer : UserControl
    {
        private class RelationEntityCombo(BlueriqRelation relation, BlueriqEntity? entity)
        {
            public BlueriqRelation Relation { get; set; } = relation;
            public BlueriqEntity? Entity { get; set; } = entity;
        }
        public delegate void NavigateToRelationEventHandler(object sender, BlueriqRelation relation, BlueriqEntity? blueriqEntity);

        public event NavigateToRelationEventHandler? NavigateToRelationEvent;

        public UsrEntityViewer()
        {
            InitializeComponent();
            SetDataGridViewDefaultStyle(dgvAttributes);
            SetDataGridViewDefaultStyle(dgvRelations);
            SetDataGridViewDefaultStyle(dgvParents);
            dgvAttributes.LostFocus += (sender, e) => dgvAttributes.ClearSelection();
            dgvRelations.LostFocus += (sender, e) => dgvRelations.ClearSelection();
            dgvParents.LostFocus += (sender, e) => dgvParents.ClearSelection();
            chkShowRelations.Checked = false;
        }
        private static void SetDataGridViewDefaultStyle(DataGridView dataGridView)
        {
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        public void Clear()
        {
            txtEntityTypeValue.Text = "";
            txtInstanceIdValue.Text = "";
            txtRelationValue.Text = "";
            dgvAttributes.Rows.Clear();
            dgvAttributes.Tag = null;
            dgvRelations.Rows.Clear();
            dgvParents.Rows.Clear();
        }

        public void UpdateEntity(BlueriqEntity entity, string entityPath)
        {
            Clear();

            txtRelationValue.Text = entityPath;
            txtEntityTypeValue.Text = entity.Type;
            txtInstanceIdValue.Text = entity.Id;

            PopulateDataGridViewAttributes(dgvAttributes, entity.Attributes);
            PopulateDataGridViewRelations(dgvRelations, entity);
            PopulateDataGridViewParents(dgvParents, entity);
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
                row.Tag = new RelationEntityCombo(relation, null);

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
                row.Tag = new RelationEntityCombo(relation, entity);
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
                if (dataGridView.Rows[e.RowIndex].Tag is not RelationEntityCombo relationEntityCombo) return;

                NavigateToRelationEvent?.Invoke(this, relationEntityCombo.Relation, relationEntityCombo.Entity);
            }
        }

        public bool CanNavigateToParentRelations { get { return dgvParents.Columns[2].Visible; } set { dgvParents.Columns[2].Visible = value; } }

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

        private void ChkOnlyShowAttributesHavingAValue_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvAttributes.Tag == null) return;

            dgvAttributes.Rows.Clear();
            PopulateDataGridViewAttributes(dgvAttributes, (List<BlueriqAttribute>)dgvAttributes.Tag);
        }

        private void ChkShowRelations_CheckedChanged(object sender, EventArgs e)
        {
            scAttributesAndOthers.Panel2Collapsed = !chkShowRelations.Checked;
        }
    }
}
