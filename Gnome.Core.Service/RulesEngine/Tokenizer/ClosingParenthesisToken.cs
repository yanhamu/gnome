﻿namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class ClosingParenthesisToken : IToken
    {
        public string Value { get; }
        public ClosingParenthesisToken()
        {
            this.Value = ")";
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
