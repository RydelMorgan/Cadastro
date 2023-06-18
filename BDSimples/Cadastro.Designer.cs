namespace BDSimples
{
    partial class Cadastros
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cadastros));
            nome = new Label();
            nameBox = new TextBox();
            sexo = new Label();
            cidade = new Label();
            cityBox = new TextBox();
            btn_incluir = new Button();
            btn_alterar = new Button();
            btn_excluir = new Button();
            btn_contar = new Button();
            F = new RadioButton();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel4 = new Panel();
            analiseText = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            dgvSearch = new DataGridView();
            panel3 = new Panel();
            M = new RadioButton();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSearch).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // nome
            // 
            resources.ApplyResources(nome, "nome");
            nome.Name = "nome";
            // 
            // nameBox
            // 
            resources.ApplyResources(nameBox, "nameBox");
            nameBox.BorderStyle = BorderStyle.FixedSingle;
            nameBox.Cursor = Cursors.IBeam;
            nameBox.Name = "nameBox";
            // 
            // sexo
            // 
            resources.ApplyResources(sexo, "sexo");
            sexo.Name = "sexo";
            // 
            // cidade
            // 
            resources.ApplyResources(cidade, "cidade");
            cidade.Name = "cidade";
            // 
            // cityBox
            // 
            resources.ApplyResources(cityBox, "cityBox");
            cityBox.AccessibleRole = AccessibleRole.ScrollBar;
            cityBox.BorderStyle = BorderStyle.FixedSingle;
            cityBox.Cursor = Cursors.IBeam;
            cityBox.Name = "cityBox";
            // 
            // btn_incluir
            // 
            resources.ApplyResources(btn_incluir, "btn_incluir");
            btn_incluir.Name = "btn_incluir";
            btn_incluir.UseVisualStyleBackColor = true;
            btn_incluir.Click += btnIncluir_Click;
            // 
            // btn_alterar
            // 
            resources.ApplyResources(btn_alterar, "btn_alterar");
            btn_alterar.Name = "btn_alterar";
            btn_alterar.UseVisualStyleBackColor = true;
            btn_alterar.Click += btnAlterar_Click;
            // 
            // btn_excluir
            // 
            resources.ApplyResources(btn_excluir, "btn_excluir");
            btn_excluir.Name = "btn_excluir";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btnExcluir_Click;
            // 
            // btn_contar
            // 
            resources.ApplyResources(btn_contar, "btn_contar");
            btn_contar.Name = "btn_contar";
            btn_contar.UseVisualStyleBackColor = true;
            btn_contar.Click += btnContar_Click;
            // 
            // F
            // 
            resources.ApplyResources(F, "F");
            F.Name = "F";
            F.TabStop = true;
            F.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Name = "panel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(tableLayoutPanel2, "tableLayoutPanel2");
            tableLayoutPanel2.Controls.Add(panel4, 0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // panel4
            // 
            resources.ApplyResources(panel4, "panel4");
            panel4.Controls.Add(analiseText);
            panel4.Controls.Add(btn_contar);
            panel4.Name = "panel4";
            // 
            // analiseText
            // 
            resources.ApplyResources(analiseText, "analiseText");
            analiseText.Name = "analiseText";
            analiseText.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.Controls.Add(dgvSearch);
            panel2.Name = "panel2";
            // 
            // dgvSearch
            // 
            resources.ApplyResources(dgvSearch, "dgvSearch");
            dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSearch.Name = "dgvSearch";
            dgvSearch.ReadOnly = true;
            dgvSearch.RowTemplate.Height = 25;
            dgvSearch.DoubleClick += dgvSearch_DoubleClick;
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.Controls.Add(F);
            panel3.Controls.Add(btn_excluir);
            panel3.Controls.Add(nome);
            panel3.Controls.Add(btn_alterar);
            panel3.Controls.Add(M);
            panel3.Controls.Add(btn_incluir);
            panel3.Controls.Add(sexo);
            panel3.Controls.Add(cidade);
            panel3.Controls.Add(nameBox);
            panel3.Controls.Add(cityBox);
            panel3.Name = "panel3";
            // 
            // M
            // 
            resources.ApplyResources(M, "M");
            M.Name = "M";
            M.TabStop = true;
            M.UseVisualStyleBackColor = true;
            // 
            // Cadastros
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(panel1);
            Name = "Cadastros";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSearch).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        private Label nome;
        private Label sexo;
        private Label cidade;

        private TextBox nameBox;
        private TextBox cityBox;
        private TextBox analiseText;

        private Button btn_incluir;
        private Button btn_alterar;
        private Button btn_excluir;
        private Button btn_contar;

        private RadioButton F;
        private RadioButton M;

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;

        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;

        private DataGridView dgvSearch;
    }
}