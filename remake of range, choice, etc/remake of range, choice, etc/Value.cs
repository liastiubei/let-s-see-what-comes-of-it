using System;
using System.Collections.Generic;
using System.Text;

namespace RemakeOfRangeChoiceEtc
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
            var ws = new Any(" \n\t");
            this.pattern = value;
            var manyForObject = new Many(
                new Sequence(
                    new JsonString(),
                    ws,
                    new Character(':'),
                    new Value(),
                    new Character(','),
                    ws));
            var optionalForObject = new Optional(
                new Sequence(
                    new JsonString(),
                    ws,
                    new Character(':'),
                    new Value()));
            var obj = new Sequence(
                new Character('{'),
                ws,
                manyForObject,
                optionalForObject,
                new Character('}'));
            var array = new Sequence(
                new Character('['),
                new Many(
                    new Sequence(
                        ws,
                        new Value())),
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
