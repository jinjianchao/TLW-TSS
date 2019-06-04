using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LydTOPDP.Service;
using System.Xml;
using System.Collections;
using PluginLib;

namespace LYDTOPDP
{
    public partial class PluginManagerForm : BaseFormV2
    {
        public PluginManagerForm()
        {
            InitializeComponent();
        }

        void InitLeft()
        {
            MenuService leftMenuService = new MenuService();
            PluginService pgService = new PluginService();
            IList<ArrayList> leftMenus = leftMenuService.GetMenus("all");
            for (int i = 0; i < leftMenus.Count; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Name = "root_" + leftMenus[i][0];
                tn.Text = (leftMenus[i][1] as string).Split(';')[0];
                tn.Tag = leftMenus[i][1] as string;
                treeMenu.Nodes.Add(tn);

                foreach (string item in (leftMenus[i][2] as IList<String>))
                {
                    PluginModel pm = pgService.GetPluginItem(item, "0");
                    if (pm == null) continue;
                    TreeNode subTn = new TreeNode();
                    subTn.Name = pm.GUID;
                    subTn.Text = pm.Text;
                    subTn.Tag = pm;
                    tn.Nodes.Add(subTn);
                }
            }
        }

        void InitRight()
        {
            PluginService pgService = new PluginService();
            IList<PluginModel> notUsedPg = pgService.GetNotUsedItems("0");
            listNotUsedPg.DisplayMember = "Text";

            for (int i = 0; i < notUsedPg.Count; i++)
            {
                listNotUsedPg.Items.Add(notUsedPg[i]);
            }
        }

        private void PluginManagerForm_Load(object sender, EventArgs e)
        {
            InitLeft();
            InitRight();
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            NewMenuFrom newForm = new NewMenuFrom();
            newForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = newForm.ShowDialog(this);
            if (result == DialogResult.Cancel) return;
            string cnName = newForm.CNName;
            string enName = newForm.EnName;

            TreeNode tn = new TreeNode();
            tn.Name = "root_" + new Guid().ToString();
            tn.Text = cnName;
            tn.Tag = cnName + ";" + enName;
            treeMenu.Nodes.Add(tn);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            IList<ArrayList> pgs = new List<ArrayList>();
            TreeNodeCollection rootNodes = treeMenu.Nodes;
            int i = 0;
            foreach (TreeNode item in rootNodes)
            {
                ArrayList arr = new ArrayList();
                arr.Add(i);
                arr.Add(item.Tag.ToString());

                IList<string> sub = new List<String>();
                TreeNodeCollection subNodes = item.Nodes;
                foreach (TreeNode subItem in subNodes)
                {
                    sub.Add((subItem.Tag as PluginModel).GUID);
                }
                arr.Add(sub);
                pgs.Add(arr);
            }
            MenuService leftMenuService = new MenuService();
            leftMenuService.SaveMenus(pgs);
            this.Close();
        }

        private void listNotUsedPg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listNotUsedPg.SelectedItems.Count > 0 && treeMenu.SelectedNode != null && treeMenu.SelectedNode.Name.ToString().Contains("root"))
            {
                btnToLeft.Enabled = true;
            }
            else
            {
                btnToLeft.Enabled = false;
            }
        }

        private void treeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (listNotUsedPg.SelectedItems.Count > 0 && treeMenu.SelectedNode != null && treeMenu.SelectedNode.Name.ToString().Contains("root"))
            {
                btnToLeft.Enabled = true;
            }
            else
            {
                btnToLeft.Enabled = false;
            }
            if (treeMenu.SelectedNode != null && treeMenu.SelectedNode.Tag is PluginModel)
            {
                btnToRight.Enabled = true;
            }
            else
            {
                btnToRight.Enabled = false;
            }
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ListBox.SelectedObjectCollection selectedItems = listNotUsedPg.SelectedItems;
            foreach (PluginModel pm in selectedItems)
            {
                TreeNode subTn = new TreeNode();
                subTn.Name = pm.GUID;
                subTn.Text = pm.Text;
                subTn.Tag = pm;
                treeMenu.SelectedNode.Nodes.Add(subTn);
                treeMenu.SelectedNode.Expand();
            }

            for (int i = listNotUsedPg.Items.Count - 1; i > -1; i--)
            {
                if (listNotUsedPg.GetSelected(i))
                {
                    listNotUsedPg.Items.RemoveAt(i);
                }
            }
        }

        private void btnToRight_Click(object sender, EventArgs e)
        {
            if (treeMenu.SelectedNode != null && treeMenu.SelectedNode.Tag is PluginModel)
            {
                listNotUsedPg.Items.Add(treeMenu.SelectedNode.Tag as PluginModel);
                treeMenu.SelectedNode.Remove();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (treeMenu.SelectedNode == null) return;
            if (!treeMenu.SelectedNode.Name.Contains("root")) return;
            treeMenu.SelectedNode.Remove();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            
        }
    }
}
