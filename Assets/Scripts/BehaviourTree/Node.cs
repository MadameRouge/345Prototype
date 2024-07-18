using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BehavTree
{
    public class BehaviourTree : Node
    {
        public BehaviourTree(string name) : base(name) { }

        public override Status Process()
        {
            while (currentChild < children.Count)
            {
                var status = children[currentChild].Process();
                if (status != Status.Sucess)
                {
                    return status;
                }
                currentChild++;
            }
            return Status.Sucess;
        }
    }
    public class Leaf : Node
    {
        readonly IStrategy strategy;

        public Leaf(string name, IStrategy strategy) : base(name)
        {
            this.strategy = strategy;
        }

        public override Status Process() => strategy.Process();

        public override void Reset() => strategy.Reset();
    }
    public class Node
    {
        public enum Status { Sucess, Failure, Running }
        public readonly string name;

        public readonly List<Node> children = new();
        protected int currentChild;

        public Node(string name = "DefaultName")
        {
            this.name = name;
        }

        public void AddChild(Node child) => children.Add(child);
        public virtual Status Process() => children[currentChild].Process();

        public virtual void Reset()
        {
            currentChild = 0;
            foreach (var child in children)
            {
                child.Reset();
            }
        }
    }
}
