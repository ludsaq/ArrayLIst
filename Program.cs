using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayLIst
{
     class Node
    {
        internal Node prevNode;
        internal object dataNode;
    }

    class RealizationList
    {
        Node headList;
        private int lenghtList = 0;
        public void AddElementInBegin(Object Element)
        {
            Node nextNode = new Node();
            nextNode.dataNode = Element;

            if (IsExsistHead())
            {
                nextNode.prevNode = headList;
                headList = nextNode;
            }
            else
            {
                headList = nextNode;
            }
            lenghtList++;
        }
        public void RemoveElement()
        {
            if (IsExsistHead())
            {
                headList = headList.prevNode;
            }
            else
            {
                throw new Exception("Список пуст");
            }
        }
        public Node GetHeadNode()
        {
            if (IsExsistHead())
            {
                return headList;
            }
            else
            {
                throw new Exception("Список пуст");
            }
        }
        public Node GetTailNode()
        {
            Node tailNode = new Node();

            if (IsExsistHead())
            {
                Node isTail = headList;
                do
                {
                    isTail = isTail.prevNode;
                    tailNode = isTail;

                }
                while (isTail.prevNode == null);

                return tailNode;
            }
            else 
            {
                throw new Exception("Список пуст");
            }
        }
        private bool IsExsistHead() 
        { 
           return (headList != null);
        }
        private Node[] CopyList() 
        {
            Node[] arrayElements = new Node[lenghtList];
            Node isEnd = headList;
            Enumerator enumerator = new Enumerator();
            int index = 0;

            while (true)
            {
                enumerator.MoveNext(isEnd); 

                try 
                {
                    if (enumerator._current.prevNode != null)
                    {
                        arrayElements[index] = (enumerator._current);
                        isEnd = isEnd.prevNode;
                        index++;
                    }
                    else 
                    {
                        break;
                    }
                }
                catch(Exception ex) 
                {
                    break;
                }
               

            }
            return arrayElements;
        }
        public IEnumerator GetEnumerator()
        {
            Node[] arrayElements = CopyList();
            return arrayElements.GetEnumerator();
        }
    }
    class Enumerator
    {
        public Node _current { get; set; }
        public Enumerator() { }
        public object MoveNext(Node ElementList)
        {
            _current = ElementList;
            return _current;
        }
    }

    static class ExpandMethods 
    {
        public static void sortElement(this RealizationList list,object newElement) 
        {
            int index = 0;
            if ((newElement is int))
            {
                //пусть отсортирован по убыванию
                //голова -> хвост наибольший -> наименьший 
                foreach (Node item in list)
                {
                    if ((int)newElement < (int)item.dataNode)
                    {
                        index++;
                        continue;
                    }
                    else 
                    {
                        list.addElement(newElement,index);
                        break;
                    }
                }
            }
            else 
            { 
               //сортировка для других типов
            }
        }
        private static void addElement(this RealizationList list, object newElement,int index) 
        {
            Node beginNode = list.GetHeadNode();
            Node previosNode = list.GetHeadNode().prevNode;

            for (int numNode = 0; numNode < index; numNode++) 
            {
                beginNode = previosNode;
                previosNode = beginNode.prevNode;
            }

            Node newNode = new Node();

            beginNode.prevNode = newNode;

            newNode.prevNode = previosNode;
            newNode.dataNode = newElement;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test MyCollect");

            Program obj = new Program();

            Console.WriteLine("Пример цифр и сортировка");
            obj.testNum();

            Console.WriteLine("Пример букв");
            obj.testChar();

            Console.ReadKey();
        }

        public void testNum()
        {
            RealizationList list = new RealizationList();

            for (int i = 0; i < 10; i++)
            {
                list.AddElementInBegin(i);
            }

            list.sortElement(5);

            foreach (Node item in list)
            {
                Console.WriteLine(item.dataNode);
            }
        }

        public void testChar() 
        {
            char[] testChar = { 'a', 'b', 'c', 'd' };
            RealizationList list = new RealizationList();

            for (int i = 0; i < testChar.Length; i++)
            {
                list.AddElementInBegin(testChar[i]);
            }

            foreach (Node item in list)
            {
                if (item == null) { break; }
                Console.WriteLine(item.dataNode);
            }
        }
    }
}
