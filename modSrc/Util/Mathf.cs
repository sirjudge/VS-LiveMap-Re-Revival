namespace LiveMap.Util;

public abstract class Mathf {
    public static long AsLong(int x, int z) => (x & 0xFFFFFFFF) | ((z & 0xFFFFFFFF) << 32);

    public static int LongToX(long index) => (int)(index & 0xFFFFFFFF);

    public static int LongToZ(long index) => (int)((index >>> 32) & 0xFFFFFFFF);

    public static int BlockIndex(int x, int z) => ((z & 31) << 5) + (x & 31);

    public static int BlockIndex(int x, int y, int z) => ((((y & 31) << 5) + (z & 31)) << 5) + (x & 31);

    public static float Lerp(float a, float b, float t) => a + (t * (b - a));

    public static uint Max(params uint[] numbers) => numbers.Max();

    public static uint Min(params uint[] numbers) => numbers.Min();
}
