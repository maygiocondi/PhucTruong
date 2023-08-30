namespace XoaPhanTu
{
    class XoaPhanTu
    {
        static void Main(string[] args)
        {
            float[] a = { 4, 66, 33, 63, 11 };
            XoaPhanTuKhoiMang(a, 11);
        }

        private static void XoaPhanTuKhoiMang(float[] mang, int soCanXoa)
        {
            for (int i = 0; i < mang.Length; i++)
            {
                Console.Write(mang[i] + " ");
            }
            int indexToRemove = -1;
            for (int i = 0; i < mang.Length; i++)
            {
                if (mang[i] == soCanXoa)
                {
                    indexToRemove = i;
                }
            }
            Console.WriteLine();
            if (indexToRemove == -1)
            {
                Console.WriteLine("Ko tim thay gia tri " + soCanXoa);
                return;
            }

            for (int i = indexToRemove; i < mang.Length; i++)
            {
                if (i == mang.Length - 1)
                {
                    mang[i] = 0;
                }
                else
                {
                    mang[i] = mang[i + 1];
                }
            }

            for (int i = 0; i < mang.Length; i++)
            {
                Console.Write(mang[i] + " ");
            }
        }
    }
}
