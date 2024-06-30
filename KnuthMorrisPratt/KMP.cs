namespace KnuthMorrisPratt
{
    public class KMP
    {
        public static void KMPSearch(string text, string pattern)
        {
            int[] lps = ComputeLPSArray(pattern);
            int i = 0; // index for text
            int j = 0; // index for pattern

            while (i < text.Length)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }

                if (j == pattern.Length)
                {
                    Console.WriteLine("Found pattern at index " + (i - j));
                    j = lps[j - 1];
                }
                else if (i < text.Length && pattern[j] != text[i])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private static int[] ComputeLPSArray(string pattern)
        {
            int[] lps = new int[pattern.Length];
            int len = 0; // length of the previous longest prefix suffix
            int i = 1;

            lps[0] = 0; // lps[0] is always 0

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }
    }
}
