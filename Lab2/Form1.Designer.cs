namespace Lab2
{
  partial class Form1
  {
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
      menuStrip1 = new MenuStrip();
      menuCalculate = new ToolStripMenuItem();
      menuStep = new ToolStripMenuItem();
      menuClear = new ToolStripMenuItem();
      lblF = new Label();
      txtFormula = new TextBox();
      lblA = new Label();
      txtA = new TextBox();
      lblB = new Label();
      txtB = new TextBox();
      lblE = new Label();
      txtEps = new TextBox();
      lblResult = new Label();
      picGraph = new PictureBox();
      menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)picGraph).BeginInit();
      SuspendLayout();
     
      menuStrip1.Items.AddRange(new ToolStripItem[] { menuCalculate, menuStep, menuClear });
      menuStrip1.Location = new Point(0, 0);
      menuStrip1.Name = "menuStrip1";
      menuStrip1.Size = new Size(884, 24);
      menuStrip1.TabIndex = 0;
      menuStrip1.Text = "menuStrip1";
      
      menuCalculate.Name = "menuCalculate";
      menuCalculate.Size = new Size(80, 20);
      menuCalculate.Text = "Рассчитать";
      menuCalculate.Click += menuCalculate_Click;
     
      menuStep.Name = "menuStep";
      menuStep.Size = new Size(83, 20);
      menuStep.Text = "Шаг вперед";
      menuStep.Click += menuStep_Click;
     
      menuClear.Name = "menuClear";
      menuClear.Size = new Size(71, 20);
      menuClear.Text = "Очистить";
      menuClear.Click += menuClear_Click;
    
      lblF.AutoSize = true;
      lblF.Location = new Point(12, 38);
      lblF.Name = "lblF";
      lblF.Size = new Size(27, 15);
      lblF.TabIndex = 1;
      lblF.Text = "f(x):";
    
      txtFormula.Location = new Point(45, 35);
      txtFormula.Name = "txtFormula";
      txtFormula.Size = new Size(180, 23);
      txtFormula.TabIndex = 2;
      txtFormula.Text = "x*x-4*x+4";
    
      lblA.AutoSize = true;
      lblA.Location = new Point(235, 38);
      lblA.Name = "lblA";
      lblA.Size = new Size(16, 15);
      lblA.TabIndex = 3;
      lblA.Text = "a:";
   
      txtA.Location = new Point(255, 35);
      txtA.Name = "txtA";
      txtA.Size = new Size(50, 23);
      txtA.TabIndex = 4;
      txtA.Text = "0";
   
      lblB.AutoSize = true;
      lblB.Location = new Point(315, 38);
      lblB.Name = "lblB";
      lblB.Size = new Size(17, 15);
      lblB.TabIndex = 5;
      lblB.Text = "b:";
   
      txtB.Location = new Point(335, 35);
      txtB.Name = "txtB";
      txtB.Size = new Size(50, 23);
      txtB.TabIndex = 6;
      txtB.Text = "5";
     
      lblE.AutoSize = true;
      lblE.Location = new Point(395, 38);
      lblE.Name = "lblE";
      lblE.Size = new Size(16, 15);
      lblE.TabIndex = 7;
      lblE.Text = "e:";
     
      txtEps.Location = new Point(415, 35);
      txtEps.Name = "txtEps";
      txtEps.Size = new Size(60, 23);
      txtEps.TabIndex = 8;
      txtEps.Text = "0,001";
   
      lblResult.AutoSize = true;
      lblResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      lblResult.Location = new Point(12, 70);
      lblResult.Name = "lblResult";
      lblResult.Size = new Size(224, 15);
      lblResult.TabIndex = 9;
      lblResult.Text = "Введите данные и нажмите \"Рассчитать\"";
  
      picGraph.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      picGraph.BackColor = Color.White;
      picGraph.BorderStyle = BorderStyle.FixedSingle;
      picGraph.Location = new Point(12, 95);
      picGraph.Name = "picGraph";
      picGraph.Size = new Size(860, 450);
      picGraph.TabIndex = 10;
      picGraph.TabStop = false;
   
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(884, 561);
      Controls.Add(picGraph);
      Controls.Add(lblResult);
      Controls.Add(txtEps);
      Controls.Add(lblE);
      Controls.Add(txtB);
      Controls.Add(lblB);
      Controls.Add(txtA);
      Controls.Add(lblA);
      Controls.Add(txtFormula);
      Controls.Add(lblF);
      Controls.Add(menuStrip1);
      MainMenuStrip = menuStrip1;
      Name = "Form1";
      StartPosition = FormStartPosition.CenterScreen;
      menuStrip1.ResumeLayout(false);
      menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)picGraph).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem menuCalculate;
    private ToolStripMenuItem menuStep;
    private ToolStripMenuItem menuClear;
    private Label lblF;
    private TextBox txtFormula;
    private Label lblA;
    private TextBox txtA;
    private Label lblB;
    private TextBox txtB;
    private Label lblE;
    private TextBox txtEps;
    private Label lblResult;
    private PictureBox picGraph;
  }
}