using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NCalc;

namespace Lab2
{
  public partial class Form1 : Form
  {
    private List<double> steps = new List<double>();
    private int currentStepIndex = -1;
    private double currentPointX = double.NaN;

    public Form1()
    {
      InitializeComponent();
      picGraph.Paint += PicGraph_Paint;
    }

    // подсчет значения формулы f(x)
    private double Eval(string formula, double x)
    {
      Expression expr = new Expression(formula);
      expr.Parameters["x"] = x;
      return Convert.ToDouble(expr.Evaluate());
    }

    // первая производная: (f(x+h) - f(x-h)) / 2h
    private double D1(string f, double x, double h = 1e-5)
    {
      return (Eval(f, x + h) - Eval(f, x - h)) / (2.0 * h);
    }

    // вторая производная: (f(x+h) - 2f(x) + f(x-h)) / h^2
    private double D2(string f, double x, double h = 1e-5)
    {
      return (Eval(f, x + h) - 2.0 * Eval(f, x) + Eval(f, x - h)) / (h * h);
    }

    // метод ньютона
    private void RunNewton(string formula, double a, double b, double eps)
    {
      steps.Clear();
      double x = (a + b) / 2.0;
      steps.Add(x);

      int maxIter = 1000;
      for (int i = 0; i < maxIter; i++)
      {
        double d1 = D1(formula, x);
        double d2 = D2(formula, x);

        if (Math.Abs(d2) < 1e-12)
        {
          throw new Exception("Не удалось найти минимум (вторая производная близка к 0).");
        }

        double nextX = x - (d1 / d2);

        if (nextX < a) nextX = a;
        if (nextX > b) nextX = b;

        steps.Add(nextX);

        if (Math.Abs(nextX - x) < eps || Math.Abs(d1) < eps)
        {
          break;
        }
        x = nextX;
      }
    }

    // график
    private void PicGraph_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

      if (!double.TryParse(txtA.Text.Replace('.', ','), out double a) ||
          !double.TryParse(txtB.Text.Replace('.', ','), out double b) || a >= b) return;

      string f = txtFormula.Text.Trim();
      if (string.IsNullOrWhiteSpace(f)) return;

      int w = picGraph.ClientSize.Width;
      int h = picGraph.ClientSize.Height;
      if (w <= 0 || h <= 0) return;

      int count = 100;
      PointF[] points = new PointF[count + 1];
      double minY = double.MaxValue, maxY = double.MinValue;
      double[] ys = new double[count + 1];

      try
      {
        for (int i = 0; i <= count; i++)
        {
          double x = a + i * (b - a) / count;
          double y = Eval(f, x);
          ys[i] = y;
          if (y < minY) minY = y;
          if (y > maxY) maxY = y;
        }
      }
      catch
      {
        return;
      }

      if (Math.Abs(maxY - minY) < 1e-6) maxY = minY + 1;

      float ToScreenX(double x) => (float)((x - a) / (b - a) * (w - 40) + 20);
      float ToScreenY(double y) => (float)(h - 20 - (y - minY) / (maxY - minY) * (h - 40));

      g.DrawRectangle(Pens.LightGray, 20, 20, w - 40, h - 40);

      for (int i = 0; i <= count; i++)
      {
        double x = a + i * (b - a) / count;
        points[i] = new PointF(ToScreenX(x), ToScreenY(ys[i]));
      }

      using (Pen penCurve = new Pen(Color.SteelBlue, 2))
      {
        g.DrawLines(penCurve, points);
      }

      if (!double.IsNaN(currentPointX))
      {
        try
        {
          double py = Eval(f, currentPointX);
          float px = ToScreenX(currentPointX);
          float pyScreen = ToScreenY(py);

          using (Brush brush = new SolidBrush(Color.Crimson))
          {
            g.FillEllipse(brush, px - 6, pyScreen - 6, 12, 12);
          }
        }
        catch { }
      }
    }

    private void menuCalculate_Click(object sender, EventArgs e)
    {
      if (!ValidateInputs(out string f, out double a, out double b, out double eps)) return;

      try
      {
        RunNewton(f, a, b, eps);

        currentStepIndex = steps.Count - 1;
        currentPointX = steps[currentStepIndex];
        double minY = Eval(f, currentPointX);

        lblResult.Text = $"Минимум: x = {currentPointX:F4}, y = {minY:F4} (за {steps.Count - 1} шагов)";
        picGraph.Invalidate();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void menuStep_Click(object sender, EventArgs e)
    {
      if (steps.Count == 0)
      {
        if (!ValidateInputs(out string f, out double a, out double b, out double eps)) return;
        try
        {
          RunNewton(f, a, b, eps);
          currentStepIndex = -1;
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }

      if (currentStepIndex + 1 < steps.Count)
      {
        currentStepIndex++;
        currentPointX = steps[currentStepIndex];
        double currY = Eval(txtFormula.Text, currentPointX);

        lblResult.Text = $"Шаг {currentStepIndex}: x = {currentPointX:F4}, y = {currY:F4}";
        picGraph.Invalidate();
      }
      else
      {
        MessageBox.Show("Минимум уже найден!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void menuClear_Click(object sender, EventArgs e)
    {
      steps.Clear();
      currentStepIndex = -1;
      currentPointX = double.NaN;
      lblResult.Text = "Всё очищено";
      picGraph.Invalidate();
    }

    private bool ValidateInputs(out string formula, out double a, out double b, out double eps)
    {
      formula = txtFormula.Text.Trim();
      a = b = eps = 0;

      if (string.IsNullOrWhiteSpace(formula))
      {
        MessageBox.Show("Введите формулу функции.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      if (!double.TryParse(txtA.Text.Replace('.', ','), out a) ||
          !double.TryParse(txtB.Text.Replace('.', ','), out b) ||
          !double.TryParse(txtEps.Text.Replace('.', ','), out eps))
      {
        MessageBox.Show("В полях a, b и e должны быть только числа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      if (a >= b)
      {
        MessageBox.Show("Число 'a' должно быть меньше числа 'b'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      if (eps <= 0)
      {
        MessageBox.Show("Точность 'e' должна быть больше 0.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      return true;
    }
  }
}