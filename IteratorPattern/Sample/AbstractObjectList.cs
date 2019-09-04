namespace IteratorPattern.Sample
{
    using System.Collections.Generic;

    abstract class AbstractObjectList
    {
        private readonly List<object> objects;

        public AbstractObjectList(List<object> objects)
        {
            this.objects = objects;
        }

        public void AddObject(object obj)
        {
            this.objects.Add(obj);
        }

        public void RemoveObject(object obj)
        {
            this.objects.Remove(obj);
        }

        public object[] GetObjects() => this.objects.ToArray();

        public abstract IIterator CreateIterator();
    }

    class ProductList : AbstractObjectList
    {
        public ProductList():base(new List<object>())
        {
        }

        public ProductList(List<object> products) : base(products)
        {
        }

        /// <summary>
        /// 迭代器工厂方法
        /// </summary>
        /// <returns></returns>
        public override IIterator CreateIterator()
        {
            return new ProductIterator(this);
        }

        private class ProductIterator:IIterator
        {
            private int cursor;
            private readonly List<object> objects;

            public ProductIterator(ProductList productList)
            {
                this.cursor = 0;
                this.objects = new List<object>(productList.GetObjects());
            }

            public void MoveToNext()
            {
                if(!IsLast())
                    this.cursor++;
            }

            public bool IsLast()
            {
                return this.cursor == this.objects.Count - 1;
            }

            public void MoveToPrevious()
            {
                if (!IsFirst()) this.cursor--;
            }

            public bool IsFirst()
            {
                return this.objects.Count == 0;
            }

            /// <summary>
            /// 获取相对于当前位置的后一个的对象, 保持当前位置不变
            /// 如果当前位置已经是最后一个位置, 返回null
            /// </summary>
            /// <returns>相对于当前位置的后一个的对象</returns>
            public object GetNextItem()
            {
                return IsLast() ? null : this.objects[this.cursor+1];
            }

            /// <summary>
            /// 获取相对于当前位置的前一个对象, 保持当前位置不变
            /// 如果当前位置已经是第一个位置, 返回null
            /// </summary>
            /// <returns>相对于当前位置的前一个对象</returns>
            public object GetPreviousItem()
            {
                return IsFirst() ? null : this.objects[this.cursor - 1];
            }
        }
    }
}
