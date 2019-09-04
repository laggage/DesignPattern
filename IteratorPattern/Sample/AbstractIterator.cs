namespace IteratorPattern.Sample
{
    interface IIterator
    {
        void MoveToNext(); //移至下一个元素
        bool IsLast();
        void MoveToPrevious();
        bool IsFirst();
        object GetNextItem();
        object GetPreviousItem();
    }
}
