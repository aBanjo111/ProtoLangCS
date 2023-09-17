using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoLangCS
{
    public struct Token
    {
        public TOKENTYPES type;
        public string value;
        public Token(TOKENTYPES type, string value)
        {
            this.type = type;
            this.value = value;
        }
    }
    public enum TOKENTYPES
    {
        OPERATOR, LITERAL, KEYWORD, IDENTIFIER, SEPARATOR, COMMENT
    }
}