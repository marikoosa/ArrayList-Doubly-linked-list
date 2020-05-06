using System;
using System.Collections;

{
    public class DLinkedListNode
    {
        //Declaring variables 
        public object element;
        public DLinkedListNode next;
        public DLinkedListNode previous;
     

        // A constructor to make the first element of the list
        public DLinkedListNode(object element)
        {
            this.element = element;
            this.next = null;
            this.previous = null;
        }

        //A constructor to make the rest of the nodes
        public DLinkedListNode(object element, DLinkedListNode prevNode)
        {
            this.element = element;
            this.previous = prevNode;
            prevNode.next = this;
        }

        //Getters and Setters
        public void SetElement(object objElement)
        { element = objElement; }

        public object GetElement()
        {
            return element;
        }

        public void SetNext(DLinkedListNode objNext)
        { next = objNext; }

        public object GetNext()
        {
            return next;
        }

        public void SetPrevious(DLinkedListNode objPrevious)
        { next = objPrevious; }

        public object GetPrevious()
        {
            return previous;
        }
    }
}

