namespace Worshipmaker.Core.Music
{
    public class TimeSignature
    {
        public int Top { get; set; }
        public int Bottom { get; set; }
        public required string Value { get; set; }

        /// <summary>
        /// Returns a list of common time signatures.
        /// </summary>
        /// <returns></returns>
        public static List<TimeSignature> GetTimeSignatures()
        {
            return
            [
                new() { Top = 2, Bottom = 2, Value = "2/2" },
                new() { Top = 2, Bottom = 4, Value = "2/4" },
                new() { Top = 3, Bottom = 4, Value = "3/4" },
                new() { Top = 3, Bottom = 8, Value = "3/8" },
                new() { Top = 4, Bottom = 2, Value = "4/2" },
                new() { Top = 4, Bottom = 4, Value = "4/4" },
                new() { Top = 5, Bottom = 4, Value = "5/4" },
                new() { Top = 5, Bottom = 8, Value = "5/8" },
                new() { Top = 6, Bottom = 8, Value = "6/8" },
                new() { Top = 7, Bottom = 8, Value = "7/8" },
                new() { Top = 9, Bottom = 8, Value = "9/8" },
                new() { Top = 12, Bottom = 8, Value = "12/8" }
            ];
        }
    }
}