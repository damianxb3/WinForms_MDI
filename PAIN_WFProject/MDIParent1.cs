using System;
using System.Windows.Forms;
using PAIN_WFProject.model;

namespace PAIN_WFProject
{
    public partial class MDIParent1 : Form
    {
        private readonly PiecesRepository _piecesRepository = PiecesRepository.Instance;
        private int childFormNumber = 0;
        public Piece[] Pieces { get; set; }

        public MDIParent1(Piece[] pieces)
        {
            Pieces = pieces;
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void view1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewForm listViewForm = new ListViewForm {MdiParent = this};
            listViewForm.Show();
        }

        private void treeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeViewForm treeViewForm = new TreeViewForm { MdiParent = this};
            treeViewForm.Show();
        }

        public void AddPiece(Piece piece)
        {
            _piecesRepository.Add(piece);
            foreach (var mdiChild in MdiChildren)
            {
                var form = mdiChild as IViewForm;
                form?.AddPiece(piece);
            }
        }

        public void DeletePiece(Piece piece)
        {
            _piecesRepository.Delete(piece);
            foreach (var mdiChild in MdiChildren)
            {
                var form = mdiChild as IViewForm;
                form?.DeletePiece(piece);
            }
        }

        public void EditPiece(Piece piece, Piece updatedPiece)
        {
            _piecesRepository.Update(piece, updatedPiece);
            foreach (var mdiChild in MdiChildren)
            {
                var form = mdiChild as IViewForm;
                form?.EditPiece(piece, updatedPiece);
            }
        }

        public void AddPieceDialog()
        {
            var newPieceDialog = new NewPieceDialog();

            if (newPieceDialog.ShowDialog(this) == DialogResult.OK)
            {
                var newPiece = newPieceDialog.Tag as Piece;
                AddPiece(newPiece);
            }
        }

        public void EditPieceDialog(Piece pieceToEdit)
        {
            var editPieceDialog = new EditPieceDialog(pieceToEdit);
            if (editPieceDialog.ShowDialog(this) == DialogResult.OK)
            {
                var pieces = editPieceDialog.Tag as Tuple<Piece, Piece>;
                EditPiece(pieces?.Item1, pieces?.Item2);
            }
        }
    }
}
