using System;
using System.Collections.Generic;
using System.Text;

namespace NotesPrism.Models
{
    public class FileModel
    {
        public string  FileName { get; set; }
        public string FilePath { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string TextPreview { get; set; }
    }
}
