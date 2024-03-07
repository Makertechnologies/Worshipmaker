using System.Text.RegularExpressions;

namespace Worshipmaker.Common.Music
{
    public static class Chordsheet
    {
        /// <summary>
        /// Breaks down a text-based chordsheet into separate lines and determines the type of each.
        /// </summary>
        /// <param name="chordsheetText"></param>
        /// <returns></returns>
        public static List<ChordsheetLine> GetChordsheetLines(string chordsheetText)
        {
            List<ChordsheetLine> chordsheetLines = new List<ChordsheetLine>();
            string[] lines = chordsheetText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                chordsheetLines.Add(new ChordsheetLine(line, DetermineLineType(line)));
            }
            return chordsheetLines;
        }

        /// <summary>
        /// Returns only the stanza titles for the specified text-based chordsheet.
        /// </summary>
        /// <param name="chordsheetText"></param>
        /// <returns></returns>
        public static List<string> GetStanzaLines(string chordsheetText)
        {
            List<string> chordsheetStanzaLines = new List<string>();
            foreach (ChordsheetLine chordsheetLine in GetLines(chordsheetText))
            {
                if (chordsheetLine.LineType == ChordsheetLineType.Stanza)
                {
                    chordsheetStanzaLines.Add(chordsheetLine.Text);
                }
            }
            return chordsheetStanzaLines;
        }

        /// <summary>
        /// Determines the chordsheet line type the specified text appears to represent.
        /// </summary>
        /// <param name="lineText"></param>
        /// <returns></returns>
        private static ChordsheetLineType DetermineLineType(string lineText)
        {
            // Out counters
            int chordCount = 0;
            int stanzaCount = 0;
            int pagebreakCount = 0;
            int lyricCount = 0;

            // Housekeeping
            lineText = lineText.Trim();

            // Analyze each piece of the line passed in
            string[] pieces = lineText.Split(null);
            foreach (string piece in pieces)
            {
                if (piece.Trim().Length > 0)
                {
                    if (IsChord(piece))
                    {
                        chordCount++;
                    }
                    else if (IsStanza(piece))
                    {
                        stanzaCount++;
                    }
                    else if (IsPagebreak(piece))
                    {
                        pagebreakCount++;
                    }
                    else
                    {
                        lyricCount++;
                    }
                }
            }

            // Determine the type
            if (pieces.Length > 0)
            {
                if (((chordCount / pieces.Length) * 100) >= 50)
                {
                    return ChordsheetLineType.Chords;
                }
                if (stanzaCount > 0)
                {
                    return ChordsheetLineType.Stanza;
                }
                if (pagebreakCount > 0)

                {
                    return ChordsheetLineType.Pagebreak;
                }
            }

            return ChordsheetLineType.Lyrics;
        }

        /// <summary>
        /// Determines of the specified text appears to be a chord.
        /// </summary>
        /// <param name="pieceText"></param>
        /// <returns></returns>
        private static bool IsChord(string pieceText)
        {
            string pattern = @"\b[A-G](\##|2|4|5|6|7|9|11|13|6\/9|7\-5|7\-9|7\##5|7\##9|7\+5|7\+9|7b5|7b9|7sus2|7sus4|add2|add4|add9|aug|b|dim|dim7|m|m\/maj7|m11|m13|m6|m7|m7b5|m9|maj11|maj13|maj7|maj9|maj|mb5|sus|sus2|sus4)*\b";
            return Regex.IsMatch(pieceText, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Determines of the specified text appears to be a stanza title.
        /// </summary>
        /// <param name="pieceText"></param>
        /// <returns></returns>
        private static bool IsStanza(string pieceText)
        {
            foreach (string stanza in Stanza.GetStanzas())
            {
                if (pieceText.Trim().ToLower() == stanza.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines of the specified text appears to be a pagebreak separator.
        /// </summary>
        /// <param name="pieceText"></param>
        /// <returns></returns>
        private static bool IsPagebreak(string pieceText)
        {
            if (pieceText.Trim().StartsWith("-----") || pieceText.Trim().StartsWith("~"))
            {
                return true;
            }
            return false;
        }
    }
}