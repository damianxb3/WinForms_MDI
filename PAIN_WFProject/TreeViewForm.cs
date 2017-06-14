using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PAIN_WFProject.model;

namespace PAIN_WFProject
{
    public partial class TreeViewForm : Form, IViewForm
    {
        private readonly PiecesRepository _piecesRepository = PiecesRepository.Instance;

        public TreeViewForm()
        {
            InitializeComponent();
            foreach (var piece in _piecesRepository.All())
            {
                var node = PieceToNode(piece);
                treeView1.Nodes.Add(node);
            }
        }

        public void AddPiece(Piece piece)
        {
            treeView1.Nodes.Add(PieceToNode(piece));
        }

        public void DeletePiece(Piece piece)
        {
            treeView1.Nodes.Remove(PieceToNode(piece));
        }

        public void EditPiece(Piece piece, Piece updatedPiece)
        {
            
        }

        private static TreeNode PieceToNode(Piece piece)
        {
            var authorNode = new TreeNode(piece.Author);
            var recordingDateNode = new TreeNode(piece.RecordingDate);
            var categoryNode = new TreeNode(piece.Category);
            return new TreeNode(piece.Title, new[] { authorNode, recordingDateNode, categoryNode });
        }
    }
}
