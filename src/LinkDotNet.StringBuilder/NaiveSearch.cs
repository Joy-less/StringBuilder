namespace LinkDotNet.StringBuilder;

internal static class NaiveSearch
{
    /// <summary>
    /// Finds all occurence of <paramref name="word"/> in <paramref name="text"/>.
    /// </summary>
    /// <param name="text">The text to look for.</param>
    /// <param name="word">The word which should be found in <paramref name="word"/>.</param>
    /// <returns>Array of indexes where <paramref name="word"/> was found.</returns>
    public static ReadOnlySpan<int> FindAll(ReadOnlySpan<char> text, ReadOnlySpan<char> word)
    {
        if (text.IsEmpty || word.IsEmpty)
        {
            return Array.Empty<int>();
        }

        if (text.Length < word.Length)
        {
            return Array.Empty<int>();
        }

        var hits = new TypedSpanList<int>();

        for (var i = 0; i < text.Length; i++)
        {
            for (var j = 0; j < word.Length; j++)
            {
                if (text[i + j] != word[j])
                {
                    break;
                }

                if (j == word.Length - 1)
                {
                    hits.Add(i);
                }
            }
        }

        return hits.AsSpan;
    }
}