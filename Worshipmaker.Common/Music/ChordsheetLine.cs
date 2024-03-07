namespace Worshipmaker.Common.Music
{
    public class ChordsheetLine
    {
        public string Text { get; set; }
        public ChordsheetLineType LineType { get; set; }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="lineType"></param> 
        public ChordsheetLine(string text, ChordsheetLineType lineType)
        {
            this.Text = text;
            this.LineType = lineType;
        }
    }
}
