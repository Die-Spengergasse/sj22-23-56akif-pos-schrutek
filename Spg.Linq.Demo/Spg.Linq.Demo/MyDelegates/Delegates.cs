using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Linq.Demo.MyDelegates
{
    public delegate TReturn MyFunc<TP1, TReturn>(TP1 p1);
    public delegate TReturn MyFunc<TP1, TP2, TReturn>(TP1 p1, TP2 p2);
    public delegate TReturn MyFunc<TP1, TP2, TP3, TReturn>(TP1 p1, TP2 p2, TP3 p3);
    //...
}
