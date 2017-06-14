using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PAIN_WFProject.model.helper;

namespace PAIN_WFProject.model
{
    public sealed class PiecesRepository
    {
        private PiecesXmlHelper _piecesXmlHelper;
        private static volatile PiecesRepository _instance;
        private static object syncRoot = new object();

        private PiecesRepository()
        {
            _piecesXmlHelper = new PiecesXmlHelper();
        }

        public static PiecesRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new PiecesRepository();
                        }
                    }
                }
                return _instance;
            }
        }

        public Piece[] All()
        {
            lock (syncRoot)
            {
                return _piecesXmlHelper.Deserialize().Pieces;
            }
        }
        public void Add(Piece piece)
        {
            lock (syncRoot)
            {
                var piecesCollection = _piecesXmlHelper.Deserialize();
                var allPieces = piecesCollection.Pieces.ToList();
                allPieces.Add(piece);
                piecesCollection.Pieces = allPieces.ToArray();
                _piecesXmlHelper.Serialize(piecesCollection);
            }
        }

        public void Delete(Piece piece)
        {
            lock (syncRoot)
            {
                var piecesCollection = _piecesXmlHelper.Deserialize();
                var allPieces = piecesCollection.Pieces.ToList();
                allPieces.Remove(piece);
                piecesCollection.Pieces = allPieces.ToArray();
                _piecesXmlHelper.Serialize(piecesCollection);
            }
        }

        public void Update(Piece piece, Piece updatedPiece)
        {
            lock (syncRoot)
            {
                var piecesCollection = _piecesXmlHelper.Deserialize();
                var allPieces = piecesCollection.Pieces.ToList();
                var newPiece = allPieces.Find(p => p.Equals(piece));
                newPiece.Title = updatedPiece.Title;
                newPiece.Author = updatedPiece.Author;
                newPiece.Category = updatedPiece.Category;
                newPiece.RecordingDate = updatedPiece.RecordingDate;
                piecesCollection.Pieces = allPieces.ToArray();
                _piecesXmlHelper.Serialize(piecesCollection);
            }
        }
    }
}
