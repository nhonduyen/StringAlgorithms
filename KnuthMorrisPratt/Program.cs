using KnuthMorrisPratt;

string text = "ABABDABACDABABCABAB";
string pattern = "ABABCABAB";

var kmp = new KMP();
KMP.KMPSearch(text, pattern);