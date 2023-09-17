using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ProtoLangCS
{
    public class Lexer
    {
        //Regex reg = new Regex(@"[a-zA-Z0-9]{1,}");
        public static void Start(string[] inputs)
        {
            List<Token> tokens = new List<Token>();
            string value = "";
            bool added = false;
            bool inComment = false;
            bool inString = false;
            foreach (string input in inputs)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '\"')
                    {
                        inString = !inString;
                    }
                    
                    if (inString)
                    {
                        i++;
                        while (inString)
                        {
                            value += input[i];
                            i++;
                            if (i == input.Length)
                            {
                                break;
                            }
                            if (input[i] == '\"')
                            {
                                inString = !inString;
                            }
                        }
                        tokens.Add(new Token(TOKENTYPES.LITERAL, value));
                        value = "";
                        continue;
                    }
                    

                    if (i + 1 < input.Length)
                    {
                        if (input[i] == '/' & input[i + 1] == '/')
                        {
                            i += 2;
                            while (true)
                            {
                                value += input[i];
                                i++;
                                if (i >= input.Length)
                                {
                                    break;
                                }
                            }
                            tokens.Add(new Token(TOKENTYPES.COMMENT, value));
                            value = "";
                            i--;
                            continue;
                        }

                        if (input[i] == '/' & input[i+1] == '*')
                        {
                            inComment = !inComment;
                        }
                    }

                    if (input[i] == ' ')
                    {
                        continue;
                    }

                    if (isSeperator(input[i]))
                    {
                        tokens.Add(new Token(TOKENTYPES.SEPARATOR, input[i].ToString()));
                        continue;
                    }

                    if (char.IsNumber(input[i]) & !isOperator(input[i].ToString()))
                    {
                        while (char.IsNumber(input[i]))
                        {
                            value += input[i];
                            i++;
                            if (i >= input.Length)
                            {
                                break;
                            }
                        }
                        tokens.Add(new Token(TOKENTYPES.LITERAL, value));
                        value = "";
                        i--;
                        continue;
                    }

                    if (isOperator(input[i].ToString()))
                    {
                        value = input[i].ToString();
                        if (i < input.Length - 1)
                        {
                            if (isOperator(input[i + 1].ToString()))
                            {
                                value = input[i].ToString() + input[i + 1].ToString();
                                i++;
                            }
                        }
                        tokens.Add(new Token(TOKENTYPES.OPERATOR, value));
                        value = "";
                        continue;
                    }

                    while (input[i] != ' ' & !isSeperator(input[i]) & !isOperator(input[i].ToString()))
                    {
                        value += input[i];
                        i++;
                        added = true;
                        if (i >= input.Length)
                        {
                            break;
                        }
                    }

                    if (value == "true" | value == "false")
                    {
                        tokens.Add(new Token(TOKENTYPES.LITERAL, "b" + value));
                        value = "";
                        continue;
                    }

                    if (isKeyWord(value))
                    {
                        tokens.Add(new Token(TOKENTYPES.KEYWORD, value));
                        value = "";
                        continue;
                    }
                    if (isOperator(value))
                    {
                        tokens.Add(new Token(TOKENTYPES.OPERATOR, value));
                        value = "";
                        continue;
                    }
                    tokens.Add(new Token(TOKENTYPES.IDENTIFIER, value));
                    value = "";
                    if (added) i--;

                }
            }

            foreach (Token token in tokens)
            {
                Console.WriteLine("{" + token.value + ", " + token.type + "}");
            }
        }


        public static bool isKeyWord(string str)
        {
            switch (str)
            {
                case "int": return true;
                case "long": return true;
                case "float": return true;
                case "double": return true;
                case "bool": return true;
                case "string": return true;
                case "break": return true;
                case "continue": return true;
                case "while": return true;
                case "if": return true;
                case "else": return true;
                case "foreach": return true;
                case "new": return true;
                case "in": return true;

                default:
                    return false;
            }   
        }

        public static bool isOperator(string c)
        {
            switch (c)
            {
                case "=":
                    return true;
                case "+":
                    return true;
                case "-":
                    return true;
                case "*":
                    return true;
                case "/":
                    return true;
                case ">":
                    return true;
                case "<":
                    return true;
                case "<=":
                    return true;
                case ">=":
                    return true;
                case "==":
                    return true;
                case "!=":
                    return true;
                case "+=":
                    return true;
                case "-=":
                    return true;
                case "*=":
                    return true;
                case "/=":
                    return true;
                case "++":
                    return true;
                case "--":
                    return true;
                default: return false;

            }
        }

        public static bool isSeperator(char c)
        {
            switch (c)
            {
                case '{': return true;
                case '}': return true;
                case '(': return true;
                case ')': return true;
                case ';': return true;
                case ',': return true;
                case '.': return true;
                default: return false;
            }
        }


    }
}



/*
 if (input[i] == '/' & i +1 < input.Length)
                {
                    if (input[i+1] == '/')
                    {
                        while (input[i] != '\n')
                        {
                            value += input[i];
                            i++;
                            if (i >= input.Length)
                            {
                                break;
                            }
                        }
                        tokens.Add(new Token(TOKENTYPES.COMMENT, value));
                        value = "";
                        continue;
                    }
                    if (input[i+1] == '*')
                    {
                        while (input[i] != '*' & input[i+1] != '/')
                        {
                            value += input[i];
                            i++;
                            if (i >= input.Length -1)
                            {
                                break;
                            }
                        }
                        tokens.Add(new Token(TOKENTYPES.COMMENT, value));
                        value = "";
                    }
                }
 */