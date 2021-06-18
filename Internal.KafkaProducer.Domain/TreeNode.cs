using System.Collections.Generic;

namespace Internal.KafkaProducer.Domain
{
    public class TreeNode
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public List<TreeNode> Children { get; set; }
    }
}