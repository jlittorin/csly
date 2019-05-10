using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace sly.parser.syntax.tree
{
    public class ManySyntaxNode<IN> : SyntaxNode<IN> where IN : struct
    {
        public ManySyntaxNode(string name, string shortName) : base(name, shortName,new List<ISyntaxNode<IN>>())
        {
        }

        public bool IsManyTokens { get; set; }

        public bool IsManyValues { get; set; }

        public bool IsManyGroups { get; set; }


        public void Add(ISyntaxNode<IN> child)
        {
            Children.Add(child);
        }

        [ExcludeFromCodeCoverage]
        public override string Dump(string tab)
        {
            var dump = new StringBuilder();

            dump.AppendLine($"{tab}MANY {Name} [");
            foreach (var c in Children) dump.AppendLine(c.Dump(tab + "\t"));

            dump.AppendLine($"{tab}]");

            return dump.ToString();
        }
    }
}