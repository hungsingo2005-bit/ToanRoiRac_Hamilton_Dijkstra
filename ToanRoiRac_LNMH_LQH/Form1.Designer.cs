namespace ToanRoiRac_LNMH_LQH
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
            btnThemDinh = new Button();
            btnThemCanh = new Button();
            btnTimHamilton = new Button();
            pnVeDoThi = new Panel();
            lstThongBao = new ListBox();
            lblThongBao = new Label();
            lblThongTinDoThi = new Label();
            lblThongBao2 = new Label();
            btnChonDinhBatDau = new Button();
            lblChuTrinh = new Label();
            lstChuTrinh = new ListBox();
            lstDuongDi = new ListBox();
            lblDuongDi = new Label();
            gbChuThich = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pnCanh = new Panel();
            pnDangChon = new Panel();
            pnDuongDi = new Panel();
            pnDangXet = new Panel();
            pnStart = new Panel();
            gbChuThich.SuspendLayout();
            SuspendLayout();
            // 
            // btnThemDinh
            // 
            btnThemDinh.FlatStyle = FlatStyle.Popup;
            btnThemDinh.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnThemDinh.Location = new Point(12, 12);
            btnThemDinh.Name = "btnThemDinh";
            btnThemDinh.Size = new Size(71, 29);
            btnThemDinh.TabIndex = 0;
            btnThemDinh.TabStop = false;
            btnThemDinh.Text = "Đỉnh";
            btnThemDinh.UseVisualStyleBackColor = true;
            btnThemDinh.Click += btnThemDinh_Click;
            // 
            // btnThemCanh
            // 
            btnThemCanh.FlatStyle = FlatStyle.Popup;
            btnThemCanh.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnThemCanh.Location = new Point(93, 12);
            btnThemCanh.Name = "btnThemCanh";
            btnThemCanh.Size = new Size(69, 29);
            btnThemCanh.TabIndex = 1;
            btnThemCanh.TabStop = false;
            btnThemCanh.Text = "Cạnh ";
            btnThemCanh.UseVisualStyleBackColor = true;
            btnThemCanh.Click += btnThemCanh_Click;
            // 
            // btnTimHamilton
            // 
            btnTimHamilton.FlatStyle = FlatStyle.Popup;
            btnTimHamilton.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnTimHamilton.Location = new Point(319, 12);
            btnTimHamilton.Name = "btnTimHamilton";
            btnTimHamilton.Size = new Size(119, 29);
            btnTimHamilton.TabIndex = 2;
            btnTimHamilton.TabStop = false;
            btnTimHamilton.Text = "Tìm Hamilton";
            btnTimHamilton.UseVisualStyleBackColor = true;
            btnTimHamilton.Click += btnTimHamilton_Click;
            // 
            // pnVeDoThi
            // 
            pnVeDoThi.BorderStyle = BorderStyle.FixedSingle;
            pnVeDoThi.Location = new Point(12, 124);
            pnVeDoThi.Name = "pnVeDoThi";
            pnVeDoThi.Size = new Size(471, 307);
            pnVeDoThi.TabIndex = 3;
            pnVeDoThi.Paint += pnVeDoThi_Paint;
            pnVeDoThi.MouseClick += pnVeDoThi_MouseClick;
            // 
            // lstThongBao
            // 
            lstThongBao.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lstThongBao.FormattingEnabled = true;
            lstThongBao.ItemHeight = 19;
            lstThongBao.Location = new Point(503, 124);
            lstThongBao.Name = "lstThongBao";
            lstThongBao.Size = new Size(318, 270);
            lstThongBao.TabIndex = 4;
            lstThongBao.SelectedIndexChanged += lstThongBao_SelectedIndexChanged;
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.BorderStyle = BorderStyle.FixedSingle;
            lblThongBao.FlatStyle = FlatStyle.Flat;
            lblThongBao.Location = new Point(581, 99);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(131, 22);
            lblThongBao.TabIndex = 5;
            lblThongBao.Text = "Nhật kí hoạt động";
            // 
            // lblThongTinDoThi
            // 
            lblThongTinDoThi.AutoSize = true;
            lblThongTinDoThi.Location = new Point(165, 78);
            lblThongTinDoThi.Name = "lblThongTinDoThi";
            lblThongTinDoThi.Size = new Size(18, 20);
            lblThongTinDoThi.TabIndex = 6;
            lblThongTinDoThi.Text = "...";
            lblThongTinDoThi.Click += lblThongTinDoThi_Click;
            // 
            // lblThongBao2
            // 
            lblThongBao2.AutoSize = true;
            lblThongBao2.Location = new Point(40, 78);
            lblThongBao2.Name = "lblThongBao2";
            lblThongBao2.Size = new Size(122, 20);
            lblThongBao2.TabIndex = 7;
            lblThongBao2.Text = "Thông tin đồ thị :";
            // 
            // btnChonDinhBatDau
            // 
            btnChonDinhBatDau.FlatStyle = FlatStyle.Popup;
            btnChonDinhBatDau.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnChonDinhBatDau.Location = new Point(168, 12);
            btnChonDinhBatDau.Name = "btnChonDinhBatDau";
            btnChonDinhBatDau.Size = new Size(145, 29);
            btnChonDinhBatDau.TabIndex = 8;
            btnChonDinhBatDau.TabStop = false;
            btnChonDinhBatDau.Text = "Chọn đỉnh bắt đầu";
            btnChonDinhBatDau.UseVisualStyleBackColor = true;
            btnChonDinhBatDau.Click += btnChonDinhBatDau_Click;
            // 
            // lblChuTrinh
            // 
            lblChuTrinh.AutoSize = true;
            lblChuTrinh.BorderStyle = BorderStyle.FixedSingle;
            lblChuTrinh.Location = new Point(719, 424);
            lblChuTrinh.Name = "lblChuTrinh";
            lblChuTrinh.Size = new Size(134, 22);
            lblChuTrinh.TabIndex = 9;
            lblChuTrinh.Text = "Chu trình tìm được";
            lblChuTrinh.Click += lblChuTrinh_Click;
            // 
            // lstChuTrinh
            // 
            lstChuTrinh.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lstChuTrinh.FormattingEnabled = true;
            lstChuTrinh.ItemHeight = 19;
            lstChuTrinh.Location = new Point(503, 449);
            lstChuTrinh.Name = "lstChuTrinh";
            lstChuTrinh.Size = new Size(576, 137);
            lstChuTrinh.TabIndex = 10;
            lstChuTrinh.SelectedIndexChanged += lstChuTrinh_SelectedIndexChanged;
            // 
            // lstDuongDi
            // 
            lstDuongDi.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lstDuongDi.FormattingEnabled = true;
            lstDuongDi.ItemHeight = 19;
            lstDuongDi.Location = new Point(854, 124);
            lstDuongDi.Name = "lstDuongDi";
            lstDuongDi.Size = new Size(225, 80);
            lstDuongDi.TabIndex = 11;
            // 
            // lblDuongDi
            // 
            lblDuongDi.AutoSize = true;
            lblDuongDi.BorderStyle = BorderStyle.FixedSingle;
            lblDuongDi.Location = new Point(889, 99);
            lblDuongDi.Name = "lblDuongDi";
            lblDuongDi.Size = new Size(131, 22);
            lblDuongDi.TabIndex = 12;
            lblDuongDi.Text = "Đường đi hiện tại ";
            // 
            // gbChuThich
            // 
            gbChuThich.Controls.Add(label5);
            gbChuThich.Controls.Add(label4);
            gbChuThich.Controls.Add(label3);
            gbChuThich.Controls.Add(label2);
            gbChuThich.Controls.Add(label1);
            gbChuThich.Controls.Add(pnCanh);
            gbChuThich.Controls.Add(pnDangChon);
            gbChuThich.Controls.Add(pnDuongDi);
            gbChuThich.Controls.Add(pnDangXet);
            gbChuThich.Controls.Add(pnStart);
            gbChuThich.Location = new Point(14, 489);
            gbChuThich.Name = "gbChuThich";
            gbChuThich.Size = new Size(469, 129);
            gbChuThich.TabIndex = 13;
            gbChuThich.TabStop = false;
            gbChuThich.Text = "Chú thích";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 97);
            label5.Name = "label5";
            label5.Size = new Size(148, 20);
            label5.TabIndex = 9;
            label5.Text = "Cạnh thuộc đường đi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(253, 61);
            label4.Name = "label4";
            label4.Size = new Size(114, 20);
            label4.TabIndex = 8;
            label4.Text = "Đỉnh được chọn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(253, 27);
            label3.Name = "label3";
            label3.Size = new Size(198, 20);
            label3.TabIndex = 7;
            label3.Text = "Đỉnh trong đường đi hiện tại";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 61);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 6;
            label2.Text = "Đỉnh đang xét";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 27);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 5;
            label1.Text = "Đỉnh bắt đầu";
            // 
            // pnCanh
            // 
            pnCanh.BackColor = Color.DarkOrange;
            pnCanh.Location = new Point(17, 95);
            pnCanh.Name = "pnCanh";
            pnCanh.Size = new Size(22, 22);
            pnCanh.TabIndex = 4;
            // 
            // pnDangChon
            // 
            pnDangChon.BackColor = Color.Yellow;
            pnDangChon.Location = new Point(214, 59);
            pnDangChon.Name = "pnDangChon";
            pnDangChon.Size = new Size(22, 22);
            pnDangChon.TabIndex = 3;
            // 
            // pnDuongDi
            // 
            pnDuongDi.BackColor = Color.DeepSkyBlue;
            pnDuongDi.Location = new Point(214, 27);
            pnDuongDi.Name = "pnDuongDi";
            pnDuongDi.Size = new Size(22, 22);
            pnDuongDi.TabIndex = 2;
            // 
            // pnDangXet
            // 
            pnDangXet.BackColor = Color.Red;
            pnDangXet.Location = new Point(17, 61);
            pnDangXet.Name = "pnDangXet";
            pnDangXet.Size = new Size(22, 22);
            pnDangXet.TabIndex = 1;
            // 
            // pnStart
            // 
            pnStart.BackColor = Color.LightGreen;
            pnStart.Location = new Point(17, 27);
            pnStart.Name = "pnStart";
            pnStart.Size = new Size(22, 22);
            pnStart.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 627);
            Controls.Add(gbChuThich);
            Controls.Add(lblDuongDi);
            Controls.Add(lstDuongDi);
            Controls.Add(lstChuTrinh);
            Controls.Add(lblChuTrinh);
            Controls.Add(btnChonDinhBatDau);
            Controls.Add(lblThongBao2);
            Controls.Add(lblThongTinDoThi);
            Controls.Add(lblThongBao);
            Controls.Add(lstThongBao);
            Controls.Add(pnVeDoThi);
            Controls.Add(btnTimHamilton);
            Controls.Add(btnThemCanh);
            Controls.Add(btnThemDinh);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            gbChuThich.ResumeLayout(false);
            gbChuThich.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnThemDinh;
        private Button btnThemCanh;
        private Button btnTimHamilton;
        private Panel pnVeDoThi;
        private ListBox lstThongBao;
        private Label lblThongBao;
        private Label lblThongTinDoThi;
        private Label lblThongBao2;
        private Button btnChonDinhBatDau;
        private Label lblChuTrinh;
        private ListBox lstChuTrinh;
        private ListBox lstDuongDi;
        private Label lblDuongDi;
        private GroupBox gbChuThich;
        private Label label1;
        private Panel pnCanh;
        private Panel pnDangChon;
        private Panel pnDuongDi;
        private Panel pnDangXet;
        private Panel pnStart;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}
