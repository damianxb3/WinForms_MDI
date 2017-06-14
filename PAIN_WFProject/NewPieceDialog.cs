using System;
using System.Windows.Forms;
using PAIN_WFProject.model;

namespace PAIN_WFProject
{
    public partial class NewPieceDialog : Form
    {
        public NewPieceDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            var newPiece = new Piece
            {
                Title = textBox1.Text,
                Author = textBox2.Text,
                RecordingDate = textBox3.Text,
                Category = textBox4.Text
            };
            Tag = newPiece;
            Dispose(true);
        }
    }
}
