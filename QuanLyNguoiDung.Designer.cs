namespace DO_AN_1
{
    partial class QuanLyNguoiDung
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

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyNguoiDung));
            this.dgv_nguoidung = new System.Windows.Forms.DataGridView();
            this.btn_Timkiem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Matkhau = new System.Windows.Forms.TextBox();
            this.txt_taikhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Diachi = new System.Windows.Forms.TextBox();
            this.txt_Chucvu = new System.Windows.Forms.TextBox();
            this.rbnu = new System.Windows.Forms.RadioButton();
            this.rbnam = new System.Windows.Forms.RadioButton();
            this.txt_Hoten = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.datetime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nguoidung)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_nguoidung
            // 
            this.dgv_nguoidung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_nguoidung.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_nguoidung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_nguoidung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nguoidung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.MaNV,
            this.HoTen,
            this.Ngaysinh,
            this.gt,
            this.ChucVu,
            this.DiaChi});
            this.dgv_nguoidung.EnableHeadersVisualStyles = false;
            this.dgv_nguoidung.Location = new System.Drawing.Point(510, 303);
            this.dgv_nguoidung.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_nguoidung.Name = "dgv_nguoidung";
            this.dgv_nguoidung.ReadOnly = true;
            this.dgv_nguoidung.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_nguoidung.RowHeadersWidth = 51;
            this.dgv_nguoidung.Size = new System.Drawing.Size(771, 338);
            this.dgv_nguoidung.TabIndex = 64;
            this.dgv_nguoidung.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nguoidung_CellContentClick_2);
            // 
            // btn_Timkiem
            // 
            this.btn_Timkiem.BackColor = System.Drawing.Color.White;
            this.btn_Timkiem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Timkiem.ForeColor = System.Drawing.Color.Black;
            this.btn_Timkiem.Image = ((System.Drawing.Image)(resources.GetObject("btn_Timkiem.Image")));
            this.btn_Timkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Timkiem.Location = new System.Drawing.Point(362, 47);
            this.btn_Timkiem.Name = "btn_Timkiem";
            this.btn_Timkiem.Size = new System.Drawing.Size(137, 43);
            this.btn_Timkiem.TabIndex = 66;
            this.btn_Timkiem.Text = "&Tìm kiếm";
            this.btn_Timkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Timkiem.UseVisualStyleBackColor = false;
            this.btn_Timkiem.Click += new System.EventHandler(this.btn_Timkiem_Click_2);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Yellow;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(362, 125);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(137, 43);
            this.btnThoat.TabIndex = 65;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click_3);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(32, 125);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(116, 43);
            this.btnXoa.TabIndex = 35;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_2);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btn_Timkiem);
            this.groupBox2.Controls.Add(this.btnBoqua);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(510, 76);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.groupBox2.Size = new System.Drawing.Size(521, 194);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tác vụ ";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(32, 47);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(116, 43);
            this.btnThem.TabIndex = 36;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_2);
            // 
            // btnBoqua
            // 
            this.btnBoqua.BackColor = System.Drawing.Color.White;
            this.btnBoqua.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoqua.Image = ((System.Drawing.Image)(resources.GetObject("btnBoqua.Image")));
            this.btnBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoqua.Location = new System.Drawing.Point(196, 125);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(116, 43);
            this.btnBoqua.TabIndex = 59;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBoqua.UseVisualStyleBackColor = false;
            this.btnBoqua.Click += new System.EventHandler(this.btnBoqua_Click_2);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(196, 47);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(116, 43);
            this.btnSua.TabIndex = 37;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_2);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(450, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(404, 40);
            this.label12.TabIndex = 69;
            this.label12.Text = "QUẢN LÝ NGƯỜI DÙNG";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox1.Controls.Add(this.txt_Matkhau);
            this.groupBox1.Controls.Add(this.txt_taikhoan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txt_Diachi);
            this.groupBox1.Controls.Add(this.txt_Chucvu);
            this.groupBox1.Controls.Add(this.rbnu);
            this.groupBox1.Controls.Add(this.rbnam);
            this.groupBox1.Controls.Add(this.txt_Hoten);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.datetime);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(33, 76);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.groupBox1.Size = new System.Drawing.Size(433, 565);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin người dùng";
            // 
            // txt_Matkhau
            // 
            this.txt_Matkhau.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Matkhau.Location = new System.Drawing.Point(129, 125);
            this.txt_Matkhau.Name = "txt_Matkhau";
            this.txt_Matkhau.Size = new System.Drawing.Size(283, 34);
            this.txt_Matkhau.TabIndex = 61;
            // 
            // txt_taikhoan
            // 
            this.txt_taikhoan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_taikhoan.Location = new System.Drawing.Point(127, 56);
            this.txt_taikhoan.Name = "txt_taikhoan";
            this.txt_taikhoan.Size = new System.Drawing.Size(283, 34);
            this.txt_taikhoan.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 26);
            this.label2.TabIndex = 59;
            this.label2.Text = "Mật Khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 26);
            this.label1.TabIndex = 58;
            this.label1.Text = "Tài Khoản";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(129, 187);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(283, 34);
            this.txtMaNV.TabIndex = 57;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(20, 187);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 26);
            this.label13.TabIndex = 56;
            this.label13.Text = "Mã NV";
            // 
            // txt_Diachi
            // 
            this.txt_Diachi.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.txt_Diachi.Location = new System.Drawing.Point(128, 514);
            this.txt_Diachi.Multiline = true;
            this.txt_Diachi.Name = "txt_Diachi";
            this.txt_Diachi.Size = new System.Drawing.Size(283, 33);
            this.txt_Diachi.TabIndex = 55;
            // 
            // txt_Chucvu
            // 
            this.txt_Chucvu.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.txt_Chucvu.Location = new System.Drawing.Point(129, 453);
            this.txt_Chucvu.Multiline = true;
            this.txt_Chucvu.Name = "txt_Chucvu";
            this.txt_Chucvu.Size = new System.Drawing.Size(283, 31);
            this.txt_Chucvu.TabIndex = 54;
            // 
            // rbnu
            // 
            this.rbnu.AutoSize = true;
            this.rbnu.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnu.Location = new System.Drawing.Point(261, 386);
            this.rbnu.Name = "rbnu";
            this.rbnu.Size = new System.Drawing.Size(63, 31);
            this.rbnu.TabIndex = 47;
            this.rbnu.TabStop = true;
            this.rbnu.Text = "Nữ";
            this.rbnu.UseVisualStyleBackColor = true;
            // 
            // rbnam
            // 
            this.rbnam.AutoSize = true;
            this.rbnam.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnam.Location = new System.Drawing.Point(139, 386);
            this.rbnam.Name = "rbnam";
            this.rbnam.Size = new System.Drawing.Size(79, 31);
            this.rbnam.TabIndex = 48;
            this.rbnam.TabStop = true;
            this.rbnam.Text = "Nam";
            this.rbnam.UseVisualStyleBackColor = true;
            // 
            // txt_Hoten
            // 
            this.txt_Hoten.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Hoten.Location = new System.Drawing.Point(128, 253);
            this.txt_Hoten.Multiline = true;
            this.txt_Hoten.Name = "txt_Hoten";
            this.txt_Hoten.Size = new System.Drawing.Size(283, 34);
            this.txt_Hoten.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 514);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 27);
            this.label9.TabIndex = 46;
            this.label9.Text = "Địa Chỉ";
            // 
            // datetime
            // 
            this.datetime.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.datetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime.Location = new System.Drawing.Point(129, 321);
            this.datetime.Name = "datetime";
            this.datetime.Size = new System.Drawing.Size(283, 34);
            this.datetime.TabIndex = 49;
            this.datetime.Value = new System.DateTime(2024, 5, 5, 20, 43, 49, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 27);
            this.label8.TabIndex = 45;
            this.label8.Text = "Chức Vụ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 27);
            this.label5.TabIndex = 42;
            this.label5.Text = "Họ Tên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 27);
            this.label7.TabIndex = 44;
            this.label7.Text = "Giới Tính";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 27);
            this.label6.TabIndex = 43;
            this.label6.Text = "Ngày Sinh";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1070, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 194);
            this.button1.TabIndex = 70;
            this.button1.UseVisualStyleBackColor = false;

            // 
            // MaNhanVien
            // 

            this.Column1.DataPropertyName = "TaiKhoan";
            this.Column1.HeaderText = "Tài Khoản";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;

            // 
            // HoTen
            // 

            this.Column2.DataPropertyName = "MatKhau";
            this.Column2.HeaderText = "Mật Khẩu";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã Nhân Viên";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // Ngaysinh
            // 
            this.Ngaysinh.DataPropertyName = "NamSinh";
            this.Ngaysinh.HeaderText = "Năm Sinh";
            this.Ngaysinh.MinimumWidth = 6;
            this.Ngaysinh.Name = "Ngaysinh";
            this.Ngaysinh.ReadOnly = true;
            // 
            // gt
            // 
            this.gt.DataPropertyName = "GioiTinh";
            this.gt.HeaderText = "Giới Tính";
            this.gt.MinimumWidth = 6;
            this.gt.Name = "gt";
            this.gt.ReadOnly = true;
            // 
            // ChucVu
            // 
            this.ChucVu.DataPropertyName = "ChucVu";
            this.ChucVu.HeaderText = "Chức Vụ";
            this.ChucVu.MinimumWidth = 6;
            this.ChucVu.Name = "ChucVu";
            this.ChucVu.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.MinimumWidth = 6;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // QuanLyNguoiDung
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 667);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_nguoidung);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("QuanLyNguoiDung.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QuanLyNguoiDung";
            this.Text = "QuanLyNguoiDung";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nguoidung)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.DataGridView dgv_nguoidung;
        private System.Windows.Forms.Button btn_Timkiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Diachi;
        private System.Windows.Forms.TextBox txt_Chucvu;
        private System.Windows.Forms.RadioButton rbnu;
        private System.Windows.Forms.RadioButton rbnam;
        private System.Windows.Forms.TextBox txt_Hoten;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker datetime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Matkhau;
        private System.Windows.Forms.TextBox txt_taikhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn gt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;

    }
}