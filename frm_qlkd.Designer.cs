namespace DO_AN_1
{
    partial class frm_qlkd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_qlkd));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_qlnd = new DevExpress.XtraBars.BarButtonItem();
            this.btn_qlsp = new DevExpress.XtraBars.BarButtonItem();
            this.btn_qlnh = new DevExpress.XtraBars.BarButtonItem();
            this.btn_qlbh = new DevExpress.XtraBars.BarButtonItem();
            this.btn_qlkh = new DevExpress.XtraBars.BarButtonItem();
            this.byn_bctk = new DevExpress.XtraBars.BarButtonItem();
            this.btn_tc = new DevExpress.XtraBars.BarButtonItem();
            this.tacvu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.page_nguoidung = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_sanpham = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_nhaphang = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_khachhang = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_thongke = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_tracuu = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dcmManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.acc_ele_tacvu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acc_qlnd = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acc_qlsp = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acc_qlnh = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acc_qlbh = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acc_qlkh = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acc_bctk = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acc_tc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator1 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator2 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcmManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btn_qlnd,
            this.btn_qlsp,
            this.btn_qlnh,
            this.btn_qlbh,
            this.btn_qlkh,
            this.byn_bctk,
            this.btn_tc});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 385;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.tacvu});
            this.ribbon.Size = new System.Drawing.Size(1497, 178);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btn_qlnd
            // 
            this.btn_qlnd.Caption = "Quản lý người dùng";
            this.btn_qlnd.Id = 1;
            this.btn_qlnd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_qlnd.ImageOptions.LargeImage")));
            this.btn_qlnd.LargeWidth = 105;
            this.btn_qlnd.Name = "btn_qlnd";
            this.btn_qlnd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_qlnd_ItemClick);
            // 
            // btn_qlsp
            // 
            this.btn_qlsp.Caption = "Quản lý sản phẩm";
            this.btn_qlsp.Id = 2;
            this.btn_qlsp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_qlsp.ImageOptions.Image")));
            this.btn_qlsp.LargeWidth = 105;
            this.btn_qlsp.Name = "btn_qlsp";
            this.btn_qlsp.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_qlsp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_qlsp_ItemClick);
            // 
            // btn_qlnh
            // 
            this.btn_qlnh.Caption = "Quản lý nhập hàng";
            this.btn_qlnh.Id = 3;
            this.btn_qlnh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_qlnh.ImageOptions.Image")));
            this.btn_qlnh.LargeWidth = 105;
            this.btn_qlnh.Name = "btn_qlnh";
            this.btn_qlnh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_qlnh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_qlnh_ItemClick);
            // 
            // btn_qlbh
            // 
            this.btn_qlbh.Caption = "Quản lý bán hàng";
            this.btn_qlbh.Id = 4;
            this.btn_qlbh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_qlbh.ImageOptions.Image")));
            this.btn_qlbh.LargeWidth = 105;
            this.btn_qlbh.Name = "btn_qlbh";
            this.btn_qlbh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_qlbh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_qlbh_ItemClick);
            // 
            // btn_qlkh
            // 
            this.btn_qlkh.Caption = "Quản lý khách hàng";
            this.btn_qlkh.Id = 5;
            this.btn_qlkh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_qlkh.ImageOptions.Image")));
            this.btn_qlkh.LargeWidth = 105;
            this.btn_qlkh.Name = "btn_qlkh";
            this.btn_qlkh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btn_qlkh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_qlkh_ItemClick);
            // 
            // byn_bctk
            // 
            this.byn_bctk.Caption = "Báo cáo thống kê";
            this.byn_bctk.Id = 6;
            this.byn_bctk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("byn_bctk.ImageOptions.Image")));
            this.byn_bctk.LargeWidth = 105;
            this.byn_bctk.Name = "byn_bctk";
            this.byn_bctk.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.byn_bctk.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.byn_bctk_ItemClick);
            // 
            // btn_tc
            // 
            this.btn_tc.Caption = "Tra cứu";
            this.btn_tc.Id = 7;
            this.btn_tc.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_tc.ImageOptions.LargeImage")));
            this.btn_tc.LargeWidth = 105;
            this.btn_tc.Name = "btn_tc";
            this.btn_tc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_tc_ItemClick);
            // 
            // tacvu
            // 
            this.tacvu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.page_nguoidung,
            this.page_sanpham,
            this.page_nhaphang,
            this.ribbonPageGroup1,
            this.page_khachhang,
            this.page_thongke,
            this.page_tracuu});
            this.tacvu.Name = "tacvu";
            this.tacvu.Text = "Tác vụ";
            // 
            // page_nguoidung
            // 
            this.page_nguoidung.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.True;
            this.page_nguoidung.ItemLinks.Add(this.btn_qlnd);
            this.page_nguoidung.Name = "page_nguoidung";
            this.page_nguoidung.Text = "Người dùng";
            // 
            // page_sanpham
            // 
            this.page_sanpham.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.True;
            this.page_sanpham.ItemLinks.Add(this.btn_qlsp);
            this.page_sanpham.Name = "page_sanpham";
            this.page_sanpham.Text = "Sản phẩm";
            // 
            // page_nhaphang
            // 
            this.page_nhaphang.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.True;
            this.page_nhaphang.ItemLinks.Add(this.btn_qlnh);
            this.page_nhaphang.Name = "page_nhaphang";
            this.page_nhaphang.Text = "Nhập hàng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_qlbh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Bán hàng";
            // 
            // page_khachhang
            // 
            this.page_khachhang.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.True;
            this.page_khachhang.ItemLinks.Add(this.btn_qlkh);
            this.page_khachhang.Name = "page_khachhang";
            this.page_khachhang.Text = "Khách hàng";
            // 
            // page_thongke
            // 
            this.page_thongke.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.True;
            this.page_thongke.ItemLinks.Add(this.byn_bctk);
            this.page_thongke.Name = "page_thongke";
            this.page_thongke.Text = "Thống kê";
            // 
            // page_tracuu
            // 
            this.page_tracuu.ItemLinks.Add(this.btn_tc);
            this.page_tracuu.Name = "page_tracuu";
            this.page_tracuu.Text = "Tra cứu";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 772);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1497, 37);
            // 
            // dcmManager
            // 
            this.dcmManager.MdiParent = this;
            this.dcmManager.MenuManager = this.ribbon;
            this.dcmManager.View = this.tabbedView1;
            this.dcmManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.Style = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Light;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.Style = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Light;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("795d0690-91bf-4e60-ab75-1884d8036cfb");
            this.dockPanel1.Location = new System.Drawing.Point(0, 178);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowAutoHideButton = false;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(201, 200);
            this.dockPanel1.Size = new System.Drawing.Size(251, 594);
            this.dockPanel1.Text = "TRANG CHỦ";
            this.dockPanel1.Click += new System.EventHandler(this.dockPanel1_Click);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.accordionControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 26);
            this.dockPanel1_Container.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(250, 568);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.acc_ele_tacvu,
            this.accordionControlElement2,
            this.accordionControlSeparator2,
            this.accordionControlElement3});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.Size = new System.Drawing.Size(232, 530);
            this.accordionControl1.TabIndex = 0;
            // 
            // acc_ele_tacvu
            // 
            this.acc_ele_tacvu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.acc_qlnd,
            this.acc_qlsp,
            this.acc_qlnh,
            this.acc_qlbh,
            this.acc_qlkh,
            this.acc_bctk,
            this.acc_tc,
            this.accordionControlSeparator1});
            this.acc_ele_tacvu.Expanded = true;
            this.acc_ele_tacvu.Name = "acc_ele_tacvu";
            this.acc_ele_tacvu.Text = "Tác vụ";
            this.acc_ele_tacvu.Click += new System.EventHandler(this.acc_ele_tacvu_Click);
            // 
            // acc_qlnd
            // 
            this.acc_qlnd.Name = "acc_qlnd";
            this.acc_qlnd.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acc_qlnd.Text = "Quản lý người dùng";
            this.acc_qlnd.Click += new System.EventHandler(this.acc_qlnd_Click);
            // 
            // acc_qlsp
            // 
            this.acc_qlsp.Name = "acc_qlsp";
            this.acc_qlsp.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acc_qlsp.Text = "Quản lý sản phẩm";
            this.acc_qlsp.Click += new System.EventHandler(this.acc_qlsp_Click);
            // 
            // acc_qlnh
            // 
            this.acc_qlnh.Name = "acc_qlnh";
            this.acc_qlnh.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acc_qlnh.Text = "Quản lý nhập hàng";
            this.acc_qlnh.Click += new System.EventHandler(this.acc_qlnh_Click);
            // 
            // acc_qlbh
            // 
            this.acc_qlbh.Name = "acc_qlbh";
            this.acc_qlbh.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acc_qlbh.Text = "Quản lý bán hàng";
            this.acc_qlbh.Click += new System.EventHandler(this.acc_qlbh_Click);
            // 
            // acc_qlkh
            // 
            this.acc_qlkh.Name = "acc_qlkh";
            this.acc_qlkh.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acc_qlkh.Text = "Quản lý khách hàng";
            this.acc_qlkh.Click += new System.EventHandler(this.acc_qlkh_Click);
            // 
            // acc_bctk
            // 
            this.acc_bctk.Name = "acc_bctk";
            this.acc_bctk.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acc_bctk.Text = "Báo cáo thống kê";
            this.acc_bctk.Click += new System.EventHandler(this.acc_bctk_Click);
            // 
            // acc_tc
            // 
            this.acc_tc.Name = "acc_tc";
            this.acc_tc.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acc_tc.Text = "Tra cứu";
            this.acc_tc.Click += new System.EventHandler(this.acc_tc_Click);
            // 
            // accordionControlSeparator1
            // 
            this.accordionControlSeparator1.Name = "accordionControlSeparator1";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Text = "Element2";
            // 
            // accordionControlSeparator2
            // 
            this.accordionControlSeparator2.Name = "accordionControlSeparator2";
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Text = "Element3";
            // 
            // frm_qlkd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1497, 809);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_qlkd";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "QUẢN LÝ KINH DOANH";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcmManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage tacvu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup page_nguoidung;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btn_qlnd;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup page_sanpham;
        private DevExpress.XtraBars.BarButtonItem btn_qlsp;
        private DevExpress.XtraBars.BarButtonItem btn_qlnh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup page_nhaphang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btn_qlbh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup page_khachhang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup page_thongke;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup page_tracuu;
        private DevExpress.XtraBars.BarButtonItem btn_qlkh;
        private DevExpress.XtraBars.BarButtonItem byn_bctk;
        private DevExpress.XtraBars.BarButtonItem btn_tc;
        private DevExpress.XtraBars.Docking2010.DocumentManager dcmManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acc_ele_tacvu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acc_qlnd;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acc_qlsp;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acc_qlnh;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acc_qlbh;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acc_qlkh;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acc_bctk;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acc_tc;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator1;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator2;
    }
}