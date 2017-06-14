using System;
using System.Windows.Forms;
using PAIN_WFProject.model;

namespace PAIN_WFProject
{
    public partial class EditPieceDialog : Form
    {
        public EditPieceDialog(Piece pieceToEdit)
        {
            InitializeComponent();
            textBox1.Text = pieceToEdit.Title;
            textBox2.Text = pieceToEdit.Author;
            textBox3.Text = pieceToEdit.RecordingDate;
            textBox4.Text = pieceToEdit.Category;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var updatedPiece = new Piece()
            {
                Title = textBox1.Text,
                Author = textBox2.Text,
                RecordingDate = textBox3.Text,
                Category = textBox4.Text
            };
            var pieces = new Tuple<Piece, Piece>(Tag as Piece, updatedPiece);
            Tag = pieces;
            Dispose(true);
        }
    }
}
