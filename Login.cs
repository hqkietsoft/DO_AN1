using DevExpress.XtraEditors;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DO_AN_1
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        private Image originalImage;
        private Image hoverImage;
        ConnData connData = new ConnData();

        public Login()
        {
            InitializeComponent();

            pictureBox3.MouseEnter += new EventHandler(pictureBox3_MouseEnter);
            pictureBox3.MouseLeave += new EventHandler(pictureBox3_MouseLeave);
            pictureBox3.MouseClick += new MouseEventHandler(pictureBox3_MouseClick);

            originalImage = pictureBox3.Image;

            hoverImage = CreateHoverImage(originalImage);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = hoverImage;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = originalImage;
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private Image CreateHoverImage(Image original)
        {
            Bitmap bmp = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                float[][] colorMatrixElements = {
                    new float[] {0.3f, 0.3f, 0.3f, 0, 0}, // Red
                    new float[] {0.3f, 0.3f, 0.3f, 0, 0}, // Green
                    new float[] {0.3f, 0.3f, 0.3f, 0, 0}, // Blue
                    new float[] {0, 0, 0, 1, 0}, // Alpha
                    new float[] {0, 0, 0, 0, 1}
                };
                ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
            }

            return bmp;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateLogin()
        {
            if (string.IsNullOrEmpty(alphaBlendtxtTaiKhoan.Text))
            {
                alphaBlendtxtTaiKhoan.Focus();
                MessageBox.Show("Vui lòng nhập tài khoản người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(alphaBlendtxtMatKhau.Text))
            {
                alphaBlendtxtMatKhau.Focus();
                MessageBox.Show("Vui lòng nhập mật khẩu người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult huy = MessageBox.Show("Bạn có chắc muốn hủy đăng nhập", "Thông báo", MessageBoxButtons.YesNo);
            if (huy == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!ValidateLogin()) return;

            try
            {
                string strTenDangNhap = alphaBlendtxtTaiKhoan.Text.Trim();
                string strMatKhau = alphaBlendtxtMatKhau.Text.Trim();

                string connectionString = ConnData.GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM NguoiDung WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaiKhoan", strTenDangNhap);
                        command.Parameters.AddWithValue("@MatKhau", strMatKhau);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            this.Hide();

                            frm_qlkd frmMain = new frm_qlkd();
                            frmMain.ShowDialog(); // Hiển thị form chính và chờ cho đến khi nó được đóng
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult huy = MessageBox.Show("Bạn có chắc muốn hủy đăng nhập", "Thông báo", MessageBoxButtons.YesNo);
            if (huy == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (alphaBlendtxtMatKhau.PasswordChar == '*')
            {
                picShow.BringToFront();
                alphaBlendtxtMatKhau.PasswordChar = '\0';
            }
        }

        private void picShow_Click(object sender, EventArgs e)
        {
            if (alphaBlendtxtMatKhau.PasswordChar == '\0')
            {
                picHide.BringToFront();
                alphaBlendtxtMatKhau.PasswordChar = '*';
            }
        }

        private void alphaBlendtxtMatKhau_Enter(object sender, EventArgs e)
        {
            if (alphaBlendtxtMatKhau.Text == "Password")
            {
                alphaBlendtxtMatKhau.Text = "";
                alphaBlendtxtMatKhau.PasswordChar = '*';
            }
        }
        private void alphaBlendtxtMatKhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(alphaBlendtxtMatKhau.Text))
            {
                alphaBlendtxtMatKhau.Text = "Password";
                alphaBlendtxtMatKhau.PasswordChar = '\0';
            }
        }


        private void alphaBlendtxtTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (alphaBlendtxtTaiKhoan.Text == "Username")
            {
                alphaBlendtxtTaiKhoan.Text = "";
            }
        }

        private void alphaBlendtxtTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(alphaBlendtxtTaiKhoan.Text))
            {
                alphaBlendtxtTaiKhoan.Text = "Username";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)delegate
            {
                btnThoat.Focus();
            });
            
        }

        private void pictureBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    pictureBox3_Click(sender, e);
            //}
        }

        
    }
}
