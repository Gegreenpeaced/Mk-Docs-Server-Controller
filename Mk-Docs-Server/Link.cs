using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mk_Docs_Server
{
    internal class Link
    {
        private static string _downloadPathAtom = "https://nxcloud.norku.de/index.php/s/exGqkZWeqCJmFae/download/atom-portable.zip";
        private static string _downloadPathVSC = "https://replace.de"; // To Do (Licence Problems)
        private static string _downloadPathNotepadPP = "https://nxcloud.norku.de/index.php/s/Mq2Ex3cMjpArBf4/download/NotepadPP-portable.zip";
        private static string _downloadCommandMKDocs = "pip --proxy http://kjs-03.lan.dd-schulen.de:3128 install mkdocs mkdocs-material break";
        private static string _fileVersion = "v1.0";

        public static string GetVersion ()
            { return _fileVersion; }

        public static string downloadPathAtom()
        { return _downloadPathAtom; }

        public static string downloadPathVSC()
        { return _downloadPathVSC; }

        public static string dowloadPathNotepadPP()
        { return _downloadPathNotepadPP; }

        public static string downloadCommandMKDocs()
        { return _downloadCommandMKDocs; }
    }
}
