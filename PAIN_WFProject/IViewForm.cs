using PAIN_WFProject.model;

namespace PAIN_WFProject
{
    internal interface IViewForm
    {
        void AddPiece(Piece piece);
        void DeletePiece(Piece piece);
        void EditPiece(Piece piece, Piece updatedPiece);
    }
}