
using System;
using Lists;

namespace Trees
{
    public class TreeNode<T>
    {
        private T Value;
        //TODO #1: Declare a member variable called "Children" as a list of TreeNode<T> objects

        List<TreeNode<T>> Children;

        public TreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
            Children = new List<TreeNode<T>>();
            Value = value;

        }

        public string ToString(int depth, int index)
        {
            //TODO #3: Uncomment the code below

            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
                TreeNode<T> child = Children.Get(childIndex);
                output += child.ToString(depth + 1, childIndex);
            }
            return output;


        }

        public TreeNode<T> Add(T value)
        {
            //TODO #4: Add a new instance of class GenericTreeNode<T> with Value=value. Return the instance we just created
            
            TreeNode<T> nuevo = new TreeNode<T>(value);
            Children.Add(nuevo);
            return nuevo;
        }

        public int Count()
        {
            //TODO #5: Return the total number of elements in this tree

            int contador = 1;
           
            for( int i = 0; i < Children.Count(); i++ )
            {
                contador = contador + Children.Get(i).Count();
            }
            return contador;
        }

        public int Height()
        {
            //TODO #6: Return the height of this tree
        
            if (Children.Count() == 0)
            {
                return 0;
            }
            int altura = 0;
           
            for (int i = 0; i < Children.Count(); i++)
            {
                altura = Math.Max(altura , Children.Get(i).Height() );
            }
            return altura + 1;
        }

        

        
        public void Remove(T value)
        {
            //TODO #7: Remove the child node that has Value=value. Apply recursively
             TreeNode<T> node;
            
            for (int i = 0; i < Children.Count(); i++)
            {
                node = Children.Get(i); 

                if( node.Value.Equals(value))
                {
                    Children.Remove(i);
                }
                else
                {
                    node.Remove(value);
                }
            }
        }

        public TreeNode<T> Find(T value)
        {
            //TODO #8: Return the node that contains this value (it might be this node or a child). Apply recursively
            
            if (Value.Equals(value))
            {
                return this;
            }
            else
            {
                for (int i = 0; i < Children.Count(); i++)
                {
                    TreeNode<T> node = Children.Get(i);

                    if (node.Value.Equals(value))
                    {
                        return node;
                    }

                    TreeNode<T> buscado = node.Find(value);

                    if (buscado != null)
                    {
                        return buscado;
                    }
                }
                return null;
            }
        }


        public void Remove(TreeNode<T> node)
        {
            //TODO #9: Same as #6, but this method is given the specific node to remove, not the value
             Remove( node.Value);
        }
    }
}