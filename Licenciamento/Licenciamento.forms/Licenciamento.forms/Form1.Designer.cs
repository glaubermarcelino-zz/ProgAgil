namespace Licenciamento.forms
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSerialEstacao = new System.Windows.Forms.Label();
            this.btnAtivar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnBloquear = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSerialEstacao
            // 
            this.lblSerialEstacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSerialEstacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialEstacao.Location = new System.Drawing.Point(52, 29);
            this.lblSerialEstacao.Name = "lblSerialEstacao";
            this.lblSerialEstacao.Size = new System.Drawing.Size(594, 69);
            this.lblSerialEstacao.TabIndex = 0;
            this.lblSerialEstacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAtivar
            // 
            this.btnAtivar.Location = new System.Drawing.Point(52, 110);
            this.btnAtivar.Name = "btnAtivar";
            this.btnAtivar.Size = new System.Drawing.Size(103, 44);
            this.btnAtivar.TabIndex = 1;
            this.btnAtivar.Text = "Ativar Estação";
            this.btnAtivar.UseVisualStyleBackColor = true;
            this.btnAtivar.Click += new System.EventHandler(this.btnAtivar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(225, 110);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(103, 44);
            this.btnCadastrar.TabIndex = 2;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnBloquear
            // 
            this.btnBloquear.Location = new System.Drawing.Point(388, 110);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(103, 44);
            this.btnBloquear.TabIndex = 2;
            this.btnBloquear.Text = "Bloquear";
            this.btnBloquear.UseVisualStyleBackColor = true;
            this.btnBloquear.Click += new System.EventHandler(this.btnBloquear_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(543, 110);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(103, 44);
            this.btnStatus.TabIndex = 2;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 191);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnBloquear);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnAtivar);
            this.Controls.Add(this.lblSerialEstacao);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSerialEstacao;
        private System.Windows.Forms.Button btnAtivar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnBloquear;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button button1;
    }
}

