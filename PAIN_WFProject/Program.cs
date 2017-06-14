using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PAIN_WFProject.model;
using PAIN_WFProject.model.helper;

namespace PAIN_WFProject
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Piece[] pieces = LoadPieces();
            MDIParent1 mdiParent = new MDIParent1(pieces);
            Application.Run(mdiParent);
        }

        private static Piece[] LoadPieces()
        {
            PiecesXmlHelper xmlHelper = new PiecesXmlHelper();
            PiecesCollection pieces = xmlHelper.Deserialize();
            return pieces.Pieces;
        }
    }
}
