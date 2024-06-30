namespace RabinKarp
{
    public static class RabinKarpAlgorithm
    {
        // d is the number of characters in the input alphabet
        private static readonly int d = 256;

        public static void Search(string pattern, string text, int q)
        {
            int m = pattern.Length;
            int n = text.Length;
            int i, j;
            int p = 0; // hash value for pattern
            int t = 0; // hash value for text
            int h = 1;

            // The value of h would be "pow(d, m-1)%q"
            for (i = 0; i < m - 1; i++)
                h = (h * d) % q;

            // Calculate the hash value of pattern and first window of text
            for (i = 0; i < m; i++)
            {
                p = (d * p + pattern[i]) % q;
                t = (d * t + text[i]) % q;
            }

            // Slide the pattern over text one by one
            for (i = 0; i <= n - m; i++)
            {
                // Check the hash values of current window of text and pattern.
                // If the hash values match then only check for characters one by one
                if (p == t)
                {
                    /* Check for characters one by one */
                    for (j = 0; j < m; j++)
                    {
                        if (text[i + j] != pattern[j])
                            break;
                    }

                    // If p == t and pattern[0...m-1] = text[i, i+1, ...i+m-1]
                    if (j == m)
                        Console.WriteLine("Pattern found at index " + i);
                }

                // Calculate hash value for next window of text: Remove leading digit, add trailing digit
                if (i < n - m)
                {
                    t = (d * (t - text[i] * h) + text[i + m]) % q;

                    // We might get negative value of t, converting it to positive
                    if (t < 0)
                        t = (t + q);
                }
            }

        }
    }
}