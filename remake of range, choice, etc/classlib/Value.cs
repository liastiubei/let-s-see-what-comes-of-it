using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var value = new Choice(
                new JsonString(),
                new Number(),
                new Text("true"),
                new Text("false"),
                new Text("null"));
            var ws = new Any(" \n\t\r");
            var listForObject = new List(
                new Sequence(
                    new JsonString(),
                    ws,
                    new Character(':'),
                    ws,
                    value,
                    ws),
                new Sequence(
                    new Character(','),
                    ws));
            var obj = new Sequence(
                new Character('{'),
                ws,
                listForObject,
                new Character('}'));
            var array = new Sequence(
                new Character('['),
                new List(
                        ws,
                        value),
                new Character(']'));
            value.Add(obj);
            value.Add(array);
            this.pattern = value;
        }

        public IMatch Match(string text)
        {
            if (this.pattern.Match(text).RemainingText() != "")
            {
                return new Match(false, text);
            }

            return this.pattern.Match(text);
        }
    }
}
