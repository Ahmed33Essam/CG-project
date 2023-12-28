using System;
using System.Windows.Forms;

namespace Graphics
{
    public partial class GraphicsForm : Form
    {
        Renderer renderer = new Renderer();
        public GraphicsForm()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
            initialize();
        }
        void initialize()
        {
            renderer.Initialize(0, 0, 2, 0, 0, 0, 0, 1, 0);   
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            renderer.Update();
            renderer.Draw();
        }

        private void GraphicsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            renderer.CleanUp();
        }

        private void simpleOpenGlControl1_Load(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            InitializeComponent();

            float eye1=float.Parse(textBox1.Text),
                eye2= float.Parse(textBox2.Text),
                eye3= float.Parse(textBox3.Text),

                  center1= float.Parse(textBox9.Text),
                  center2= float.Parse(textBox5.Text),
                  center3=float.Parse(textBox7.Text),

                  up1= float.Parse(textBox11.Text), 
                  up2= float.Parse(textBox6.Text),
                  up3= float.Parse(textBox10.Text);

            renderer.Initialize(eye1, eye2, eye3, center1, center2, center3, up1, up2, up3);

            renderer.Update();
            renderer.Draw();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
