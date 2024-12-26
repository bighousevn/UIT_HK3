namespace Bai_4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            systemToolStripMenuItem = new ToolStripMenuItem();
            addMenu = new ToolStripMenuItem();
            openMenu = new ToolStripMenuItem();
            saveMenu = new ToolStripMenuItem();
            exitMenu = new ToolStripMenuItem();
            formatToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            addTool = new ToolStripButton();
            saveTool = new ToolStripButton();
            fontTool = new ToolStripComboBox();
            sizeTool = new ToolStripComboBox();
            boldTool = new ToolStripButton();
            italicTool = new ToolStripButton();
            underlineTool = new ToolStripButton();
            textSpace = new RichTextBox();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { systemToolStripMenuItem, formatToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            systemToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addMenu, openMenu, saveMenu, exitMenu });
            systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            systemToolStripMenuItem.Size = new Size(83, 24);
            systemToolStripMenuItem.Text = "Hệ thống";
            // 
            // addMenu
            // 
            addMenu.Image = Properties.Resources._new;
            addMenu.Name = "addMenu";
            addMenu.Size = new Size(221, 24);
            addMenu.Text = "Tạo văn bản mới";
            addMenu.Click += addMenu_Click;
            // 
            // openMenu
            // 
            openMenu.Image = Properties.Resources.open;
            openMenu.Name = "openMenu";
            openMenu.Size = new Size(221, 24);
            openMenu.Text = "Mở tập tin";
            openMenu.Click += openMenu_Click;
            // 
            // saveMenu
            // 
            saveMenu.Image = Properties.Resources.save;
            saveMenu.Name = "saveMenu";
            saveMenu.Size = new Size(221, 24);
            saveMenu.Text = "Lưu nội dung văn bản";
            saveMenu.Click += saveMenu_Click;
            // 
            // exitMenu
            // 
            exitMenu.Name = "exitMenu";
            exitMenu.Size = new Size(221, 24);
            exitMenu.Text = "Thoát";
            exitMenu.Click += exitMenu_Click;
            // 
            // formatToolStripMenuItem
            // 
            formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            formatToolStripMenuItem.Size = new Size(90, 24);
            formatToolStripMenuItem.Text = "Định dạng";
            formatToolStripMenuItem.Click += formatToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { addTool, saveTool, fontTool, sizeTool, boldTool, italicTool, underlineTool });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 28);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // addTool
            // 
            addTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            addTool.Image = Properties.Resources._new;
            addTool.ImageTransparentColor = Color.Magenta;
            addTool.Name = "addTool";
            addTool.Size = new Size(23, 25);
            addTool.Text = "Tạo mới";
            addTool.Click += addTool_Click;
            // 
            // saveTool
            // 
            saveTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveTool.Image = Properties.Resources.save;
            saveTool.ImageTransparentColor = Color.Magenta;
            saveTool.Name = "saveTool";
            saveTool.Size = new Size(23, 25);
            saveTool.Text = "Lưu";
            saveTool.Click += saveTool_Click;
            // 
            // fontTool
            // 
            fontTool.Name = "fontTool";
            fontTool.Size = new Size(121, 28);
            fontTool.Text = "Arial";
            fontTool.TextChanged += changeFont;
            // 
            // sizeTool
            // 
            sizeTool.Name = "sizeTool";
            sizeTool.Size = new Size(121, 28);
            sizeTool.Text = "15";
            sizeTool.TextChanged += changeFont;
            // 
            // boldTool
            // 
            boldTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            boldTool.Image = Properties.Resources.Bold;
            boldTool.ImageTransparentColor = Color.Magenta;
            boldTool.Name = "boldTool";
            boldTool.Size = new Size(23, 25);
            boldTool.Text = "In đậm";
            boldTool.Click += boldTool_Click;
            // 
            // italicTool
            // 
            italicTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            italicTool.Image = Properties.Resources.Italic;
            italicTool.ImageTransparentColor = Color.Magenta;
            italicTool.Name = "italicTool";
            italicTool.Size = new Size(23, 25);
            italicTool.Text = "In nghiêng";
            italicTool.Click += italicTool_Click;
            // 
            // underlineTool
            // 
            underlineTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            underlineTool.Image = Properties.Resources.Underlined;
            underlineTool.ImageTransparentColor = Color.Magenta;
            underlineTool.Name = "underlineTool";
            underlineTool.Size = new Size(23, 25);
            underlineTool.Text = "Gạch dưới";
            underlineTool.Click += underlineTool_Click;
            // 
            // textSpace
            // 
            textSpace.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textSpace.Location = new Point(0, 59);
            textSpace.Name = "textSpace";
            textSpace.Size = new Size(800, 347);
            textSpace.TabIndex = 2;
            textSpace.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textSpace);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem systemToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripMenuItem addMenu;
        private ToolStripMenuItem openMenu;
        private ToolStripMenuItem saveMenu;
        private ToolStripMenuItem exitMenu;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripButton addTool;
        private ToolStripButton saveTool;
        private ToolStripComboBox fontTool;
        private ToolStripComboBox sizeTool;
        private ToolStripButton boldTool;
        private ToolStripButton italicTool;
        private ToolStripButton underlineTool;
        private RichTextBox textSpace;
    }
}
