using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PAIN_WFProject.model;

namespace PAIN_WFProject
{
    public partial class ListViewForm : Form, IViewForm
    {
        private readonly PiecesRepository _piecesRepository = PiecesRepository.Instance;

        public ListViewForm()
        {
            InitializeComponent();
            InitColumns();
            InitRecords(_piecesRepository.All());
        }


        private void InitColumns()
        {
            foreach (var columnName in PiecesCollection.Columns)
            {
                listView1.Columns.Add(columnName);  
            }
        }

        private void InitRecords(IEnumerable<Piece> pieces)
        {
            foreach (var piece in pieces)
            {
                string[] row = { piece.Title, piece.Author, piece.RecordingDate, piece.Category };
                var listViewItem = new ListViewItem(row) {Tag = piece};
                listView1.Items.Add(listViewItem);
            }
        }

        public void AddPiece(Piece piece)
        {
            listView1.Items.Add(PieceToListViewItem(piece));
        }

        public void DeletePiece(Piece piece)
        {
            listView1.Items.Remove(PieceToListViewItem(piece));
        }

        public void EditPiece(Piece piece, Piece updatedPiece)
        {
            var listViewItem = listView1.Items.Find(PieceToListViewItem(piece).ToString(), true).First();
            listViewItem.Text = PieceToListViewItem(updatedPiece).Text;
        }


        private static ListViewItem PieceToListViewItem(Piece piece)
        {
            return new ListViewItem(new[]
            {
                piece.Title,
                piece.Author,
                piece.RecordingDate,
                piece.Category
            });
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.FocusedItem.Bounds.Contains(e.Location))
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void addPiece_Click(object sender, EventArgs e)
        {
            ((MDIParent1)MdiParent).AddPieceDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItem = listView1.SelectedItems[0];
            var pieceToEdit = selectedItem.Tag as Piece;
            ((MDIParent1)MdiParent).EditPieceDialog(pieceToEdit);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItem = listView1.SelectedItems[0];
            var pieceToDelete = selectedItem.Tag as Piece;
            ((MDIParent1) MdiParent).DeletePiece(pieceToDelete);
        }
    }
}
