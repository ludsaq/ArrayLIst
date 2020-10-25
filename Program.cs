using System;

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
        public void addElementInBegin(Object Element)
        {
            Node nextNode = new Node();
            nextNode.dataNode = Element;

            if (isExsistHead())
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

        public void removeElement()
        {
            if (isExsistHead())
            {
                headList = headList.prevNode;
            }
            else
            {
                throw new Exception();
            }
        }

        public Node getHeadNode()
        {
            if (isExsistHead())
            {
                return headList;
            }
            else
            {
                throw new Exception();
            }
        }

        public Node getTailNode()
        {
            Node tailNode = new Node();

            if (isExsistHead())
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
                throw new Exception();
            }
        }

        private bool isExsistHead() 
        { 
           return (headList != null);
        }

        public object[] realizatonForEach() 
        {
            Object[] arrayElement = new object[lenghtList];
            Node isEnd = headList;
            Enumerator enumerator = new Enumerator();
            int index = 0;

            while (true)
            {
                try
                {
                    enumerator.MoveNext(isEnd);
                    arrayElement[index] = enumerator.Current;

                    isEnd = isEnd.prevNode;

                    if (isEnd == null)
                    {
                        break;
                    }

                    index++;
                }
                catch (Exception ex)
                {
                    break;
                }

            }

            return arrayElement;
        }
    }
    class Enumerator 
    {
        public object Current;
        public object MoveNext(Node ElementList)
        {
            Current = ElementList.dataNode;
            return Current;
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
                foreach (var item in list.realizatonForEach())
                {
                    if ((int)newElement < (int)item)
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
            Node beginNode = list.getHeadNode();
            Node previosNode = list.getHeadNode().prevNode;

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
            RealizationList List = new RealizationList();

            for (int i = 0; i < 10; i++)
            {
                List.addElementInBegin(i);
            }

            List.sortElement(5);

            foreach (var item in List.realizatonForEach())
            {
                Console.WriteLine(item);
            }
        }

        public void testChar() 
        {
            char[] testChar = { 'a', 'b', 'c', 'd' };
            RealizationList List = new RealizationList();

            for (int i = 0; i < testChar.Length; i++)
            {
                List.addElementInBegin(testChar[i]);
            }

            foreach (var item in List.realizatonForEach())
            {
                Console.WriteLine(item);
            }
        }
    }
}
