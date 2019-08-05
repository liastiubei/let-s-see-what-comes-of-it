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
            var manyForObject = new Many(new Sequence(new JsonString(), new Character(' '), new Character(':'), new Value(), new Character(','), new Character(' ')));
            var optionalForObject = new Optional(new Sequence(new JsonString(), new Character(' '), new Character(':'), new Value()));
            var obj = new Sequence(new Character('{'), new Character(' '), manyForObject, optionalForObject, new Character('}'));
            var array = new Sequence(new Character('['), new Many(new Value()), new Character(']'));
            this.pattern = new Choice(obj, array, new JsonString(), new Number(), new Text("true"), new Text("false"), new Text("null"));
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
