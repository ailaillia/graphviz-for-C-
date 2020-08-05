using System;
using System.Runtime.InteropServices;

//It is a class of C#, the test method is a demo for calling graphviz

public class graphviz
{
    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern byte _Agdirected();

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern IntPtr _gvContext();

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern IntPtr _agopen(byte[] name, byte desc, IntPtr disc);

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern IntPtr _agnode(IntPtr g, byte[] name, int createflag);

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern IntPtr _agedge(IntPtr g, IntPtr t, IntPtr h, byte[] name, int createflag);

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern int _agsafeset(IntPtr obj, byte[] name, byte[] value, byte[] def);

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern int _gvLayout(IntPtr gvc, IntPtr g, byte[] engine);

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern int _gvRenderContext(IntPtr gvc, IntPtr g, byte[] format, IntPtr context);

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern int _gvRenderData(IntPtr gvc, IntPtr g, byte[] format, ref Int32 result, ref Int32 length);

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern void _gvFreeRenderData(Int32 data);

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern int _gvFreeLayout(IntPtr gvc, IntPtr g);

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern int _agclose(IntPtr g);

    [DllImport("./graphviz.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern int _gvFreeContext(IntPtr gvc);

    public static string test()
    {
        IntPtr g;
        IntPtr n, m;
        IntPtr e,f;
        IntPtr gvc;

        Int32 result = 0;
        Int32 length = 0;
        
        gvc = _gvContext();
        g = _agopen(System.Text.Encoding.Default.GetBytes("g"), _Agdirected(), IntPtr.Zero);
        n = _agnode(g, System.Text.Encoding.Default.GetBytes("n"), 1);
        m = _agnode(g, System.Text.Encoding.Default.GetBytes("m"), 1);
        e = _agedge(g, n, m, null, 1);
        f = _agedge(g, m, n, null, 1);
        _agsafeset(e, System.Text.Encoding.Default.GetBytes("label"), System.Text.Encoding.Default.GetBytes("go"), System.Text.Encoding.Default.GetBytes(""));
        /* Set an attribute - in this case one that affects the visible rendering */
        _agsafeset(n, System.Text.Encoding.Default.GetBytes("color"), System.Text.Encoding.Default.GetBytes("red"), System.Text.Encoding.Default.GetBytes(""));
        _gvLayout(gvc, g, System.Text.Encoding.Default.GetBytes("dot"));
        //_gvRenderContext(gvc, g, System.Text.Encoding.Default.GetBytes("svg"), IntPtr.Zero);
        _gvRenderData(gvc, g, System.Text.Encoding.Default.GetBytes("svg"), ref result, ref length);
        string res = Marshal.PtrToStringAnsi(new IntPtr(result),length);
        _gvFreeRenderData(result);
        _gvFreeLayout(gvc, g);
        _agclose(g);
        _gvFreeContext(gvc);

        return res;
    }
}

