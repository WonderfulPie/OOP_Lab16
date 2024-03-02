using System;
using System.Windows.Forms;
using VectorOperations;

namespace Лаб16_Данилко
{
    public partial class Form1 : Form
    {
        // Об'єкти для роботи з векторами
        Vector3D vector1;
        Vector3D vector2;

        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PerformOperation((v1, v2) => v1 + v2, "Сума векторів");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformOperation((v1, v2) => v1 - v2, "Різниця векторів");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            double dotProduct = Vector3D.DotProduct(vector1, vector2);
            ShowResult($"Скалярний добуток: {dotProduct}");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            double magnitude = vector1.Magnitude();
            ShowResult($"Довжина вектора 1: {Math.Round(magnitude, 4)}");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            double cosineAngle = Vector3D.CosineAngle(vector1, vector2);
            ShowResult($"Косинус кута між векторами: {Math.Round(cosineAngle, 4)}");
        }

        private void PerformOperation(Func<Vector3D, Vector3D, Vector3D> operation, string operationName)
        {
            try
            {
                vector1 = GetVector(textBoxX1, textBoxY1, textBoxZ1);
                vector2 = GetVector(textBoxX2, textBoxY2, textBoxZ2);

                Vector3D result = operation(vector1, vector2);

                ShowResult($"{operationName}: {result.ToString()}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильний формат введених даних. Будь ласка, введіть числа.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //вектор із текстових полів
        private Vector3D GetVector(TextBox textBoxX, TextBox textBoxY, TextBox textBoxZ)
        {
            double x = double.Parse(textBoxX.Text);
            double y = double.Parse(textBoxY.Text);
            double z = double.Parse(textBoxZ.Text);
            return new Vector3D(x, y, z);
        }

        //результат операції
        private void ShowResult(string message)
        {
            labelRes.Text = "Результат: " + message;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}