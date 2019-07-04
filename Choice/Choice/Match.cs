using System;
using System.Collections.Generic;
using System.Text;

namespace Choice
{
    class Match:IMatch
    {
        string thisText;

        Match (string text)
        {
            this.thisText = text;
        }
        bool Success(string text)
        {
            return this.RemainingText(text) != text;
        }
        string RemainingText(string text)
        {
            if (text.Length < this.thisText.Length) return text;
            string newText = "";
            for (int i = 0; i < text.Length; i++) if (text[i] != this.thisText[i]) return text;
            return text.Substring(this.thisText.Length);
            
        }
    }
}
